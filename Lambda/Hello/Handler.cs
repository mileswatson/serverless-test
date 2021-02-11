using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

namespace Functions.Hello
{
    public class Handler : HttpHandler
    {
        private int x = 0;

        protected override Response Get(Request request)
        {
            var query = request.QueryStringParameters;

            if (query is null || !query.ContainsKey("name") || query["name"] == "")
            {
                return new Response
                {
                    StatusCode = (int) Code.BAD_REQUEST,
                    Body = $"Sorry, I don't think we've met. Please include a name parameter in the url query!"
                };
            }

            var name = query["name"];
            return new Response
            {
                StatusCode = 200,
                Body = $"Hello, {name}! {x++}"
            };
        }
    }
}
