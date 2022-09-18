using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property4Rent.API.Domain.Entities
{
    public class Property: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public bool IsAvailable { get; set; } 
        public DateTime AvailableDatte { get; set; }
        public virtual ICollection<PropertyPhoto> Photos { get; set; }
        public virtual ICollection<PropertyUtilities> PropertyUtilities { get; set; }
        [NotMapped]
        public virtual ICollection<Place> PropertyNearBy { get; set; }
        [ForeignKey("City")]
        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        [ForeignKey("PropertyType")]
        public Guid PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }
    }
}
