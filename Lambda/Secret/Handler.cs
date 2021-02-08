using System;
using System.Security.Cryptography;
using System.Text;
using Paseto;
using Paseto.Protocol;
using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

namespace Functions.Secret
{
    public class Handler : HttpHandler
    {
        private PasetoEncoder encoder;
        private PasetoDecoder decoder;

        const string IsAuthenticated = "IsAuthenticated";

        public Handler()
        {
            var secretString = Environment.GetEnvironmentVariable("PASETO_KEY");
            var secretBytes = Encoding.ASCII.GetBytes(secretString);
            var hash = SHA256.Create().ComputeHash(secretBytes);

            encoder = new PasetoEncoder(cfg => cfg.Use<Version2>(hash, Purpose.Local));
            decoder = new PasetoDecoder(cfg => cfg.Use<Version2>(hash, Purpose.Local));
        }

        protected override Response Get(Request request)
        {
            if (request.Cookies is null || request.Cookies.Length == 0)
            {
                var token = GenerateToken(
                    !(request.QueryStringParameters is null)
                    && request.QueryStringParameters.ContainsKey("allowed")
                    && request.QueryStringParameters["allowed"] == "true"
                );
                return new Response {
                    StatusCode = (int) Code.OK,
                    Body = "No token was found, so a new one was added.",
                    Cookies = new string[] { token }
                };
            }
            PasetoPayload payload;
            try 
            {
                payload = decoder.DecodeToObject(request.Cookies[0]).Payload;
            }
            catch 
            {
                return new Response {
                    StatusCode = (int) Code.UNAUTHORIZED,
                    Body = "Token was invalid!"
                };
            }
            if (!Authenticated(payload)) {
                return new Response {
                    StatusCode = (int) Code.FORBIDDEN,
                    Body = "Access denied!"
                };
            }
            return new Response {
                StatusCode = (int) Code.OK,
                Body = "Authorised."
            };
        }

        private string GenerateToken(bool authenticated)
        {
            return encoder.Encode(new PasetoPayload {
                { IsAuthenticated, authenticated }
            });
        }

        private bool Authenticated(PasetoPayload payload) =>
            payload.ContainsKey(IsAuthenticated) && (bool)payload[IsAuthenticated];
    }
}
