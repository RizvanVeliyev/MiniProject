namespace Pustok.Core.Entities
{
    public class Subscribe : BaseEntity
    {
        public required string Email { get; set; }
        public bool IsSubscribed { get; set; } = true;

        public bool isDeleted { get; set; } = false;
    }
}
