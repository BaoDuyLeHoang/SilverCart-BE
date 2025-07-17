@echo off
setlocal enabledelayedexpansion

REM Check if force parameter is provided
if "%~1"=="/force" (
    echo 🗑️ Force dropping database...
    dotnet ef database drop --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI --force --yes
) else (
    echo ⚠️ Dropping database (use /force to skip confirmation)...
    dotnet ef database drop --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
)

if %ERRORLEVEL% EQU 0 (
    echo ✅ Database dropped successfully
) else (
    echo ❌ Failed to drop database
    exit /b 1
)

echo 🔄 Creating new database...
dotnet ef database update --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI

if %ERRORLEVEL% EQU 0 (
    echo ✅ Database reset completed successfully
) else (
    echo ❌ Failed to create new database
    exit /b 1
)
