using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Model.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public Guid IdGuid { get; set; }
        public TimeSpan CreateTimeSpan { get; set; }
        public TimeSpan UpdatedTimeSpan { get; set; }
        public TimeSpan DeleteTimeSpan { get; set; }
        public StateEntity State { get; set; }

    }
    public enum StateEntity { 
        Created,
        Updated,
        Deleted,
    }
}