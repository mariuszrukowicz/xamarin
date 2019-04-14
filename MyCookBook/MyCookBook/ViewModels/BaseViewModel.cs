using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyCookBook.ViewModels
{
        public abstract class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string porpoertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(porpoertyName));
            }
        }
    
}
