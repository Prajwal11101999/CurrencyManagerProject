using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currency.Data.Model
{
    public class CurrencyInfo
    {
        public int CurrencyId { get; set; }
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyAbbreviation { get; set; }
        public float ConvertedINRValue { get; set; }
    }
}
