@echo off

set CurrentDirectoryPath=%cd%
set TempDirectoryPath=%CurrentDirectoryPath%\tmp

mkdir %TempDirectoryPath%

dotnet build %CurrentDirectoryPath%\src\CodWeaponsRandomizer.CodWebPagesScraper\CodWeaponsRandomizer.CodWebPagesScraper.csproj -c Release -o %TempDirectoryPath%

set DatabasesPath=%CurrentDirectoryPath%\src\CodWeaponsRandomizer\dbs
set CodScraperProgram=CodWeaponsRandomizer.CodWebPagesScraper.exe

%TempDirectoryPath%\%CodScraperProgram% %DatabasesPath%

set MwImagesFolder=mw_weapon_images
set MwImagesPath=%DatabasesPath%\mw\%MwImagesFolder%
set CwImagesFolder=cw_weapon_images
set CwImagesPath=%DatabasesPath%\cw\%CwImagesFolder%

set AppAssetsPath=%CurrentDirectoryPath%\src\CodWeaponsRandomizer\wwwroot
set MwAssetsPath=%AppAssetsPath%\%MwImagesFolder%
set CwAssetsPath=%AppAssetsPath%\%CwImagesFolder%

rmdir /s /q %MwAssetsPath%
mkdir %MwAssetsPath%
move %MwImagesPath%\* %MwAssetsPath%
rmdir /s /q %MwImagesPath%

rmdir /s /q %CwAssetsPath%
mkdir %CwAssetsPath%
move %CwImagesPath%\* %CwAssetsPath%
rmdir /s /q %CwImagesPath%

rmdir /s /q %TempDirectoryPath%