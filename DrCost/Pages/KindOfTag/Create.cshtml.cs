using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.KindOfTag
{
    public class CreateModel : PageModel
    {
        private readonly KindOfTagsRepo repo;

        public CreateModel(KindOfTagsRepo repo)
        {
            this.repo = repo;
        }
        public void OnGet()
        {
            KindOfTag = new Models.Stuff.KindOfTag();
        }

        public IActionResult OnPost() 
        {
            repo.Save(KindOfTag);

            return RedirectToPage("/KindOfTag/index");
        }

        [BindProperty]
        public Models.Stuff.KindOfTag? KindOfTag { get; set; }
    }
}
