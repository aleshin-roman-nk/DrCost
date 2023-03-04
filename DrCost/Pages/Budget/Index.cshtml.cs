using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.Budget
{
    public class IndexModel : PageModel
    {
        private readonly BudgetRepo repo;

        public IndexModel(BudgetRepo repo)
        {
            this.repo = repo;
        }

        public void OnGet()
        {
            Budgets = repo.GetBudgets();
        }

        public IEnumerable<Models.Budget>? Budgets { get; set; }
    }
}
