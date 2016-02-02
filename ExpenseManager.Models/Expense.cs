using System;

namespace ExpenseManager.Models
{
    public class Expense
    {        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public int TierId { get; set; }
        public Tier SelectedTier { get; set; }
        public int CategoryId { get; set; }
        public Category SelectedCategory { get; set; }
    }
}
