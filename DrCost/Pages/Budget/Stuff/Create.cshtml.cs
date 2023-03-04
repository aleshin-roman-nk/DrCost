using DrCost.Models.Stuff;
using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrCost.Pages.Budget.Stuff
{
    public class CreateModel : PageModel
    {
        private readonly AppSettingsRepo appSettings;
        private readonly StuffRepo repo;
        private readonly KindOfTagsRepo tags;

        public CreateModel(AppSettingsRepo appSettings, StuffRepo repo, KindOfTagsRepo tags) 
        {
            this.appSettings = appSettings;
            this.repo = repo;
            this.tags = tags;
        }

        public void OnGet(int budgetId, string dt)
        {
            DateTime d = DateTime.Parse(dt);

            Item = new StuffItem { budgetId = budgetId, Date = d };

            Item.currencyName = appSettings.GetString("currency_name");
            currencyPriceInRub = appSettings.GetDecimal("currency_value").ToString().Replace(',', '.');
            count = 1.ToString();

            Tags = tags.Get().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList();
        }

        public IActionResult OnPost()
        {
            Item.currencyPriceInRub = decimal.Parse(currencyPriceInRub.Replace('.', ','));
            Item.count = decimal.Parse(count.Replace('.',','));
            Item.price = decimal.Parse(price.Replace('.',','));
            repo.Save(Item);

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
        public List<SelectListItem> Tags { get; set; }
    }
}
