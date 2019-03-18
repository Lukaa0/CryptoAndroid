using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PortableCryptoLibrary;
using static Java.Text.Normalizer;
using Square.Picasso;

namespace App5.Adapters
{
    public  class CoinListViewAdapter : BaseAdapter<CryptoItem>
    {
        public Activity activity { get; set; }
        public List<CryptoItem> cryptoItems { get; set; }
        public Bitmap imgBitmap { get; set; }
        CryptoImages cryptoImages = WebServiceSingleton.Instance.GetApi<CryptoImages>("https://www.cryptocompare.com/api/data/coinlist/");

        public CoinListViewAdapter(Activity activity, List<CryptoItem> CryptoItems)
        {
            this.activity = activity;
            this.cryptoItems = CryptoItems;

        }
        public override CryptoItem this[int position] => cryptoItems[position];

        public override int Count => cryptoItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }
        
       

        public override  View GetView(int position, View convertView, ViewGroup parent)
        {
            var cryptoItem = cryptoItems[position];
            
            var imageData = cryptoImages.Data;
            string imgurl;
            if (imageData.ContainsKey(cryptoItem.symbol.ToUpper()))
            {
                imgurl = cryptoImages.BaseImageUrl + imageData[cryptoItem.symbol.ToUpper()].ImageUrl;
            }
            else
            {
                imgurl = cryptoImages.BaseImageUrl + imageData["BTC"].ImageUrl;
            }
            
           


            if (convertView == null)
            {
                convertView = activity.LayoutInflater.Inflate(Resource.Layout.ListItem, null);
            }
            
            convertView.FindViewById<TextView>(Resource.Id.Title).Text = cryptoItem.name;
           // convertView.FindViewById<TextView>(Resource.Id.Description).Text = "$" + cryptoItem.price_usd;
            var imgView = convertView.FindViewById<ImageView>(Resource.Id.Thumbnail);
            Picasso.With(activity).Load(imgurl).Into(imgView);
            return convertView;
        }
    }
}