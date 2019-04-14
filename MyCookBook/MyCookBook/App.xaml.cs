using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyCookBook.Views;
using MyCookBook.Data;
using MyCookBook.Interfaces;
using MyCookBook.Models;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MyCookBook
{
	public partial class App : Application
	{

        private static LocalDB localDB;

        public static LocalDB LocalDB
        {
            get
            {
                if (localDB == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var filename = fileHelper.GetLocalFilePath("app2.db3");
                    localDB = new LocalDB(filename);
                }

                return localDB;
            }
        }

        public App ()
		{
			InitializeComponent();
            
            AddDataToDb.AddRecipe();
            
            MainPage = new NavigationPage(new MainTabbedPage());
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
