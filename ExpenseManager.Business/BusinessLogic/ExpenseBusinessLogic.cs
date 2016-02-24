using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ExpenseManager.Business.Services;
using ExpenseManager.Models;

namespace ExpenseManager.Business.BusinessLogic
{
    public interface IExpenseBusinessLogic
    {
        void Add(Expense expense);
        void Update(Expense expense);
        void Remove(Expense expense);
        bool DoesExpenseAlreadyExists(Expense expense);        
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
            ExpenseDataService.Add(expense);
            ExpenseDataService.SaveChanges();
        }

        public void AddRange(IEnumerable<Expense> expenses)
        {

            this.ExpenseDataService.AddRange(expenses);
            this.ExpenseDataService.SaveChanges();
        }

        public void Update(Expense model)
        {
            var targetExpense = ExpenseDataService.GetExpenseById(model.Id);
            MapForEdit(targetExpense, model);
            ExpenseDataService.SaveChanges();
        }

        public void Remove(Expense expense)
        {
            ExpenseDataService.Remove(expense);
        }

        public bool DoesExpenseAlreadyExists(Expense expense)
        {
            return this.ExpenseDataService.Exists(x => x.Description == expense.Description && x.Value == expense.Value && x.Date == expense.Date);
        }

        public IEnumerable<Expense> Classifier(IEnumerable<string[]> expenses)
        {
            var result = new List<Expense>();
            var trainingSets = TrainingSetDataService.GetAllTrainingSets().ToList();
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
                expense.TierId = _tierFinder(expense.CategoryId);
                result.Add(expense);
            }
            return result;
        }

        private static void MapForEdit(Expense target, Expense model)
        {
            target.Value = model.Value;
            target.Name = model.Name;
            target.Description = model.Description;
            target.CategoryId = model.CategoryId;
            target.TierId = model.TierId;
        }

        private readonly Func<TrainingSet, Expense, bool> _function = (x, y) =>
        {
            var descriptionWords = y.Description.Split(' ');
            return descriptionWords.Any(word => x.Keywords.Contains(word) == true);
        };

        private readonly Func<int, int> _tierFinder = (x) =>
        {
            if (x > 0 && x < 14)
            {
                return (int) Tiers.MonthToMonth;
            }
            if (x == 14 || x == 15)
            {
                return (int) Tiers.Food;
            }    
                    
            return (int) Tiers.UniqueExpenses;            
        };

        private IExpenseDataService ExpenseDataService { get; set; }
        private ITrainingSetDataService TrainingSetDataService { get; set; }
    }
}
