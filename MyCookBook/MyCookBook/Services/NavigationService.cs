using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCookBook.Services
{
    public sealed class NavigationService
    {
        public static async Task Push(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public static async Task Pop()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
