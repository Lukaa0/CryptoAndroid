using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCompare;
using PortableCryptoLibrary;
using PortableCryptoServices;

namespace HandyCrypto.Model
{
    public static class  DataUtility
    {
        public static async Task<List<CryptoItemModel>> PopulateAndGetData(List<FavoriteCoin> data)
        {
            var models = new List<CryptoItemModel>();
            var priceData = new List<IReadOnlyDictionary<string, CoinFullAggregatedData>>();
            var priceResponse = new PriceMultiFullResponse();


            try
            {
                var symbols = data.Select(x => x.Symbol).ToList();
                priceResponse = await CryptoCompareClient.Instance.Prices.MultipleSymbolFullDataAsync(symbols, new[] { "USD" });
                priceData = priceResponse.Raw.Values.ToList();
                for (int i = 0; i < priceData.Count; i++)
                {
                    var pData = priceData[i].Values.ToList()[0];
                    var info = HandyCryptoClient.Instance.GeneralCoinInfo.GetInfoById(pData.FromSymbol);
                    models.Add(new CryptoItemModel(info,pData)
                    {
                        IsFavorite = true
                    });
                }

            }
            catch (Exception)
            {

            }


            return models;
        }
    }
}