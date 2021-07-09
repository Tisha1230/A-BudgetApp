using BudApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterBudget : ContentPage
    {

        public EnterBudget()
        {
            InitializeComponent();
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            BudgetManager budgetManager = new BudgetManager();
            ExpenseManager expenseManager = new ExpenseManager();

            //string BudgetFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            //"BudgetSetFile.txt");

            //saves and displays new reset budget
            double temp = 0;
            if (double.TryParse(SetBudgetEditor.Text, out temp))
            //tryparse converts string representation to double value and returns true if conversion succeed and sets temp to the converted value
            {
                App.BudgetAmount = temp;

                budgetManager.SaveBudget(temp);
                expenseManager.Reset();
                Application.Current.MainPage = new NavigationPage(new ExpenseView());
            }
            else
            {
                SetBudgetEditor.Text = string.Empty;
            }
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            SetBudgetEditor.Text = string.Empty;
        }
    }
}