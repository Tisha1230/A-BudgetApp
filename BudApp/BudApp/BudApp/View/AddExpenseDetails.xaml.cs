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
            expense.AmountSpent = double.Parse(AmountSpent.Text);
            expense.Date = Date.Text;
            expense.Category = (ExpenseCategory)Enum.Parse(typeof(ExpenseCategory), (string)SelectCategory.SelectedItem);

            expenseManager.SaveExpenseDetails(expense);

            Application.Current.MainPage = new NavigationPage(new ExpenseView());
        }
    }
	
}