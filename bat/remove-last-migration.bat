@echo off
setlocal enabledelayedexpansion

echo Checking parameters...

if "%~1"=="" (
    echo Removing last migration...
    dotnet ef migrations remove --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
    if %ERRORLEVEL% EQU 0 (
        echo Migration removed successfully
    ) else (
        echo Failed to remove migration
        exit /b 1
    )
    goto :end
)

echo %~1| findstr /r "^[0-9]*$" >nul
if %ERRORLEVEL% NEQ 0 (
    echo Error: Parameter must be a number
    echo Usage: remove-last-migration.bat [number_of_migrations]
    exit /b 1
)

echo Removing last %~1 migration(s)...
for /l %%i in (1,1,%~1) do (
    dotnet ef migrations remove --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
    if !ERRORLEVEL! NEQ 0 (
        echo Failed to remove migration #%%i
        exit /b 1
    )
)
echo Migration(s) removed successfully

:end
