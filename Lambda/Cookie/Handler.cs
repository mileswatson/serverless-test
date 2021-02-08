using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

namespace Functions.Cookie
{
    public class Handler : HttpHandler
    {
        protected override Response Get(Request request)
        {
            if (request.Cookies is null || request.Cookies.Length == 0)
            {
                var newCookie = "sample cookie";
                return new Response {
                    StatusCode = (int) Code.OK,
                    Body = $"Could not find any cookies, so [{newCookie}] was added.",
                    Cookies = new string[] {
                        newCookie
                    },
                    
                };
            }

            var cookie = request.Cookies[0];
            return new Response
            {
                StatusCode = (int) Code.OK,
                Body = $"Found [{cookie}]",
                Cookies = request.Cookies
            };
        }
    }
}
