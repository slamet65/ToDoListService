using System.Text.Json.Serialization;

namespace ToDoListService.Model
{
    public class RegisterModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
