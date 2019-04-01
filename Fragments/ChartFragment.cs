using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using CryptoCompare;
using HandyCrypto.Model;
using Newtonsoft.Json;
using PortableCryptoLibrary;
using Syncfusion.Android.Buttons;

namespace HandyCrypto.Fragments
{
    public class ChartFragment : Android.Support.V4.App.Fragment
    {
        private SfSegmentedControl segmentedChartTime;
        private SfSegmentedControl segmentedChartType;
        private CryptoItemModel cryptoItem;
        private SfChart sfChart;
        private delegate Task<List<CandleData>> HistoricalDataDelegate(
            string symbol,
            string currency,
            int? limit,
            bool? allData = null,
            DateTimeOffset? toDate = null,
            string exchangeName = "CCCCAG",
            int? aggregate = null,
            bool? tryConvention = null
        );
        private HistoricalDataDelegate dayDel;
        private ObservableCollection<OhlcDataModel> ohlcData;
        private HistoricalDataDelegate hourDel;
        private HistoricalDataDelegate minuteDel;
        private ChartSeries _series;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            cryptoItem = JsonConvert.DeserializeObject<CryptoItemModel>(Arguments.GetString("cryptoDetails"));

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom parentView for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.chart_detail_layout, container, false);
            FindViews(view);
            dayDel = HandyCryptoClient.Instance.GeneralCoinInfo.GetHistoricalDayPrices;
            minuteDel = HandyCryptoClient.Instance.GeneralCoinInfo.GetHistoricalMinutePrices;
            hourDel = HandyCryptoClient.Instance.GeneralCoinInfo.GetHistoricalHourPrices;
            ConfigureSegment(view);
            InitChart();
            _series = new AreaSeries()
            {
                ItemsSource = ohlcData,
                
                ColorModel = new ChartColorModel(ChartColorPalette.Custom),
                Color = Color.Aqua,
                XBindingPath = "Date",
                YBindingPath = "Close"
            };
            sfChart.Series.Add(_series);
            return view;

        }
        private void FindViews(View view)
        {
            segmentedChartTime = view.FindViewById<SfSegmentedControl>(Resource.Id.segment_chartType);
            segmentedChartType = view.FindViewById<SfSegmentedControl>(Resource.Id.segment_chartTime);
            sfChart = view.FindViewById<SfChart>(Resource.Id.detail_chart);

        }
        private async Task GetHitoricalData(HistoricalDataDelegate chartData, string symbol, string
            currency, int? limit, bool? allData = null, DateTime? toDate = null, bool? 
            tryConvention = null, int? aggregate = null, string exchangeName = "CCCAGG")
        {
            var histoData = await chartData(symbol, currency, limit, allData, toDate, exchangeName, aggregate, tryConvention);
            ohlcData = new ObservableCollection<OhlcDataModel>();
            foreach (var t in histoData)
            {
                ohlcData.Add(new OhlcDataModel(t.Time.DateTime, t.Close, t.Open, t.High, t.Low));
            }
        }

        private double GetMin()
        {
             return Convert.ToDouble(ohlcData.Min(x => x.Close));
        }
        private double GetMax()
        {
            return Convert.ToDouble(ohlcData.Max(x => x.Close));
        }

        public void InitChart()
        {
            sfChart.Series.Clear();
            sfChart.Behaviors.Clear();
            DateTimeCategoryAxis dateTimeAxis = new DateTimeCategoryAxis();
            dateTimeAxis.LabelStyle.LabelFormat = "dd/MMM HH:mm";
            NumericalAxis numericalAxis = new NumericalAxis()
            {
                AutoIntervalOnZoomingEnabled = true,
                RangePadding = NumericalPadding.Additional,
                
            };
            sfChart.PrimaryAxis = dateTimeAxis;
            sfChart.SecondaryAxis = numericalAxis;
            CustomTrackBallBehavior trackballBehavior = new CustomTrackBallBehavior
            {
                ShowLabel = true,
                ShowLine = true,
                LabelDisplayMode = TrackballLabelDisplayMode.FloatAllPoints
            };
            trackballBehavior.LabelStyle.LabelFormat = "0.####";
            ChartZoomPanBehavior zoomPan = new ChartZoomPanBehavior()
            {
                ScrollingEnabled = true,
                ZoomingEnabled = false,



            };
            sfChart.Behaviors.Add(trackballBehavior);
            sfChart.Behaviors.Add(zoomPan);
            
        }
        private void TypeSegmentedControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    {
                        sfChart.Series.Clear();
                        _series = new AreaSeries()
                        {
                            ItemsSource = ohlcData,
                            ColorModel = new ChartColorModel(ChartColorPalette.Custom),
                            
                            Color = Color.Aqua,
                            XBindingPath = "Date",
                            YBindingPath = "Close"
                        };
                        sfChart.Series.Add(_series);
                        break;
                    }
                case 1:
                    {
                        sfChart.Series.Clear();
                        var series = new HiLoOpenCloseSeries()
                        {
                            ItemsSource = ohlcData,
                            XBindingPath = "Date",
                            Open = "Open",
                            High = "High",
                            Low = "Low",
                            Close = "Close",
                            Name = "OHLC",
                            EnableAnimation = true,

                        };
                        
                        sfChart.Series.Add(series);
                        break;
                    }

            }
        }

        private async void SegmentedChartTimeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    {
                        await GetHitoricalData(minuteDel, cryptoItem.Info.Symbol, "USD", 60);
                        RefreshChartSeries();

                        break;
                    }
                case 1:
                    {
                        await GetHitoricalData(hourDel, cryptoItem.Info.Symbol, "USD", 24);

                        RefreshChartSeries();
                        break;
                    }
                case 2:
                    {
                        await GetHitoricalData(dayDel, cryptoItem.Info.Symbol, "USD", 7);
                        RefreshChartSeries();
                        break;
                    }
                case 3:
                    {
                        await GetHitoricalData(dayDel, cryptoItem.Info.Symbol, "USD", 360);
                        RefreshChartSeries();
                        break;
                    }
                case 4:
                    {
                        await GetHitoricalData(dayDel, cryptoItem.Info.Symbol, "USD", null, true);
                        RefreshChartSeries();
                        break;
                    }
            }
        }

        private void RefreshChartSeries()
        {
            sfChart.Series[0].ItemsSource = ohlcData;
            ((NumericalAxis)sfChart.SecondaryAxis).Minimum = Math.Round(GetMin(),4);
            sfChart.RedrawChart();
        }
        private void ConfigureSegment(View view)
        {
            try
            {
                var typedValue = new Android.Util.TypedValue();
                this.Activity.Theme.ResolveAttribute(Resource.Attribute.colorPrimary, typedValue, true);
                var colorObject = Application.Context.GetDrawable(typedValue.ResourceId);
                var colorPrimary = ((Android.Graphics.Drawables.ColorDrawable)colorObject).Color;
                segmentedChartTime.SelectionChanged += SegmentedChartTimeSelectionChanged;
                segmentedChartTime.FontColor = Color.Black;
                segmentedChartTime.BorderColor = new Color(colorPrimary);
                segmentedChartTime.VisibleSegmentsCount = 5;
                segmentedChartTime.DisplayMode = SegmentDisplayMode.Text;
                string[] items = new string[5] { "1 Hour", "1 Day", "1 Week", "1 Year", "All time" };
                segmentedChartTime.ItemsSource = items;
                segmentedChartType.Visibility = ViewStates.Visible;
                segmentedChartType.DisplayMode = SegmentDisplayMode.Image;
                ImageView[] images = new ImageView[2];
                images[0] = new ImageView(this.Activity);
                images[0].SetImageResource(Resource.Drawable.ic_timeline_yellow_dark_24dp);
                images[1] = new ImageView(this.Activity);
                images[1].SetImageResource(Resource.Drawable.candlestick_icon);
                //segmentedChartTime.SelectionTextColor = new Color(vibrantColor);
                segmentedChartType.BorderColor = new Color(colorPrimary);
                segmentedChartType.FontColor = new Color(colorPrimary);
                segmentedChartType.VisibleSegmentsCount = 2;
                segmentedChartType.ItemsSource = images;
                segmentedChartType.SelectionChanged += TypeSegmentedControl_SelectionChanged;
                segmentedChartTime.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
  
}