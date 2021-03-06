# ocr_service

This project is a subset of https://github.com/schwamster/docStack

[![CircleCI](https://circleci.com/gh/schwamster/ocr_service.svg?style=shield&circle-token)](https://circleci.com/gh/schwamster/ocr_service)
[![Docker Automated buil](https://img.shields.io/docker/automated/jrottenberg/ffmpeg.svg)](https://hub.docker.com/r/schwamster/ocr_service/)

This is a a wrapper api (asp .net core 1.0) for the Microsoft Cognitive Services - or to be more exact the Computer Vision Service.
You will need to get your own key at https://www.microsoft.com/cognitive-services/en-us/computer-vision-api

# getting started
Environmentvariable 'ComputerVisionKey' must be set on the system you are running the service on.

Start ocr_service.webapi (either by running the project itself of by running the docker image with parmeter host - see also build.ps1 and run.ps1)

post image to api/ocr and wait for the result.

## Example request:
POST /api/ocr HTTP/1.1
Host: localhost:5000
Cache-Control: no-cache
Postman-Token: a08ee620-646b-7d33-2c7e-c188dbee8131
Content-Type: multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW

------WebKitFormBoundary7MA4YWxkTrZu0gW
Content-Disposition: form-data; name="files"; filename=""
Content-Type: 


------WebKitFormBoundary7MA4YWxkTrZu0gW--

##Example response (at the moment it returns the exact same result as with the service itself):
{
  "language": "en",
  "textAngle": 0,
  "orientation": "Up",
  "regions": [
    {
      "boundingBox": "454,264,177,18",
      "lines": [
        {
          "boundingBox": "454,264,177,18",
          "words": [
            {
              "boundingBox": "454,269,36,13",
              "text": "ocr"
            },
            {
              "boundingBox": "499,264,132,18",
              "text": "123123123"
            }
          ]
        }
      ]
    }
  ]
}