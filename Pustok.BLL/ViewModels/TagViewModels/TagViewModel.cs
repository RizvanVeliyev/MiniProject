namespace Pustok.BLL.ViewModels.TagViewModels
{

    public class TagViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
