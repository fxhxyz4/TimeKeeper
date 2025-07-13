@echo off

chcp 65001 >nul

setlocal enabledelayedexpansion

echo 🔧 Building the project...

cd ..

set "VERSION_TYPE=%1"

if "%VERSION_TYPE%"=="" (
    set "VERSION_TYPE=net8.0-windows"
)

cd TimeKeeper

dir *.csproj >nul 2>&1
if errorlevel 1 (
    dir *.sln >nul 2>&1
    if errorlevel 1 (
        echo ❌ Error: No .csproj or .sln file found in %cd%
        pause
        exit /b 1
    )
)

dotnet build --framework %VERSION_TYPE%

if errorlevel 1 (
    echo ❌ Build failed!
    pause
    exit /b 1
)

echo 🚀 Build completed for framework (%VERSION_TYPE%)...
echo ✅ Done!

dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
echo ✅ Release publishing!

cd TimeKeeper
cd publish

del .env
del appsettings.json

cd bin/Debug/net8.0-windows
del .env
del appsettings.json

cd ..
cd ..
cd Release/net8.0-windows/win-x64
del .env
del appsettings.json

cd publish
del .env
del appsettings.json

echo PORT=DB=HOST=USER=PASS= > .env.example
echo {"RabbitMQ": {"HostName": "amqps://url","UserName": "user","Password": "pass"}} > appsettings.example.json

pause