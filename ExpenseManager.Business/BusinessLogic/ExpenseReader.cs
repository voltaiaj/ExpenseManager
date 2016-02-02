using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Business.Services;
using ExpenseManager.Models;
using Microsoft.Office.Interop.Excel;

namespace ExpenseManager.Business.BusinessLogic
{
    public static class ExpenseReader
    {
        public static IEnumerable<string[]> ReadExpenses(string path)
        {
            var result = new List<string[]>();
            var app = new Application();
            app.Workbooks.Open(path);
            var row = 1;
            while (!string.IsNullOrEmpty(app.Cells[row, 1].Value))
            {
                var entry = new string[]
                {
                    app.Cells[row, 1].Value,
                    app.Cells[row, 3].Value,
                    app.Cells[row, 4].Value,
                };
                Console.WriteLine("{0} -- {1} -- {2}", entry[0], entry[1], entry[2]);
                result.Add(entry);
                row++;
            }            
            return result;
        }
    }
}
