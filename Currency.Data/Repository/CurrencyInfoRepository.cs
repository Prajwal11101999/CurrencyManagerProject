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
    }
}
