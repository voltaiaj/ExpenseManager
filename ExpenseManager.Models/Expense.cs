using System;

namespace ExpenseManager.Models
{
    public interface IExpense
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        string Name { get; set; }
        decimal Value { get; set; }
        string Description { get; set; }
        int TierId { get; set; }        
        int CategoryId { get; set; }
    }
    public class Expense: IExpense
    {        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int TierId { get; set; }
        public virtual Tier SelectedTier { get; set; }
        public int CategoryId { get; set; }
        public virtual Category SelectedCategory { get; set; }
    }
}
