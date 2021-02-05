#!/bin/bash

#install zip on debian OS, since microsoft/dotnet container doesn't have zip by default
if [ -f /etc/debian_version ]
then
  apt -qq update
  apt -qq -y install zip
fi

dotnet restore Lambda
dotnet tool install Lambda -g Amazon.Lambda.Tools --framework netcoreapp3.1
dotnet lambda package -pl Lambda --configuration Release --framework netcoreapp3.1 --output-package Lambda/bin/Release/netcoreapp3.1/Lambda.zip
