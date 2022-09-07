using AutoMapper;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Model.Response;

namespace Sat.Recruitment.Model.AutoMapper
{
    /// <summary>
    ///Use to configurate AutoMapper
    /// </summary>
    public class DomainProfile : Profile
    {
        public DomainProfile() 
        {
            CreateMaps();
        }

        public void CreateMaps() 
        {
            // Users config
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
        }
    }
}
