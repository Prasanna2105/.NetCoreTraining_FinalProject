using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkForceManagement.API.Abstractions;
using WorkForceManagement.API.Helpers;
using WorkForceManagement.API.Models;

namespace WorkForceManagement.API.Services
{
    public class UserService:IUserService
    {
        private readonly WFMDbContext _wfmDbContext;
        public UserService(WFMDbContext wFMDbContext)
        {
            _wfmDbContext = wFMDbContext;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _wfmDbContext.Users.SingleOrDefault(x => x.username == model.Username && x.password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public Users GetByUsername(string username)
        {
            return _wfmDbContext.Users.FirstOrDefault(x => x.username == username);
        }

        // helper methods

        private string generateJwtToken(Users user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my first Security key and hope this is enough to create jwt token");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.username) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
