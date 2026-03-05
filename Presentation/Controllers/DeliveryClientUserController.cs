using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions;
using Service.Contracts;
using Service.DeliveryClientUserService;
using Shared.DataTransferObjects.DeliveryClientOrganization;
using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.DeliveryCompany;
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

        [HttpPost("org/create")]
        [Authorize(Policy = "DeliveryClient")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CreateDeliveryCopmanyForUser(AddDeliveryClientOrganizationRequest request)
        {
            Guid? ProfileId = HttpContext.GetProfileIdAsGuid();

            if (ProfileId is null)
                return BadRequest(new { message = "Profile Id is missing" });

            if (!await _deliveryClientUser.IsDeliveryClientUserHasManagerRole(ProfileId.Value))
                return BadRequest(new { message = "You don't have permession to create delivery company!" });

            bool result = await _deliveryClientUser.HandleCreateClientOrgForUser(request, ProfileId.Value);

            return Ok(result);
        }
    }
}
