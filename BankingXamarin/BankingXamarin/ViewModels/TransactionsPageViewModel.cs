using Banking;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BankingXamarin.ViewModels
{
    public class TransactionsPageViewModel : BaseViewModel
    {
        private BankAccount _bankAccount;

        public BankAccount Account
        {
            get { return _bankAccount; }
            set { _bankAccount = value;
                OnPropertyChanged();
            }
        }


        public TransactionsPageViewModel(INavigation navigation, BankAccount account) : base(navigation)
        {
            Account = account;
        }
    }
}
