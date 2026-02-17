using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Extentions
{
    public static class CookieExtension
    {
        public static void SetTokendDtoIntoCoookie(this HttpResponse response,TokenDto tokens,int AccessTime,int RefreshTime,bool HasRefresh=true)
        {
            response.Cookies.Append("AuthToken", tokens.AccessToken, new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTime.UtcNow.AddHours(AccessTime)
            });

            if(HasRefresh)
            {
                response.Cookies.Append("RefreshToken", tokens.RefreshToken, new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddDays(RefreshTime)
                });
            }
        }
    }
}
