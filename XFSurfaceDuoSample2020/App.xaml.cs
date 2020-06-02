using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSurfaceDuoSample2020.Services;
using XFSurfaceDuoSample2020.Views;

namespace XFSurfaceDuoSample2020
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MasterDetail();
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
