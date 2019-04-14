using MyCookBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCookBook.ViewModels
{
    class SearchViewModel : RecipeSelectedBase
    {
        private string enteredText;
        public string EnteredText
        {
            get { return enteredText; }
            set
            {
                    enteredText = value;
                    this.SearchCommand.Execute(null);
                    OnPropertyChanged();
            }
        }

        public ObservableCollection<Recipe> RecipesList { get; set; }

        public SearchViewModel():base()
        {
            RecipesList = new ObservableCollection<Recipe>();
        }

        public void ExecuteSearchCommand(object parameter)
        {
            if (enteredText.Length >= 1)
            {
                RecipesList.Clear();

                var recipes = Task.Run(() => App.LocalDB.GeRecipeByText(enteredText)).Result;
                foreach (var rec in recipes)
                {
                    RecipesList.Add(rec);
                }
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(ExecuteSearchCommand,
                CanExecuteSearchCommand);
            }
        }

        public bool CanExecuteSearchCommand(object parameter)
        {
            return true;
        }
    }
}
