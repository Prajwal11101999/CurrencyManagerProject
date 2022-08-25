using System.Collections.Generic;
using Currency.Data.Model;

namespace Currency.Data.Interface
{
    public interface ICurrencyInfo
    {
        List<CurrencyInfo> GetAllCurrencyInfo();
        CurrencyInfo GetCurrencyInfo(int id);
        void AddNewCurrency(CurrencyInfo currencyInfo);
        void UpdateCurrency(CurrencyInfo currencyInfo);
        void DeleteCurrency(int id);
        void ConvertToCSV();
        ConversionInfo ExchangeToINR(CurrencyInfo currencyInfo, int num);
    }
}
