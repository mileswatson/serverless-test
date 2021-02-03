dotnet restore LambdaFunctions
dotnet tool install LambdaFunctions -g Amazon.Lambda.Tools --framework netcoreapp3.1
dotnet lambda package -pl LambdaFunctions --configuration Release --framework netcoreapp3.1 --output-package LambdaFunctions/bin/Release/netcoreapp3.1/hello.zip
