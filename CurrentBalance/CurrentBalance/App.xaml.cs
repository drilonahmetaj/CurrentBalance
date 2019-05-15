using CurrentBalance.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CurrentBalance
{
    public partial class App : Application
    {
        public NavigationPage NavigationPage { get; set; }
        public InputPageVM InputPageVM;
        public MainPageVM MainPageVM;
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            (Application.Current as App).NavigationPage = new NavigationPage(new MainPage()); // Declare NavigationPage in App.cs 
            Application.Current.MainPage = NavigationPage;
            InputPageVM = new InputPageVM();
            MainPageVM = new MainPageVM();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async Task PushAync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }
    }
}
