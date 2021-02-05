using Amazon.Lambda.APIGatewayEvents;

namespace Functions
{
    public class Cookie
    {

        public APIGatewayHttpApiV2ProxyResponse Handler(APIGatewayHttpApiV2ProxyRequest request)
        {
            if (request.Cookies is null || request.Cookies.Length == 0)
            {
                var newCookie = "sample cookie";
                return new APIGatewayHttpApiV2ProxyResponse {
                    StatusCode = 200,
                    Body = $"Could not find any cookies, so [{newCookie}] was added.",
                    Cookies = new string[] {
                        newCookie
                    },
                    
                };
            }

            var cookie = request.Cookies[0];
            return new APIGatewayHttpApiV2ProxyResponse
            {
                StatusCode = 200,
                Body = $"Found [{cookie}]",
                Cookies = request.Cookies
            };
        }
        
    }
}
