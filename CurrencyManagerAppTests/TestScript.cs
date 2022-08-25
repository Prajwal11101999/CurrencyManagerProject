using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication7.Controllers;
using System;

namespace CurrencyManagerAppTests
{
    [TestClass]
    public class TestScript
    {
        // TestCase to check if we are getting all the CurrencyInfo From JsonFile
        [TestMethod]
        public void TestGetAllCurrencyInfo()
        {
            var testcontroller = new CurrencyInfoAPIController();
            var testresult = testcontroller.GetAllCurrencyInfo();
            Assert.IsNotNull(testresult);
            Console.WriteLine("All the Data is Fetched from the JsonFile by Controller and is Displayed.");
        }

        // TestCase to check if we are getting a specified CurrencyInfo Data From the JsonFile
        [TestMethod]
        public void TestGetCurrencyById()
        {
            int id = 1;
            var testcontroller = new CurrencyInfoAPIController();
            var testresult = testcontroller.GetCurrencyInfoById(id);
            Assert.IsNotNull(testresult);
            Console.WriteLine("The Specified CurrencyInfo Data is Fetched from the JsonFile by Controller and is Displayed.");
        }

    }
}
