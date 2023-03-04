using DrCost.Services;

namespace DrCost
{
    public class AppSystemProperties: IAppSystemProperties
    {
        public string DbPath => @"..\db\budgets.sqlite";
    }
}
