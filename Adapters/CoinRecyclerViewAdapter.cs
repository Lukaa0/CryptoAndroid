using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using App5.View_Holders;
using PortableCryptoLibrary;
using Square.Picasso;

namespace App5.Adapters
{
    public class CoinRecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<CryptoItem> Coins;
        private Activity activity;
        private CryptoImages cryptoImages = WebServiceSingleton.Instance.GetApi<CryptoImages>("https://www.cryptocompare.com/api/data/coinlist/");
        public CoinRecyclerViewAdapter(List<CryptoItem> coins,Activity act)
        {
            activity = act;
            Coins = coins;
        }
        
        public override int ItemCount => Coins.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CoinViewHolder coinViewHolder = holder as CoinViewHolder;
            var cryptoItem = Coins[position];

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
            Picasso.With(activity).Load(imgurl).Into(coinViewHolder.CoinImage);
            coinViewHolder.Title.Text = cryptoItem.name;
            coinViewHolder.PriceText.Text = cryptoItem.price_usd;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListItem, parent, false);
            CoinViewHolder coinViewHolder = new CoinViewHolder(view);
            return coinViewHolder;
        }
    }
}
