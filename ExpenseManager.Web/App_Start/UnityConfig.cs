using System.Web.Mvc;
using ExpenseManager.Business;
using ExpenseManager.Business.BusinessLogic;
using ExpenseManager.Business.Services;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace ExpenseManager.Web.App_Start
{
    public  static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IExpenseBusinessLogic, ExpenseBusinessLogic>()
                     .RegisterType<IExpenseDataService, ExpenseDataService>()
                     .RegisterType<ITrainingSetDataService, TrainingSetDataService>()
                     .RegisterType<IExpenseManagerDbContext, ExpenseManagerDbContext>()
                     ;
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));            
        }

    }
}