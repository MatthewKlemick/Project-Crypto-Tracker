using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RestSharp;
using Newtonsoft.Json;
using Project_Crypto_Tracker.Model;

namespace Project_Crypto_Tracker
{
    public partial class MainPage : ContentPage
    {
        //http://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;USDT;LTC;XMR

        private string Key = "BEE9AA15-AA15-4261-B92A-9E96E428E5A3";

        private string StartofUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";

        public MainPage()
        {
            InitializeComponent();



            cryptoListView.ItemsSource = UpdateCryptos();
        }

        private void Rbuton_Clicked(object sender, EventArgs e)
        {
            cryptoListView.ItemsSource = UpdateCryptos();
        }

        private List<CryptoClass> UpdateCryptos()
        {
            List<CryptoClass> Cryptos;

            var client = new RestClient("http://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;USDT;LTC;XMR");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", Key);

            var response = client.Execute(request);
            Cryptos = JsonConvert.DeserializeObject<List<CryptoClass>>(response.Content);



            foreach (var c in Cryptos)
            {
                c.Icon_link = StartofUrl + c.Id_Icon.Replace("-", "") + ".png";
            }

            return Cryptos;
        }
    }
}
