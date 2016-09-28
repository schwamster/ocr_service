FROM microsoft/dotnet:latest

RUN mkdir -p /app/src/ocr_service/ && mkdir -p /app/src/ocr_service.webapi/ && mkdir -p /app/src/ocr_service.console/ && mkdir -p /app/test/ocr_service.Tests/ 

COPY ./src/ocr_service/project.json /app/src/ocr_service
COPY ./src/ocr_service.webapi/project.json /app/src/ocr_service.webapi
COPY ./src/ocr_service.console/project.json /app/src/ocr_service.console
COPY ./test/ocr_service.Tests/project.json /app/test/ocr_service.Tests
COPY global.json /app

WORKDIR /app
RUN ["dotnet", "restore"]

COPY . /app
WORKDIR /app/src/ocr_service.webapi
RUN ["dotnet", "build"]

WORKDIR /app
ENTRYPOINT ["bash", "./entrypoint.sh"]