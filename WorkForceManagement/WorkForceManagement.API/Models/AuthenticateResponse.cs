namespace WorkForceManagement.API.Models
{
    public class AuthenticateResponse
    {
      
        public string Username { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Users user, string token)
        {
            Username = user.username;
            Name = user.name;
            Role = user.role;
            Token = token;
        }
    }
}
