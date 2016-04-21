using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.TestDoubles
{
    public class FakeExpenseManagerContext : IExpenseManagerDbContext
    {        
        public FakeExpenseManagerContext()
        {
            this.Expenses = new FakeDbSet<Expense>();
            this.TrainingSets = new FakeDbSet<TrainingSet>();    
            this.Tiers = new FakeDbSet<Tier>();
            this.Categories = new FakeDbSet<Category>();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public IDbSet<Expense> Expenses { get; set; }
        public IDbSet<TrainingSet> TrainingSets { get; set; } 
        public IDbSet<Tier> Tiers { get; set; }
        public IDbSet<Category> Categories { get; set; } 
    }
}
