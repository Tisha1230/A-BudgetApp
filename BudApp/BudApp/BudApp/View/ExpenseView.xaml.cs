using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseView : ContentPage
    {
               
        public ExpenseView()
        {
            InitializeComponent();
        }

        private void OnResetButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new EnterBudget());
        
        }

        private void AddExpense_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new AddExpenseDetails());
        }
    }
} 