#!/bin/bash

#install zip on debian OS, since microsoft/dotnet container doesn't have zip by default
if [ -f /etc/debian_version ]
then
  apt -qq update
  apt -qq -y install zip
fi

dotnet restore lambda-functions
dotnet tool install lambda-functions -g Amazon.Lambda.Tools --framework netcoreapp3.1
dotnet lambda package -pl lambda-functions --configuration Release --framework netcoreapp3.1 --output-package lambda-functions/bin/Release/netcoreapp3.1/hello.zip
