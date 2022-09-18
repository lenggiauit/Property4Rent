using Property4Rent.API.Domain.Entities;
using System;

namespace Property4Rent.API.Domain.Entities
{
    public class State: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string IsPublic { get; set; }

    }
}
