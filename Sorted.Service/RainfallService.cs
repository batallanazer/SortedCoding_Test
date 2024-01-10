using Microsoft.Extensions.Configuration;
using Sorted.DataContract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sorted.Service
{
    public class RainfallService : IRainfallService
    {
        private readonly IConfiguration _configuration;
        public RainfallService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<GetRainfallResponse> Get(int stationId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("RainfallApiUrl").Value ?? "");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"id/stations/{stationId}/readings");
                var content = await response.Content.ReadFromJsonAsync<GetRainfallResponse>();
                return content;
            }
        }
    }
}
