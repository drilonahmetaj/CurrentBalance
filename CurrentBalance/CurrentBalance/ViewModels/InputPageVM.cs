  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using static CurrentBalance.Constants;
namespace CurrentBalance.ViewModels
{
    public class InputPageVM : ViewModelBase
    {
        public InputPageVM()
        {
        }
        public InputPageVM(string text)
        {
            Text = text;
        }
        private string text;

        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }


        public Command OkButtonCommand
        {
            get
            {
                return new Command(() => 
                {
                    if (Text== Add)
                    {
                        (Application.Current as App).MainPageVM.AddAmountMethod(Amount);
                        (Application.Current as App).MainPage = new NavigationPage (new MainPage());
                        Amount = 0;
                    }
                    else if (Text == Subtract)
                    {
                        (Application.Current as App).MainPageVM.SubtractAmountMethod(Amount);
                        (Application.Current as App).MainPage = new NavigationPage(new MainPage());
                        Amount = 0;
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                });
            }
        }

    }
}
