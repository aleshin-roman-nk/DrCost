using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.Budget
{
    public class EditModel : PageModel
    {
        private readonly BudgetRepo repo;

        public EditModel(BudgetRepo repo)
        {
            this.repo = repo;
        }

        public void OnGet(int budgetid)
        {
            Budget = repo.GetBudget(budgetid);
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Budget.Name))
            {
                msg = "Name should not be empty";
                return Page();
            }

            repo.Save(Budget);

            var dt = DateTime.Today;

            return RedirectToPage("/budget/detail", new { budgetid = Budget.Id, year = dt.Year, month = dt.Month});
        }

        public IActionResult OnGetDelete(int budgetid)
        {
            repo.Delete(new Models.Budget { Id = budgetid});
            return RedirectToPage("/budget/index");
        }

        [BindProperty]
        public Models.Budget Budget { get; set; }
        public string msg { get; set; }
    }
}
