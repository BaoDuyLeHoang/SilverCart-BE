@echo off
setlocal enabledelayedexpansion

echo 📋 Entity Framework Migrations List
echo ====================================

REM Check if verbose mode is requested
if "%~1"=="/v" (
    echo 🔍 Verbose mode enabled
    dotnet ef migrations list --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI --verbose
) else (
    dotnet ef migrations list --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
)

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ✅ Migration list retrieved successfully
    echo.
    echo 💡 Tips:
    echo    - Use /v for verbose output
    echo    - Use update-db.bat to apply migrations
    echo    - Use remove-last-migration.bat to remove migrations
) else (
    echo ❌ Failed to retrieve migration list
    exit /b 1
) 