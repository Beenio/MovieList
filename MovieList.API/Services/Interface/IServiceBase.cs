using System.Threading.Tasks;
using MovieList.API.Requests;
using MovieList.API.Responses;

namespace MovieList.API.Services.Interface
{
    public interface IServiceBase
    {
        Task<Res> DoGet<Req, Res>(string URL, Req RequestObject) where Req : GenericRequest where Res : GenericResponse;
    }
}
