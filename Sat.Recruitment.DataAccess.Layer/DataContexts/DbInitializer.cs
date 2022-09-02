

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Sat.Recruitment.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new SatRecruitmentContext(serviceProvider.GetRequiredService<DbContextOptions<SatRecruitmentContext>>()))
            {
                // Agregando  a la BD
              //  DeleteDataBase(_context);
                //Seed(_context);
                if (_context.Users.Any())
                {
                    return;
                }
                //  Seed(_context);

            }
        }

        private static void DeleteDataBase(SatRecruitmentContext _context)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.SaveChanges();
        }

        public static void InitDataBase(SatRecruitmentContext _context)
        {
            DeleteDataBase(_context);
            Seed(_context);

        }
        public static void Seed(SatRecruitmentContext _context)
        {
         
        }

    }
}
