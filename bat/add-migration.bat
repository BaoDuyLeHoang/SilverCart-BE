@echo off
setlocal enabledelayedexpansion

REM Check if migration name is provided as parameter
if "%~1"=="" (
    set /p MIGRATION_NAME=Migration name: 
) else (
    set MIGRATION_NAME=%~1
)

REM Check if migration name is empty
if "!MIGRATION_NAME!"=="" (
    echo ❌ Error: Migration name cannot be empty
    echo Usage: add-migration.bat [migration_name]
    exit /b 1
)

echo 🔄 Creating migration: !MIGRATION_NAME!
dotnet ef migrations add !MIGRATION_NAME! --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI --verbose

if %ERRORLEVEL% EQU 0 (
    echo ✅ Migration created successfully: !MIGRATION_NAME!
) else (
    echo ❌ Failed to create migration: !MIGRATION_NAME!
    exit /b 1
)
