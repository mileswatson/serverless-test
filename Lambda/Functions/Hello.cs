using Amazon.Lambda.APIGatewayEvents;

namespace Functions
{
    public class Hello
    {
        
        public APIGatewayHttpApiV2ProxyResponse Handler(APIGatewayHttpApiV2ProxyRequest request)
        {
            var query = request.QueryStringParameters;

            if (query is null || !query.ContainsKey("name") || query["name"] == "")
            {
                return new APIGatewayHttpApiV2ProxyResponse
                {
                    StatusCode = 400,
                    Body = $"Sorry, I don't think we've met. Please include a name parameter in the url query!"
                };
            }

            var name = query["name"];

            return new APIGatewayHttpApiV2ProxyResponse
            {
                StatusCode = 200,
                Body = $"Hello, {name}!"
            };
        }

    }
}
