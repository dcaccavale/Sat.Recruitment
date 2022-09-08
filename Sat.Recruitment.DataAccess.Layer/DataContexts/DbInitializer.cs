

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new SatRecruitmentContext(serviceProvider.GetRequiredService<DbContextOptions<SatRecruitmentContext>>()))
            {
                InitDataBase(_context);

            }
        }

        private static void DeleteDataBase(SatRecruitmentContext _context)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.SaveChanges();
        }

        public static void InitDataBase(SatRecruitmentContext _context, int countRecordToAdd = 0)
        {
            DeleteDataBase(_context);
            Seed(_context, countRecordToAdd);

        }
        public static void Seed(SatRecruitmentContext _context, int countRecordToAdd)
        {
            if (countRecordToAdd > 0)
            {
                Random random = new Random();
                List<User> listUSer = new List<User>();
                for (int i = 0; i < countRecordToAdd; i++)
                {
                    var guid = Guid.NewGuid();

                    listUSer.Add(new User
                    {
                        IdGuid = guid,
                        Name = "prueba" + guid.ToString(),
                        Email = guid + "prueba@gmail.com",
                        Address = guid + "calle charles 855",
                        Phone = guid + "5255555555",
                        Type = UserType.Normal,
                        Money = random.Next(random.Next(0, 200)),
                    });
                }
                _context.AddRange(listUSer);
                _context.SaveChanges();
            }
        }

    }
}
