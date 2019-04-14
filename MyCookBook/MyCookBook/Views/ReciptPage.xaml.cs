using MyCookBook.Models;
using MyCookBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCookBook.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReciptPage : ContentPage
	{
		public ReciptPage (Recipe recipe)
		{
			InitializeComponent ();
            BindingContext = new RecipeDetailsViewModel(recipe);
        }
	}
}