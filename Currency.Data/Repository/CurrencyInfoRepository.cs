using System.Collections.Generic;
using System.IO;
using System.Linq;
using Currency.Data.Interface;
using Currency.Data.Model;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Json.Net;
using Newtonsoft.Json;

namespace Currency.Data.Repository
{
    public class CurrencyInfosRepository : ICurrencyInfo
    {
        public string jsonFile = @"C:\Users\PB65852\source\repos\WebApplication7\Currency.Data\JsonDataFile\AllCurrencyInfoJsonFile.json";
        public List<CurrencyInfo> GetAllCurrencyInfo()
        {
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                string CurrencyListString = reader.ReadToEnd();
                List<CurrencyInfo> ListCurrency = JsonConvert.DeserializeObject<List<CurrencyInfo>>(CurrencyListString);
                reader.Close();
                if (ListCurrency != null)
                {
                    return ListCurrency;
                }
                else
                {
                    return null;
                }
                //try
                //{
                //    string CurrencyListString = reader.ReadToEnd();
                //    List<CurrencyInfo> ListCurrency = JsonConvert.DeserializeObject<List<CurrencyInfo>>(CurrencyListString);
                //    if (ListCurrency != null)
                //    {
                //        return ListCurrency;
                //    }
                //    else
                //    {
                //        return null;
                //    }
                //}
                //catch (System.Exception)
                //{
                //    throw;
                //}
                //finally
                //{
                //    reader.Close();
                //}
            }
        }

        public CurrencyInfo GetCurrencyInfo(int id)
        {
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                string CurrencyListString = reader.ReadToEnd();
                List<CurrencyInfo> ListCurrency = JsonConvert.DeserializeObject<List<CurrencyInfo>>(CurrencyListString);
                reader.Close();
                if (ListCurrency != null)
                {
                    return ListCurrency.FirstOrDefault(x => x.CurrencyId == id);
                }
                else
                {
                    return null;
                }
                //try
                //{
                //    string CurrencyListString = reader.ReadToEnd();
                //    List<CurrencyInfo> ListCurrency = JsonConvert.DeserializeObject<List<CurrencyInfo>>(CurrencyListString);
                //    if (ListCurrency != null)
                //    {
                //        return ListCurrency.FirstOrDefault(x => x.CurrencyId == id);
                //    }
                //    else
                //    {
                //        return null;
                //    }
                //}
                //catch (System.Exception)
                //{
                //    throw;
                //}
                //finally
                //{
                //    reader.Close();
                //
            }
        }

        public void AddNewCurrency(CurrencyInfo currencyInfo)
        {
            using(StreamReader reader = new StreamReader(jsonFile))
            {
                string CurrencyListString = reader.ReadToEnd();
                List<CurrencyInfo> ListCurrency = JsonConvert.DeserializeObject<List<CurrencyInfo>>(CurrencyListString);
                ListCurrency.Add(currencyInfo);

                string UpdatedJsonCurrencyList = JsonConvert.SerializeObject(ListCurrency, Formatting.Indented);
                reader.Close();
                File.WriteAllText(jsonFile, UpdatedJsonCurrencyList);
            }
            //var ListCurrency = System.Text.Json.JsonSerializer.Deserialize<List<CurrencyInfo>>(jsonFile);
            //if (ListCurrency.Count == 0)
            //{
            //    ListCurrency.Add(new CurrencyInfo { CurrencyId = 1, CountryName = currencyInfo.CountryName, CurrencyName = currencyInfo.CurrencyName, CurrencyAbbreviation = currencyInfo.CurrencyAbbreviation, ConvertedINRValue = currencyInfo.ConvertedINRValue });
            //}
            //else
            //{
            //    ListCurrency.Add(new CurrencyInfo { CurrencyId = ListCurrency.Count + 1, CountryName = currencyInfo.CountryName, CurrencyName = currencyInfo.CurrencyName, CurrencyAbbreviation = currencyInfo.CurrencyAbbreviation, ConvertedINRValue = currencyInfo.ConvertedINRValue });
            //}
        }

        public void UpdateCurrency(CurrencyInfo currencyInfo)
        {
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                string CurrencyListString = reader.ReadToEnd();
                List<CurrencyInfo> ListCurrency = JsonConvert.DeserializeObject<List<CurrencyInfo>>(CurrencyListString);
                for (int i = 0; i < ListCurrency.Count; i++)
                {
                    if(ListCurrency[i].CurrencyId == currencyInfo.CurrencyId)
                    {
                        ListCurrency[i].CurrencyId = currencyInfo.CurrencyId;
                        ListCurrency[i].CountryName = currencyInfo.CountryName;
                        ListCurrency[i].CurrencyName = currencyInfo.CurrencyName;
                        ListCurrency[i].CurrencyAbbreviation = currencyInfo.CurrencyAbbreviation;
                        ListCurrency[i].ConvertedINRValue = currencyInfo.ConvertedINRValue;
                    }
                }

                string UpdatedJsonCurrencyList = JsonConvert.SerializeObject(ListCurrency, Formatting.Indented);
                reader.Close();
                File.WriteAllText(jsonFile, UpdatedJsonCurrencyList);
            }
        }

        public void DeleteCurrency(int id)
        {
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                string CurrencyListString = reader.ReadToEnd();
                List<CurrencyInfo> ListCurrency = JsonConvert.DeserializeObject<List<CurrencyInfo>>(CurrencyListString);
                ListCurrency.Remove(ListCurrency.SingleOrDefault(x => x.CurrencyId == id));

                string UpdatedJsonCurrencyList = JsonConvert.SerializeObject(ListCurrency, Formatting.Indented);
                reader.Close();
                File.WriteAllText(jsonFile, UpdatedJsonCurrencyList);
            }
        }
    }
}
