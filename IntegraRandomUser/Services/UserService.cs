using IntegraRandomUser.DTOs;
using IntegraRandomUser.Interfaces;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace IntegraRandomUser.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserService> _logger;

        public UserService(HttpClient httpClient, ILogger<UserService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<UserDTO?> GetUserAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<RandomUserResponse>("https://randomuser.me/api/");
                if (response != null && response.Results.Any())
                {
                    var r = response.Results[0];
                    return new UserDTO
                    {
                        FirstName = r.Name?.First,
                        LastName = r.Name?.Last,
                        Email = r.Email,
                        Username = r.Login?.Username,
                        Gender = r.Gender,
                        City = r.Location?.City,
                        State = r.Location?.State,
                        Country = r.Location?.Country
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar User.");
                return null;
            }
        }
    }

    public class RandomUserResponse
    {
        public List<Result> Results { get; set; } = new();
    }

    public class Result
    {
        public Name Name { get; set; } = new();
        public Location Location { get; set; } = new();
        public string Email { get; set; } = "";
        public Login Login { get; set; } = new();
        public string Gender { get; set; } = "";
    }

    public class Name
    {
        public string First { get; set; } = "";
        public string Last { get; set; } = "";
    }

    public class Location
    {
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
    }

    public class Login
    {
        public string Username { get; set; } = "";
    }
}
