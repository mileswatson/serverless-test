using System;
using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

namespace Functions.Secret
{
    public class Handler : HttpHandler
    {
        private string secret;

        public Handler()
        {
            secret = Environment.GetEnvironmentVariable("SECRET_VARIABLE");
        }

        protected override Response Get(Request request)
        {
            return new Response
            {
                StatusCode = 200,
                Body = $"The secret is {secret}!"
            };
        }
    }
}
