using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Reflection;
using WebApiTestÖvning2._0;
using WebApiTestÖvning2._0.Model;

namespace Test.WebApiTestÖvning2._0
{
    public class TestFelanmälan
    {
        private WebApplicationFactory<Program> _webAppFactory;
        private HttpClient _httpClient;

        public TestFelanmälan()
        {
            _webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = _webAppFactory.CreateDefaultClient();
        }
        [Fact]
        public async Task Get_Felanmalan_List_From_Api()
        {
            //var response = await _httpClient.GetAsync("https://localhost:7124/api/Felanmalan");
            bool result = false;
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Felanmälan>>("https://localhost:7124/api/Felanmalan");
            //var stringResult = await response.Content.ReadAsStringAsync();

            if (response.ElementAt(0).Title != null && response.ElementAt(0).Description != null)
                result = true;

            Assert.True(result);
        }

        [Fact]
        public async Task Get_Felanmalan_By_Id_From_Api()
        {
            var response = await _httpClient.GetFromJsonAsync<Felanmälan>("https://localhost:7124/api/Felanmalan/4");
            var expectedResult = false;

            if(response != null)
                expectedResult = true;

            Assert.True(expectedResult);
        }
    }
}