using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HandyCrypto.Model.Interfaces
{
    public interface IWalletService
    {
        
         Task<decimal> CalculateCurrent(DateTime date, Wallet cryptoItem, string currency, string symbol, decimal invest);
         Task<ObservableCollection<HistoricalDataModel>> CalculateHistorical(DateTime date, string currency, string symbol, decimal invest,decimal originalPrice);
    }
}