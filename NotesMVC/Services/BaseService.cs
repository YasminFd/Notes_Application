using Newtonsoft.Json;
using NotesMVC.Models;
using System;
using System.Net;
using System.Text;
using static NotesMVC.Models.SD;

namespace NotesMVC.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory )
        {
            _httpClientFactory  = httpClientFactory;
        }
        public async Task<Response> SendAsync(Request request)
        {
            HttpClient client = _httpClientFactory.CreateClient("NotesAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            //token
            message.RequestUri = new Uri(request.URL);
            if (request.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(request.Data),Encoding.UTF8,"application/json");
            }
            
            switch(request.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.GET:
                    message.Method = HttpMethod.Get;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;

            }
            HttpResponseMessage? apiresponse = null;
            apiresponse = await client.SendAsync(message);
            try
            {
                switch (apiresponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "NOT FOUND" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Forbidden" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorised" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "InternalServerError" };
                    default:
                        var apiContent = await apiresponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<Response>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new Response
                { Message = ex.Message.ToString(), IsSuccess = false };
                return dto;
            }
        }
    }
    
}
