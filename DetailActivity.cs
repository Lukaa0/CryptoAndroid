using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PortableCryptoLibrary;
using PortableCryptoServices;
using Square.Picasso;

namespace App5
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        protected  override void OnCreate(Bundle savedInstanceState)
        {
            CryptoImages ForImage =  WebServiceSingleton.Instance.GetApi<CryptoImages>("https://www.cryptocompare.com/api/data/coinlist/");
            var ImageData = ForImage.Data;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DetailPage);
            var dataService = new CryptoItemService();
            var cryptoID = Intent.Extras.GetString("cryptoID");
            var cryptoItem = dataService.GetById(cryptoID);
            var image = FindViewById<ImageView>(Resource.Id.detailPageImage);
            var title = FindViewById<TextView>(Resource.Id.detailPageTitle);
            title.Text = cryptoItem.name;
            var imgurl = ForImage.BaseImageUrl + ImageData[cryptoItem.symbol.ToUpper()].ImageUrl;
            Picasso.With(this).Load(imgurl).Into(image);




            // Create your application here
        }
    }
}