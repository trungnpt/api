using BICAPI.Common;
using BICAPI.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BICAPI.Attributes
{
    public class SystemAuthenAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
                throw new AppException(AppMessage.UnAuthor);
            //Validate token

            base.OnActionExecuting(context);
        }
    }
}
