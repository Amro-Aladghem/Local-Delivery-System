using Entities.Models;
using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extentions;
using Service.Contracts;
using Service.DeliveryClientUserService;
using Shared.DataTransferObjects.DeliveryClientOrganization;
using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.DeliveryCompany;
using Shared.DataTransferObjects.Driver;
using Shared.InternalModels;
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

            DeliveryClientUserModel deliveryClientUserModel = await _deliveryClientUser.GetDeliveryClientUserModel(ProfileId.Value);

            if ((deliveryClientUserModel.DeliveryClientOrgUserRole != DeliveryClientOrgUserRole.Manager))
                return BadRequest(new { message = "You don't have permession to create delivery company!" });

            bool result = await _deliveryClientUser.HandleCreateClientOrgForUser(request, ProfileId.Value);

            return Ok(result);
        }

        [HttpPost("admin/create")]
        [Authorize(Policy = "DeliveryClient")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CreateAdminForClientOrg(AddDeliveryClientAdminRequest request)
        {
            Guid? ProfileId = HttpContext.GetProfileIdAsGuid();

            if (ProfileId is null)
                return BadRequest(new { message = "Profile Id is missing" });

            DeliveryClientUserModel deliveryClientUserModel = await _deliveryClientUser.GetDeliveryClientUserModel(ProfileId.Value);

            if ((deliveryClientUserModel.DeliveryClientOrgUserRole != DeliveryClientOrgUserRole.Manager)
                || deliveryClientUserModel.DeliveryClientOrganizationId is null)
                return BadRequest(new { message = "You don't have permession to create delivery company!" });

            bool result = await _deliveryClientUser.HandleCreateAdminUserForOrg(request, deliveryClientUserModel.DeliveryClientOrganizationId.Value);

            return Ok(result);
        }






    }
}
