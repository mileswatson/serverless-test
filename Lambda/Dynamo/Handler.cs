using System;
using System.Threading.Tasks;
using Request = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyRequest;
using Response = Amazon.Lambda.APIGatewayEvents.APIGatewayHttpApiV2ProxyResponse;

namespace Functions.Dynamo
{
    public class Handler : HttpHandlerAsync
    {
        
        Database db = new Database();

        protected override async Task<Response> Get(Request request)
        {
            try 
            {
                await db.Add("testPk", "testPassword");
                return new Response {
                    StatusCode = (int) Code.OK,
                    Body = await db.Get("testPk")
                };
            }
            catch (Exception e)
            {
                return new Response {
                    StatusCode = (int) Code.BAD_REQUEST,
                    Body = e.ToString()
                };
            }
        }
    }
}
