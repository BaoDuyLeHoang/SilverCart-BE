@echo off
setlocal enabledelayedexpansion

echo 🔍 Database Status Check
echo =======================

REM Check if detailed mode is requested
if "%~1"=="/d" (
    echo 📊 Detailed mode enabled
    echo.
    echo 📋 Current Migrations:
    dotnet ef migrations list --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
    echo.
    echo 📊 Database Status:
    dotnet ef database update --dry-run --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
) else (
    echo 📋 Current Migrations:
    dotnet ef migrations list --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
    echo.
    echo 💡 Use /d for detailed status including pending migrations
)

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ✅ Database status check completed
    echo.
    echo 💡 Available actions:
    echo    - update-db.bat - Apply pending migrations
    echo    - reset-db.bat - Reset database completely
    echo    - script-migrations.bat - Generate SQL scripts
) else (
    echo ❌ Failed to check database status
    echo 💡 Check your connection string and database server
    exit /b 1
) 