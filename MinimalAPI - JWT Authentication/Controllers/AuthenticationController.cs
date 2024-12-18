using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI___JWT_Authentication.Entities;
using MinimalAPI___JWT_Authentication.Services;

namespace MinimalAPI___JWT_Authentication.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        public AuthenticationController(JwtTokenGenerator jwtTokenGenerator) 
        {
            _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        }
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(User user)
        {
            var token = _jwtTokenGenerator.GenerateToken(user.UserName, user.Password);

            if (token is null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

    }
}
