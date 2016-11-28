#!bin/bash
set -e
dotnet restore
rm -rf $(pwd)/testresults
dotnet test test/ocr_service.Tests/project.json -xml $(pwd)/testresults/out.xml
rm -rf $(pwd)/publish/web
dotnet publish src/ocr_service.webapi/project.json -c release -o $(pwd)/publish/web