using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.Budget
{
    public class CreateModel : PageModel
    {
        private readonly BudgetRepo repo;

        public CreateModel(BudgetRepo repo) 
        {
            this.repo = repo;
        }
        public void OnGet()
        {
            Budget = new Models.Budget { HasCalendar = true };
        }

        public IActionResult OnPost()
        {
            if(string.IsNullOrEmpty(Budget.Name))
            {
                msg = "Name should not be empty";
                return Page();
            }

            repo.Save(Budget);

            return RedirectToPage("/budget/index");
        }

        [BindProperty]
        public Models.Budget Budget { get; set; }
        public string msg { get; set; }
    }
}
