using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Models;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVetDirectoryService _vetDirectoryService;
        private readonly IParsingService _parsingService;
        public HomeController(ILogger<HomeController> logger, IVetDirectoryService vetDirectoryService, IParsingService parsingService)
        {
            this._vetDirectoryService = vetDirectoryService;
            this._parsingService = parsingService;
            this._logger = logger;
        }

        #region Get
        public async Task<ActionResult> IndexAsync()
        {
            return View();
        }
        public async Task<ActionResult> ProductDetails()
        {
            IEnumerable<Product> products = null;
            try
            {
                products = _vetDirectoryService.GetAllProducts();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View(products.ToList());
        }


        public async Task<ActionResult> StoreDetails()
        {
            IEnumerable<Store> stores = null;
            try
            {
                stores = _vetDirectoryService.GetAllStores();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View(stores.ToList());
        }

        [HttpGet]
        public async Task<JsonResult> GetProductsAsync()
        {
            IEnumerable<Product> products = null;
            try
            {
                products = await _parsingService.GetAndTransformProducts();
                await _vetDirectoryService.InsertProductsAsync(products.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(data: ex.Message);
            }
            return Json(new
            {
                redirectUrl = Url.Action("ProductDetails", "Home"),
                isRedirect = true
            });
        }

        [HttpGet]
        public async Task<JsonResult> GetStoresAsync()
        {
            IEnumerable<Store> stores = null;
            try
            {
                stores = await _parsingService.GetAndTransformStores();
                await _vetDirectoryService.InsertStoresAsync(stores.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(data: ex.Message);
            }
            return Json(new
            {
                redirectUrl = Url.Action("StoreDetails", "Home"),
                isRedirect = true
            });
        }
        #endregion

        #region Post

        [HttpPost]
        public async Task<JsonResult> GetProductsFromApi()
        {
            IEnumerable<Product> products = null;
            try
            {
                products = await _parsingService.GetAndTransformProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { data = "", msg = ex.Message });
            }
            return Json(data: products);
        }

        [HttpPost]
        public async Task<JsonResult> GetStoresFromApi()
        {
            IEnumerable<Store> stores = null;
            try
            {
                stores = await _parsingService.GetAndTransformStores();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Json(new { data = "", msg = ex.Message });
            }
            return Json(data: stores);
        }
        [HttpPost]
        public IActionResult Privacy()
        {
            return Json(data: null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region Delete

        public async Task<IActionResult> DeleteAllProductsAsync()
        {
            try
            {
                var products = _vetDirectoryService.GetAllProducts();
                if (products != null && products.Any())
                    await _vetDirectoryService.RemoveProductsAsync(products.ToList());
            }
            catch (Exception ex)
            {
                return RedirectToAction("ProductDetails");
            }
            return RedirectToAction("ProductDetails");
        }

        public async Task<IActionResult> DeleteAllStoresAsync()
        {
            try
            {
                var stores = _vetDirectoryService.GetAllStores();
                if (stores != null && stores.Any())
                    await _vetDirectoryService.RemoveStoresAsync(stores.ToList());
            }
            catch (Exception ex)
            {
                return RedirectToAction("StoreDetails");
            }
            return RedirectToAction("StoreDetails");
        }

        #endregion
    }
}
