using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICT13580090EndB.Helper;
using Xamarin.Forms;

namespace ICT13580090EndB
{
    public partial class App : Application
    {
        public static DbHelper DbHelper { get; set; }
        public App(string dbPath)
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MainPage());

            DbHelper = new DbHelper(dbPath);
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
    }
}
