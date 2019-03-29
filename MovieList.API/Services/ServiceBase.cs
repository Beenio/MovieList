using System.Threading.Tasks;
using MovieList.API.Requests;
using MovieList.API.Responses;

namespace MovieList.API.Services
{
    public class ServiceBase : IServiceBase
    {
        public async Task<Res> DoGet<Req,Res>(Req RequestObject) where Req : GenericRequest
                                                                             where Res : GenericResponse
        {
            var Manager = new HttpRequestManager<Req, Res>();
            var Response = await Manager.DoGet(RequestObject);

            return Response;
        }
    }
}
