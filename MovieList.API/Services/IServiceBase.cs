using System.Threading.Tasks;
using MovieList.API.Requests;
using MovieList.API.Responses;

namespace MovieList.API.Services
{
    public interface IServiceBase
    {
        Task<Res> DoGet<Req, Res>(Req RequestObject) where Req : GenericRequest where Res : GenericResponse;
    }
}
