
namespace ExpenseManager.Models
{
    public enum Categories
    {
        //MonthToMonth
        Gym = 1,
        Mortgage = 2,
        CarInsurance = 3,
        SatelliteTv = 4,
        CellPhone = 5,
        Internet = 6,
        Spotify = 7,
        GasForHome = 8,
        Electricity = 9,
        Water = 10,
        HomeSecurity = 11,
        IdentityGuard = 12,
        Landscaping = 13,
        //Food  
        Groceries = 14,
        FastFood = 15,
        //UniqueExpenses
        Entertainment = 16,
        Services = 17,
        AnnualRenewals = 18
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TierId { get; set; }
        public Tier SelectedTier { get; set; }  

    }
}
