using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.TagViewModels;

namespace MiniProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class TagsController : AdminController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = (await _tagService.GetAllAsync()).Where(t => !t.IsDeleted).ToList();

            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
               
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(TagCreateViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            await _tagService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")] 

        public async Task<IActionResult> Details(int id)
        {
            var tag= await _tagService.GetAsync(id);
            return View(tag);

        }

        public async Task<IActionResult> Update(int id)
        {
            var vm = await _tagService.GetUpdatedTagAsync(id);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TagUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _tagService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            await _tagService.DeleteAsync(id);



            return RedirectToAction(nameof(Index));
        }
    }
}
