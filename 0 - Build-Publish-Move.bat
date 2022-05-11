@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.Id3\bin\Release\Panosen.Id3.*.nupkg D:\LocalSavoryNuget\

pause