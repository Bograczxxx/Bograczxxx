using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using BograczApi.Models;

namespace BograczApi.Tests
{
    public class UsersControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public UsersControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_ReturnsOk()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/users");
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<User[]>();
            Assert.NotNull(users);
        }
    }
}
