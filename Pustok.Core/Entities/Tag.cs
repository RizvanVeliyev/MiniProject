namespace Pustok.Core.Entities
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<TagProduct>? ProductTags { get; set; }

    }
}
