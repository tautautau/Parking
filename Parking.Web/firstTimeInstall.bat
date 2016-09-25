
@echo off
REM prerequests:
REM node.js installed
REM npm -g install types
REM npm -g install gulp
REM Add to environment variables NODE_PATH --> %AppData%\npm\node_modules
REM dotNetCore installed
@echo on

echo ---- Downloading and installing js dependencies ----
call npm install
echo ---- js dependencies downloaded & installed ----

echo ---- Creating .js from .ts ----
call gulp ts

echo ---- Creating .css from .less ----
call gulp less

echo ---- Downloading DotNetCore dependencies ----
call dotnet restore

echo ---- Building DotNetCore app ----
call dotnet build
echo ---- Build finished ----

echo ---- firstTimeInstallation compleated ----