@echo off
setlocal enabledelayedexpansion

REM Kiểm tra nếu số lượng migrations cần xóa được cung cấp như tham số
if "%~1"=="" (
    echo 🗑️ Đang xóa migration cuối cùng
    dotnet ef migrations remove --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
) else (
    REM Xác thực nếu tham số là một số
    echo %~1| findstr /r "^[0-9]*$" > nul
    if %ERRORLEVEL% == 0 (
        echo 🗑️ Đang xóa %~1 migration(s) cuối cùng
        for /l %%i in (1,1,%~1) do (
            dotnet ef migrations remove --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
            if !ERRORLEVEL! NEQ 0 (
                echo ❌ Không thể xóa migration #%%i
                exit /b 1
            )
        )
    ) else (
        echo ❌ Lỗi: Tham số phải là một số
        echo Cách sử dụng: remove-last-migration.bat [số_lượng_migrations]
        exit /b 1
    )
)

if %ERRORLEVEL% == 0 (
    echo ✅ Migration(s) đã được xóa thành công
) else (
    echo ❌ Không thể xóa migration(s)
    exit /b 1
)
