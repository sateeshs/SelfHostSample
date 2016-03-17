@ECHO OFF
set DOTNET4=%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319
set PATH=%PATH%;%DOTNET4%
echo------------------------------------
InstallUtil ..\bin\Debug\selfhost.exe 
echo------------------------------------
echo Done.
pause