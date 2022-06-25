using Ejercicio1_4.Models;
using Ejercicio1_4.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio1_4
{    
    public partial class MainPage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photoFile = null;
        private string photoName = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGallery_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gallery());
        }

        private async void imgPhoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                photoName = "IMG_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                photoFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Mis Fotos",
                    Name = photoName,
                    SaveToAlbum = true
                });

                if (photoFile != null)
                {
                    imgPhoto.Source = ImageSource.FromStream(() =>
                    {
                        return photoFile.GetStream();
                    });
                }
            }
            catch (Exception)
            {
                //throw ex;
            }
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (photoFile == null)
            {
                await DisplayAlert("Error", "No ha tomado una fotografía", "OK");
                return;
            }

            var foto = new Fotos
            {
                Id = 0,
                PhotoName = txbName.Text,
                Descrip = txbDescrip.Text,               
                Photo = ConvertImageToByteArray()
                
            };

            var result = await App.DB.SavePhoto(foto);

            if (result > 0)
            {
                await DisplayAlert("Aviso", "Fotografía Guardada", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha ocurrido un error", "OK");
            }
        }

        private Byte[] ConvertImageToByteArray()
        {
            if (photoFile != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photoFile.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }
            return null;
        }
    }
}
