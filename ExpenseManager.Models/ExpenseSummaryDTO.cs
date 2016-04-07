using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class ExpenseSummaryDTO
    {
        public IEnumerable<string> Labels_Categories { get; set; }
        public IEnumerable<decimal> Data_Categories { get; set; }         
        public IEnumerable<string> Labels_Tiers { get; set; } 
        public IEnumerable<decimal> Data_Tiers { get; set; } 
        public IEnumerable<Expense> Expenses { get; set; }  
    }
}
