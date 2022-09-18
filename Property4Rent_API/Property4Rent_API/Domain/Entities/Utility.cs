namespace Property4Rent.API.Domain.Entities
{
    public class Utility :  BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsPublic { get; set; }
    }
}
