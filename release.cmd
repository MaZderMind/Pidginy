@echo off
set launchy=C:\Program Files (x86)\Launchy
mkdir _release
mkdir _release\plugins
mkdir _release\plugins\icons
copy /y "%launchy%\Launchy#API.dll" _release
copy /y "%launchy%\Launchy#API.License.txt" _release
copy /y "%launchy%\Launchy#API.xml" _release
copy /y "%launchy%\LaunchySharpAPI.chm" _release
copy /y "%launchy%\QtCore4.dll" _release
copy /y Pidginy\bin\Release\Pidginy.dll _release\plugins
copy /y Pidginy\Pidginy.ico _release\plugins\icons

cd _release
"%ProgramFiles%\7-Zip\7z.exe" a ..\release-%DATE%.zip .
cd ..
pause
