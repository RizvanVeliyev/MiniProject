namespace Pustok.Core.Entities
{
    public class ProductImage : BaseEntity
    {

        public string Path { get; set; } = null!;
        public bool IsMain { get; set; } 
        public int ProductId { get; set; }
        public bool isDeleted { get; set; } = false;
        public required Product Product { get; set; }
    }
}
