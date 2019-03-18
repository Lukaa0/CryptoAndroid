using Android.App;
using Android.Widget;
using Android.OS;
using PortableCryptoLibrary;
using System.Collections.Generic;
using App5.Adapters;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Android.Content;
using Android.Support.V7.AppCompat;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Graphics;

namespace App5
{
    [Activity(Label = "App5", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        CoinRecyclerViewAdapter coinRecyclerViewAdapter;
        Android.Support.V7.Widget.Toolbar toolbar;
        ImageView logo;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
           
            SetContentView(Resource.Layout.Main);
            FindViews();
            //logo.Visibility = Android.Views.ViewStates.Visible;
            //toolbar.Visibility = Android.Views.ViewStates.Invisible;
            var coins = await WebServiceSingleton.Instance.GetApiAsync<List<CryptoItem>>("https://api.coinmarketcap.com/v1/ticker/");
            layoutManager = new GridLayoutManager(this,3,GridLayoutManager.Horizontal,false);
            recyclerView.SetLayoutManager(layoutManager);
            coinRecyclerViewAdapter = new CoinRecyclerViewAdapter(coins, this);
            recyclerView.SetAdapter(coinRecyclerViewAdapter);
            //logo.Visibility = Android.Views.ViewStates.Invisible;
            //logo.Visibility = Android.Views.ViewStates.Gone;
            //toolbar.Visibility = Android.Views.ViewStates.Visible;

            //SetSupportActionBar(toolbar);
            //SupportActionBar.Title = "All coins";


        }

        private void FindViews()
        {
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            //toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //logo = FindViewById<ImageView>(Resource.Id.noLogo);

        }
        private void CoinListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = WebServiceSingleton.Instance.GetApi<List<CryptoItem>>("https://api.coinmarketcap.com/v1/ticker/")[e.Position];
            var intent = new Intent();
            intent.SetClass(this, typeof(DetailActivity));
            intent.PutExtra("cryptoID", item.id);
            StartActivity(intent);
        }

    } 
}

