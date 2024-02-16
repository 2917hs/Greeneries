using System.Net;
using System.Text;
using Green.Web.Models;
using Green.Web.Models.Dto;
using Newtonsoft.Json;
using static Green.Web.Utility.StaticDetails;

namespace Green.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            var client = httpClientFactory.CreateClient("GreenApi");

            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");            
            message.RequestUri = new Uri(requestDto.Url);

            if (requestDto.Data is not null)
            {
                message.Content = new StringContent(
                                    JsonConvert.SerializeObject(requestDto.Data),
                                    Encoding.UTF8,
                                    "application/json");
            }

            message.Method = requestDto.ApiType switch
            {
                ApiType.POST => HttpMethod.Post,
                ApiType.PUT => HttpMethod.Put,
                ApiType.DELETE => HttpMethod.Delete,
                _ => HttpMethod.Get
            };

            HttpResponseMessage? apiResponse = await client.SendAsync(message);

            ResponseDto? apiResponseDto = apiResponse.StatusCode switch
            {
                HttpStatusCode.NotFound => new() { IsSuccess = false, Message = "NotFound" },
                HttpStatusCode.Forbidden => new() { IsSuccess = false, Message = "Forbidden" },
                HttpStatusCode.Unauthorized => new() { IsSuccess = false, Message = "Unauthorized" },
                HttpStatusCode.InternalServerError => new() { IsSuccess = false, Message = "InternalServerError" },
                _ => new() { IsSuccess = true, Message = "Success" }
            };

            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            }

            return apiResponseDto;
        }
    }
}

