using Xamarin.Forms;
using Prism.Navigation;
using System;

namespace PrismUnityToDolistMobile.Views
{
    public partial class MainPage : ContentPage, IDestructible
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Destroy()
        {
           
        }

        void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
