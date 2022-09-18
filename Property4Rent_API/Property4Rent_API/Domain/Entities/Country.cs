using Property4Rent.API.Domain.Entities;

namespace Property4Rent.API.Domain.Entities
{
    public class Country: BaseEntity
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool IsPublic { get; set; }
    }
}
