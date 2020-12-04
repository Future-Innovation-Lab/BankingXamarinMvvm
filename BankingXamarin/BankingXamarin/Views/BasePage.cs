using BankingXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BankingXamarin.Views
{
    public class BasePage : ContentPage
    {

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var baseViewModel = BindingContext as BaseViewModel;

            if (baseViewModel != null)
            {
                baseViewModel.OnAppearing();
            }

        }
    }
}
