﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSurfaceDuoSample2020.Services;

namespace XFSurfaceDuoSample2020
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new MasterDetailPage());
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
