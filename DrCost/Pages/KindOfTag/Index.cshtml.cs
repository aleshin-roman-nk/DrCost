using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.KindOfTag
{
    public class IndexModel : PageModel
    {
        private readonly KindOfTagsRepo repo;

        public IndexModel(KindOfTagsRepo repo)
        {
            this.repo = repo;
        }

        public void OnGet()
        {
            Tags = repo.Get();
        }

        public IEnumerable<Models.Stuff.KindOfTag> Tags { get; set; }
    }
}
