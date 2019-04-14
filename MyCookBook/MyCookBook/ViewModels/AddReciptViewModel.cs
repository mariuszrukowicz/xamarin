using MyCookBook.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyCookBook.ViewModels
{
    class AddReciptViewModel : BaseViewModel
    {
        private MediaFile _image;

        //public MediaFile Image
        //{
        //    get { return _image; }
        //    set {
        //        OnPropertyChanged();
        //        _image = value;
        //    }
        //}

        private Recipt _recipt;

        public Recipt Recipt
        {
            get { return _recipt; }
            set {
                OnPropertyChanged();
                _recipt = value;
            }
        }

        public ObservableCollection<Igredient> IgredientList { get; set; }



        public AddReciptViewModel()
        {

        }
    }
}
