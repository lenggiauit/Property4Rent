using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property4Rent.API.Domain.Entities
{
    public class PlacePhoto: BaseEntity
    {
        [ForeignKey("Place")]
        public Guid PlaceId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Photo_reference { get; set; }
        public bool IsPublic {get; set; }
    }
}
