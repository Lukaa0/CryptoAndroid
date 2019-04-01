using System;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Clans.Fab;
using Com.Syncfusion.Charts;
using HandyCrypto.Model;

namespace HandyCrypto.View_Holders
{
    public class WalletViewHolder:RecyclerView.ViewHolder
    {
        public TextView PercentHour { get; set; }
        public TextView PercentDay { get; set; }
        public FloatingActionButton floatingDeleteButton { get; set; }
        private FloatingActionMenu fMenu;
        public TextView PercentWeek { get; set; }
        public TextView Rank { get; set; }
        public TextView MarketCap { get; set; }
        public TextView PriceTrackBall { get; set; }
        public TextView DateTrackBall { get; set; }
        public SfChart Chart { get; set; }
        public TextView TotalSupply { get; set; }
        public CryptoScrollView scrollView { get; set; }
        public ImageView Image { get; set; }
        public TextView PercentAllTime { get; set; }
        public TextView upCoinTtle { get; private set; }
        public TextView budgetTxt { get; private set; }

        // public SfChart chart { get; private set; }
        // public Button chartButton { get; private set; }

        public WalletViewHolder(View view, Action<int> actionListener,Action<int> fabDelListener) : base(view)
        {
            PercentHour = view.FindViewById<TextView>(Resource.Id.percentHour);
            PercentDay = view.FindViewById<TextView>(Resource.Id.percentDay);
            PercentWeek = view.FindViewById<TextView>(Resource.Id.percentWeek);
            floatingDeleteButton = view.FindViewById<FloatingActionButton>(Resource.Id.fab_del);
            MarketCap = view.FindViewById<TextView>(Resource.Id.MarketCap);
            Rank = view.FindViewById<TextView>(Resource.Id.Rank);
            Chart = view.FindViewById<SfChart>(Resource.Id.wallet_chart);
            TotalSupply = view.FindViewById<TextView>(Resource.Id.totalSupply);
            Image = view.FindViewById<ImageView>(Resource.Id.walletCoinImage);
            upCoinTtle = view.FindViewById<TextView>(Resource.Id.upTitle2);
            budgetTxt = view.FindViewById<TextView>(Resource.Id.wallet_profit2);
           // chart = view.FindViewById<SfChart>(Resource.Id.walletChartPage);
           // chartButton = view.FindViewById<Button>(Resource.Id.chartButton);
            PercentAllTime = view.FindViewById<TextView>(Resource.Id.percentAllTime);
            PriceTrackBall = view.FindViewById<TextView>(Resource.Id.wallet_track_price_txt);
            DateTrackBall = view.FindViewById<TextView>(Resource.Id.wallet_track_date_txt);
            fMenu = view.FindViewById<FloatingActionMenu>(Resource.Id.fab_menu);
            scrollView = view.FindViewById<CryptoScrollView>(Resource.Id.wallet_item_scrollview);
            scrollView.OnScrollDown += delegate { fMenu.HideMenu(true); };
            scrollView.OnScrollUp += delegate { fMenu.ShowMenu(true); };



            view.Click += (sender, e) => actionListener(base.LayoutPosition);
            floatingDeleteButton.Click += (sender, e) => fabDelListener(base.LayoutPosition);

        }

       
    }
}