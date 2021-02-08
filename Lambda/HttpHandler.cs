using System;

using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

namespace Functions
{
    public class HttpHandler
    {
        public enum Code {
            OK = 200,
            BAD_REQUEST = 400,
            UNAUTHORIZED = 401,
            FORBIDDEN = 403,
            NOT_FOUND = 404
        }

        public Response Handle(Request request)
        {
            return request.RequestContext.Http.Method switch {
                "GET" => Get(request),
                "POST" => Post(request),
                _ => Any(request)
            };
        }

        protected virtual Response Get(Request request) => Any(request);

        protected virtual Response Post(Request request) => Any(request);

        protected virtual Response Any(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
