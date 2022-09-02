using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Model
{
    public class User :Entity
    {

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? UserType { get; set; }
        public double  Money { get; set; }
    }
}