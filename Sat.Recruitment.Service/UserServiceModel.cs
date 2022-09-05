using AutoMapper;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.DataAccess.Repositories;
using Sat.Recruitment.Model;
using Sat.Recruitment.Service.Validates;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service
{
    public class UserServiceModel : IUserServiceModel
    {
        public IUserRepository _userRepository;
        public IMapper _mapper;
        public ILogger _logger;
        public UserServiceModel(IUserRepository userRepository, IMapper mapper, ILogger logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<User> Create(User aUser)
        {
            StringBuilder sb = new StringBuilder();
            UserValidate userValidate = new UserValidate(aUser);
            if (userValidate.Validate(sb))
            {
                aUser.Money = 0;
                aUser = await _userRepository.Add(aUser);
            }
            else
            ///Not valid argument to create User
            {
                throw new ArgumentException(sb.ToString());
            }
            return aUser;
        }
    }
}