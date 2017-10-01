@echo off

start "ApiServer" "ApiServerStandalone\bin\Debug\ApiServerStandalone.exe"

start "AuthServer" "AuthServer\bin\Debug\AuthServer.exe"

ping -n2 localhost>nul

MSTest.exe /testcontainer:AuthApiTester\bin\Debug\AuthApiTester.dll

taskkill /IM ApiServerStandalone.exe

taskkill /IM AuthServer.exe

echo on|