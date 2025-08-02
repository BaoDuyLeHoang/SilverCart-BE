@echo off
setlocal enabledelayedexpansion

echo.
echo 🔧 EF Core Script Generator - Enhanced Version
echo ==============================================
echo.

REM Auto-detect project paths
set "DETECTED_EF_PROJECT="
set "DETECTED_STARTUP_PROJECT="

REM Look for Infrastructure project
for /r . %%i in (*Infrastructure*.csproj) do (
    if not defined DETECTED_EF_PROJECT (
        set "DETECTED_EF_PROJECT=%%i"
    )
)

REM Look for WebAPI project
for /r . %%i in (*WebAPI*.csproj) do (
    if not defined DETECTED_STARTUP_PROJECT (
        set "DETECTED_STARTUP_PROJECT=%%i"
    )
)

REM If not found, look for any .csproj files
if not defined DETECTED_EF_PROJECT (
    for /r . %%i in (*.csproj) do (
        if not defined DETECTED_EF_PROJECT (
            set "DETECTED_EF_PROJECT=%%i"
        )
    )
)

if not defined DETECTED_STARTUP_PROJECT (
    for /r . %%i in (*.csproj) do (
        if not defined DETECTED_STARTUP_PROJECT (
            set "DETECTED_STARTUP_PROJECT=%%i"
        )
    )
)

echo 📁 Auto-detected projects:
if defined DETECTED_EF_PROJECT (
    echo    EF Project: !DETECTED_EF_PROJECT!
) else (
    echo    EF Project: Not found
)

if defined DETECTED_STARTUP_PROJECT (
    echo    Startup Project: !DETECTED_STARTUP_PROJECT!
) else (
    echo    Startup Project: Not found
)
echo.

REM Ask user to confirm or input custom paths
set /p CONFIRM="Use auto-detected paths? (Y/n): "
if /i "!CONFIRM!"=="n" (
    set /p PROJECT_PATH=Enter path to EF project (.csproj): 
    set /p STARTUP_PATH=Enter path to Startup project (.csproj): 
) else (
    set "PROJECT_PATH=!DETECTED_EF_PROJECT!"
    set "STARTUP_PATH=!DETECTED_STARTUP_PROJECT!"
)

REM Validate paths
if not exist "!PROJECT_PATH!" (
    echo ❌ Error: EF project not found at: !PROJECT_PATH!
    exit /b 1
)

if not exist "!STARTUP_PATH!" (
    echo ❌ Error: Startup project not found at: !STARTUP_PATH!
    exit /b 1
)

echo.
echo ✅ Using paths:
echo    EF Project: !PROJECT_PATH!
echo    Startup Project: !STARTUP_PATH!
echo.

REM Create backup of existing scripts
if exist "add-migration.bat" (
    echo 📦 Creating backup of existing scripts
    if not exist "backup" mkdir backup
    move "add-migration.bat" "backup\add-migration.bat.backup" >nul 2>&1
    move "update-db.bat" "backup\update-db.bat.backup" >nul 2>&1
    move "remove-last-migration.bat" "backup\remove-last-migration.bat.backup" >nul 2>&1
    move "script-migrations.bat" "backup\script-migrations.bat.backup" >nul 2>&1
    move "reset-db.bat" "backup\reset-db.bat.backup" >nul 2>&1
    echo ✅ Backup created in 'backup' folder
)

echo.
echo 🔨 Generating enhanced EF Core scripts
echo.

REM ========== 1. add-migration.bat ==========
echo Creating add-migration.bat
(
echo @echo off
echo setlocal enabledelayedexpansion
echo.
echo REM Check if migration name is provided as parameter
echo if "%%~1"=="" ^(
echo     set /p MIGRATION_NAME=Migration name: 
echo ^) else ^(
echo     set MIGRATION_NAME=%%~1
echo ^)
echo.
echo REM Check if migration name is empty
echo if "!MIGRATION_NAME!"=="" ^(
echo     echo ❌ Error: Migration name cannot be empty
echo     echo Usage: add-migration.bat [migration_name]
echo     exit /b 1
echo ^)
echo.
echo echo 🔄 Creating migration: !MIGRATION_NAME!
echo dotnet ef migrations add !MIGRATION_NAME! --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo.
echo if %%ERRORLEVEL%% EQU 0 ^(
echo     echo ✅ Migration created successfully: !MIGRATION_NAME!
echo ^) else ^(
echo     echo ❌ Failed to create migration: !MIGRATION_NAME!
echo     exit /b 1
echo ^)
) > "add-migration.bat"

REM ========== 2. update-db.bat ==========
echo Creating update-db.bat
(
echo @echo off
echo setlocal enabledelayedexpansion
echo.
echo REM Check if target migration is provided as parameter
echo if "%%~1"=="" ^(
echo     echo 🔄 Updating database to latest migration
echo     dotnet ef database update --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo ^) else ^(
echo     echo 🔄 Updating database to migration: %%~1
echo     dotnet ef database update %%~1 --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo ^)
echo.
echo if %%ERRORLEVEL%% EQU 0 ^(
echo     echo ✅ Database updated successfully
echo ^) else ^(
echo     echo ❌ Failed to update database
echo     exit /b 1
echo ^)
) > "update-db.bat"

REM ========== 3. remove-last-migration.bat ==========
echo Creating remove-last-migration.bat
(
echo @echo off
echo setlocal enabledelayedexpansion
echo.
echo REM Check if number of migrations to remove is provided as parameter
echo if "%%~1"=="" ^(
echo     echo 🗑️ Removing last migration
echo     dotnet ef migrations remove --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo ^) else ^(
echo     REM Validate if parameter is a number
echo     echo %%~1^| findstr /r "^[0-9]*$" ^>nul
echo     if %%ERRORLEVEL%% EQU 0 ^(
echo         echo 🗑️ Removing last %%~1 migration^(s^)
echo         for /l %%%%i in ^(1,1,%%~1^) do ^(
echo             dotnet ef migrations remove --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo             if !ERRORLEVEL! NEQ 0 ^(
echo                 echo ❌ Failed to remove migration #%%%%i
echo                 exit /b 1
echo             ^)
echo         ^)
echo     ^) else ^(
echo         echo ❌ Error: Parameter must be a number
echo         echo Usage: remove-last-migration.bat [number_of_migrations]
echo         exit /b 1
echo     ^)
echo ^)
echo.
echo if %%ERRORLEVEL%% EQU 0 ^(
echo     echo ✅ Migration^(s^) removed successfully
echo ^) else ^(
echo     echo ❌ Failed to remove migration^(s^)
echo     exit /b 1
echo ^)
) > "remove-last-migration.bat"

REM ========== 4. script-migrations.bat ==========
echo Creating script-migrations.bat
(
echo @echo off
echo setlocal enabledelayedexpansion
echo.
echo REM Check if output file name is provided as parameter
echo if "%%~1"=="" ^(
echo     set OUTPUT_FILE=migration.sql
echo ^) else ^(
echo     set OUTPUT_FILE=%%~1
echo ^)
echo.
echo REM Check if from/to migrations are provided
echo if "%%~2"=="" ^(
echo     echo 📝 Generating migration script to: !OUTPUT_FILE!
echo     dotnet ef migrations script --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!" -o !OUTPUT_FILE!
echo ^) else ^(
echo     if "%%~3"=="" ^(
echo         echo ❌ Error: Both from and to migration names are required
echo         echo Usage: script-migrations.bat [output_file] [from_migration] [to_migration]
echo         exit /b 1
echo     ^) else ^(
echo         echo 📝 Generating migration script from %%~2 to %%~3: !OUTPUT_FILE!
echo         dotnet ef migrations script %%~2 %%~3 --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!" -o !OUTPUT_FILE!
echo     ^)
echo ^)
echo.
echo if %%ERRORLEVEL%% EQU 0 ^(
echo     echo ✅ Migration script generated successfully: !OUTPUT_FILE!
echo ^) else ^(
echo     echo ❌ Failed to generate migration script
echo     exit /b 1
echo ^)
) > "script-migrations.bat"

REM ========== 5. reset-db.bat ==========
echo Creating reset-db.bat
(
echo @echo off
echo setlocal enabledelayedexpansion
echo.
echo REM Check if force parameter is provided
echo if "%%~1"=="/force" ^(
echo     echo 🗑️ Force dropping database
echo     dotnet ef database drop --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!" --force --yes
echo ^) else ^(
echo     echo ⚠️ Dropping database ^(use /force to skip confirmation^)
echo     dotnet ef database drop --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo ^)
echo.
echo if %%ERRORLEVEL%% EQU 0 ^(
echo     echo ✅ Database dropped successfully
echo ^) else ^(
echo     echo ❌ Failed to drop database
echo     exit /b 1
echo ^)
echo.
echo echo 🔄 Creating new database
echo dotnet ef database update --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo.
echo if %%ERRORLEVEL%% EQU 0 ^(
echo     echo ✅ Database reset completed successfully
echo ^) else ^(
echo     echo ❌ Failed to create new database
echo     exit /b 1
echo ^)
) > "reset-db.bat"

REM ========== 6. list-migrations.bat ==========
echo Creating list-migrations.bat
(
echo @echo off
echo setlocal enabledelayedexpansion
echo.
echo echo 📋 Entity Framework Migrations List
echo echo ====================================
echo.
echo REM Check if verbose mode is requested
echo if "%%~1"=="/v" ^(
echo     echo 🔍 Verbose mode enabled
echo     dotnet ef migrations list --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!" --verbose
echo ^) else ^(
echo     dotnet ef migrations list --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo ^)
echo.
echo if %%ERRORLEVEL%% EQU 0 ^(
echo     echo.
echo     echo ✅ Migration list retrieved successfully
echo     echo.
echo     echo 💡 Tips:
echo     echo    - Use /v for verbose output
echo     echo    - Use update-db.bat to apply migrations
echo     echo    - Use remove-last-migration.bat to remove migrations
echo ^) else ^(
echo     echo ❌ Failed to retrieve migration list
echo     exit /b 1
echo ^)
) > "list-migrations.bat"

REM ========== 7. db-status.bat ==========
echo Creating db-status.bat
(
echo @echo off
echo setlocal enabledelayedexpansion
echo.
echo echo 🔍 Database Status Check
echo echo =======================
echo.
echo REM Check if detailed mode is requested
echo if "%%~1"=="/d" ^(
echo     echo 📊 Detailed mode enabled
echo     echo.
echo     echo 📋 Current Migrations:
echo     dotnet ef migrations list --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo     echo.
echo     echo 📊 Database Status:
echo     dotnet ef database update --dry-run --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo ^) else ^(
echo     echo 📋 Current Migrations:
echo     dotnet ef migrations list --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!"
echo     echo.
echo     echo 💡 Use /d for detailed status including pending migrations
echo ^)
echo.
echo if %%ERRORLEVEL%% EQU 0 ^(
echo     echo.
echo     echo ✅ Database status check completed
echo     echo.
echo     echo 💡 Available actions:
echo     echo    - update-db.bat - Apply pending migrations
echo     echo    - reset-db.bat - Reset database completely
echo     echo    - script-migrations.bat - Generate SQL scripts
echo ^) else ^(
echo     echo ❌ Failed to check database status
echo     echo 💡 Check your connection string and database server
echo     exit /b 1
echo ^)
) > "db-status.bat"

echo.
echo ✅ Done! Enhanced EF Core scripts created:
echo    - add-migration.bat
echo    - update-db.bat
echo    - remove-last-migration.bat
echo    - script-migrations.bat
echo    - reset-db.bat
echo    - list-migrations.bat
echo    - db-status.bat
echo.

REM Test the configuration
echo 🔍 Testing configuration
dotnet ef migrations list --project "!PROJECT_PATH!" --startup-project "!STARTUP_PATH!" >nul 2>&1
if %ERRORLEVEL% EQU 0 (
    echo ✅ Configuration test passed
    echo.
    echo 🚀 Ready to use! Try:
    echo    - list-migrations.bat
    echo    - db-status.bat
    echo    - add-migration.bat "TestMigration"
) else (
    echo ⚠️ Configuration test failed - check your connection string
    echo 💡 Scripts are created but may need connection string setup
)

echo.
pause
