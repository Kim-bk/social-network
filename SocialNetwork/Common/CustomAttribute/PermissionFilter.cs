using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using SocialNetwork.Models;
using Castle.Core.Internal;

namespace SocialNetwork.Commons.CustomAttribute
{
    public class PermissionFilter : IAuthorizationFilter
    {
        private readonly string _role;

        public PermissionFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // 1. Get all credentials of the user
            var userCredentials = context.HttpContext.User.FindFirst("Credentials")?.Value;

            // 2. Cast to list
            List<string> result = userCredentials.Split(',').ToList();

            // 3. Check user credential has role
            var claim = result.Where(r => r.Equals(_role)).IsNullOrEmpty();
            if (claim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}