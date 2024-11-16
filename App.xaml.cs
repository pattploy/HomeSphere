namespace _1111
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ///MainPage = new AppShell();
            MainPage = new NavigationPage(new Login());
            //MainPage = new UserPage();
            //MainPage = new UserRPage();
        }
    }
}
