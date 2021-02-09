dotnet restore Lambda
dotnet tool install -g Amazon.Lambda.Tools --framework netcoreapp3.1
dotnet lambda package -pl Lambda --configuration Release --framework netcoreapp3.1 --output-package Lambda/bin/Release/netcoreapp3.1/Lambda.zip
