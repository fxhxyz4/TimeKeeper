@echo off
setlocal

set DOWNLOAD_DIR=%USERPROFILE%\Desktop\dev\TimeKeeper\TimeKeeper
cd /d %DOWNLOAD_DIR%

if not exist nuget.exe (
    powershell -Command "Invoke-WebRequest -Uri https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile '%DOWNLOAD_DIR%\..\nuget.exe'"
)

:: cd /d packages
:: nuget install

:: restore libs
"%DOWNLOAD_DIR%\..\nuget.exe" restore "%DOWNLOAD_DIR%\..\packages.config" -PackagesDirectory "%DOWNLOAD_DIR%\..\packages"
powershell -executionpolicy remotesigned -File "%USERPROFILE%\Desktop\dev\TimeKeeper\scripts\ps1\packages.ps1"

pause
endlocal
