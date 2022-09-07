using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Model.Response;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service
{
    public interface IUserServiceModel
    {
        Task<UserResponse> Create(UserRequest userRequest);
    }
}