using System;
using System.Threading.Tasks;

using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

namespace Functions
{
    public class HttpHandler
    {
        public Response Handle(Request request)
        {
            return request.RequestContext.Http.Method switch {
                "GET" => Get(request),
                "POST" => Post(request),
                _ => Any(request)
            };
        }

        public virtual Response Get(Request request) => Any(request);

        public virtual Response Post(Request request) => Any(request);

        public virtual Response Any(Request request)
        {
            throw new NotImplementedException();
        }
    }
}