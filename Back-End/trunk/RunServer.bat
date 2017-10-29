@echo off

start "ApiServer" "ApiServerStandalone\bin\Debug\ApiServerStandalone.exe"

start "AuthServer" "AuthServer\bin\Debug\AuthServer.exe"

rem ping -n2 localhost>nul

rem MSTest.exe /testcontainer:AuthApiTester\bin\Debug\AuthApiTester.dll

rem taskkill /IM ApiServerStandalone.exe

rem taskkill /IM AuthServer.exe

echo on|