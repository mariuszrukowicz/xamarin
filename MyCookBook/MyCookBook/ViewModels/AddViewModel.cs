using MyCookBook.Models;
using MyCookBook.Services;
using MyCookBook.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCookBook.ViewModels
{
    class AddViewModel : BaseViewModel
    {
        private Recipe recipe;

        public Recipe Recipe
        {
            get { return recipe; }
            set
            {
                recipe = value;
                OnPropertyChanged();
            }
        }

        private Igredient igredient;

        public Igredient Igredient
        {
            get { return igredient; }
            set
            {
                igredient = value;
                OnPropertyChanged();
            }
        }

        private List<Igredient> igredientList;

        public string IgredientListString
        {
            get { return igredientList?.ConverTotextList(); }

        }
        public List<string> Units { get; set; }

        public ICommand TakePhoto { get; set; }
        public ICommand PickPhoto { get; set; }
        public ICommand AddIgredient { get; set; }
        public ICommand RemoveIgredient { get; set; }
        public ICommand AddRecpie { get; set; }



        public AddViewModel()
        {
            Recipe = new Recipe() { Image = "addImage" };
            Igredient = new Igredient() { Name = String.Empty, Unit = null, Quantity = 0 };
            igredientList = new List<Igredient>();
            Units = new List<string>() { "kg", "dag", "g", "l", "ml", "szt" };       
            TakePhoto = new Command(takePhoto);
            PickPhoto = new Command(pickPhoto);
            AddIgredient = new Command(addIgredient);
            RemoveIgredient = new Command(removeIgredient);
            AddRecpie = new Command(addRecpie);
        }



        private async void takePhoto()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front

            });

            if (file == null)
                return;
            Recipe.Image = file.Path;
            OnPropertyChanged("Recipe");
        }

        private async void pickPhoto()
        {
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return;
            Recipe.Image = file.Path;
            OnPropertyChanged("Recipe");
        }
        private void addIgredient()
        {
            if (Igredient.Name == null || Igredient.Quantity <= 0 || Igredient.Unit == null)
            {
                return;
            }
            int index;
            if (Int32.TryParse(Igredient.Unit, out index))
            {               
                Igredient.Unit = Units[index];
            }

            igredientList.Add(Igredient);
            OnPropertyChanged("IgredientListString");

            Igredient = new Igredient() { Name = igredient.Name, Quantity = igredient.Quantity, Unit = igredient.Unit };
        }
        private void removeIgredient()
        {
            if (igredientList.Count > 0)
            {
                igredientList?.RemoveAt(igredientList.Count - 1);
                OnPropertyChanged("IgredientListString");
            }
        }
        private async void addRecpie()
        {
            if (Recipe.Name == null || Recipe.Image == null || Recipe.Description == null) return;
            Recipe.AddedDate = DateTime.UtcNow;
            var recipe = await App.LocalDB.SaveItem(Recipe);

            igredientList.ForEach(async x =>
            {
                x.RecipeId = recipe.Id;
                await App.LocalDB.SaveItem(x);
            });

            App.Current.MainPage = new MainTabbedPage();

        }
    }
}

