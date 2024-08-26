@echo off
echo Handling Custom Deployment.

:: Skip file deletion for the database
set OPT_EXCLUDE_FILE="dinners.db"

:: Run KuduSync
call :ExecuteCmd "kudusync" -v 50 -f "%DEPLOYMENT_SOURCE%" -t "%DEPLOYMENT_TARGET%" -n -x "%OPT_EXCLUDE_FILE%" --perf

:: Continue with the rest of the deployment process
call :ExecuteCmd "cmd /c npm install"

goto :EOF

:ExecuteCmd
echo %1
%~1
IF !ERRORLEVEL! NEQ 0 goto error

goto :EOF

:error
echo Failed to execute command: %~1
exit /b 1