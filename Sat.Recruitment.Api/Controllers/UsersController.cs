using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Utils;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Model.Request.Validations;
using Sat.Recruitment.Model.Response;
using Sat.Recruitment.Service;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserServiceModel _userServiceModel;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserServiceModel userServiceModel, ILogger<UsersController> logger)
        {
            _userServiceModel = userServiceModel;
            _logger = logger;
        }
        [HttpPost]
        [Authorize]
       
    [MapToApiVersion("1.0")]
        public async Task<IActionResult> CreateUser(UserRequest userRequest)
        {
       
            UserResponse result = null;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            string messagge = string.Empty;

            try
            {
                UserRequestValidate userValidate = new UserRequestValidate();
                var validatorResult = userValidate.Validate(userRequest);
                if (validatorResult.IsValid)
                {

                    result = await _userServiceModel.Create(userRequest);
                    if (result != null)
                    {
                        httpStatusCode = HttpStatusCode.OK;
                    }
                }
                else
                {
                    messagge = validatorResult.ToString(" - ");
                    _logger.LogWarning(messagge);

                }
            }
            catch (TypeLoadException ex)
            {
                _logger.LogError(ex.Message);
                messagge = ex.Message;
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex.Message);
                messagge = ex.Message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                messagge = "Error to create the user";
            }
            return new WebApiEnvelope<UserResponse>(httpStatusCode, result, messagge).Result;
            

        }
    }

}
