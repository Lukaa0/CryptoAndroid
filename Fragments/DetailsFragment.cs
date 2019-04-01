using Android;
using Android.OS;
using Android.Views;
using Android.Widget;
using HandyCrypto.Activities;
using HandyCrypto.Model;
using Newtonsoft.Json;
using PortableCryptoLibrary;

namespace HandyCrypto.Fragments
{
    public class DetailsFragment : Android.Support.V4.App.Fragment
    {
        private TextView percentOne;
        private TextView percent24;
        private TextView percent7;
        private TextView price;
        private TextView volume;
        private TextView marketCap;
        private TextView rank;
        private TextView symbol;
        private CryptoItemModel cryptoItem;

        public override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            cryptoItem = JsonConvert.DeserializeObject<CryptoItemModel>(Arguments.GetString("cryptoDetails"));

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.detail_page_items_layout, container, false);

            Init(view);
            return view;
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Activity.RunOnUiThread(() => Assign());

        }
        public void Init(View view)
        {
            percentOne = view.FindViewById<TextView>(Resource.Id.percentChange1H);
            percent24 = view.FindViewById<TextView>(Resource.Id.percentChange24H);
            percent7 = view.FindViewById<TextView>(Resource.Id.percentChange7D);
            volume = view.FindViewById<TextView>(Resource.Id.Volume);
            marketCap = view.FindViewById<TextView>(Resource.Id.MarketCap);
            rank = view.FindViewById<TextView>(Resource.Id.Rank);
            price = view.FindViewById<TextView>(Resource.Id.Price);
            symbol = view.FindViewById<TextView>(Resource.Id.Symbol);
        }
        public void Assign()
        {

            rank.Text = cryptoItem.Info.SortOrder.ToString() ?? "N/A";
            symbol.Text = cryptoItem.Info.Symbol ?? "N/A";
            volume.Text = cryptoItem.AggregatedData.LastVolume.ToString() ?? "N/A";
            marketCap.Text = cryptoItem.AggregatedData.MarketCap.ToString() ?? "N/A";
            price.Text = cryptoItem.AggregatedData.Price.ToString()?? "N/A";
            percent24.Text = cryptoItem.AggregatedData.ChangePCT24Hour.ToString() ?? "N/A";
            percent7.Text = cryptoItem.AggregatedData.ChangePCTDay.ToString() ?? "N/A";
            percentOne.Text = cryptoItem.AggregatedData.ChangePCT24Hour.ToString() ?? "N/A";
            
        }
    }
}