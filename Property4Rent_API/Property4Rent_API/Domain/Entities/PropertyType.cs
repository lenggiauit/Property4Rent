namespace Property4Rent.API.Domain.Entities
{
    public class PropertyType : BaseEntity
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
    }
}
