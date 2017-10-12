@echo off

pushd Back-End\trunk
mklink /d MockClient "../../Helper Libs/trunk/MockClient"
popd

pushd Front-End\trunk
mklink /d MockClient "../../Helper Libs/trunk/MockClient"
popd

echo on