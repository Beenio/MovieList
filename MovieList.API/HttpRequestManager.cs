using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MovieList.API.Enums;
using MovieList.API.Exceptions;
using MovieList.API.Requests;
using MovieList.API.Responses;
using Newtonsoft.Json;

namespace MovieList.API
{
    public class HttpRequestManager<Request, Response>  where Request : GenericRequest
                                                        where Response : GenericResponse
    {
        public CancellationTokenSource CancellationTokenSource { get; private set; }

        public int Timeout { get; set; }

        public async Task<Response> DoGet(Request requestObject)
        {
            return await DoRequestAsync(RequestTypeEnum.Get, requestObject);
        }

        private async Task<Response> DoRequestAsync(RequestTypeEnum requestMethodType, Request requestObject)
        {
            CancellationTokenSource = new CancellationTokenSource(requestObject.Timeout * 1000);

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(requestObject.Timeout);
                client.MaxResponseContentBufferSize = requestObject.MaxResponseContentBufferSize;

                if (!string.IsNullOrEmpty(requestObject.Host))
                    client.BaseAddress = new Uri(requestObject.Host);

                HttpResponseMessage response;

                if (requestMethodType == RequestTypeEnum.Get)
                    response = await client.GetAsync(requestObject.Url, CancellationTokenSource.Token);
                else
                    throw new RequestMethodNotImplementedException();

                if (response.IsSuccessStatusCode)
                {
                    var deserializeSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };

                    var result = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<Response>(result, deserializeSettings);
                    return model;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var StatusCode = (int)response.StatusCode;
                    var Message = await response.Content.ReadAsStringAsync();
                    throw new RequestFailureException(StatusCode, Message);
                }
            }
        }
    }
}