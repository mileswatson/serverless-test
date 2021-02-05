using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using System.Linq;
using System.Reflection;

[assembly:LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]
namespace Functions
{
    public class Root
    {
        private string types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "Functions" && t.Name != "Root" && t.Name.All(char.IsLetterOrDigit))
                .Select(t => t.Name)
                .Aggregate((x, y) => $"{x}\n\t{y}");

        public APIGatewayHttpApiV2ProxyResponse Handler(APIGatewayHttpApiV2ProxyRequest request)
        {
            return new APIGatewayHttpApiV2ProxyResponse
            {
                StatusCode = 200,
                Body = $"Welcome to the CSBoost API. Available functions: \n\t{types}"
            };
        }

    }
}