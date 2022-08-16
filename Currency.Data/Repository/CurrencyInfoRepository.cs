using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Currency.Data.Interface;
using Currency.Data.Model;

namespace Currency.Data.Repository
{
    public class CurrencyInfosRepository : ICurrencyInfo
    {
        List<CurrencyInfo> ListCurrency = new List<CurrencyInfo>
        {
            new CurrencyInfo{CurrencyId = 1, CurrencyName = "USA Dollar", CurrencyAbbreviation = "USD" , CurrencyValue = 1, ConvertedINRValue = 0},
            new CurrencyInfo{CurrencyId = 2, CurrencyName = "Afghanistan Afghani", CurrencyAbbreviation = "AFN" , CurrencyValue = 1, ConvertedINRValue = 0},
            // new CurrencyInfo{CurrencyId = 2, CurrencyName = "Afghanistan Afghani", CurrencyAbbreviation = "AFN" , CurrencyValue = 1, ConvertedINRValue = 0}
        };
        public List<CurrencyInfo> GetAllCurrencyInfo()
        {
            return ListCurrency;
        }

        public CurrencyInfo GetCurrencyInfo(int id)
        {
            return ListCurrency.FirstOrDefault(x => x.CurrencyId == id);
        }

        public void AddNewCurrency(CurrencyInfo currencyInfo)
        {
            ListCurrency = new List<CurrencyInfo>
            {
                new CurrencyInfo{CurrencyId = ListCurrency.Count + 1 , CurrencyName = currencyInfo.CurrencyName , CurrencyAbbreviation = currencyInfo.CurrencyAbbreviation , CurrencyValue = 1, ConvertedINRValue = currencyInfo.ConvertedINRValue}
            };
        }

        public void UpdateCurrency(CurrencyInfo currencyInfo)
        {
            foreach (var item in ListCurrency)
            {
                if(item.CurrencyId == currencyInfo.CurrencyId)
                {
                    item.CurrencyName = currencyInfo.CurrencyName;
                    item.CurrencyAbbreviation = currencyInfo.CurrencyAbbreviation;
                    item.CurrencyValue = currencyInfo.CurrencyValue;
                    item.ConvertedINRValue = currencyInfo.ConvertedINRValue;
                }
            }
        }

        public void DeleteCurrency(CurrencyInfo currencyInfo)
        {
            foreach (var item in ListCurrency)
            {
                if (item.CurrencyId == currencyInfo.CurrencyId)
                {
                    ListCurrency.Remove(item);
                }
            }
        }
    }
}
