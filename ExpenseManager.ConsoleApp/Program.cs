using System;
using System.CodeDom;
using System.Linq;
using ExpenseManager.Business;
using ExpenseManager.Business.BusinessLogic;
using ExpenseManager.Business.Services;

namespace ExpenseManager.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var path = "C:\\Users\\Alexander\\Desktop\\Projects\\ExpenseProject.xlsx";
            var path = "F:\\Project\\ExpenseProject.xlsx";
            var readResults = ExpenseReader.ReadExpenses(path);                
            var businessLogic = new ExpenseBusinessLogic(new ExpenseDataService(new ExpenseManagerDbContext()), new TrainingSetDataService(new ExpenseManagerDbContext()));
            var results = businessLogic.Classifier(readResults);
            businessLogic.AddRange(results.Where(x=> x.CategoryId != 0));
            //Console.WriteLine(readResults);
            Console.ReadLine();
        }
    }
}
