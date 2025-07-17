@echo off
setlocal enabledelayedexpansion

REM Check if output file name is provided as parameter
if "%~1"=="" (
    set OUTPUT_FILE=migration.sql
) else (
    set OUTPUT_FILE=%~1
)

REM Check if from/to migrations are provided
if "%~2"=="" (
    echo 📝 Generating migration script to: !OUTPUT_FILE!
    dotnet ef migrations script --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI -o !OUTPUT_FILE!
) else (
    if "%~3"=="" (
        echo ❌ Error: Both from and to migration names are required
        echo Usage: script-migrations.bat [output_file] [from_migration] [to_migration]
        exit /b 1
    ) else (
        echo 📝 Generating migration script from %~2 to %~3: !OUTPUT_FILE!
        dotnet ef migrations script %~2 %~3 --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI -o !OUTPUT_FILE!
    )
)

if %ERRORLEVEL% EQU 0 (
    echo ✅ Migration script generated successfully: !OUTPUT_FILE!
) else (
    echo ❌ Failed to generate migration script
    exit /b 1
)
