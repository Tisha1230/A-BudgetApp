using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BudApp.ViewModel;

namespace BudApp
{
    public partial class App : Application
    {
        public static double BudgetAmount { get; set; }
        public static double AmountSpent { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new EnterBudget();

            BudgetManager budgetManager = new BudgetManager();
            double totalBudget = budgetManager.ReadBudget();

            if (totalBudget == 0)
            {
                AmountSpent = 0;
                MainPage = new NavigationPage(new EnterBudget());
            }
            else
            {
                BudgetAmount = totalBudget;
                ExpenseManager expenseManager = new ExpenseManager();
                AmountSpent = expenseManager.GetAmountSpent();
                MainPage = new NavigationPage(new ExpenseView());

            }


            ////combine base folder with special folder and file location
            

            //string BudgetFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            //"BudgetSetFile.txt");

            //if (File.Exists(BudgetFileName))
            //{
            //    string BudgetFileText = File.ReadAllText(BudgetFileName); //reads the file if exists

            //    double temp = 0;
            //    if (double.TryParse(BudgetFileText, out temp)) 
            //    //tryparse converts string representation to double value and returns true if conversion succeed and sets temp to the converted value
            //    {
            //        BudgetAmount = temp;
            //        MainPage = new NavigationPage(new Expense());
            //    }
            //    else
            //    {
            //        MainPage = new NavigationPage(new EnterBudget());
            //    }
            //}

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
