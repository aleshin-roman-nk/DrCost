using DrCost.Models;
using DrCost.Services;
using DrCost.ViewDataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace DrCost.Pages.Budget
{
    public class DetailModel : PageModel
    {
        private readonly MonthBudgetInstanceRepo r;

        public DetailModel(MonthBudgetInstanceRepo r)
        {
            this.r = r;
        }

        public IActionResult OnPost(int budgetid, int year, int month)
        {
            return RedirectToPage("/budget/detail", new { budgetid = budgetid, year = year, month = month });
        }

        public void OnGet(int budgetid, int year, int month)
        {
            var reqDate = new DateTime(year, month, 1);

            var today = DateTime.Today;
            int dayCount = DateTime.DaysInMonth(reqDate.Year, reqDate.Month);

            bool isThisMonth = today.Year == reqDate.Year && today.Month == reqDate.Month;

            BudgetInst = r.Get(budgetid, reqDate.Year, reqDate.Month);

            BudgetInst.Year = year;
            BudgetInst.Month = month;

            MonthSpent = BudgetInst.Items.Sum(x => x.Total);
            MoneyPerDay = BudgetInst.AllotedSum / dayCount;
            if (isThisMonth)
                MoneyPerDayAfterToday = (BudgetInst.AllotedSum - MonthSpent) / (dayCount - today.Day + 1);
            else
                MoneyPerDayAfterToday = MoneyPerDay;

            Calendar = Enumerable.Range(1, dayCount)
                .Select(x => new DayBallance
                {
                    Date = new DateTime(reqDate.Year, reqDate.Month, x),
                    Spent = BudgetInst.Items.Where(xd => xd.Date.Day == x).Sum(x => x.Total)
                    //Spent = BudgetInst.Items.Where(xd => xd.Date.Day == x).Sum(x => x.TotalInRub),
                }).ToList();

            foreach (var tday in Calendar)
            {
                if (isThisMonth)
                {
                    if (tday.Date.Day < today.Day)
                    {
                        tday.Allowed = MoneyPerDay;
                        tday.isPastOrPresent= true;
                        tday.isToday = false;
                    }
                    else if (tday.Date.Day == today.Day)
                    {
                        tday.isToday = true;
                        tday.Allowed = MoneyPerDay;
                        tday.isPastOrPresent = true;
                    }
                    else
                    {
                        tday.Allowed = MoneyPerDayAfterToday;
                        tday.isPastOrPresent = false;
                        tday.isToday = false;
                    }
                }
                else
                {
                    tday.Allowed = MoneyPerDay;
                    tday.isPastOrPresent = true;
                    tday.isToday = false;
                }
            }
        }

        public decimal MonthSpent { get; set; }
        public MonthBudgetInstance BudgetInst { get; set; }
        public decimal MoneyPerDay { get; set; }
        public decimal MoneyPerDayAfterToday { get; set; }
        public List<DayBallance> Calendar { get; set; }
    }
}
