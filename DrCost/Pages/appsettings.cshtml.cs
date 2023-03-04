using DrCost.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages
{
    public class appsettingsModel : PageModel
    {
        private readonly AppSettingsRepo appSettingsRepo;

        public appsettingsModel(AppSettingsRepo appSettingsRepo)
        {
            this.appSettingsRepo = appSettingsRepo;
        }

        public void OnGet()
        {
            CurrencyValue = appSettingsRepo.GetDecimal("currency_value").ToString();
            CurrencyName = appSettingsRepo.GetString("currency_name");
        }

        public IActionResult OnPostUpdateCurrencyValue()
        {
            CurrencyValue = CurrencyValue.Replace('.', ',');
            appSettingsRepo.Set("currency_value", CurrencyValue.ToString());
            return RedirectToPage("/appsettings");
        }

        public IActionResult OnPostUpdateCurrencyName()
        {
            appSettingsRepo.Set("currency_name", CurrencyName);
            return RedirectToPage("/appsettings");
        }

        [BindProperty]
        public string CurrencyValue { get; set; }
        [BindProperty]
        public string CurrencyName { get; set; }
    }
}
