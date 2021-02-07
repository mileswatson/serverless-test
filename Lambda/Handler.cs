using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;

using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

[assembly:LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]
namespace Functions
{
    public class Handler : HttpHandler
    {
        public override Response Get(Request request)
        {
            return new Response
            {
                StatusCode = 200,
                Body = $"Welcome to the CSBoost API. Available functions: Hello, Cookie."
            };
        }
    }
}