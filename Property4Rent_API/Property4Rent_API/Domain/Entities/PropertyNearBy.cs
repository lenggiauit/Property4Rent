using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property4Rent.API.Domain.Entities
{
    public class PropertyNearBy : BaseEntity
    {
        [ForeignKey("Place, PlaceId"), Column(Order = 0)]
        public Guid PlaceId { get; set; }
        public virtual Place Place { get; set; }

        [ForeignKey("Property, PropertyId"), Column(Order = 1)]
        public Guid PropertyId { get; set; }
        public virtual Property Property { get; set; }

    }
}
