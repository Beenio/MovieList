using System.Threading.Tasks;
using MovieList.API.Requests;
using MovieList.API.Responses;
using MovieList.API.Services.Interface;

namespace MovieList.API.Services
{
    public class ServiceBase : IServiceBase
    {
        public async Task<Res> DoGet<Req,Res>(string URL, Req RequestObject) where Req : GenericRequest
                                                                             where Res : GenericResponse
        {
            var Manager = new HttpRequestManager<Req, Res>();
            var Response = await Manager.DoGet(RequestObject);
            return Response;
        }
    }
}
