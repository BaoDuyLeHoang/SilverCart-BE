@echo off
setlocal enabledelayedexpansion

REM Check if number of migrations to remove is provided as parameter
if "%~1"=="" (
    echo 🗑️ Removing last migration...
    dotnet ef migrations remove --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
) else (
    REM Validate if parameter is a number
    echo %~1| findstr /r "^[0-9]*$" >nul
    if %ERRORLEVEL% EQU 0 (
        echo 🗑️ Removing last %~1 migration(s)...
        for /l %%i in (1,1,%~1) do (
            dotnet ef migrations remove --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
            if !ERRORLEVEL! NEQ 0 (
                echo ❌ Failed to remove migration #%%i
                exit /b 1
            )
        )
    ) else (
        echo ❌ Error: Parameter must be a number
        echo Usage: remove-last-migration.bat [number_of_migrations]
        exit /b 1
    )
)

if %ERRORLEVEL% EQU 0 (
    echo ✅ Migration(s) removed successfully
) else (
    echo ❌ Failed to remove migration(s)
    exit /b 1
)
