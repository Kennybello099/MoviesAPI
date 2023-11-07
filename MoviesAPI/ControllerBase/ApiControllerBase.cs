using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Abstraction;

namespace MoviesAPI.ControllerBase
{
    public class ApiControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ProcessResponse<TResult>(ApiResponse<TResult> serviceResponse) where TResult : class
        {
            return serviceResponse.Code switch
            {
                Enum.StatusCodes.OK => Ok(serviceResponse),
                Enum.StatusCodes.UNAUTHORIZED => Unauthorized(serviceResponse),
                Enum.StatusCodes.NOT_FOUND => NotFound(serviceResponse),
                Enum.StatusCodes.BAD_REQUEST => BadRequest(serviceResponse),
                Enum.StatusCodes.EXCEPTION => StatusCode(StatusCodes.Status500InternalServerError, serviceResponse),
                Enum.StatusCodes.ERROR => Ok(serviceResponse),
                _ => throw new NotImplementedException()
            };
        }
    }
}
