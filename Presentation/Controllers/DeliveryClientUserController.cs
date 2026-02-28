using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions;
using Service.Contracts;
using Service.DeliveryClientUserService;
using Shared.DataTransferObjects.DeliveryClientUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/deliveryClientUser")]
    [ApiController]
    public class DeliveryClientUserController : ControllerBase
    {
        private readonly IDeliveryClientUser _deliveryClientUser;

        public DeliveryClientUserController(IDeliveryClientUser deliveryClientUser)
        {
            _deliveryClientUser = deliveryClientUser;
        }

        [HttpPost("register")]
        [Authorize(Policy = "PreRegister")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeliveryClientUserDto>> RegisterDeliveryClientUser(AddDeliveryClientUserRequest addDeliveryClientUserRequest)
        {
            string? UserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            if (UserId is null)
                return BadRequest(new { message = "Invalid Data" });

            RegisterDeliveryClientUserResult? result = await _deliveryClientUser.CreateDeliveryClientUser(addDeliveryClientUserRequest,new Guid(UserId));

            if (result is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed To Register,Server Error!" });

            Response.SetTokendDtoIntoCoookie(result.TokenDto, 7, true);

            return Ok(result.DeliveryClientUserDto);
        }
    }
}
