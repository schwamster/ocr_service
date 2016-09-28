#!/bin/bash

if [ "$#" -eq 0 ]
then
    echo "no args provided -> args: run -s <your_computer_vision_msft_cognitive_services_subscription> -p /app/test/ocr_service.Tests/testdata/ocr-test2.png"
    #bash
elif [[ $# == 1 && "$1" == "test" ]]
then
    echo "test"
    cd ./test/ocr_service.Tests
    dotnet test
elif [[ $# == 1 && "$1" == "host" ]]
then
    echo "host"
    cd ./src/ocr_service.webapi
    dotnet run
elif [[ $# == 5 && "$1" == "run" ]]
then
    echo "run"
    #-s <your_computer_vision_msft_cognitive_services_subscription> -p /app/test/ocr_service.Tests/testdata/ocr-test2.png"
    cd ./src/ocr_service.console
    dotnet run $2 $3 $4 $5
else
    echo "unknown arg $@"
fi