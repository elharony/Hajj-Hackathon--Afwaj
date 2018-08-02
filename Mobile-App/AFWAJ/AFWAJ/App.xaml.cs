using System;

using AFWAJ.Views;
using Xamarin.Forms;

namespace AFWAJ
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();
            WebView wv = new WebView();
		    wv.Source = "";

            MainPage = new Home();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
