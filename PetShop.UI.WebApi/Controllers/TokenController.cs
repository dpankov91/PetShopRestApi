using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using PetShop.Core.Security;
using PetShop.UI.WebApi.Authorization;

namespace PetShop.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private IAuthenticationHelper _authHelper;

        public TokenController(IUserService userService, IAuthenticationHelper authenticationHelper)
        {
            _userService = userService;
            _authHelper = authenticationHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _userService.getUsers().FirstOrDefault(u => u.Username == model.Username);

            //Cheking if user exists
            if (user == null)
                return Unauthorized();

            //Chek if pass is correct
            if (!_authHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            //Authentication successfull
            return Ok(new
            {
                username = user.Username,
                token = _authHelper.GenerateToken(user)
            });
        }
    }
}
