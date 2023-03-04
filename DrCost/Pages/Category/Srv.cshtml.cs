using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.Category
{
    // Эта страница для сервисного обслуживания перемещения 
    // Эта страница менеджмента категорий
    // Создать новую категорию
    // Создать новый товар
    // Переместиться в категорию id

    public class SrvModel : PageModel
    {
        public void OnGet(int budgid)
        {
            BudgetID = budgid;
        }

        public int BudgetID { get; set; }
    }
}
