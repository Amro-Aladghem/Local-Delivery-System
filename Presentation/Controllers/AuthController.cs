using Microsoft.AspNetCore.Authorization;
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
    public class AuthController:ControllerBase
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

            AuthUserResponseResult? Result = await _authService.AuthenticateUser(userForAuthenticationRequest);

            if (Result == null)
                return BadRequest(new { message = $"{authApproach} or Password is not correct!" });


            Response.SetTokendDtoIntoCoookie(Result.Token,7, true);

            return Ok(Result.User);
        }

        [HttpPost("pre-register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserPreRegisterResponse>> PreRegister(UserPreRegisterRequest userPreRegisterRequest)
        {
            PreRegisterResponseResult? Result = await _authService.PreRegisterUser(userPreRegisterRequest);

            if (Result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new {message="Server Error!"});

            Response.SetTokendDtoIntoCoookie(Result.Token,0, false,1);

            return Ok(Result.User);
        }

        [HttpPost("register")]
        [Authorize(Policy = "PreRegisterUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserForAuthenticationResponse>> RegisterUser(UserForRegisterationRequest registerUserRequest)
        {
            AuthUserResponseResult? Result = await _authService.RegisterUser(registerUserRequest);

            if (Result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Server Error!" });

            Response.SetTokendDtoIntoCoookie(Result.Token, 7, true);

            return Ok(Result.User);
        }

        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RefreshToken()
        {
            string accessToken = Request.Cookies["accessToken"];
            string refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
                return Unauthorized();

            TokenDto? tokenDto = await _authService.RefreshToken(accessToken, refreshToken);

            if (tokenDto is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to generate token!" });

            Response.SetTokendDtoIntoCoookie(tokenDto, 7, true);

            return Ok(true);
        }

    }
}
