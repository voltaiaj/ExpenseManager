using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpenseManager.Business.DataAccess;
using ExpenseManager.Models;

namespace ExpenseManager.Business.Services
{
    public interface ITrainingSetDataService
    {
        IEnumerable<TrainingSet> GetAllTrainingSets();
        TrainingSet GetTrainingSetById(int id);
        IEnumerable<TrainingSet> GetTrainingSetsByCategoryId(int categoryId);
        TrainingSet Add(TrainingSet trainingSet);
        TrainingSet Remove(TrainingSet trainingSet);
        int SaveChanges();
        bool Exists(Expression<Func<TrainingSet, bool>> expression);
    }

    public class TrainingSetDataService : DataServiceBase<TrainingSet>, ITrainingSetDataService
    {
        public TrainingSetDataService(IExpenseManagerDbContext context)
            : base(new ExpenseManagerUnitOfWorkAdapter(context), context.TrainingSets)
        {
            this.Context = context;
        }

        private IExpenseManagerDbContext Context { get; set; }

        public IEnumerable<TrainingSet> GetAllTrainingSets()
        {
            return this.Context.TrainingSets;
        }

        public TrainingSet GetTrainingSetById(int id)
        {
            return this.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<TrainingSet> GetTrainingSetsByCategoryId(int categoryId)
        {
            return this.Find(x => x.CategoryId == categoryId);  
        }

        
    }
}
