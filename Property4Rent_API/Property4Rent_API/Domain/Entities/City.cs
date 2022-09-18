using System;

namespace Property4Rent.API.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public bool IsPublic { get; set; }
        public Guid StateId { get; set; }
        public virtual State State { get; set; }

    }
}
