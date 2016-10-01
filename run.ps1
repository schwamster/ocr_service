$computerVisionEnvironment = "ComputerVisionKey=" + [Environment]::GetEnvironmentVariable("ComputerVisionKey","Machine")
docker run -t -p 5001:5000 --env $computerVisionEnvironment ocr_service:1 host