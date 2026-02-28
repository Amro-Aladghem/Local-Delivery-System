using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions;
using Service.Contracts;
using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.DeliveryCompanyUser;
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
    public class DeliveryCompanyUserController :ControllerBase
    {
        private readonly IDeliveryCompanyUser _deliveryCompanyUser;

        public DeliveryCompanyUserController(IDeliveryCompanyUser deliveryCompanyUser)
        {
            _deliveryCompanyUser = deliveryCompanyUser;
        }

        [HttpPost("register")]
        [Authorize(Policy = "PreRegister")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeliveryCompanyUserDto>> RegisterDeliveryCompanyUser(AddDeliveryCompanyUserDto addDeliveryCompanyUserDto)
        {
            string? UserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            if (UserId is null)
                return BadRequest(new { message = "Invalid Data" });

            RegisterDeliveryCompanyUserResult? result = await _deliveryCompanyUser.CreateDeliveryCompanyUser(addDeliveryCompanyUserDto, new Guid(UserId));

            if (result is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed To Register,Server Error!" });

            Response.SetTokendDtoIntoCoookie(result.TokenDto, 7, true);

            return Ok(result.DeliveryCompanyUserDto);
        }


    }
}
