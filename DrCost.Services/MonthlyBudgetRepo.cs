using DrCost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Services
{
    public class MonthBudgetInstanceRepo : RepoBase
    {
        public MonthBudgetInstanceRepo(IAppDbFactory dbFactory) : base(dbFactory)
        {
        }

        public MonthBudgetInstance Get(int budgetId, int year, int month)
        { 
            DateTime dt1 = new DateTime(year, month, 1, 0, 0, 0);
            int days = DateTime.DaysInMonth(year, month);
            DateTime dt2 = dt1.AddDays(days);

            using (var db = dbFactory.Create())
            {
                var res = db.Budgets.Where(x => x.Id == budgetId)
                    .Select(x => 
                    new MonthBudgetInstance { 
                        BudgetId = x.Id, 
                        BudgetName = x.Name,
                        AllotedSum = x.DefaultMoney,
                        HasCalendar= x.HasCalendar
                    }).FirstOrDefault();

                res.Items = db.StuffItems.Where(x => x.budgetId == budgetId && (x.Date >= dt1 && x.Date < dt2)).ToArray();

                // !!! переменная в бд появляется только тогда, когда потребовалось сохранить индивидуальную
                var propr = db.MonthlyBudgetProperties
                    .FirstOrDefault(x => x.name.Equals("month-money") && x.budgetId == budgetId && x.Year == year && x.Month == month);


                if (propr != null)
                    res.AllotedSum = decimal.Parse(propr.value);

                return res;
            }
        }
    }
}
