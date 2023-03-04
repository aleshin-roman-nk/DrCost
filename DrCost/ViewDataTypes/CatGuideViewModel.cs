using DrCost.Models.Stuff;

namespace DrCost.ViewDataTypes
{
    public class CatGuideViewModel
    {
        public Category? Current { get; set; }
        public IEnumerable<Category>? Children { get; set; }
        public IEnumerable<Category>? Parents { get; set; }
    }
}
