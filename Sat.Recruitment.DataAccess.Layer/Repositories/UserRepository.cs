namespace Sat.Recruitment.DataAccess.Repositories
{
    /// <summary>
    /// Data access class for User business object
    /// </summary>
    public class UserRepository : GenericRepository, IUserRepository
    {

        public UserRepository(SatRecruitmentContext dataContext) : base(dataContext) { }


    }

}
