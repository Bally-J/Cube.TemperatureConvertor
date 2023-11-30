using Cube.Core.Enums;
using Cube.TemperatureConvertor.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace Cube.TemperatureConvertor.Api.IntegrationTests
{
    public class TemperatureConversionApiIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TemperatureConversionApiIntegrationTest(WebApplicationFactory<Program> application)
        {
            _client = application.CreateClient();
        }

        [Fact]
        public async Task CanConvertTemperature()
        {
            var request = new TemperatureConversionRequest
            {
                TemperatureToConvert = 32.0,
                ConvertFromTemperatureUnit = TemperatureUnit.Fahrenheit,
                ConvertToTemperatureUnit = TemperatureUnit.Celsius,
                Username = "testuser"
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/convert-temperature", content);

            response.EnsureSuccessStatusCode();
        }
    }
}