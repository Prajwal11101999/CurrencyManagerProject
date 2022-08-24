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

        public CurrencyInfoAPIController()
        {

        }


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
        public IActionResult CreateNewCurrency([FromBody] CurrencyInfo currencyInfo)
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

        [Route("Currency/Update")]
        [HttpPut]
        public IActionResult UpdateCurrency([FromBody] CurrencyInfo currencyInfo)
        {
            try
            {
                if (currencyInfo is null)
                {
                    return BadRequest("Owner object is null");
                }
                var currencyinfoEntity = currency.GetCurrencyInfo(currencyInfo.CurrencyId);
                if (currencyinfoEntity is null)
                {
                    return NotFound();
                }
                else
                {
                    currency.UpdateCurrency(currencyInfo);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            return Ok();
            // return RedirectToAction("GetAllCurrencyInfo");
        }

        [Route("Currency/Delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteOwner(int id)
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
                    currency.DeleteCurrency(id);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            return Ok();
            // return RedirectToAction("GetAllCurrencyInfo");
        }
    }
}
