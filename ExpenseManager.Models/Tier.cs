
namespace ExpenseManager.Models
{
    public enum Tiers
    {
        MonthToMonth = 1,
        Food = 2,
        UniqueExpenses = 3
    }

    public class Tier
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
