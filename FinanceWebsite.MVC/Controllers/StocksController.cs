using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FinanceWebsite.MVC.Models;

namespace FinanceWebsite.MVC.Controllers
{
    public class StocksController : Controller
    {
        #region Constructors and Destructors

        public StocksController()
        {
        }

        #endregion

        #region Public APIs

        // GET: Stock
        [Route("stocks/index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // No [Route] neededed.  Gets /Movies/Create
        public ActionResult Quote(StockQuote viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            return View("Quote", viewModel);
        }

        //[HttpGet]
        //[Route("stocks/history")]
        //public async Task<JsonResult> GetStockHistory(string tickerSymbol, DateTime beginDate, DateTime endDate)
        //{
        //    ViewBag.SyncOrAsync = "Asynchronous";

        //    var something = await Historical.GetPriceAsync(
        //                tickerSymbol,
        //                beginDate,
        //                endDate);

        //    return Json(
        //        new
        //        {
        //            HistoricalPrice = something
        //        },
        //        JsonRequestBehavior.AllowGet);
        //}

        #endregion

        #region Private Methods

        #endregion
    }
}