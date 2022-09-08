

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.ApiAuth.Model;

namespace Sat.Recruitment.ApiAuth.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new ApiAuthContext(serviceProvider.GetRequiredService<DbContextOptions<ApiAuthContext>>()))
            {
                Seed(_context);

            }
        }

        public static void Seed(ApiAuthContext _context)
        {
            var guid = Guid.NewGuid();
            var user = new UserInfo
            {
                IdGuid = guid,
                UserName = "user",
                Email = "user@user",
                Password = "123",
                DisplayName = "USER",
                CreatedDate = DateTime.Now



            };
            _context.Add(user);
            _context.SaveChanges();
        }
    }

}

