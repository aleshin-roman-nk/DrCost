using DrCost.Models.Stuff;
using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.Budget
{
    public class spendingModel : PageModel
    {
        private readonly StuffRepo repo;

        public spendingModel(StuffRepo repo)
        {
            this.repo = repo;
        }
        public void OnGet(int budgetId, string date)
        {
            Idate = date;
            d = DateTime.Parse(date);
            this.budgetId = budgetId;

            Stuffs = repo.GetItems(this.budgetId, d);
        }

        public string? Idate { get; set; }
        public DateTime d { get; set; }
        public int budgetId { get; set; }
        public IEnumerable<StuffItem> Stuffs { get; set; }
    }
}
