using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace Framework.Api
{
    public class ClaimRequirementFilter : AuthorizeAttribute
    {
        readonly string _claim;

        public ClaimRequirementFilter(string claim)
        {
            _claim = claim;
        }

        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            //if (!hasClaim)
            //{
            //    context.Result = new ForbidResult();
            //}
        }
    }
}
