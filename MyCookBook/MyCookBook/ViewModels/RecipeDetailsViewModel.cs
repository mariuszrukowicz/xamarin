using MyCookBook.Models;
using MyCookBook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyCookBook.ViewModels
{
    public class RecipeDetailsViewModel :BaseViewModel
    {
        private Recipe recipe;
        public Recipe Recipe
        {
            get => recipe;
            set
            {
                recipe = value;
                OnPropertyChanged();
            }
        }
        public string ListIgredients
        {
            get => listIgredients;
            set
            {
                listIgredients = value;
                OnPropertyChanged();
            }

        }
        private string listIgredients;

        private void getIgredients()
        {
            var list = Task.Run(() => App.LocalDB.GetAllIgredientsByRecipe(Recipe)).Result;
            ListIgredients = list.ConverTotextList();
        }

        public RecipeDetailsViewModel(Recipe recipe)
        {
            this.recipe = recipe;
            getIgredients();
        }
    }
}
