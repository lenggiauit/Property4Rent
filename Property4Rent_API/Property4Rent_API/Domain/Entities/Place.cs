using System.Collections.Generic;

namespace Property4Rent.API.Domain.Entities
{
    public class Place: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string Icon { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsPublic { get; set; }
        public virtual ICollection<PlacePhoto> Photos { get; set; }
    }
}
