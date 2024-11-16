 namespace Pustok.Core.Entities
{
    public class Setting : BaseEntity
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public required string ContactNumber { get; set; }
    }
}
