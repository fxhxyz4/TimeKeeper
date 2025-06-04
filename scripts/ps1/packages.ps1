$packagesFilePath =  "C:\\Users\cadet51\Desktop\dev\TimeKeeper\packages.txt"

$packages = Get-Content -Path $packagesFilePath

foreach ($package in $packages) {
    Write-Host "Adding package: $package"
    dotnet add package $package
}
