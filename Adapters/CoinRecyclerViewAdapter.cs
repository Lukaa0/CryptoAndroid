using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AFollestad.MaterialDialogs;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Request;
using Com.Orhanobut.Dialogplus;
using CryptoCompare;
using HandyCrypto.DataHelper;
using HandyCrypto.Fragments;
using HandyCrypto.Model;
using HandyCrypto.View_Holders;
using Newtonsoft.Json;
using PortableCryptoLibrary;
using Square.Picasso;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

namespace HandyCrypto.Adapters
{
    public class CoinRecyclerViewAdapter : RecyclerView.Adapter
    {
        private DataHelper<FavoriteCoin> db;
        private List<CryptoItemModel> Coins;
        private  Activity activity;
        private const string BaseUrl = "https://www.cryptocompare.com";
        FragmentManager fragmentManager;
        List<FavoriteCoin> favorites;
        private CryptoItemModel cryptoItem;
        private string coinImage;
        private bool isOnFavorites;
        public event EventHandler<int> ItemClick;
        public CoinRecyclerViewAdapter(List<CryptoItemModel> coins,Activity act , FragmentManager supportFragmentManager,DataHelper<FavoriteCoin> db,List<FavoriteCoin> favorites,bool isOnFavorites)
        {
            activity = act;
            Coins = coins;
            fragmentManager = supportFragmentManager;
            this.db = db;
            this.favorites = favorites;
            this.isOnFavorites = isOnFavorites;

        }

        public override int ItemCount => Coins.Count;
        public void AddAndRefresh(List<CryptoItemModel> data)
        {
            int startPosition = Coins.Count + 1;
            Coins.AddRange(data);
            NotifyItemRangeInserted(startPosition,data.Count);

        }

        public void ReplaceAndRefresh(List<CryptoItemModel> data)
        {
            int startPosition = Coins.Count+1;
            Coins = data;
            NotifyItemRangeInserted(startPosition, Coins.Count);
        }
        public void ReplaceAndRefresh(List<FavoriteCoin> data)
        {
            favorites = data;
            NotifyDataSetChanged();
        }

        public  void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
            var item = Coins[position];
            
            Bundle Data = new Bundle();
            Data.PutString("symbol", item.Info.Symbol);
            
            var view = LayoutInflater.From(activity).Inflate(Resource.Layout.item_modal_dialog, null);
            var dialog = new MaterialDialog.Builder(this.activity);
            dialog.CustomView(view, false);
   
            ItemModalDialogFragment itemModalDialogFragment = new ItemModalDialogFragment(view,item,activity);
            itemModalDialogFragment.Create();
            dialog.Show();

        }
        private  void SetAnim(View view)
        {
            Animation animation = AnimationUtils.LoadAnimation(activity.BaseContext, Resource.Animation.cFlipRightIn);
            view.StartAnimation(animation);
        }
        public override    void  OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is CoinViewHolder coinViewHolder)
            {
                cryptoItem = Coins[position];
                StringBuilder coinImageSb = new StringBuilder();
                coinImageSb.Append(Constant.BaseCoinUri);
                coinImageSb.Append(cryptoItem.Info.ImageUrl);                
                Picasso.With(activity).Load(coinImageSb.ToString()).CenterCrop().Fit()
                    .Placeholder(Resource.Drawable.handycrypto_logo).Into(coinViewHolder.CoinImage);
                coinImageSb = null;
                    coinViewHolder.PriceText.Text = cryptoItem.AggregatedData.Price.ToString() ?? "Loading...";
                    coinViewHolder.Title.Text = cryptoItem.Info.Name;
                   // coinViewHolder.Favorite.Checked = isOnFavorites || favorites.Any(x => x.Symbol == cryptoItem.Info.Symbol);


            }
            else
            {

                ProgressViewHolder vp = holder as ProgressViewHolder;
                vp.Progress.Visibility = ViewStates.Visible;
            }


            //SetAnim(coinViewHolder.ItemView);


        }


        public override int GetItemViewType(int position)
        {
            try
            {
                var itemToCheck = Coins[position + 1];
                return itemToCheck != null ? 1 : 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }
        public void Filter(List<CryptoItemModel> newList)
        {
            Coins = newList;
            Coins.AddRange(newList);
            NotifyDataSetChanged();
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            RecyclerView.ViewHolder viewHolder;
            if (viewType == 1)
            {

                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListItem, parent, false);
                viewHolder = new CoinViewHolder(view, OnClick, OnFavoriteClick);
                return viewHolder;
            }

            else
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.progressbar_layout, parent, false);
                viewHolder = new ProgressViewHolder(view);
                return viewHolder;

            }

        }

        private async void OnFavoriteClick(int position, ToggleButton item)
        {
            var crypto = Coins[position];
            if (item.Checked)
            {
                var favCoin = new FavoriteCoin(crypto.Info.Symbol, crypto.Info.Name, crypto.Info.ImageUrl);
                await db.insertUpdateDataAsync(favCoin, false);
                favorites.Add(favCoin);

            }
            else if(!item.Checked&&!isOnFavorites)
            {
                await DeleteItemAsync(crypto);

            }
            else if (!item.Checked && isOnFavorites)
            {
                await DeleteItemAsync(crypto);
                Coins.Remove(crypto);
                NotifyItemRemoved(position);

            }
        }

        private async System.Threading.Tasks.Task DeleteItemAsync(CryptoItemModel item)
        {
            var match = favorites.FirstOrDefault(x => x.Symbol == item.Info.Symbol);
            if (match != null)
            {
                favorites.Remove(match);
                await db.Delete(match);
            }
        }
    }

    public class ProgressViewHolder : RecyclerView.ViewHolder
    {
        public ProgressBar Progress { get; set; }
        public ProgressViewHolder(View itemView) : base(itemView)
        {
            Progress = itemView.FindViewById<ProgressBar>(Resource.Id.recyclerProgress);
        }
    }
}
