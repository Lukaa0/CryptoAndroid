using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CryptoCompare;
using HandyCrypto.Model.Interfaces;
using PortableCryptoLibrary;
using PortableCryptoServices;

namespace HandyCrypto.Model
{
    public  class WalletService  :IWalletService
    {
        public  async Task<decimal> CalculateCurrent(DateTime date, Wallet cryptoItem, string currency, string symbol, decimal invest)
        {
            try
             {
                var histoPriceTask =  HandyCryptoClient.Instance.GeneralCoinInfo.GetHistoricalPrice(symbol, new[] {currency}, date);
                 var currentPriceTask = HandyCryptoClient.Instance.GeneralCoinInfo.GetPrice(symbol,currency);
                 await Task.WhenAll(histoPriceTask, currentPriceTask);
                 var item = await histoPriceTask;
                 var currentPrice = await currentPriceTask;
                decimal budget = 0;
                decimal cryptoValue = invest / item;
                budget = (cryptoValue * currentPrice);
                 var result = Math.Round(budget, 6);
                return result;
            }
            catch (DivideByZeroException ex)
            {
                return 0;
            }
        }
        public async  Task<ObservableCollection<HistoricalDataModel>> CalculateHistorical(DateTime date, string currency, string symbol, decimal invest,decimal originalPrice)
        {
            
            var now = DateTime.Now;
            var limit = Convert.ToInt32((now - date).TotalHours);
            ObservableCollection<HistoricalDataModel> historicalPrices = new ObservableCollection<HistoricalDataModel>();
            var data = await HandyCryptoClient.Instance.GeneralCoinInfo.GetHistoricalHourPrices(symbol, currency, limit);
            var orderedData = data.OrderBy(x => x.Time);


            foreach(var item in orderedData)
            {

                var price = (item.Close / originalPrice) * invest;
                var model = new HistoricalDataModel(item.Time.DateTime, price);
                historicalPrices.Add(model);

            }
            return historicalPrices;
        }
    }
}