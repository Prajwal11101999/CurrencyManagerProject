using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Currency.Data.Interface;
using Currency.Data.Model;
using Currency.Data.Repository;
using System.Web;


namespace WebApplication7.Controllers
{
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

        [Route("Currency/ById/{id}")]
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

                currency.AddNewCurrency(currencyInfo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            return RedirectToAction("GetAllCurrencyInfo");
        }

        [Route("Currency/Update/{id}")]
        [HttpPut]
        public ActionResult UpdateCurrency(int id, [FromBody] CurrencyInfo currencyInfo)
        {
            try
            {
                if (currencyInfo is null)
                {
                    return BadRequest("Owner object is null");
                }
                var currencyinfoEntity = currency.GetCurrencyInfo(id);
                if (currencyinfoEntity is null)
                {
                    return NotFound();
                }
                currency.UpdateCurrency(currencyInfo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            return RedirectToAction("GetAllCurrencyInfo");
        }

        [Route("Currency/Delete/{id}")]
        [HttpDelete]
        public ActionResult DeleteOwner(int id)
        {
            try
            {
                var currencyInfo = currency.GetCurrencyInfo(id);
                if (currencyInfo == null)
                {
                    return NotFound();
                }
                else
                {
                    currency.DeleteCurrency(currencyInfo);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            return RedirectToAction("GetAllCurrencyInfo");
        }
    }
}
