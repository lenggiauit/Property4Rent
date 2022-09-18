using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property4Rent.API.Domain.Entities
{
    public class PropertyPhoto: BaseEntity
    {
        [ForeignKey("Property")]
        public Guid PropertyId { get; set; }
        public string Url { get; set; }
    }
}
