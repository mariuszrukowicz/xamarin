using MyCookBook.Models;
using MyCookBook.Services;
using MyCookBook.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCookBook.ViewModels
{
    public class RecipeSelectedBase : BaseViewModel
    {
        public DelegateCommand<Recipe> RecipeSelectedCommand { get; }

        public RecipeSelectedBase()
        {
            RecipeSelectedCommand = new DelegateCommand<Recipe>(RecipeSelected);

        }

        protected virtual async void RecipeSelected(Recipe recipe)
        {
            var parameters = new NavigationParameters
            {
                { "recipe", recipe}
            };
            await NavigationService.Push(new ReciptPage(recipe));

        }
    }
}
