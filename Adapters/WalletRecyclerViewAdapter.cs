using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Provider;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Syncfusion.Charts;
using HandyCrypto.Activities;
using HandyCrypto.DataHelper;
using HandyCrypto.Fragments;
using HandyCrypto.Model;
using HandyCrypto.View_Holders;
using Newtonsoft.Json;
using PortableCryptoLibrary;
using Square.Picasso;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace HandyCrypto.Adapters
{
    public class WalletRecyclerViewAdapter : RecyclerView.Adapter
    {
        public List<WalletModel> Coins{ get; set; }

        private Activity activity;
        private RecyclerView recView;
        private static readonly object syncLock = new object();
        public event EventHandler<int> ItemClick;
        private WalletModel cryptoItem;
        private ObservableCollection<HistoricalDataModel> historicalDataItem;
        private string CoinUrl;
        private string baseImageUrl = Constant.BaseCoinUri;

        public WalletRecyclerViewAdapter(List<WalletModel> coins, Activity act, RecyclerView _recView)
        {
            activity = act;
            Coins = coins;
            recView = _recView;

        }

        public void AddAndRefresh(List<WalletModel> data)
        {
            Coins.AddRange(data);
            NotifyDataSetChanged();

        }

        public override int ItemCount => Coins.Count;

        public void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public void Update(List<WalletModel> data)
        {
            Coins = data;
            NotifyDataSetChanged();

        }
        public void AddBudgetValue(decimal result,int walletId)
        {
            try
            {
                var position = Coins.FindIndex(x => x.Wallet.Id == walletId);
                Coins[position].CurrentBudget = result;
                NotifyItemChanged(position);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            
        }

        public void AddChartData(ObservableCollection<HistoricalDataModel> historicalData, int walletId)
        {
            try
            {
                var position = Coins.FindIndex(x => x.Wallet.Id == walletId);
                Coins[position].HistoricalData = historicalData;
                activity.RunOnUiThread(() => { NotifyItemChanged(position); });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            WalletViewHolder walletViewHolder = holder as WalletViewHolder;
            cryptoItem = Coins[position];
            CoinUrl = cryptoItem.Info.ImageUrl;
            string currentImageUrl = baseImageUrl + CoinUrl;
            try
            {

                Picasso.With(activity).Load(currentImageUrl).Into(walletViewHolder.Image);
                activity.RunOnUiThread(() =>
                {

                    //    walletViewHolder.Rank.Text = $"Rank {cryptoItem.rank}";

                    //    walletViewHolder.PercentDay.Text = $"Percent Change(1D): {cryptoItem.percent_change_24h}";
                    //    walletViewHolder.PercentHour.Text = $"Percent Change(1H): {cryptoItem.percent_change_1h}";
                    //    walletViewHolder.PercentWeek.Text = $"Percent Change(1W): {cryptoItem.percent_change_7d}";
                    //    walletViewHolder.TotalSupply.Text = $"Total Supply: {cryptoItem.total_supply}";
                    walletViewHolder.MarketCap.Text = cryptoItem.AggregatedData == null ? $"Market Cap: Loading" : $"Market Cap: {cryptoItem.AggregatedData.Price}";


                    ChartAsync(walletViewHolder, position);
                    walletViewHolder.budgetTxt.Text = cryptoItem.CurrentBudget.ToString(CultureInfo.InvariantCulture);


                });


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            try
            {


                activity.RunOnUiThread(() =>
                {
                    walletViewHolder.upCoinTtle.Text = cryptoItem.Info.Name.ToUpper();
                    walletViewHolder.PercentAllTime.Text = cryptoItem.PercentAllTime.ToString("P") ?? "Loading...";
                    Animation a = AnimationUtils.LoadAnimation(this.activity, Resource.Animation.abc_slide_in_bottom);
                    a.Duration = 500;
                    a.Reset();
                    walletViewHolder.budgetTxt.ClearAnimation();
                    walletViewHolder.budgetTxt.StartAnimation(a);
                    walletViewHolder.PercentAllTime.ClearAnimation();
                    walletViewHolder.PercentAllTime.StartAnimation(a);
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

       


        public void ChartAsync(WalletViewHolder viewHolder, int position)
        {
            historicalDataItem = Coins[position].HistoricalData;
            if (historicalDataItem == null || historicalDataItem.Count <= 0) return;
            try
            {
                var chart = viewHolder.Chart;
                chart.Series.Clear();
                
                DateTimeCategoryAxis dateTimeAxis = new DateTimeCategoryAxis()
                {
                    ShowTrackballInfo = true
                };
                NumericalAxis priceAxis = new NumericalAxis();

                chart.PrimaryAxis = dateTimeAxis;
                priceAxis.TrackballLabelStyle.LabelAlignment = ChartLabelAlignment.Far;
                chart.SecondaryAxis = priceAxis;
                CustomTrackBallBehavior trackballBehavior = new CustomTrackBallBehavior
                {
                    ShowLabel = true,
                    ShowLine = true,

                };
                ChartZoomPanBehavior zoomPan = new ChartZoomPanBehavior()
                {
                    ScrollingEnabled = false,
                    ZoomingEnabled = true,


                };

                chart.Series.Add(GetChartSeries());
                chart.Behaviors.Add(trackballBehavior);
                chart.Behaviors.Add(zoomPan);
                chart.Focusable = false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
        private AreaSeries GetChartSeries()
        {
            var series = new AreaSeries()
            {
                ItemsSource = historicalDataItem,

                XBindingPath = "Date",

                YBindingPath = "Price",

                ShowTrackballInfo = true,
                TooltipEnabled = true,
                EnableAnimation=true


            };
            return series;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.wallet_layout, parent, false);
            WalletViewHolder walletViewHolder = new WalletViewHolder(view, OnClick,OnDeleteClick);
            return walletViewHolder;
        }

        private async void OnDeleteClick(int position)
        {
            var item = Coins[position];
            var accessKey = item.Wallet.Id;
            var walletActivity = (WalletActivity) activity;
            var walletDbItem = walletActivity.wallets.Find(x => x.Id == accessKey);
            if (walletDbItem != null) await walletActivity.db.Delete(walletDbItem);
            Coins.Remove(item);
            this.NotifyItemRemoved(position);
        }
    }
}