dotnet restore lambda-functions
dotnet tool install lambda-functions -g Amazon.Lambda.Tools --framework netcoreapp3.1
dotnet lambda package -pl lambda-functions --configuration Release --framework netcoreapp3.1 --output-package lambda-functions/bin/Release/netcoreapp3.1/hello.zip
