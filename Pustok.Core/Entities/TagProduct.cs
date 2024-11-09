namespace Pustok.Core.Entities
{
    public class TagProduct : BaseEntity
    {
        public int TagId { get; set; }
        public required Tag Tag { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
    }
}
