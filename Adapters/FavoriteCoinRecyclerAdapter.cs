using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using HandyCrypto.View_Holders;
using PortableCryptoLibrary;
using System.Text;
using Android.App;
using Square.Picasso;
using Android.Content;
using HandyCrypto.DataHelper;
using HandyCrypto.Model;
using FragmentManager = Android.Support.V4.App.FragmentManager;
namespace HandyCrypto.Adapters
{
    class FavoriteCoinRecyclerAdapter : RecyclerView.Adapter
    {
        List<CryptoItemModel> items;
        private string coinImage;
        private readonly Activity activity;
        private DataHelper<FavoriteCoin> db;

        public FavoriteCoinRecyclerAdapter(List<CryptoItemModel> data,DataHelper<FavoriteCoin> db,Activity activity,FragmentManager fragmentManager)
        {
            items = data;
            this.db = db;
            this.activity = activity;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListItem, parent, false);

            var vh = new CoinViewHolder(itemView,OnClick,OnFavoriteClick);


            return vh;
        }

        private async void OnFavoriteClick(int position, ToggleButton toggleButton)
        {
            var crypto = items[position];
            var favoriteCoin = new FavoriteCoin(crypto.Info.Symbol);
            await DeleteItemAsync(favoriteCoin);
            items.Remove(crypto);
            NotifyItemRemoved(position);
        }
        private async System.Threading.Tasks.Task DeleteItemAsync(FavoriteCoin item)
        {
            if(item!=null)
            {
                await db.Delete(item);
            }
        }

        private void OnClick(int obj)
        {
            throw new NotImplementedException();
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            var holder = viewHolder as CoinViewHolder;
            coinImage = item.Info.ImageUrl;
            StringBuilder imageStringBuilder = new StringBuilder("https://www.cryptocompare.com");
            imageStringBuilder.Append(coinImage);
            var imageUrl = imageStringBuilder.ToString();
            Picasso.With(activity).Load(imageUrl).Into(holder.CoinImage);
            holder.PriceText.Text = item.AggregatedData.Price.ToString() ?? "Loading...";
            holder.Title.Text = item.Info.Name;
            holder.Favorite.Checked = true;
        }

        internal void ReplaceAndRefresh(List<CryptoItemModel> items)
        {
            int startPosition = items.Count + 1;
            this.items = items;
            NotifyItemRangeInserted(startPosition, items.Count);
        }

        public override int ItemCount => items.Count;


    }
    


}