using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions;
using Service.Contracts;
using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserForAuthenticationResponse>> Login (UserForAuthenticationRequest userForAuthenticationRequest)
        {
            string authApproach = string.IsNullOrEmpty(userForAuthenticationRequest.Email) ? "Phone" : "Email";

            UserForAuthenticationResponse? user = await _authService.AuthenticateUser(userForAuthenticationRequest);

            if (user == null)
                return BadRequest(new { message = $"{authApproach} or Password is not correct!" });

            var tokenDto = await _authService.CreateToken(populateExp: true);

            Response.SetTokendDtoIntoCoookie(tokenDto, 5, 7, true);

            return Ok(user);
        }

        [HttpPost("pre-register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserPreRegisterResponse>> PreRegister(UserPreRegisterRequest userPreRegisterRequest)
        {
            UserPreRegisterResponse? user = await _authService.PreRegisterUser(userPreRegisterRequest);

            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new {message="Server Error!"});

            var tokenDto = await _authService.CreateToken(populateExp: false);

            Response.SetTokendDtoIntoCoookie(tokenDto, 5, 0, false);

            return Ok(user);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserForAuthenticationResponse>> RegisterUser(UserForRegisterationRequest registerUserRequest)
        {
            UserForAuthenticationResponse? user = await _authService.RegisterUser(registerUserRequest);

            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Server Error!" });

            var tokenDto = await _authService.CreateToken(populateExp: false);

            Response.SetTokendDtoIntoCoookie(tokenDto, 5, 7, true);

            return Ok(user);
        }

    }
}
