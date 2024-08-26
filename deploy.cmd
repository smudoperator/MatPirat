@echo off
:: 1. Create app_offline.htm to stop the app during deployment
echo Creating app_offline.htm
echo app_offline.htm > "%DEPLOYMENT_TARGET%\app_offline.htm"

:: 2. KuduSync to sync files, but exclude the database file
echo Syncing files, excluding dinners.db
:: Use KuduSync with the --exclude option
KuduSync.NET.exe -v 50 -f "%DEPLOYMENT_SOURCE%" -t "%DEPLOYMENT_TARGET%" -n --exclude="dinners.db"

:: 3. Remove app_offline.htm after deployment
echo Removing app_offline.htm
del "%DEPLOYMENT_TARGET%\app_offline.htm"

:: Testing if works