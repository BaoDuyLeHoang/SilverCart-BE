@echo off
setlocal enabledelayedexpansion
set isForce=false
REM Check if force parameter is provided
if "%~1"=="/force" (
    set isForce=true
    echo 🗑️ Force dropping database
) else (
    echo ⚠️ Dropping database (use /force to skip confirmation)
)

if "%isForce%" == "true" (
    dotnet ef database drop --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI --force 
) else (
    dotnet ef database drop --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI 
)

if %ERRORLEVEL% EQU 0 (
    echo ✅ Database dropped successfully
) else (
    echo ❌ Failed to drop database
    exit /b 1
)

echo 🔄 Creating new database
dotnet ef database update --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI 

if %ERRORLEVEL% EQU 0 (
    echo ✅ Database reset completed successfully
) else (
    echo ❌ Failed to create new database
    exit /b 1
)
