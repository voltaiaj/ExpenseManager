using System.Collections.Generic;
using ExpenseManager.Models.Helpers;

namespace ExpenseManager.Models
{
    public class ExpenseSummaryDTO
    {
        public IEnumerable<string> Labels_Categories { get; set; }
        public IEnumerable<decimal> Data_Categories { get; set; }
        public IEnumerable<string> Labels_Tiers { get; set; }
        public IEnumerable<decimal> Data_Tiers { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }

        public IEnumerable<ValueName> Categories
        {
            get { return EnumHelper.GetItems<Categories>(); }
        }
    }
}