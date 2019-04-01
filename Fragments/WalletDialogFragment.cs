using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using CryptoCompare;
using HandyCrypto.Activities;
using HandyCrypto.Adapters;
using HandyCrypto.DataHelper;
using HandyCrypto.Model;
using Java.Util;
using Newtonsoft.Json;
using PortableCryptoLibrary;
using Wdullaer.MaterialDateTimePicker.Date;
using static Wdullaer.MaterialDateTimePicker.Date.DatePickerDialog;
using Calendar = Java.Util.Calendar;
using DatePickerDialog = Wdullaer.MaterialDateTimePicker.Date.DatePickerDialog;

namespace HandyCrypto.Fragments
{
    public class WalletDialogFragment : DialogFragment, IOnDateSetListener
    {
       List<CoinInfo> cryptoCoins;
        Spinner spinner;
        SpinnerAdapter adapter;
        Button timeButton;
        string ImageDb = "ImagesDb.db";
        string OriginalPath  = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        private DataHelper<CoinInfo> coinsDb;
        private DataHelper<Wallet> dbData;
        Button confirmBtn;
        Button cancelBtn;
        DateTime investmentDate;
        EditText investment;
        string dbName = "WalletDb.db";
        private View view;
        private CryptoItemModel cryptoItem;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            coinsDb = new DataHelper<CoinInfo>();

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            view = inflater.Inflate(Resource.Layout.wallet_dialog, container, false);
            Task.Run(async () => await Init());
            

            return view;
        }
        
        public override async void OnResume()
        {
            base.OnResume();
            cryptoCoins = await coinsDb.selectItems();
            cryptoItem = JsonConvert.DeserializeObject<CryptoItemModel>(Arguments.GetString("cryptoDetails"));
            var index = cryptoCoins.FindIndex(x => x.Symbol == cryptoItem.Info.Symbol);
            adapter = new SpinnerAdapter(view.Context, cryptoCoins);
            spinner.Adapter = adapter;
            spinner.SetSelection(index);
            adapter?.NotifyDataSetChanged();
        }
      
        private  async Task Init()
        {
            
            timeButton = view.FindViewById<Button>(Resource.Id.timeBtn);
            investment = view.FindViewById<EditText>(Resource.Id.boughtEditTxt);
            path = Path.Combine(OriginalPath, dbName);

            dbData = new DataHelper<Wallet>();
            await dbData.createDatabase();
            confirmBtn = view.FindViewById<Button>(Resource.Id.submitBtn);
            cancelBtn = view.FindViewById<Button>(Resource.Id.cancelbtn);
            cancelBtn.Click += CancelBtn_Click;
            timeButton.Click += TimeButton_Click;
            confirmBtn.Click += ConfirmBtn_Click;
            spinner = view.FindViewById<Spinner>(Resource.Id.spinner);
            
        }
    
     

        private async void ConfirmBtn_Click(object sender, EventArgs e)
        {
            var basePrice =
                await HandyCryptoClient.Instance.GeneralCoinInfo.GetHistoricalPrice(cryptoItem.Info.Symbol, new[] {"USD"},
                    investmentDate.AddDays(1));
            
            Wallet newWallet = new Wallet(cryptoItem.Info.Symbol, decimal.Parse(investment.Text), investmentDate.ToString(CultureInfo.InvariantCulture))
            {
                CoinPrice = basePrice
            };


            bool contains=false;
           
            await dbData.insertUpdateDataAsync(newWallet, contains);
            Intent intent = new Intent(this.Activity, typeof(WalletActivity));
            intent.SetFlags(ActivityFlags.NoHistory);
            this.StartActivity(intent);
        }
                
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Dismiss();
        }

        public void OnDateSet(Wdullaer.MaterialDateTimePicker.Date.DatePickerDialog view, int year, int monthOfYear, int dayOfMonth)
        {
            investmentDate = new DateTime(year, monthOfYear+1, dayOfMonth);
        }



        private void TimeButton_Click(object sender, EventArgs e)
        {
            Calendar now = Calendar.Instance;
            DatePickerDialog datepicker = NewInstance(this,
                now.Get(CalendarField.Year),
                now.Get(CalendarField.Month),
                now.Get(CalendarField.DayOfMonth));

            datepicker.SetTitle("Enter the date ");
            datepicker.Show(FragmentManager, "Date");
        }
    }
    }