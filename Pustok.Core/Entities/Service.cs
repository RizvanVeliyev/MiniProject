namespace Pustok.Core.Entities
{
    public class Service : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string IconUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
