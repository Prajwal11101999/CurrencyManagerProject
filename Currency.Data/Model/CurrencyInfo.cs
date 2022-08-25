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
