#!bin/bash
set -e
dotnet restore
dotnet test test/ocr_service.Tests/project.json -xml $(pwd)/testresults/out.xml
rm -rf $(pwd)/publish/web
rm -rf $(pwd)/testresults
dotnet publish src/text_worker/project.json -c release -o $(pwd)/publish/web