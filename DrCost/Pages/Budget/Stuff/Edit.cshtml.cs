using DrCost.Models.Stuff;
using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.Budget.Stuff
{
    public class EditModel : PageModel
    {
        private readonly StuffRepo repo;

        public EditModel(StuffRepo repo)
        {
            this.repo = repo;
        }

        public void OnGet(int stuffId)
        {
            Item = repo.Get(stuffId);
            currencyPriceInRub = Item.currencyPriceInRub.ToString().Replace(',', '.');
            price = Item.price.ToString().Replace(',', '.');
            count = Item.count.ToString().Replace(',', '.');
        }

        public IActionResult OnPost()
        {
            Item.currencyPriceInRub = decimal.Parse(currencyPriceInRub.Replace('.', ','));
            Item.price = decimal.Parse(price.Replace('.', ','));
            Item.count = decimal.Parse(count.Replace('.', ','));
            repo.Save(Item);

            return RedirectToPage("/budget/spending", new { budgetid = Item.budgetId, date = Item.Date.ToShortDateString() });
        }

        public IActionResult OnPostDelete()
        {
            repo.Delete(Item);
            return RedirectToPage("/budget/spending", new { budgetid = Item.budgetId, date = Item.Date.ToShortDateString() });
        }

        [BindProperty]
        public StuffItem? Item { get; set; }
        [BindProperty]
        public string currencyPriceInRub { get; set; }
        [BindProperty]
        public string price { get; set; }
        [BindProperty]
        public string count { get; set; }
    }
}
