namespace BaseProject.Application.Models.DTOs.Accounts.Responses
{
    public class AuthenticationResponse
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
