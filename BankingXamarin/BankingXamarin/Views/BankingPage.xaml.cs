using System;
using Xamarin.Forms;
using Banking;
using BankingXamarin.Services;
using BankingXamarin.Views;
using BankingXamarin.ViewModels;

namespace BankingXamarin
{
    public partial class BankingPage : BasePage
    {
        public BankingPage()
        {
            InitializeComponent();

            BindingContext = new BankingPageViewModel(Navigation);
        }
    }
}
