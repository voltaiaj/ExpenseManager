using ExpenseManager.Models;
using System.Data.Entity;

namespace ExpenseManager.Business
{
    public interface IExpenseManagerDbContext
    {
        int SaveChanges();
        IDbSet<Expense> Expenses { get; set; }
        IDbSet<TrainingSet> TrainingSets { get; set; }
        IDbSet<Tier> Tiers { get; set; }
        IDbSet<Category> Categories { get; set; }
    }

    public class ExpenseManagerDbContext : DbContext, IExpenseManagerDbContext
    {
        public ExpenseManagerDbContext()
            : base("name=ExpenseManager")
        {
        }

        private const string AppSchemaName = "ExpenseManager";

        public IDbSet<Expense> Expenses { get; set; }
        public IDbSet<TrainingSet> TrainingSets { get; set; }
        public IDbSet<Tier> Tiers { get; set; }
        public IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ExpenseManagerDbContext>(null);

            #region "Category"

            modelBuilder.Entity<Category>().ToTable("Category", schemaName: AppSchemaName);
            modelBuilder.Entity<Category>().HasKey(category => category.Id)
                        .HasRequired(category => category.SelectedTier)
                        .WithMany()
                        .HasForeignKey(category => category.TierId);            
            #endregion

            #region "Expense"

            modelBuilder.Entity<Expense>().ToTable("Expense", schemaName: AppSchemaName);
            modelBuilder.Entity<Expense>().HasKey(expense => expense.Id)
                        .HasRequired(expense => expense.SelectedTier)
                        .WithMany()
                        .HasForeignKey(expense => expense.TierId);
            modelBuilder.Entity<Expense>().HasRequired(expense => expense.SelectedCategory)
                        .WithMany()
                        .HasForeignKey(expense => expense.CategoryId);
            #endregion

            #region "Tier"

            modelBuilder.Entity<Tier>().ToTable("Tier", schemaName: AppSchemaName);
            modelBuilder.Entity<Tier>().HasKey(tier => tier.Id);                
            #endregion

            #region "TrainingSet"

            modelBuilder.Entity<TrainingSet>().ToTable("TrainingSet", schemaName: AppSchemaName);
            modelBuilder.Entity<TrainingSet>().HasKey(trainingSet => trainingSet.Id)
                        .HasRequired(trainingSet => trainingSet.SelectedCategory)
                        .WithMany()
                        .HasForeignKey(trainingSet => trainingSet.CategoryId);
            #endregion


            base.OnModelCreating(modelBuilder);
        }        
    }

}
