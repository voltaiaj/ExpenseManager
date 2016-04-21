using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using ExpenseManager.Business.Services;
using ExpenseManager.Models;

namespace ExpenseManager.Business.BusinessLogic
{
    public interface IExpenseBusinessLogic
    {
        void Add(Expense expense);
        void AddRange(IEnumerable<Expense> expenses);
        void Update(Expense expense);
        void Remove(int expenseId);
        bool DoesExpenseAlreadyExists(Expense expense);
        IEnumerable<Expense> Classifier(IEnumerable<string[]> expenses);
        ExpenseSummaryDTO GetExpenseSummaryFromExpenses(IEnumerable<Expense> expenses);
    }

    public class ExpenseBusinessLogic: IExpenseBusinessLogic
    {
        public ExpenseBusinessLogic(IExpenseDataService expenseDataService, ITrainingSetDataService trainingSetDataService)
        {
            this.ExpenseDataService = expenseDataService;
            this.TrainingSetDataService = trainingSetDataService;
        }

        public void Add(Expense expense)
        {
            this.ExpenseDataService.Add(expense);
            this.ExpenseDataService.SaveChanges();            
        }

        public void AddRange(IEnumerable<Expense> expenses)
        {
            this.ExpenseDataService.AddRange(expenses);
            this.ExpenseDataService.SaveChanges();
        }

        public void Update(Expense model)
        {
            var targetExpense = this.ExpenseDataService.GetExpenseById(model.Id);
            MapForEdit(targetExpense, model);
            this.ExpenseDataService.SaveChanges();
        }

        public void Remove(int expenseId)
        {
            var expense = this.ExpenseDataService.GetExpenseById(expenseId);
            this.ExpenseDataService.Remove(expense);
        }

        public bool DoesExpenseAlreadyExists(Expense expense)
        {
            return this.ExpenseDataService.Exists(x => x.Description == expense.Description && x.Value == expense.Value && x.Date == expense.Date);
        }

        public IEnumerable<Expense> Classifier(IEnumerable<string[]> expenses)
        {
            var result = new List<Expense>();
            var trainingSets = this.TrainingSetDataService.GetAllTrainingSets().ToList();
            foreach (var entry in expenses)
            {
                var date = String.Concat(entry[0].Trim(), " 00:00:00:AM");
                if (string.IsNullOrWhiteSpace(entry[2]))
                {
                    continue;
                }
                var expense = new Expense()
                {
                    Date = DateTime.ParseExact(date, "MM/dd/yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                    Description = entry[1],
                    Value = Decimal.Parse(entry[2].TrimStart('$').Trim())
                };

                
                var trainingSet = (trainingSets.Any()) ? trainingSets.FirstOrDefault(x => _function(x, expense)) : null;

                expense.CategoryId = trainingSet == null ? 0 : trainingSet.CategoryId;
                expense.TierId = this.tierFinder(expense.CategoryId);
                result.Add(expense);
            }
            return result;
        }

        private void MapForEdit(Expense target, Expense model)
        {
            target.Value = model.Value;
            target.Name = model.Name;
            target.Description = model.Description;
            target.CategoryId = model.CategoryId;
            target.TierId = tierFinder(model.CategoryId);
        }

        private readonly Func<TrainingSet, Expense, bool> _function = (x, y) =>
        {
            var descriptionWords = y.Description.Split(' ');
            return descriptionWords.Any(word => x.Keywords.Contains(word) == true);
        };

        private readonly Func<int, int> tierFinder = (x) =>
        {
            if (x >= (int)Categories.Gym && x < (int)Categories.Groceries)
            {
                return (int) Tiers.MonthToMonth;
            }
            if (x == (int)Categories.Groceries || x == (int)Categories.FastFood)
            {
                return (int) Tiers.Food;
            }    
                    
            return (int) Tiers.UniqueExpenses;            
        };

        /// <summary>
        /// GetExpenseSummaryFromExpenses takes in  a collection of expenses
        /// and returns an ExpenseSummaryDTO of the expenses.
        /// </summary>
        /// <param name="expenses"></param>
        /// <returns></returns>
        public ExpenseSummaryDTO GetExpenseSummaryFromExpenses(IEnumerable<Expense> expenses)
        {
            var listOfCategoryValues = new List<decimal> {}; 
            var listOfCategoryLabels = new List<string>();
            var listOfTierLabels = new List<string>();
            var listOfTierValues = new List<decimal>();

            var categories = expenses.GroupBy<Expense, int>(x => x.CategoryId).Select( x => x.Key).ToList();
            var tiers = expenses.GroupBy<Expense, int>(x => x.TierId).Select(x => x.Key).ToList();

            var numberOfCategories = categories.Count();
            var numberOfTiers = tiers.Count();

            //start a loop based on number of catgegories
            for (int i = 0; i < numberOfCategories; i++)
            {
                var categorySpecificExpenses = expenses.Where(x => x.CategoryId == categories.ElementAt(i));
                listOfCategoryValues.Add(categorySpecificExpenses.Sum(x => x.Value));
                listOfCategoryLabels.Add(Enum.GetName(typeof (Categories), categories.ElementAt(i)));
            }

            //start a loop based on the number of tiers
            for (int i = 0; i < numberOfTiers; i++)
            {
                var tierSpecificExpenses = expenses.Where(x => x.TierId == tiers.ElementAt(i));
                listOfTierValues.Add(tierSpecificExpenses.Sum(x=> x.Value));
                listOfTierLabels.Add(Enum.GetName(typeof(Tiers), tiers.ElementAt(i)));
            }

            return new ExpenseSummaryDTO
                    {
                        Labels_Categories = listOfCategoryLabels,
                        Data_Categories = listOfCategoryValues,
                        Labels_Tiers = listOfTierLabels,
                        Data_Tiers = listOfTierValues,
                        Expenses = expenses
                    };
        }        

        private IExpenseDataService ExpenseDataService { get; set; }
        private ITrainingSetDataService TrainingSetDataService { get; set; }       
    }
}
