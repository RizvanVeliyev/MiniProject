namespace Pustok.Core.Entities
{
    public class Slider : BaseEntity
    {
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public required string ImageUrl { get; set; }
        public bool isDeleted { get; set; } = false;

    }
}
