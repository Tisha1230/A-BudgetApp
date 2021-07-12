using System;
using System.Collections.Generic;
using System.Text;

namespace BudApp.Model
{
    public class Expense
    {
        
        public string Description { get; set; }
        public double AmountSpent { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public string CategoryImage { get; set; }
    }
}
