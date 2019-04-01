using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using CryptoCompare;
using HandyCrypto.Adapters;
using HandyCrypto.DataHelper;
using HandyCrypto.Model;
using PortableCryptoLibrary;
using PortableCryptoServices;

namespace HandyCrypto.Activities
{
    [Activity(Label = "WalletActivity")]
    public partial class WalletActivity : AppCompatActivity

    {
        RecyclerView recyclerView;
        private List<WalletModel> walletModels;
        public List<Wallet> wallets { get; private set; }
        LinearLayoutManager layoutManager;
        private DataHelper<CoinInfo> dbCoins;
        WalletRecyclerViewAdapter coinRecyclerViewAdapter;

        private List<CoinInfo> coins;
        private WalletService walletService;


        public DataHelper<Wallet> db { get; private set; }


        public OnScrollListenerWallet ScrollListener { get; private set; }

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.wallet_main_layout);
            dbCoins = new DataHelper<CoinInfo>();
            coins = new List<CoinInfo>();
            walletService = new WalletService();
            await dbCoins.createDatabase();
            coins = await dbCoins.selectItems();
            db = new DataHelper<Wallet>();
            await db.createDatabase();
            wallets = await DbInitAsync();
            DateTime nm = new DateTime();


           
            layoutManager = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.walletRecyclerView);

            walletModels = new List<WalletModel>();
            LoadItems();
            SetAdapter(recyclerView);
            List<Task> tasks = new List<Task>();
            tasks.Add(LoadPriceData());
            tasks.Add(CalculateBudgetAsync());
            tasks.Add(CalculateChartDataAsync());
            await Task.WhenAll(tasks).ConfigureAwait(false);
            ScrollListener = new OnScrollListenerWallet(layoutManager, coinRecyclerViewAdapter);
            //recyclerView.AddOnScrollListener(ScrollListener);




        }

        private async Task UpdateHistoricalData(WalletModel item)
        {
            var date = DateTime.Parse(item.Wallet.InvestDate,
                CultureInfo.InvariantCulture);
            var histoData = await walletService.CalculateHistorical(date, "USD", item.Info.Symbol,
                item.Wallet.Investment.ToDecimalWithCulture(), item.Wallet.CoinPrice);
            coinRecyclerViewAdapter.AddChartData(histoData, item.Wallet.Id);
        }
        private async Task UpdateBudget(WalletModel item)
        {

            var date = DateTime.Parse(item.Wallet.InvestDate, CultureInfo.InvariantCulture);
            var result = await walletService.CalculateCurrent(date, item.Wallet, "USD",
                item.Info.Symbol,
                item.Wallet.Investment);
            coinRecyclerViewAdapter.AddBudgetValue(result, item.Wallet.Id);
        }

        private async Task CalculateBudgetAsync()
        {
            try
            {
                List<Task> tasks = new List<Task>();
                if (walletModels != null)
                {
                    for (int i = 0; i < walletModels.Count; i++)
                    {
                        var task = this.UpdateBudget(walletModels[i]);
                        tasks.Add(task);
                    }

                    await Task.WhenAll(tasks);


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private async Task CalculateChartDataAsync()
        {
            try
            {

                if (walletModels != null)
                {
                    List<Task> tasks = new List<Task>();
                    for (int i = 0; i < walletModels.Count; i++)
                    {
                        tasks.Add(this.UpdateHistoricalData(walletModels[i]));
                    }

                    await Task.WhenAll(tasks);
                }





            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
    private async Task LoadPriceData()
        {
            try
            {
                if (walletModels != null)
                {


                    var symbols = walletModels.Select(x => x.Info.Symbol).ToArray();
                    var prices = await HandyCryptoClient.Instance.GeneralCoinInfo.GetPriceData(symbols);
                    foreach (var t in prices)
                    {
                        var items = walletModels.FindAll(x => x.Info.Symbol == t.FromSymbol);
                        for (int j = 0; j < items.Count; j++)
                        {
                            var index = walletModels.FindIndex(x => x.Info.Id == items[j].Info.Id);
                            walletModels[index].AggregatedData = t;
                        }

                    }


                    coinRecyclerViewAdapter.Update(walletModels);



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        private async void SListener_LoadMoreEvent(object sender, EventArgs e, int position)
        {
            //coinRecyclerViewAdapter.AddAndRefresh(cryptoModel);

        }
        private void LoadItems()
        {
            foreach (var item in wallets)
            {
                var coinItem = coins.FirstOrDefault(x => x.Symbol == item.Symbol);
                WalletModel model = new WalletModel();
                model.Info = coinItem;
                model.Wallet = item;
                
                
                walletModels.Add(model);

            }
        }

        private void SetAdapter(RecyclerView recycler)
        {
            var context = recycler.Context;
            recycler.SetLayoutManager(layoutManager);
            SnapHelper snap = new LinearSnapHelper();

            snap.AttachToRecyclerView(recycler);

            coinRecyclerViewAdapter = new WalletRecyclerViewAdapter(walletModels, this, recyclerView);
            recycler.SetAdapter(coinRecyclerViewAdapter);
        }



        private async Task<List<Wallet>> DbInitAsync()
        {
            var myWallet = await db.selectItems();
            return myWallet;
        }




    }
}