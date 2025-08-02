@echo off
setlocal enabledelayedexpansion

REM Check if target migration is provided as parameter
if "%~1"=="" (
    echo 🔄 Updating database to latest migration
    dotnet ef database update --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
) else (
    echo 🔄 Updating database to migration: %~1
    dotnet ef database update %~1 --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
)

if %ERRORLEVEL% EQU 0 (
    echo ✅ Database updated successfully
) else (
    echo ❌ Failed to update database
    exit /b 1
)
