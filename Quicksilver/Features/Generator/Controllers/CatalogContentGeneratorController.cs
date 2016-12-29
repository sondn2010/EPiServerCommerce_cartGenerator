using EPiServer.Commerce.Order;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Reference.Commerce.Site.Features.Generator.Pages;
using EPiServer.Reference.Commerce.Site.Features.Product.Models;
using EPiServer.Security;
using EPiServer.Web.Mvc;
using Mediachase.Commerce;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Core;
using Mediachase.Commerce.InventoryService;
using Mediachase.Commerce.Pricing;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EPiServer.Reference.Commerce.Site.Features.Start.Controllers
{
    public class CatalogContentGeneratorController : PageController<CatalogContentGeneratorPage>
    {
        private IContentRepository _contentRepository;
        private ReferenceConverter _referenceConverter;
        private IInventoryService _inventoryService;
        private IPriceDetailService _priceDetailService;
        private Random rnd = new Random();

        private IList<string> _names = new string[] { "Men", "Women" };
        private IList<string> _names2 = new string[] { "T-shirt", "Shoes", "Hat", "Hood", "Jacket", "Shirt" };
        private IList<string> _colors = new string [] { "red", "blue", "green", "black", "yellow" };
        private IList<string> _sizes = new string[] { "S", "M", "L", "XL", "XXL" };

        public CatalogContentGeneratorController(IContentRepository contentRepository, ReferenceConverter referenceConverter, IInventoryService inventoryService, IPriceDetailService priceDetailService)
        {
            _contentRepository = contentRepository;
            _referenceConverter = referenceConverter;
            _inventoryService = inventoryService;
            _priceDetailService = priceDetailService;
        }

        public ViewResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public ViewResult Index(FormCollection collection)
        {
            var nodeCode = string.IsNullOrEmpty(collection["nodeCode"]) ? "Fashion" : collection["nodeCode"];
            var numberOfShipment = string.IsNullOrEmpty(collection["numberOfCart"]) ? 1 : int.Parse(collection["numberOfCart"]);
            var numberOfItem = string.IsNullOrEmpty(collection["numberOfCart"]) ? 1 : int.Parse(collection["numberOfCart"]);
            
            return View();
        }





        private void CreateVariations(ContentReference parentLink, int numberOfVariation)
        {
            for (int i = 0; i < numberOfVariation; i++)
            {
                var content = _contentRepository.GetDefault<FashionVariant>(parentLink);
                content.Code = parentLink + rnd.Next(1, 1000).ToString() + "ItemContentCode" + i;
                content.Name = "FashionItemContent new- index" + i;
                var contentRef = _contentRepository.Save(content, SaveAction.Publish, AccessLevel.NoAccess);

                AddInventory(content.Code, 10);
                AddPrice(content.Code, rnd.Next(30, 99));
            }
        }
        private void AddInventory(string entryCode, decimal inStockQuantity)
        {
            if (inStockQuantity <= 0) return;

            _inventoryService.Save(new[] { new InventoryRecord
            {
                CatalogEntryCode = entryCode,
                PurchaseAvailableQuantity = inStockQuantity,
                WarehouseCode = "default"
            }});
        }

        private void AddPrice(string entryCode, decimal price)
        {
            var priceValue = new PriceDetailValue
            {
                CatalogKey = new CatalogKey(AppContext.Current.ApplicationId, entryCode),
                MarketId = "DEFAULT",
                CustomerPricing = CustomerPricing.AllCustomers,
                MinQuantity = 0,
                ValidFrom = DateTime.Now.AddDays(-7),
                ValidUntil = DateTime.Now.AddYears(7),
                UnitPrice = new Money(price, "USD")
            };

            _priceDetailService.Save(priceValue);
        }

        private void CreateProducts(ContentReference parentLink, int numberOfProduct, int numberOfVariation)
        {
            for (int i = 0; i < numberOfProduct; i++)
            {
                var content = _contentRepository.GetDefault<FashionProduct>(parentLink);
                content.Code = parentLink + rnd.Next(1, 1000).ToString() + "FashionProductc" + i;
                content.Name = "FashionProductContent new -index" + i;
                var contentRef = _contentRepository.Save(content, SaveAction.Publish, AccessLevel.NoAccess);

                CreateVariations(contentRef, numberOfVariation);
            }
        }


    }
}