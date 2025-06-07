@echo off
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
