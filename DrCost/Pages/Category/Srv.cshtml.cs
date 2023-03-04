using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrCost.Pages.Category
{
    // ��� �������� ��� ���������� ������������ ����������� 
    // ��� �������� ����������� ���������
    // ������� ����� ���������
    // ������� ����� �����
    // ������������� � ��������� id

    public class SrvModel : PageModel
    {
        public void OnGet(int budgid)
        {
            BudgetID = budgid;
        }

        public int BudgetID { get; set; }
    }
}
