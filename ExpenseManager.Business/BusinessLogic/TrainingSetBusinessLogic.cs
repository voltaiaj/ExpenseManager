using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Business.Services;
using ExpenseManager.Models;

namespace ExpenseManager.Business.BusinessLogic
{
    public class TrainingSetBusinessLogic
    {
        public TrainingSetBusinessLogic(ITrainingSetDataService trainingSetDataService)
        {
            this.TrainingSetDataService = trainingSetDataService;
        }

        public void Add(TrainingSet trainingSet)
        {
            this.TrainingSetDataService.Add(trainingSet);
        }

        public void Update(TrainingSet model)
        {
            var targetTrainingSet = this.TrainingSetDataService.GetTrainingSetById(model.Id);
            MapForEdit(targetTrainingSet, model);
            this.TrainingSetDataService.SaveChanges();
        }

        public void Remove(TrainingSet trainingSet)
        {
            this.TrainingSetDataService.Remove(trainingSet);
        }


        private static void MapForEdit(TrainingSet target, TrainingSet model)
        {
            target.CategoryId = model.CategoryId;
            target.Keywords = model.Keywords;
        }

        private ITrainingSetDataService TrainingSetDataService { get; set; }
    }
}
