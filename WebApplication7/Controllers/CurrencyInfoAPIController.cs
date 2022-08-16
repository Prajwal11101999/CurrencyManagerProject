using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Currency.Data.Interface;
using Currency.Data.Model;
using Currency.Data.Repository;


namespace WebApplication7.Controllers
{
    // [Route("api/CurrencyInfo")]
    [ApiController]
    public class CurrencyInfoAPIController : ControllerBase
    {
        private ICurrencyInfo currency = new CurrencyInfosRepository();

        [Route("Currency/All")]
        [HttpGet]
        public ActionResult<IEnumerable<CurrencyInfo>> GetAllCurrencyInfo()
        {
            return currency.GetAllCurrencyInfo();
        }

        [Route("Currency/ById/{id:int}")]
        [HttpGet]
        public ActionResult<CurrencyInfo> GetCurrencyInfoById(int id)
        {
            return currency.GetCurrencyInfo(id);
        }

        [Route("Currency/AddNew")]
        [HttpPost]
        public ActionResult CreateNewCurrency([FromBody] CurrencyInfo currencyInfo)
        {
            try
            {
                if (currencyInfo is null)
                {
                    return BadRequest("Owner object is null");
                }
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest("Invalid model object");
                //}

                currency.AddNewCurrency(currencyInfo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            return RedirectToAction("GetAllCurrencyInfo");
        }
    }
}
