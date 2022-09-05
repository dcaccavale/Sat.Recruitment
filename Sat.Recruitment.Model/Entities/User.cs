using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Model.Entities
{
    public enum UserType
    {
        Normal,
        SuperUser,
        Premium

    }
    public class User : Entity
    {

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public UserType Type { get; set; }
        public decimal Money { get; set; }
    }

}