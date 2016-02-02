using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class TrainingSet
    {
        public int Id { get; set; }
        public string Keywords { get; set; }
        public int CategoryId { get; set; }
        public Category SelectedCategory { get; set; }
     }
}
