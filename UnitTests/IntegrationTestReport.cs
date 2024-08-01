using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace TestsApp
{
    public class IntegrationTestReport : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public IntegrationTestReport(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task GetByDate_ReturnsOkResponse()
        {
            var date = new DateTime(2023, 8, 1).ToString("yyyy-MM-dd");
            var response = await _client.GetAsync($"/api/report/{date}");
            response.EnsureSuccessStatusCode(); 
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString()); 
        }

        [Fact]
        public async Task GetRangeDate_ReturnsOkResponse()
        {
         
            var startDate = new DateTime(2023, 8, 1).ToString("yyyy-MM-dd");
            var endDate = new DateTime(2023, 8, 7).ToString("yyyy-MM-dd");

          
            var response = await _client.GetAsync($"/api/report?startDate={startDate}&endDate={endDate}");

          
            response.EnsureSuccessStatusCode(); 
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString()); 
        }
    }
}
