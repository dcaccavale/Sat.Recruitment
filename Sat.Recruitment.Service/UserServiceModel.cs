using AutoMapper;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.DataAccess.Repositories;
using Sat.Recruitment.Model.Calculate;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Model.Response;
using Sat.Recruitment.Model.Request.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service
{
    /// <summary>
    /// Class of service to access the business logic for user management
    /// </summary>
    public class UserServiceModel : IUserServiceModel
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;
        public ILogger<User> _logger;
        public UserServiceModel(IUserRepository userRepository, IMapper mapper, ILogger<User> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Create and add a new User, check for duplicates and required fields
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException">invalid required fields or user is duplicated</exception>
        public async Task<UserResponse> Create(UserRequest userRequest)
        {

            User aUser =  _mapper.Map<User>(userRequest);
            UserValidate userValidate = new UserValidate();
            var validatorResult = userValidate.Validate(aUser);
            if (validatorResult.IsValid)
            {

                if (!await IsDuplicated(userRequest, _userRepository))
                {
                    aUser.Money = CalculateUserAmountManager.GetCalculate(aUser.Type).Execute(aUser.Money);
                    aUser = await _userRepository.Add(aUser);
                    _logger.Log(LogLevel.Information, "Create User", aUser);
                    return _mapper.Map<UserResponse>(aUser);
                }
                else
                {
                    _logger.Log(LogLevel.Error, "User Duplicate");
                    throw new ValidationException("User is duplicated");
                }

            }
            else
            ///Not valid argument
            {
                _logger.Log(LogLevel.Error, "Invalid userRequest field", validatorResult.ToString(" - "));
                throw new ValidationException(validatorResult.ToString(" - "));
            }

        }

        private Task<bool> IsDuplicated(UserRequest userRequest, IUserRepository userRepository)
        {
            return _userRepository.Any<User>(user => (user.Email == userRequest.Email || user.Phone == userRequest.Phone)
            || (user.Name == userRequest.Name && user.Address == userRequest.Address) 
            );
        }
    }
}