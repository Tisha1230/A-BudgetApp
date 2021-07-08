using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using BudApp.Model;
using Newtonsoft.Json;

namespace BudApp
{
    public class ExpenseManager
    {
        private double spent;
        private double balance;
        public ObservableCollection<Expense> ListOfExpenses { get; set; }

        public ExpenseManager()
        {
            ListOfExpenses = new ObservableCollection<Expense>();
            ReadExpenseDetails();
        }

        public void AddExpenseDetails(Expense expense)
        {
            ListOfExpenses.Add(expense);
        }

        public void SaveExpenseDetails(Expense saveExpense)
        {
            string savePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Expense.json";
            //string fileName = $@"{savePath}\"

            ListOfExpenses.Add(saveExpense);
            string expenseFile = JsonConvert.SerializeObject(ListOfExpenses);

            System.IO.File.WriteAllText(savePath, expenseFile);

        }

        private void ReadExpenseDetails()
        {
            string savePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Expense.json";

            string readFile = System.IO.File.ReadAllText(savePath);
            this.ListOfExpenses = JsonConvert.DeserializeObject<ObservableCollection<Expense>>(readFile);
        }


        
       public double TotalBudget
        {
            get { return App.BudgetAmount; }
            set
            { }
        }

        //gets and set total amount spent
        public double Spent
        {
            get { return spent; }
            set
            {
                spent = value;
                //NotifyPropertyChanged("Spent");
            }
        }

        //gets and sets total remaining amount
        public double Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                //NotifyPropertyChanged("Balance");
            }
        }


    }
}
