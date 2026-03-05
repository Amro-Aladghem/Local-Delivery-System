using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions;
using Service.Contracts;
using Shared.DataTransferObjects.DeliveryCompany;
using Shared.DataTransferObjects.DeliveryCompanyUser;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/deliveryCompanyUsers")]
    [ApiController]
    public class DeliveryCompanyUserController : ControllerBase
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

        [HttpPost("company/create")]
        [Authorize(Policy = "DeliveryCompanyUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CreateDeliveryCopmanyForUser(AddDeliveryCompanyRequest addDeliveryCompanyRequest)
        {
            Guid? ProfileId = HttpContext.GetProfileIdAsGuid();
            
            if (ProfileId is null)
                return BadRequest(new { message = "Profile Id is missing" });

            if (!await _deliveryCompanyUser.IsDeliveryCompanyUserHasManagerRole(ProfileId.Value))
                return BadRequest(new { message = "You don't have permession to create delivery company!" });

            bool result = await _deliveryCompanyUser.HandleCreateCompanyForUser(addDeliveryCompanyRequest, ProfileId.Value);

            return Ok(result);
        }

    }
}
