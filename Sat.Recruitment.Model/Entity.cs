using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Model
{
    public  class Entity
    {
        [Key]
        public int Id { get; set; }
        public Guid IdGuid { get; set; }
    }
}