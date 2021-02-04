using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;

[assembly:LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]
namespace LambdaFunctions
{
    public class Handler
    {
        public APIGatewayHttpApiV2ProxyResponse Hello(APIGatewayHttpApiV2ProxyRequest request)
        {
            try 
            {
                var number = int.Parse(request.RawQueryString);
                return new APIGatewayHttpApiV2ProxyResponse {
                    StatusCode = 200,
                    Body = $"{number}+1={number+1}"
                };
            }
            catch 
            {
                return new APIGatewayHttpApiV2ProxyResponse {
                    StatusCode = 400,
                    Body = $"Format was incorrect! Enter a valid integer in the query string."
                };
            }
        }
    }
}
