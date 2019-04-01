using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using CryptoCompare;
using HandyCrypto.Activities;
using HandyCrypto.Adapters;
using HandyCrypto.DataHelper;
using HandyCrypto.Fragments;
using HandyCrypto.Model;
using System;
using System.Collections.Generic;
using HandyCrypto;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PortableCryptoLibrary;
using Com.Syncfusion.Sfbusyindicator;
using Syncfusion.Android.TabView;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Database;
using BR.Com.Mauker.MaterialSearchViewLib;
using Com.Andremion.Floatingnavigationview;
using Java.Lang;
using Syncfusion.Android.ProgressBar;

namespace HandyCrypto
{
    [Activity(Label = "HandyCrypto", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity,MaterialSearchView.IOnQueryTextListener
    {
        private MaterialSearchView searchView;
        private AllCoinsFragment coinsFragment;
        private ViewPagerAdapter viewPagerAdapter;
        private FloatingNavigationView FabView;
        private FavoritesFragment favoritesFragment;
        private Android.Support.V7.Widget.Toolbar toolbar;
        private SfLinearProgressBar linearProgressBar;
        private ViewPager viewPager;
        private TabLayout tabLayout;

        protected override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
                "NjE0NjhAMzEzNjJlMzQyZTMwZWQ1TFBJVFNTSXprNXl0TnJEdGRraHN2b1p5SlMxYkt6UjlGYWVHR0EvYz0=");
            Initialize();
            FindViews();
            SetSupportActionBar(toolbar);
            SetupViewPager(viewPager);
            tabLayout.SetupWithViewPager(viewPager);
            tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.all_coins);
            tabLayout.GetTabAt(1).SetIcon(Resource.Drawable.ic_favorite_red_dark_36dp);
            FabView.Click += (sender, e) => { FabView.Open(); };
            //searchView.SetOnQueryTextListener(this);
            //var coinNames = coinsFragment.coins.Select(x => x.CoinName);
            //searchView.AddSuggestions(coinNames);




        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.wallet_nav:
                {
                    StartActivity(typeof(WalletActivity));
                    break;
                }

                case Resource.Id.set_icon:
                {
                    StartActivity(typeof(ChatActivity));
                    break;
                }



            }
            return base.OnOptionsItemSelected(item);
        }
        public void SetupViewPager(ViewPager viewPager)
        {
            viewPagerAdapter.AddFragment(coinsFragment, "All Coins");
            viewPagerAdapter.AddFragment(favoritesFragment, "Favorites");
            viewPager.Adapter = viewPagerAdapter;
            
            
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu,menu);
            return true;
            
        }
        private void Initialize()
        {
            coinsFragment = new AllCoinsFragment();
            viewPagerAdapter = new ViewPagerAdapter(SupportFragmentManager);
            favoritesFragment = new FavoritesFragment();
        }

        private void FindViews()
        {
            viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            FabView = FindViewById<FloatingNavigationView>(Resource.Id.floating_navigation_view);
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarMain);
            
        }

        public bool OnQueryTextSubmit(string query)
        {
            return false;
        }

        public bool OnQueryTextChange(string newText)
        {
            return false;
        }

        public bool OnQueryTextCleared()
        {
            return false;
        }
    }

   

}
    

