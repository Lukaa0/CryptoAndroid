using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Syncfusion.Sfbusyindicator;
using CryptoCompare;
using HandyCrypto.Activities;
using HandyCrypto.Adapters;
using HandyCrypto.DataHelper;
using HandyCrypto.Model;
using PortableCryptoLibrary;
using Syncfusion.Android.ProgressBar;
using Syncfusion.Android.TabView;

namespace HandyCrypto.Fragments
{
    public class AllCoinsFragment : Android.Support.V4.App.Fragment
    {
        RecyclerView recyclerView;
        public List<CoinInfo> coins { get; set; }
        private List<CryptoItemModel> cryptoModel;
        bool isLoading = false;
        GridLayoutManager layoutManager;
        private CoinRecyclerViewScrollListener onScrollListener;
        CoinRecyclerViewAdapter coinRecyclerViewAdapter;
        List<FavoriteCoin> favorites;
        CoordinatorLayout mainLayout;
        Bundle Data;
        string basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        private DataHelper<CoinInfo> db;
        private DataHelper<FavoriteCoin> faveDb;
        private View view;
        SfBusyIndicator progressBar;
        private SfTabView tabView;
        private string coinlistPath;
        private string favoritesPath;

           
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            favorites = new List<FavoriteCoin>();



        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             view = inflater.Inflate(Resource.Layout.all_coins_layout, container, false);
            progressBar = view.FindViewById<SfBusyIndicator>(Resource.Id.progressBarMain);
            FindViews();
            return view;
        }
        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            progressBar.AnimationType = Com.Syncfusion.Sfbusyindicator.Enums.AnimationTypes.MovieTimer;
            progressBar.IsBusy = true;
            progressBar.Visibility = ViewStates.Visible;
            progressBar.Title = "Loading...";
            db = new DataHelper<CoinInfo>();
            faveDb = new DataHelper<FavoriteCoin>();
            await db.createDatabase();
            await faveDb.createDatabase();
            coins = await DbInit();
            favorites = await faveDb.selectItems()??new List<FavoriteCoin>();
            HandyCryptoClient.Instance.GeneralCoinInfo.Coins = coins;

            cryptoModel = await HandyCryptoClient.Instance.GeneralCoinInfo.Construct(0, 150);
            //search = FindViewById<MaterialSearchView>(Resource.Id.searchv);
            //search.SetOnQueryTextListener(this);
            Data = new Bundle();

            //images = await DbInit();







            layoutManager = new GridLayoutManager(Activity, 3, GridLayoutManager.Vertical, false);

            onScrollListener = new CoinRecyclerViewScrollListener(layoutManager);
            recyclerView.AddOnScrollListener(onScrollListener);

            onScrollListener.LoadMoreEvent += OnScrollListener_LoadMoreEvent;
            SetAdapterWithAnim(recyclerView);
            progressBar.Visibility = ViewStates.Gone;
        }

        public class GridSpan : GridLayoutManager.SpanSizeLookup
        {
            public CoinRecyclerViewAdapter mAdapter { get; set; }
            public GridSpan(CoinRecyclerViewAdapter adapter)
            {
                mAdapter = adapter;
            }
            public override int GetSpanSize(int position)
            {
                return mAdapter.GetItemViewType(position) == 0 ? 3 : 1;

            }
        }









        private async void OnScrollListener_LoadMoreEvent(object sender, EventArgs e, int position)
        {
            var model = await HandyCryptoClient.Instance.GeneralCoinInfo.Construct(position,60);
            coinRecyclerViewAdapter.AddAndRefresh(model);
            onScrollListener.isLoading = false;
        }

        private void WalletNav_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Activity, typeof(WalletActivity)));
            Activity.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
        public override async void SetMenuVisibility(bool menuVisible)
        {
            base.SetMenuVisibility(menuVisible);
            if (menuVisible&&faveDb!=null)
            {
                favorites = await faveDb.selectItems()??new List<FavoriteCoin>();
                coinRecyclerViewAdapter.ReplaceAndRefresh(favorites);
            }
        }

        private void SetAdapterWithAnim(RecyclerView recycler)
        {
            var context = recycler.Context;
            layoutManager.ItemPrefetchEnabled = true;
            recycler.SetLayoutManager(layoutManager);
            coinRecyclerViewAdapter = new CoinRecyclerViewAdapter(cryptoModel, Activity, 
                Activity.SupportFragmentManager, faveDb,favorites,false);
            var gridSpan = new GridSpan(coinRecyclerViewAdapter);
            layoutManager.SetSpanSizeLookup(gridSpan);
            recycler.SetItemViewCacheSize(30);
            recycler.DrawingCacheQuality = DrawingCacheQuality.High;
            recycler.DrawingCacheEnabled = true;
            recycler.SetAdapter(coinRecyclerViewAdapter);

            

        }


        private async Task<List<CoinInfo>> DbInit()
        {
            var items = await db.selectItems();



            if (items.Count == 0 || items == null)
            {
                bool isFinished = false;
                while (!isFinished)
                {
                    try
                    {
                        progressBar.Title = "First time load...";
                        var coinData =
                            (await CryptoCompareClient.Instance.Coins.ListAsync()).Coins.Values.OrderBy(
                                x => x.SortOrder);
                        
                        await db.InsertAllAsnyc(coinData);
                        isFinished = true;
                        return coinData.ToList();
                    }
                    catch (WebException ex)
                    {
                        
                        Toast.MakeText(this.Activity, "Unresponsive network, retrying...", ToastLength.Long).Show();
                    }
                }
            }

            progressBar.Title = "Loading coins...";
            return items;
        }

        private void FindViews()
        {
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.mainRecyclerView);
            db = new DataHelper<CoinInfo>();
            

            //help = FindViewById<ImageView>(Resource.Id.help_toolbar);

        }

        
    }
}