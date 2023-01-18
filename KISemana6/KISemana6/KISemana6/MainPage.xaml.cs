using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace KISemana6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.50/uisrael2023/estudiante.php";
       

        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            obtener();
        }
        public async void obtener()
        {
            var content = await client.GetStringAsync(Url);
            List<Datos> posts = JsonConvert.DeserializeObject<List<Datos>>(content);
            _post = new ObservableCollection<Datos>(posts);
            MyListView.ItemsSource = _post;
        }

        public void btnInserta_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Registrar());
        }
    }
}

