using Demo.Core.Helper;
using Demo.DataModel.Data.Entities.Common;
using Demo.ViewModel.ApiModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]

        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginRequestVm login)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(login.Username);
                if (ModelState.IsValid)
                {
                    IActionResult response = Unauthorized();
                    var res = await AuthenticateUser(login);
                    return Ok(res);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)ResponseCodes.Error);
            }


        }

        private async Task<LoginResponse> AuthenticateUser(LoginRequestVm login)
        {
            LoginResponse res = new LoginResponse();
            UserInfo userInfo = new UserInfo();
            try
            {
                var user = await _userManager.FindByEmailAsync(login.Username);
                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(login.Username);
                }

                if (user != null)
                {
                    login.Password = login.Password.Trim();
                    var result = await PasswordSignIn(login);
                    if (!result.Succeeded)
                    {
                        res.ResponseCodes = ResponseCodes.InvalidModel;
                        res.ResponseMessage = SystemMessages.UserLoginFailed;
                        return res;
                    }

                }

                var Jwt = GenerateJwtToken(login);
                userInfo.Id = user?.Id;
                userInfo.Name = user?.UserName;
                userInfo.Jwt = Jwt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            res.ResponseData = userInfo;
            res.ResponseCodes = ResponseCodes.Success;
            res.ResponseMessage = SystemMessages.UserLoginSuccessfully;
            return res;
        }

        private async Task<SignInResult> PasswordSignIn(LoginRequestVm login)
        {
            try
            {
                bool IsTwoFactorNeeded = false;

                var user = await _userManager.FindByEmailAsync(login.Username);
                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(login.Username);
                }
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, true);
                return result;
            }
            catch (Exception ex) { throw ex; }
        }

        [Route("~/api/SignOut")]
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            try
            {
               await _signInManager.SignOutAsync();
                return Ok(new { mess = "Sign Out Successfuly" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GenerateJwtToken(LoginRequestVm login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("yourSecretKeyyourSecretKeyyourSecretKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserName", login.Username) }),
                Expires = DateTime.UtcNow.AddDays(7),
              //  SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
