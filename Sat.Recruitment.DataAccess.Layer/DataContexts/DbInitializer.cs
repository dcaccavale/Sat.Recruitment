

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new SetRecruitmentContext(serviceProvider.GetRequiredService<DbContextOptions<SetRecruitmentContext>>()))
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

        private static void DeleteDataBase(SetRecruitmentContext _context)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.SaveChanges();
        }

        public static void InitDataBase(SetRecruitmentContext _context)
        {
            DeleteDataBase(_context);
            Seed(_context);

        }
        public static void Seed(SetRecruitmentContext _context)
        {
         
        }

    }
}
