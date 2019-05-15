using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static CurrentBalance.Constants;

namespace CurrentBalance.ViewModels
{
    public class MainPageVM : ViewModelBase
    {
        decimal initVal = 0m;
        public MainPageVM()
        {
            if (Application.Current.Properties.ContainsKey(BalanceName))
            {
                Balance = decimal.Parse(Application.Current.Properties[BalanceName].ToString());
            }
            else
            {
                Application.Current.Properties[BalanceName] = initVal;
            }

        }
        
        

        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set { SetProperty(ref balance, value); }
        }

        public ICommand InputPageAdd
        {
            get
            {
                return new Command(async() => 
                {
                    (Application.Current as App).InputPageVM.Text = Add;
                    (Application.Current as App).InputPageVM.Amount = 0;
                    await (Application.Current as App).PushAync(new InputPage());
                });
            }
        }
        public ICommand InputPageSubtract
        {
            get
            {
                return new Command(async () =>
                {
                    (Application.Current as App).InputPageVM.Text = Subtract;
                    (Application.Current as App).InputPageVM.Amount = 0;
                    await (Application.Current as App).PushAync(new InputPage());
                });

            }
        }


        public void AddAmountMethod(decimal amount)
        {
            Balance = decimal.Parse(Application.Current.Properties[BalanceName].ToString()) + amount;
            Application.Current.Properties[BalanceName] = Balance;
        }
        public void SubtractAmountMethod(decimal amount)
        {
            Balance = decimal.Parse(Application.Current.Properties[BalanceName].ToString()) - amount;
            Application.Current.Properties[BalanceName] = Balance;
        }



        public Command ResetBalance
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.Properties[BalanceName] = 0;
                    Balance = decimal.Parse(Application.Current.Properties[BalanceName].ToString());
                    //(Application.Current as App).MainPage = new NavigationPage(new MainPage());
                });
            }
        }
    }
}
