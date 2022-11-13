using PM2_P2Tarea2_2.Controller;
using PM2_P2Tarea2_2.Models;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2_P2Tarea2_2
{
    public partial class MainPage : ContentPage
    {
        Byte[] resultBase;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.ListFirmas());
        }

        private async void btnSqlite_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese el nombre", "OK");
                return;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese una descripcion", "OK");
                return;
            }

            if (firmaDigital.IsBlank)
            {
                await DisplayAlert("Error", "Por favor, ingrese una firma digital", "OK");
                return;
            }


            var imageFirma = await firmaDigital.GetImageStreamAsync(SignatureImageFormat.Png);
            var mStream = (MemoryStream)imageFirma;
            Byte[] data = mStream.ToArray();




            var firma = new Firmas()
            {
                id = 0,
                nombre = txtNombre.Text,
                descripcion = txtDescripcion.Text,
                firmaa = data
            };

            var folderPath = "/storage/emulated/0/Android/data/com.companyname.pm2_p2tarea2_2/files/Pictures";
            var nameFirma = "";

            if (await new Servicios().saveFirma(firma))
            {
                try
                {
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    nameFirma = txtNombre.Text + DateTime.Now.ToString("MMddyyyyhhmmss"); ;

                    File.WriteAllBytes(folderPath + "/" + nameFirma + ".png", firma.firmaa);

                    Mensg("Firma guardada \nPath:" + folderPath + "/" + nameFirma + ".png");
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    firmaDigital.Clear();
                }
                catch
                {
                    Mensg("Firma guardada");
                }




            }
            else Mensg("Error no se guardo la firma");

        }

        public async void Mensg(string msg)
        {
            await DisplayAlert("Notificacion", msg, "OK");
        }
    }
}
