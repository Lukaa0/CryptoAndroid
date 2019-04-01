using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Sfbusyindicator;
using HandyCrypto.DataHelper;
using HandyCrypto.Fragments;
using HandyCrypto.Model;
using Newtonsoft.Json;
using PortableCryptoLibrary;
using PortableCryptoServices;
using Square.Picasso;
using Syncfusion.Android.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CryptoCompare;
using Android.Util;
using System.Linq;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using HandyCrypto.Adapters;
using System.Diagnostics;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using BottomNavigationBar;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Fragment = Android.Support.V4.App.Fragment;

namespace HandyCrypto
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : AppCompatActivity, BottomNavigationBar.Listeners.IOnMenuTabClickListener
    {
        Bitmap bitmap = null;
        Android.Support.V7.Widget.Toolbar toolbar;
        private DetailsFragment detailFragment;
        DataHelper<Wallet> db;
        private TabLayout tabLayout;
        private ImageView image;
        private TextView title;
        private BottomBar _bottomBar;
        private Stopwatch stopWatch = new Stopwatch();
        private TextView toolbarPrice;
        private ChartFragment ChartFragment = new ChartFragment();
        private ImageView addToWallet;
        private View mainLayout;
        private CryptoItemModel cryptoItem;
        private string cryptoId;
        private string imgUrl;

        
        //LinearLayout fragStrip;
        //LinearLayout tabStrip;
        Bundle chartData;
        Bundle coinInfoData;
        private Android.Support.V4.App.FragmentTransaction detailFragmentTransaction;
        List<Android.Support.V4.App.Fragment> fragments;

        private int vibrantColor;
        private int mutedColor;
        private int mutedDarkColor;
        private int mutedLightColor;
        private int darkVibrantColor;
        private int lightVibrantColor;
        LinearLayout mainContainer;
        private WalletDialogFragment walletDialogFragment;
        private Android.Support.V4.App.FragmentTransaction fragmentTransaction;
        private SfBusyIndicator progressBar;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DetailPage);
            SetTheme(Resource.Style.Theme_AppCompat_DayNight_DarkActionBar);
            Initialization();
            _bottomBar = BottomBar.Attach(this, savedInstanceState);
            _bottomBar.SetItems(Resource.Menu.menu_navigation_bar);
            _bottomBar.NoTopOffset();
            _bottomBar.MapColorForTab(0, "#7B1FA2");
            _bottomBar.MapColorForTab(1, "#FF5252");
            // ConfigureSegment();


        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            _bottomBar.OnSaveInstanceState(outState);
        }


        public override async void OnAttachedToWindow()
        { 
            base.OnAttachedToWindow();


            //SetValues();
            cryptoItem.Info = HandyCryptoClient.Instance.GeneralCoinInfo.GetInfoById(cryptoId);
            imgUrl = string.Concat(Constant.BaseCoinUri, cryptoItem.Info.ImageUrl);
            cryptoItem.AggregatedData = await HandyCryptoClient.Instance.GeneralCoinInfo.GetPriceData(cryptoItem.Info.Symbol);
            Picasso.With(this).Load(imgUrl).Into(image);
            toolbarPrice.Text = cryptoItem.AggregatedData.Price.ToString();
            SetPalette();
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            coinInfoData.PutString("cryptoDetails", JsonConvert.SerializeObject(cryptoItem));
            ChartFragment.Arguments = coinInfoData;
            walletDialogFragment.Arguments = coinInfoData;
            detailFragment.Arguments = coinInfoData;
            _bottomBar.SetOnMenuTabClickListener(this);
            addToWallet.Click += AddToWallet_Click;
            title.Text = cryptoItem.Info.Name;
            
           
                        Console.WriteLine(stopWatch.Elapsed);

        }
        private void AddToWallet_Click(object sender, EventArgs e)
        {
            Android.App.FragmentTransaction dialogTransaction = FragmentManager.BeginTransaction();
            walletDialogFragment.Show(dialogTransaction, "dialog");
        }
        

        


        private void SetPalette()
        {
            BitmapDrawable bitmapDrawable = (BitmapDrawable)image.Drawable;
            bitmap = bitmapDrawable.Bitmap;
            var palette = new Palette.Builder(bitmap).Generate();
            SetPalette(palette);
        }
        private void Initialization()
        {
            cryptoId = Intent.Extras.GetString("cryptoItem");
            cryptoItem = new CryptoItemModel();
            detailFragment = new DetailsFragment();

            walletDialogFragment = new WalletDialogFragment();
            fragmentTransaction = SupportFragmentManager.BeginTransaction();

            fragments = new List<Android.Support.V4.App.Fragment>();
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarDetail);
            //mainContainer = FindViewById<LinearLayout>(Resource.Id.main_container);
            db = new DataHelper<Wallet>();
            //tabStrip = FindViewById<LinearLayout>(Resource.Id.tabStrip);
            // infoButton = FindViewById<Button>(Resource.Id.infoStrip);
            addToWallet = FindViewById<ImageView>(Resource.Id.addto_wallet);
            image = FindViewById<ImageView>(Resource.Id.detailPageImage);
            title = FindViewById<TextView>(Resource.Id.detailPageTitle);
            addToWallet = FindViewById<ImageView>(Resource.Id.addto_wallet);
            mainLayout = FindViewById(Resource.Id.detailLayout);
            toolbarPrice = FindViewById<TextView>(Resource.Id.detailPageToolbarPrice);
            chartData = new Bundle();
            coinInfoData = new Bundle();

        }
       



       

       

        public void SetPalette(Palette palette)
        {
            var defaultcolor = Color.ParseColor("#00363a");
            vibrantColor = palette.GetVibrantColor(defaultcolor);
            mutedColor = palette.GetMutedColor(defaultcolor);
            darkVibrantColor = palette.GetDarkVibrantColor(defaultcolor);
            lightVibrantColor = palette.GetLightVibrantColor(defaultcolor);
            mutedColor = palette.GetMutedColor(defaultcolor);
            mutedDarkColor = palette.GetDarkMutedColor(defaultcolor);
            mutedLightColor = palette.GetLightMutedColor(defaultcolor);


        }



        public void OnMenuTabSelected(int menuItemId)
        {
            switch (menuItemId)
            {
                case Resource.Id.navbar_item_charts:
                {
                    OpenFragment(ChartFragment);
                    break;
                }
                case Resource.Id.navbar_item_details:
                {
                    OpenFragment(detailFragment);
                    break;
                }

            }
        }
        private void OpenFragment(Fragment fragment)
        {
            FragmentTransaction transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.detail_container, fragment);
            transaction.AddToBackStack(null);
            transaction.Commit();

        }
        public void OnMenuTabReSelected(int menuItemId)
        {
        }

        }
    }
