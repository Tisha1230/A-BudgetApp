using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Linq;
using BudApp.Model;
using Newtonsoft.Json;

namespace BudApp
{
    public class ExpenseManager
    {
        private double spent;
        private double balance;
        public ObservableCollection<Expense> ListOfExpenses { get; set; }

        //path where json object is saved
        private string savePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Expense.json";

        public ExpenseManager()
        {
            ListOfExpenses = new ObservableCollection<Expense>();
            ReadExpenseDetails();
        }

        //Calculates amount spent
        public double GetAmountSpent()
        {
            double result = 0;
            foreach (var expense in ListOfExpenses)
            {
                result = result + expense.AmountSpent;
            }

            return result; 
        }

        public void SaveExpenseDetails(Expense saveExpense)
        {
            ListOfExpenses.Add(saveExpense);
            string expenseFile = JsonConvert.SerializeObject(ListOfExpenses); //converts string to json object 

            System.IO.File.WriteAllText(savePath, expenseFile);//saving the converted json object

        }


        //converts json object to string and reads it if file exists
        private void ReadExpenseDetails()
        {
            if (File.Exists(savePath))
            { 
                string readFile = System.IO.File.ReadAllText(savePath);
                this.ListOfExpenses = JsonConvert.DeserializeObject<ObservableCollection<Expense>>(readFile);
            }
        }

        //Resets the entered budget
        public void Reset()
        {
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }
        }

        //gets total monthly budget entered
        public double TotalBudget
        {
            get { return App.BudgetAmount; }
            set
            { }
        }

        //gets and set total amount spent
        public double Spent
        {
            get { return App.AmountSpent; }
            set
            {
                spent = value;
               
            }
        }

        //gets and sets total remaining amount
        public double Balance
        {
            get { return (TotalBudget - Spent); } //returns balance left 
            set
            {
                balance = value; 
               
            }
        }


    }
}
