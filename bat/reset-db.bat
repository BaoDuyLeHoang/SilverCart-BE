@echo off
setlocal enabledelayedexpansion

REM Check if force parameter is provided
if "%~1"=="/force" (
    set isForce=true
    echo 🗑️ Force dropping database
) else (
    echo ⚠️ Dropping database (use /force to skip confirmation)
)

if("%~2" == "y") (
    set env=Release
) else (
    set env=Debug
)

if %isForce%==true (
    dotnet ef database drop --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI --force --yes -c %env%
) else (
    dotnet ef database drop --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI -c %env%
)

if %ERRORLEVEL% EQU 0 (
    echo ✅ Database dropped successfully
) else (
    echo ❌ Failed to drop database
    exit /b 1
)

echo 🔄 Creating new database
dotnet ef database update --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI -c %env%

if %ERRORLEVEL% EQU 0 (
    echo ✅ Database reset completed successfully
) else (
    echo ❌ Failed to create new database
    exit /b 1
)
