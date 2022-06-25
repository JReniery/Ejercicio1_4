using Ejercicio1_4.Models;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gallery : ContentPage
    {
        private int id = 0;
        private string photoName = "";
        private string descrip = "";
        private byte[] photo = null;
       

        public Gallery()
        {
            InitializeComponent();            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadGallery();
        }
        private async void LoadGallery()
        {
            lvGallery.ItemsSource = await App.DB.GetPhotoList();
        }

        private async void lvGallery_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var foto = (Fotos)e.Item;
            //id = foto.Id;
            //photoName = foto.PhotoName;
            //descrip = foto.Descrip;            
            //photo = foto.Photo;           

            var popupPage = new ShowPhoto();
            popupPage.BindingContext = foto;

            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Right,
                PositionOut = MoveAnimationOptions.Left
            };

            popupPage.Animation = scaleAnimation;
            await PopupNavigation.Instance.PushAsync(popupPage);

            //await PopupNavigation.Instance.PushAsync(new ShowPhoto());
        }
    }
}