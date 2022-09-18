using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property4Rent.API.Domain.Entities
{
    public class PropertyUtilities :  BaseEntity
    {
        [ForeignKey("Property, PropertyId"), Column(Order = 0)]
        public Guid PropertyId { get; set; }
        public virtual Property Property { get; set; }

        [ForeignKey("Utility, UtilityId"), Column(Order = 1)]
        public Guid UtilityId { get; set; }
        public virtual Utility  Utility { get; set; }

    }
}
