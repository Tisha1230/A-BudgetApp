using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BudApp.ViewModel
{
    public class BudgetManager
    {
        private string BudgetFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "BudgetSetFile.txt");

        public double SaveBudget(double budgetAmount)
        {
            File.WriteAllText(BudgetFileName, budgetAmount.ToString());
            return budgetAmount;
        }

        public double ReadBudget()
        {
            if (File.Exists(BudgetFileName))
            {
                string BudgetFileText = File.ReadAllText(BudgetFileName); //reads the file if exists

                double temp = 0;
                if (double.TryParse(BudgetFileText, out temp))
                //tryparse converts string representation to double value and returns true if conversion succeed and sets temp to the converted value
                {
                    return temp;
                }
            }

            return 0;
        }
    }
}
