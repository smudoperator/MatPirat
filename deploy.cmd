@echo off
setlocal

REM Set variables
set ZIP_PATH=%DEPLOYMENT_TARGET%\extracted
set TARGET_PATH=%DEPLOYMENT_TARGET%\site\wwwroot

REM Cleanup old files if necessary
if exist "%TARGET_PATH%\Data" rmdir /s /q "%TARGET_PATH%\Data"

REM Copy new files
xcopy /s /e /i "%ZIP_PATH%" "%TARGET_PATH%"

REM Handle any custom file exclusions
REM Example: Removing unwanted files
del /q "%TARGET_PATH%\unwanted_file.txt"