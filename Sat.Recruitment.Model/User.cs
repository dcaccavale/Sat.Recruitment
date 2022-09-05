using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Model
{
   public  enum UserType
    {
        Normal,
        SuperUser,
        Premium

    }
    public class User :Entity
    {
        [Required,MinLength(3), RegularExpression("/^[A-Za-z]+$/")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        [Required]
        public UserType Type { get; set; }
        [Required]
        public double  Money { get; set; }
    }

}