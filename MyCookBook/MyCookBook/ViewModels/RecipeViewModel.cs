using MyCookBook.Models;
using MyCookBook.Services;
using MyCookBook.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCookBook.ViewModels
{
    public class RecipeViewModel : RecipeSelectedBase
    {

        private List<Recipe> recipe;
        public List<Recipe> Recipe
        {
            get
            {
                return recipe;
            }
            set
            {
                if (recipe != value)
                {
                    recipe = value;
                    OnPropertyChanged();
                };
            }
        }

        public RecipeViewModel() : base()
        {
            LoadRecipe();  
        }

        private async void LoadRecipe()
        {
           Recipe = await App.LocalDB.GetItems<Recipe>();         
        }

    }
    
}
