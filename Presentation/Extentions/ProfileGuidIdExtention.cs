using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Extentions
{
    public static class ProfileGuidIdExtention
    {
        public static Guid? GetProfileIdAsGuid(this HttpContext context)
        {
            string? ProfileId = context.User.FindFirst("profile_id")!.Value;

            if (ProfileId is null)
                return null;

           return new Guid(ProfileId);
        }
    }
}
