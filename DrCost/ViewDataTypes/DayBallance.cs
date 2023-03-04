namespace DrCost.ViewDataTypes
{
    public class DayBallance
    {
        public decimal Allowed { get; set; }
        public decimal Spent { get; set; }
        public DateTime Date { get; set; }
        public bool isPastOrPresent { get; set; }
        public bool isToday { get; set; }
    }
}
