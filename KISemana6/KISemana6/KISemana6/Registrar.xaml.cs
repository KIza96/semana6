using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using Xamarin.Forms;

namespace KISemana6
{
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
        }

       public void bntInsertar_Clicked(System.Object sender, System.EventArgs e)
        {
            WebClient cliente = new WebClient();
            try
            {
                var parametros = new NameValueCollection();
                parametros.Add("codigo", txtId.Text);
                parametros.Add("nombre", txtnombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.100.50/uisrael2023/estudiante.php", "POST", parametros);
                DisplayAlert("Mensaje", "Se registro el estudiante " + txtnombre.Text, "Cerrar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

       public void bntRegresar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}

