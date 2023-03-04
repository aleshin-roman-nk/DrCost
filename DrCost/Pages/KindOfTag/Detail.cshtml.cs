using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.KindOfTag
{
    public class DetailModel : PageModel
    {
        private readonly KindOfTagsRepo repo;

        public DetailModel(KindOfTagsRepo repo)
        {
            this.repo = repo;
        }

        public void OnGet(int id)
        {
            KindOfTag = repo.Get(id);
        }

        public IActionResult OnPost()
        {
            repo.Save(KindOfTag);
            return RedirectToPage("/KindOfTag/index");
        }

        public IActionResult OnPostDelete()
        {
            repo.Delete(KindOfTag);
            return RedirectToPage("/KindOfTag/index");
        }

        [BindProperty]
        public Models.Stuff.KindOfTag? KindOfTag { get; set; }
    }
}
