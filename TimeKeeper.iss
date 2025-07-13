[Setup]
AppName=TimeKeeper
AppVersion=1.0.0
DefaultDirName={pf}\TimeKeeper
DefaultGroupName=TimeKeeper
OutputDir=.\Installer
OutputBaseFilename=TimeKeeperSetup
Compression=lzma
SolidCompression=yes
SetupIconFile="C:\Users\fxhxy\dev\TimeKeeper\TimeKeeper\icon\consul.ico"

[Files]
Source: "C:\Users\fxhxy\dev\TimeKeeper\TimeKeeper\bin\Release\net8.0-windows\win-x64\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
Source: "C:\Users\fxhxy\dev\TimeKeeper\TimeKeeper\icon\consul.ico"; DestDir: "{app}"; DestName: "consul.ico"; Flags: ignoreversion

[Icons]
Name: "{group}\TimeKeeper"; Filename: "{app}\TimeKeeper.exe"; IconFilename: "{app}\consul.ico"
Name: "{group}\Uninstall TimeKeeper"; Filename: "{uninstallexe}"
