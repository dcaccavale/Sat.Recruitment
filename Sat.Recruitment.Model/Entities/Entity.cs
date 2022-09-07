﻿using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Model.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public Guid IdGuid { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public StateEntity State { get; set; }

    }
    public enum StateEntity { 
        Created,
        Updated,
        Deleted,
    }
}