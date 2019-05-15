using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrentBalance
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InputPage : ContentPage
	{
        
        public InputPage ()
		{
			InitializeComponent ();
            BindingContext = (Application.Current as App).InputPageVM;
		}
	}
}