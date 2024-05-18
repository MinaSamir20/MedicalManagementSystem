using MedicalManagementSystem.Application.DTOs.Authentication;
using MedicalManagementSystem.Application.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService auth) : ControllerBase
    {
        private readonly IAuthService _auth = auth;

        [HttpPost, Authorize(Roles = "Admin"), Route("CreateRole")]
        public async Task<IActionResult> CreateRole(string role)
        {
            return Ok(await _auth.CreateRoleAsync(role));
        }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _auth.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            SetRefreshTokenInCookie(result.RefreshToken!, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _auth.LoginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin"), Route("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _auth.AddRoleToUserAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

        [HttpGet, Authorize, Route("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _auth.GetAllUsersAsync();
            return Ok(result);
        }
        [HttpGet, Authorize, Route("Users/{Id}")]
        public async Task<IActionResult> GetUserById(string Id)
        {
            var result = await _auth.GetUserByIdAsync(Id);
            return Ok(result);
        }

        [HttpPut, Authorize, Route("Users")]
        public async Task<IActionResult> UpdateUser(UserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _auth.UpdateUserAsync(model);
            if (result != "Updated") return BadRequest(result);
            return Ok("Updated Successfully");
        }

        [HttpDelete, Authorize, Route("Users/{Id}")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var result = await _auth.DeleteUserAsync(Id);
            if (result != "Deleted") return BadRequest(result);
            return Ok("Deleted Successfully");
        }

        [HttpGet, Route("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var result = await _auth.RefreshTokenAsync(refreshToken!);

            if (result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken!, result.RefreshTokenExpiration);
            return Ok(result);
        }

        [HttpPost, Route("revokeToken")]
        public async Task<IActionResult> RevokeToken(RevokeToken revoke)
        {
            var token = revoke.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token)) return BadRequest("Token is Required");

            var result = await _auth.RevokeTokenAsync(token);

            if (!result) return BadRequest("Token is Invalid!");
            return Ok();
        }
    }
}
