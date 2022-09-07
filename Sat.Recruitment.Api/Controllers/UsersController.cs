using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Utils;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Model.Response;
using Sat.Recruitment.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
 
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserServiceModel _userServiceModel;

        public UsersController(IUserServiceModel userServiceModel)
        {
            _userServiceModel = userServiceModel;
        }
        [HttpPost]
        [Route("/create-user")]
        public async Task<IActionResult> CreateUser(UserRequest userRequest)
        {
            try
            {
                var result = await _userServiceModel.Create(userRequest);
                return result != null
                       ? new WebApiEnvelope<UserResponse>(HttpStatusCode.OK, result).Result
                       : new WebApiEnvelope<UserResponse>(HttpStatusCode.InternalServerError, result).Result;
            }
            catch (Exception ex)
            {
                return new WebApiEnvelope<UserResponse>(HttpStatusCode.InternalServerError, null, ex.Message).Result;
            }
        }
    }

}
