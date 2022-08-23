using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Currency.Data.Interface;
using Currency.Data.Model;
using Currency.Data.JsonDataFile;
using System.Text.Json;


namespace Currency.Data.Repository
{
    public class CurrencyInfosRepository : ICurrencyInfo
    { 
        public List<CurrencyInfo> GetAllCurrencyInfo()
        {
            var ListCurrency = JsonSerializer.Deserialize<List<CurrencyInfo>>()
        }

        public CurrencyInfo GetCurrencyInfo(int id)
        {
            return ListCurrency.FirstOrDefault(x => x.CurrencyId == id);
        }

        public void AddNewCurrency(CurrencyInfo currencyInfo)
        {
            if(ListCurrency.Count == 0)
            {
                ListCurrency.Add(new CurrencyInfo { CurrencyId = 1, CountryName = currencyInfo.CountryName, CurrencyName = currencyInfo.CurrencyName, CurrencyAbbreviation = currencyInfo.CurrencyAbbreviation, ConvertedINRValue = currencyInfo.ConvertedINRValue });
            }
            else
            {
                ListCurrency.Add(new CurrencyInfo { CurrencyId = ListCurrency.Count + 1, CountryName = currencyInfo.CountryName, CurrencyName = currencyInfo.CurrencyName, CurrencyAbbreviation = currencyInfo.CurrencyAbbreviation, ConvertedINRValue = currencyInfo.ConvertedINRValue });
            }
        }

        public void UpdateCurrency(CurrencyInfo currencyInfo)
        {
            foreach (var item in ListCurrency)
            {
                if (item.CurrencyId == currencyInfo.CurrencyId)
                {
                    item.CurrencyId = currencyInfo.CurrencyId;
                    item.CountryName = currencyInfo.CountryName;
                    item.CurrencyName = currencyInfo.CurrencyName;
                    item.CurrencyAbbreviation = currencyInfo.CurrencyAbbreviation;
                    item.ConvertedINRValue = currencyInfo.ConvertedINRValue;
                    break;
                }
            }
        }

        public void DeleteCurrency(int id)
        {
            foreach (var item in ListCurrency)
            {
                if (item.CurrencyId == id)
                {
                    ListCurrency.Remove(item);
                    break;
                }
            }
        }
    }
}
