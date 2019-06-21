using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MM.DataServices.Models;
using MM.DataServices.Members;
//using Sample.Core.Identity.Api.Models;
//using Sample.Core.Identity.Data.Enities;

namespace MM.DataServices.Controllers
{

    [Route("services/[controller]")]
    public class AccountController : Controller
    {
        readonly IConfiguration configuration;
      
        public AccountController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpPost]
        [Route("login")]
        public UserModel CreateToken([FromBody] LoginModel loginModel)
        {
            UserModel user = new UserModel();
            if (ModelState.IsValid)
            {
                MemberDataManager mbrMgr = new MemberDataManager();
                var loginResult = mbrMgr.AuthenticateUser(loginModel.email , loginModel.password , "", "");

                if (loginResult != "")
                {

                    user.email = loginResult.Split("~")[1];
                    user.memberID = loginResult.Split("~")[0];
                    user.picturePath = loginResult.Split("~")[2];
                    var jwt = GetToken(user);//new JwtSecurityTokenHandler().WriteToken(jwt);
                    user.accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
                    user.expiredDate = jwt.ValidTo;
                }
            }
            return user;
        }


        //[Authorize]
        [HttpPost]
        [Route("refreshLogin")]
        public UserModel RefreshToken([FromQuery] string accessToken)
        {
            string token = accessToken;
            MemberDataManager mbrMgr = new MemberDataManager();

            var principal = GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            var user = new UserModel();
            var lst =  mbrMgr.FindByUniqueEmail (username
                //User.Identity.Name ??
                //User.Claims.Where(c => c.Properties.ContainsKey("unique_name")).Select(c => c.Value).FirstOrDefault()
                );

            if (lst != null)
            {

                user.email = lst.email;
                user.memberID = lst.memberID;
                user.picturePath = lst.picturepath;
                var jwt = GetToken(user);//new JwtSecurityTokenHandler().WriteToken(jwt);
                user.accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
                user.expiredDate = jwt.ValidTo;
            }
            return user;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<String>("Jwt:Key"))),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken; 
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            
            return principal;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public String RegisterUser([FromBody]RegisterModel body)
        {
            MemberDataManager mbrMgr = new MemberDataManager();
            return mbrMgr.RegisterUserToLG(body.firstName, body.lastName, body.email, body.password, body.day, body.month, body.year, body.gender);
        }


        #region helper routines...

        private JwtSecurityToken GetToken(UserModel user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new Claim[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.memberID),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<String>("Jwt:Key")));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddSeconds(this.configuration.GetValue<int>("Jwt:Lifetime")),
                audience: this.configuration.GetValue<String>("Jwt:Issuer"),
                issuer: this.configuration.GetValue<String>("Tokens:Issuer")
                );
            return jwt;  //new JwtSecurityTokenHandler().WriteToken(jwt); 
        }

        #endregion


        #region class sub classes or model

        public class LoginModel
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public class UserModel
        {
            public string name { get; set; }
            public string email { get; set; }
            public string memberID { get; set; }
            public string picturePath { get; set; }
            public string accessToken { get; set; }
            public DateTime expiredDate { get; set; }
        }

        public class RegisterModel
        {
           public string firstName { get; set; }
           public string lastName { get; set; }
           public string email { get; set; } 
           public string password { get; set; }
           public string day { get; set; }
           public string month { get; set; } 
           public string year { get; set; }
           public string gender { get; set; }


        }


        #endregion

    }
}
