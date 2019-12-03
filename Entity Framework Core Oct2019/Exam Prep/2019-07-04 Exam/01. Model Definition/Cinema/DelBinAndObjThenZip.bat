Echo batch file delete folder

@RD /S /Q "./../bin"
@RD /S /Q "./../obj"

@RD /S /Q "./bin"
@RD /S /Q "./obj"

echo on

for /f "tokens=3,2,4 delims=/- " %%x in ("%date%") do set d=%%y%%x%%z
set data = %d%

for /f "tokens=1,2,3 delims=:. " %%x in ("%time%") do set t=%%x%%y%%z
set time=%t%

Echo zipping...

REM "C:\Program Files\7-Zip\7z.exe" a tzip
"./Submit_%d%.zip" "./*.cs" "./*.csproj"

for /d %%x in (*) do "c:\Program Files\7-Zip\7z.exe" a -tzip "./Submit_%d%_%t%.zip" ".\%%x"

echo Done!