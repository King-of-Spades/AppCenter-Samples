﻿using System;

using Xamarin.Forms;

namespace UITestDemo
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public App(bool runningInAppCenter)
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage(runningInAppCenter);
            else
                MainPage = new NavigationPage(new MainPage(runningInAppCenter));
        }
    }
}
