using BankingXamarin.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankingXamarin
{
    public partial class App : Application
    {
        public static BankingDatabase BankingDatabase { get; set; } 

        public App()
        {
            InitializeComponent();

            BankingDatabase = new BankingDatabase();
            MainPage = new NavigationPage(new BankingPage());
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
