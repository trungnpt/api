using BICAPI.Common;
using BICAPI.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BICAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorHandlerController : Controller
    {
        /// <summary>
        /// All exception will come here
        /// </summary>
        /// <returns></returns>
        [Route("error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = context?.Error;
            if (exception is SqlDbException)
            {
                var ex = exception as SqlDbException;
                BaseResponse<string> response = new BaseResponse<string>(ex.error_code, ex.Message);
                return Ok(response);
            }
            if (exception is AppException)
            {
                var ex = exception as AppException;
                BaseResponse<string> response = new BaseResponse<string>(ex.error_code, ex.Message);
                return Ok(response);
            }

            return Ok(new { error_code = "500", error_message = exception.Message });
        }
    }
}
