using System.Collections.Generic;
using System.IO;
using System.Linq;
using Currency.Data.Interface;
using Currency.Data.Model;
using Newtonsoft.Json;
using Aspose.Cells;
using Aspose.Cells.Utility;
using System.Globalization;

namespace Currency.Data.Repository
{
    public class CurrencyInfosRepository : ICurrencyInfo
    {

        // Storing the address of the JSON File in String.
        public string jsonFile = @"C:\Users\PB65852\source\repos\WebApplication7\Currency.Data\JsonDataFile\AllCurrencyInfoJsonFile.json";

        private CultureInfo Culture = new CultureInfo("en-US");

        // Defination of the function to get all Objects in the JSON File.
        // Defination of Interface function in ICurrencyInfo Class(List<CurrencyInfo> GetAllCurrencyInfo()).
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
            }
        }

        // Defination of the function to get the specified Objects in the JSON File.
        // Defination of Interface function in ICurrencyInfo Class(CurrencyInfo GetCurrencyInfo(int id)).
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
            }
        }

        // Defination of the function to add new Objects to the JSON File.
        // Defination of Interface function in ICurrencyInfo Class(void AddNewCurrency(CurrencyInfo currencyInfo)).
        public void AddNewCurrency(CurrencyInfo currencyInfo)
        {
            using(StreamReader reader = new StreamReader(jsonFile))
            {
                string CurrencyListString = reader.ReadToEnd();
                List<CurrencyInfo> ListCurrency = JsonConvert.DeserializeObject<List<CurrencyInfo>>(CurrencyListString);

                // ListCurrency.Add(currencyInfo);

                string UpdatedJsonCurrencyList = JsonConvert.SerializeObject(ListCurrency, Formatting.Indented);
                reader.Close();
                File.WriteAllText(jsonFile, UpdatedJsonCurrencyList);
            }
        }

        // Defination of the function to update an existing Objects in the JSON File.
        // Defination of Interface function in ICurrencyInfo Class(void UpdateCurrency(CurrencyInfo currencyInfo)).
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

        // Defination of the function to delete an existing Objects in the JSON File.
        // Defination of Interface function in ICurrencyInfo Class(void DeleteCurrency(int id)).
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

        public void ConvertToCSV()
        {
            string JsonString = File.ReadAllText(jsonFile);
            var workbook = new Workbook();

            // access default empty worksheet
            var worksheet = workbook.Worksheets[0];

            // set JsonLayoutOptions for formatting
            var layoutOptions = new JsonLayoutOptions();
            layoutOptions.ArrayAsTable = true;

            // import JSON data to CSV
            JsonUtility.ImportData(JsonString, worksheet.Cells, 7, 5, layoutOptions);

            // save CSV file
            workbook.Save("output.csv", SaveFormat.Csv);
        }
    }
}
