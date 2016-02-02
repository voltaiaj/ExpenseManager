using System;
using System.CodeDom;
using ExpenseManager.Business;
using ExpenseManager.Business.BusinessLogic;
using ExpenseManager.Business.Services;

namespace ExpenseManager.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\Alexander\\Desktop\\ExpenseProject.xlsx";
            var readResults = ExpenseReader.ReadExpenses(path);
            var context = new ExpenseManagerDbContext();
            var businessLogic = new ExpenseBusinessLogic(new ExpenseDataService(context), new TrainingSetDataService(context));
            var results = businessLogic.Classifier(readResults);
            Console.WriteLine(readResults);
            Console.ReadLine();
        }
    }
}
