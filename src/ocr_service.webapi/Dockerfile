FROM microsoft/aspnetcore:1.1.0

WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "ocr_service.webapi.dll"]