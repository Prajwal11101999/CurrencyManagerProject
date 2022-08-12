using System;
using System.Collections.Generic;
using System.Text;
using Currency.Data.Model;

namespace Currency.Data.Interface
{
    public interface ICurrencyInfo
    {
        List<CurrencyInfo> GetAllCurrencyInfo();
        CurrencyInfo GetCurrencyInfo(int id);
    }
}
