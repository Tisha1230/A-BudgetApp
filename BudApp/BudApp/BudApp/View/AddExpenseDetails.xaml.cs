using BudApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpenseDetails : ContentPage
    {
        public AddExpenseDetails()
        {
            InitializeComponent();

        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            ExpenseManager expenseManager = new ExpenseManager();
            Expense expense = new Expense();
            expense.Description = ExpenseDescription.Text;

            if(string.IsNullOrEmpty(expense.Description)) //validation to catch user's errors
            {
                DisplayAlert("Validation Failed","Description Cannot be Empty", "OK");
                return;
                
            }

            double temp = 0;
            if (!double.TryParse(AmountSpent.Text, out temp))
            {
                DisplayAlert("Validation Failed", "AmountSpent needs to be a number", "OK"); //validation to catch user's errors
                return;

            }

            expense.AmountSpent = temp;

            expense.Date = PickDateEditor.Date.ToShortDateString();

            if (SelectCategory.SelectedItem == null)
            {
                DisplayAlert("Validation Failed", "Need to select a category", "OK"); //validation to catch user's errors
                return;
            }

            string category = (string)SelectCategory.SelectedItem;
            switch (category)
            {
                case "Food":
                    expense.CategoryImage = "Food.png";
                    break;

                case "Groceries":
                    expense.CategoryImage = "Groceries.jfif";
                    break;
                case "Home":
                    expense.CategoryImage = "Home1.png";
                    break;
                case "Insurance":
                    expense.CategoryImage = "Insurance.jfif";
                    break;
                case "Misc":
                    expense.CategoryImage = "misc.png";
                    break;
                case "Shopping":
                    expense.CategoryImage = "Shopping.jfif";
                    break;
                case "Travel":
                    expense.CategoryImage = "Travel.png";
                    break;
            }



            expenseManager.SaveExpenseDetails(expense);

            App.AmountSpent = expenseManager.GetAmountSpent();

            Application.Current.MainPage = new NavigationPage(new ExpenseView());
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new ExpenseView());
        }
    }
	
}