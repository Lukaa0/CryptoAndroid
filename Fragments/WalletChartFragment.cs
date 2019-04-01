using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Com.Syncfusion.Charts;
using HandyCrypto.Model;
using Newtonsoft.Json;
using PortableCryptoServices;

namespace HandyCrypto.Fragments
{
    public class WalletChartFragment : Android.Support.V4.App.Fragment
    {
        private SfChart chart;
        private Wallet wallet;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            
            View view = inflater.Inflate(Resource.Layout.crypto_chart, container, false);
            wallet = JsonConvert.DeserializeObject<Wallet>(Arguments.GetString("wItem"));
            
            
            Initiate(view);
            
            return view;
        }
        public void Initiate(View view)
        {
            chart = view.FindViewById<SfChart>(Resource.Id.wallet_chart);
            //progressBar = view.FindViewById<ProgressBar>(Resource.Id.chartProgress);
        }
        
        public override async void OnResume()
        {
            base.OnResume();
            await GetHistoricalData(wallet, chart);
        }
        public async Task GetHistoricalData(Wallet wal,SfChart chart)
        {
            chart.Series.Clear();
            chart.Behaviors.Clear();
            var data = await new WalletService().CalculateHistorical(Convert.ToDateTime(wal.InvestDate), "USD", wal.Symbol.ToUpper(),
                wal.Investment.ToDecimalWithCulture(),(decimal)232.21);



            

            DateTimeCategoryAxis dateTimeAxis = new DateTimeCategoryAxis();
            NumericalAxis numericalAxis = new NumericalAxis();
            chart.PrimaryAxis = dateTimeAxis;
            chart.SecondaryAxis = numericalAxis;
            ChartTrackballBehavior trackballBehavior = new ChartTrackballBehavior
            {
                ShowLabel = true,
                ShowLine = true,
                LabelDisplayMode = TrackballLabelDisplayMode.FloatAllPoints
            };
            ChartZoomPanBehavior zoomPan = new ChartZoomPanBehavior()
            {
                ScrollingEnabled = true,
                ZoomingEnabled = false,



            };

            chart.Behaviors.Add(trackballBehavior);
            var techData = new LineSeries()
            {
                ItemsSource = data,
                XBindingPath="Date",
                YBindingPath="Price",
                EnableAnimation = true,

            };

            chart.Series.Add(techData);
            chart.Behaviors.Add(zoomPan);





        }
    }
}