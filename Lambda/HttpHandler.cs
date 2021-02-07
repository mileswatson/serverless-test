using System;
using System.Threading.Tasks;

using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

namespace Functions
{
    public class HttpHandler
    {
        public Task<Response> Handle(Request request)
        {
            return request.RequestContext.Http.Method switch {
                "GET" => Get(request),
                "POST" => Post(request),
                _ => Any(request)
            };
        }

        public virtual Task<Response> Get(Request request) => Any(request);

        public virtual Task<Response> Post(Request request) => Any(request);

        public virtual Task<Response> Any(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
