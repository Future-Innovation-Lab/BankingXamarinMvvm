using Acr.UserDialogs;
using Banking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BankingXamarin.ViewModels
{
    public class BankingPageViewModel : BaseViewModel
    {
        private BankAccount _account;
        private Customer _customer;

        private decimal _depositAmount;

        public decimal DepositAmount
        {
            get { return _depositAmount; }
            set { _depositAmount = value;

                OnPropertyChanged();
            }
        }

        private string _depositReason;

        public string DepositReason
        {
            get { return _depositReason; }
            set
            {
                _depositReason = value;

                OnPropertyChanged();
            }
        }

        private decimal _withdrawAmount;

        public decimal WithdrawAmount
        {
            get { return _withdrawAmount; }
            set { _withdrawAmount = value;

                OnPropertyChanged();
            }
        }

        private string _withdrawReason;

        public string WithdrawReason
        {
            get { return _withdrawReason; }
            set
            {
                _withdrawReason = value;

                OnPropertyChanged();
            }
        }

        private string _transactionsText;

        public string TransactionsText
        {
            get { return _transactionsText; }
            set
            {
                _transactionsText = value;

                OnPropertyChanged();
            }
        }


        public ICommand  DepositCommand { get; set; }
        public ICommand WithdrawCommand { get; set; }
        public ICommand DisplayTransactionsCommand { get; set; }

        public BankingPageViewModel(INavigation navigation) : base(navigation)
        {

            DepositCommand = new Command(() => Deposit());
            WithdrawCommand = new Command(() => Withdraw());
            DisplayTransactionsCommand = new Command(() => DisplayTransactions());
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            var database = App.BankingDatabase;

            _customer = database.GetCustomerByIdNumber("7766445424");
            _account = database.GetCurrectAccount(_customer);

            TransactionsText = _account.GetTransactionHistory();

        }

        private void Withdraw()
        {
            decimal withdrawAmount = WithdrawAmount;

            try
            {
                var reason = WithdrawReason;

                var trans = _account.WithdrawMoney(withdrawAmount, DateTime.Now, reason);

                var database = App.BankingDatabase;

                database.SaveTransaction(_account, trans);

                TransactionsText = _account.GetTransactionHistory();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert("Transaction Error", ex.Message, "Cancel");
            }
        }

        private void Deposit()
        {
            decimal depositAmount = DepositAmount;

            var reason = DepositReason;

            var trans = _account.DepositMoney(depositAmount, DateTime.Now, reason);

            var database = App.BankingDatabase;

            database.SaveTransaction(_account, trans);

            TransactionsText = _account.GetTransactionHistory();
        }

        private void DisplayTransactions()
        {
            var database = App.BankingDatabase;
            var account = database.GetCurrectAccount(_customer);
            Navigation.PushAsync(new TransactionsPage(account));
        }

    }
}
