﻿using EPiServer.Commerce.Marketing;
using EPiServer.Commerce.Order;
using EPiServer.Reference.Commerce.Site.Features.Start.Pages;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Mediachase.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EPiServer.Reference.Commerce.Site.Features.Start.Controllers
{
    public class CartGeneratorController : PageController<CartGeneratorPage>
    {
        private readonly IOrderRepository _orderRepository;
        
        static string _defaultName = "Default";

        #region ListOfEntryCodes
        private List<string> _listOfEntryCodes = new List<string> { "SKU-40797394",
"SKU-40797396",
"SKU-40797399",
"SKU-40797402",
"SKU-40797405",
"SKU-40797409",
"SKU-40797413",
"SKU-40797417",
"SKU-40797420",
"SKU-40797423",
"SKU-40797426",
"SKU-40707713",
"SKU-40707735",
"SKU-40707740",
"SKU-40707746",
"SKU-40800952",
"SKU-40707751",
"SKU-40707717",
"SKU-40707721",
"SKU-40707730",
"SKU-40801260",
"SKU-40707703",
"SKU-41136685",
"SKU-41136683",
"SKU-41136682",
"SKU-41136681",
"SKU-41136684",
"SKU-41136726",
"SKU-41136690",
"SKU-41136688",
"SKU-41136687",
"SKU-41136686",
"SKU-41136689",
"SKU-42313640",
"SKU-42313641",
"SKU-42313642",
"SKU-42313643",
"SKU-42313644",
"SKU-42313635",
"SKU-42313636",
"SKU-42313637",
"SKU-42313638",
"SKU-42313639",
"SKU-42313650",
"SKU-43093280",
"SKU-43093282",
"SKU-43093281",
"SKU-43093283",
"SKU-43093284",
"SKU-40835688",
"SKU-42340084",
"SKU-42340065",
"SKU-42340072",
"SKU-42340074",
"SKU-42340076",
"SKU-42340078",
"SKU-42340080",
"SKU-42340066",
"SKU-42340067",
"SKU-42340069",
"SKU-42340070",
"SKU-38424528",
"SKU-38424545",
"SKU-38424534",
"SKU-38424537",
"SKU-38424552",
"SKU-40707729",
"SKU-40707701",
"SKU-40707709",
"SKU-40707712",
"SKU-40707716",
"SKU-40707722",
"SKU-40707749",
"SKU-40707754",
"SKU-40707758",
"SKU-40707763",
"SKU-40707768",
"SKU-40707883",
"SKU-40707863",
"SKU-40707865",
"SKU-40707868",
"SKU-40707872",
"SKU-40707876",
"SKU-40707823",
"SKU-40707827",
"SKU-40707831",
"SKU-40707834",
"SKU-40707837",
"SKU-39745548",
"SKU-39745549",
"SKU-39745550",
"SKU-39745551",
"SKU-39745552",
"SKU-39745553",
"SKU-39745554",
"SKU-39745555",
"SKU-39745556",
"SKU-39745557",
"SKU-39745558",
"SKU-39672546",
"SKU-39672553",
"SKU-39745507",
"SKU-39672555",
"SKU-39672557",
"SKU-39672558",
"SKU-39745508",
"SKU-39745512",
"SKU-39745514",
"SKU-39745516",
"SKU-39745518",
"SKU-39672756",
"SKU-39672734",
"SKU-39672735",
"SKU-39672736",
"SKU-39745411",
"SKU-39672737",
"SKU-39672738",
"SKU-39672739",
"SKU-39672740",
"SKU-39672741",
"SKU-39672742",
"SKU-40825889",
"SKU-40825924",
"SKU-40825907",
"SKU-40826012",
"SKU-40825957",
"SKU-40825939",
"SKU-40826000",
"SKU-37001733",
"SKU-37001258",
"SKU-37001235",
"SKU-37001236",
"SKU-37001237",
"SKU-37001239",
"SKU-37001732",
"SKU-37001251",
"SKU-37001253",
"SKU-37001263",
"SKU-37001265",
"SKU-41680136",
"SKU-41680139",
"SKU-41693982",
"SKU-41680141",
"SKU-41680142",
"SKU-41680144",
"SKU-41680146",
"SKU-41693990",
"SKU-41693999",
"SKU-41680148",
"SKU-41680151",
"SKU-40977269",
"SKU-40977316",
"SKU-40977324",
"SKU-40977327",
"SKU-40977313",
"SKU-40977281",
"SKU-40977267",
"SKU-40977273",
"SKU-40977263",
"SKU-40977261",
"SKU-40977239",
"SKU-22153156",
"SKU-27436708",
"SKU-34337940",
"SKU-34337943",
"SKU-34337947",
"SKU-34337952",
"SKU-22153144",
"SKU-22153152",
"SKU-22153159",
"SKU-22153162",
"SKU-23000543",
"SKU-38426422",
"SKU-38426370",
"SKU-38426376",
"SKU-38426377",
"SKU-38426378",
"SKU-38426418",
"SKU-38426420",
"SKU-38426421",
"SKU-38426426",
"SKU-38426410",
"SKU-38426412",
"SKU-42313030",
"SKU-42313004",
"SKU-42313033",
"SKU-42313037",
"SKU-42313618",
"SKU-42313038",
"SKU-42313039",
"SKU-42313024",
"SKU-42313027",
"SKU-42313605",
"SKU-42313616",
"SKU-42087852",
"SKU-42087869",
"SKU-42087871",
"SKU-42087868",
"SKU-42087866",
"SKU-42087861",
"SKU-42067915",
"SKU-42067903",
"SKU-42067907",
"SKU-42067909",
"SKU-42067911",
"SKU-42067905",
"SKU-41082013",
"SKU-41082020",
"SKU-41082011",
"SKU-41082012",
"SKU-41082014",
"SKU-41112726",
"SKU-41082015",
"SKU-41082016",
"SKU-41082017",
"SKU-41082018",
"SKU-41082019",
"SKU-37370489",
"SKU-37370483",
"SKU-37370484",
"SKU-37370485",
"SKU-37370486",
"SKU-37370487",
"SKU-37370501",
"SKU-37370502",
"SKU-37370503",
"SKU-37370505",
"SKU-37370495",
"SKU-39672603",
"SKU-39672593",
"SKU-39672596",
"SKU-39672598",
"SKU-39672600",
"SKU-39672602",
"SKU-39672604",
"SKU-39672607",
"SKU-39672610",
"SKU-39672613",
"SKU-39745408",
"SKU-42124404",
"SKU-42124381",
"SKU-42124384",
"SKU-42124386",
"SKU-42124378",
"SKU-42124770",
"SKU-42124406",
"SKU-42124408",
"SKU-42124401",
"SKU-42124398",
"SKU-42124373",
"SKU-37888413",
"SKU-37888418",
"SKU-37893748",
"SKU-37888408",
"SKU-37888409",
"SKU-37888410",
"SKU-37888411",
"SKU-37893749",
"SKU-37888412",
"SKU-37888414",
"SKU-37888415",
"SKU-40799209",
"SKU-40799212",
"SKU-40799215",
"SKU-40800617",
"SKU-40800618",
"SKU-40800619",
"SKU-37008157",
"SKU-37001726",
"SKU-37008153",
"SKU-37008154",
"SKU-37008155",
"SKU-37008156",
"SKU-37008158",
"SKU-37001728",
"SKU-37008159",
"SKU-37001730",
"SKU-37008160",
"SKU-42087915",
"SKU-42087921",
"SKU-42087923",
"SKU-42087924",
"SKU-42087925",
"SKU-42087922",
"SKU-42087920",
"SKU-42087917",
"SKU-42087918",
"SKU-42087919",
"SKU-42087916",
"SKU-42708712",
"SKU-24390958",
"SKU-24390951",
"SKU-36069839",
"SKU-36069827",
"SKU-36069832",
"SKU-36069837",
"SKU-36069843",
"SKU-36069848",
"SKU-36069850",
"SKU-36069854",
"SKU-31958481",
"SKU-31957691",
"SKU-27312001",
"SKU-27312186",
"SKU-27312187",
"SKU-27311773",
"SKU-27311774",
"SKU-27312060",
"SKU-36921911",
"SKU-36921977",
"SKU-36921948",
"SKU-36921953",
"SKU-36921957",
"SKU-36921964",
"SKU-36921970",
"SKU-36921976",
"SKU-36921942",
"SKU-36921916",
"SKU-36921919",
"SKU-37323420",
"SKU-37323283",
"SKU-37323284",
"SKU-37323286",
"SKU-37323288",
"SKU-37323290",
"SKU-37323292",
"SKU-37323386",
"SKU-37323389",
"SKU-37323391",
"SKU-37323393",
"SKU-36276861",
"SKU-36278481",
"SKU-36276858",
"SKU-36278480",
"SKU-36276855",
"SKU-36278477",
"SKU-36276851",
"SKU-36277594",
"SKU-36276846",
"SKU-36276840",
"SKU-21550365",
"SKU-22306156",
"SKU-13246583",
"SKU-43209328",
"SKU-13246667",
"SKU-35614412",
"SKU-35614411",
"SKU-35614414",
"SKU-40725520",
"SKU-35614416",
"SKU-40725521",
"SKU-40725527",
"SKU-35614413",
"SKU-40725525",
"SKU-40725518",
"SKU-40725519",
"SKU-41707856",
"SKU-40508316",
"SKU-40508318",
"SKU-40508319",
"SKU-38553596",
"SKU-40508317",
"SKU-38553598",
"SKU-30581828",
"SKU-42073352",
"SKU-42518256",
"SKU-36127195",
"SKU-36127198",
"SKU-36127197",
"SKU-36127202",
"SKU-36127201",
"SKU-36127200",
"SKU-36127199",
"SKU-39813617",
"SKU-39850363",
"SKU-42517751",
"SKU-42517993",
"SKU-44648724",
"SKU-44477844",
"SKU-39855373",
"SKU-44466536",
"SKU-35278811",
"SKU-35278812",
"SKU-35278813",
"SKU-35278814",
"SKU-35278815",
"SKU-35278816",
"SKU-41071811",
"SKU-41071800",
"SKU-41071802",
"SKU-41071803",
"SKU-41071804",
"SKU-41071806",
"SKU-41071807",
"SKU-41071812",
"SKU-41071815",
"SKU-21320040",
"SKU-21320033",
"SKU-21320038",
"SKU-21320037",
"SKU-21320039",
"SKU-21320041",
"SKU-21320042",
"SKU-21320043",
"SKU-42977451",
"SKU-42977424",
"SKU-42985179",
"SKU-42977448",
"SKU-42977437",
"SKU-42977433",
"SKU-42977429",
"SKU-42985176",
"SKU-42977463",
"SKU-42977460",
"SKU-42977456",
"SKU-41071750",
"SKU-41071746",
"SKU-41071747",
"SKU-41071748",
"SKU-41071743",
"SKU-41071744",
"SKU-41071745",
"SKU-41071753",
"SKU-41071757",
"SKU-37378633",
"SKU-37378635",
"SKU-37378634",
"SKU-37378636",
"SKU-36248617",
"SKU-36248606",
"SKU-36248615",
"SKU-38043749",
"SKU-38043724",
"SKU-24798588",
"SKU-24798592",
"SKU-24798601",
"SKU-24798743",
"SKU-24798752",
"SKU-24798755",
"SKU-24798671",
"SKU-24798679",
"SKU-24798685",
"SKU-38543689",
"SKU-38543738",
"SKU-38543739",
"SKU-38543729",
"SKU-38543731",
"SKU-38543721",
"SKU-38543722",
"SKU-38543725",
"SKU-38543720",
"SKU-38543714",
"SKU-38543716",
"SKU-41071786",
"SKU-41071787",
"SKU-41071788",
"SKU-41071789",
"SKU-41071790",
"SKU-41071792",
"SKU-41071794",
"SKU-41071797",
"SKU-41071799",
"SKU-38193107",
"SKU-38193121",
"SKU-38193093",
"SKU-38193094",
"SKU-38193095",
"SKU-38193096",
"SKU-38193097",
"SKU-38193098",
"SKU-38193099",
"SKU-38193100",
"SKU-38193101",
"SKU-39101253",
"SKU-39101302",
"SKU-39101307",
"SKU-39101310",
"SKU-39101313",
"SKU-39101318",
"SKU-39101256",
"SKU-39101258",
"SKU-39101260",
"SKU-36063043",
"SKU-36063046",
"SKU-36063049",
"SKU-36063040",
"SKU-40511336",
"SKU-40511333",
"SKU-40511330",
"SKU-40511327",
"SKU-36063033",
"SKU-36063035",
"SKU-36063037",
"SKU-24797574",
"SKU-24796232",
"SKU-24798216",
"SKU-24798220",
"SKU-24798225",
"SKU-24798227",
"SKU-24798284",
"SKU-24798298",
"SKU-24798303",
"SKU-24798311",
"SKU-24798287",
"SKU-42122310",
"SKU-42122323",
"SKU-42122316",
"SKU-42122296",
"SKU-42122290",
"SKU-42122302",
"SKU-42122338",
"SKU-42122346",
"SKU-42122350",
"SKU-42122335",
"SKU-42122319",
"SKU-37347117",
"SKU-37347141",
"SKU-37347142",
"SKU-37347143",
"SKU-37347144",
"SKU-37347129",
"SKU-37347130",
"SKU-37347131",
"SKU-37347132",
"SKU-37347118",
"SKU-37347119",
"SKU-42382814",
"SKU-42382858",
"SKU-42382863",
"SKU-42386676",
"SKU-42382771",
"SKU-42382773",
"SKU-42382778",
"SKU-42382829",
"SKU-42382835",
"SKU-42382838",
"SKU-42382763",
"SKU-22471422",
"SKU-22471421",
"SKU-14710977",
"SKU-14710978",
"SKU-14710979",
"SKU-22471425",
"SKU-14710981",
"SKU-14710982",
"SKU-14710983",
"SKU-14710985",
"SKU-14710986",
"SKU-42382780",
"SKU-42382801",
"SKU-42382795",
"SKU-42382793",
"SKU-42382808",
"SKU-42382824",
"SKU-42382818",
"SKU-42382813",
"SKU-42382830",
"SKU-42386741",
"SKU-42382785",
"SKU-22154305",
"SKU-22154634",
"SKU-22154306",
"SKU-22154310",
"SKU-22154315",
"SKU-22154318",
"SKU-22154352",
"SKU-22154353",
"SKU-22154354",
"SKU-22154355",
"SKU-22154655",
"SKU-25515724",
"SKU-25515307",
"SKU-25515308",
"SKU-25515310",
"SKU-25515311",
"SKU-25515309",
"SKU-25515312",
"SKU-25515313",
"SKU-25515314",
"SKU-25515348",
"SKU-25515350",
"SKU-33441617",
"SKU-33441568",
"SKU-33441575",
"SKU-33441580",
"SKU-33441585",
"SKU-33441569",
"SKU-33441574",
"SKU-33441579",
"SKU-33441584",
"SKU-33441675",
"SKU-33441682",
"SKU-38581029",
"SKU-38581001",
"SKU-38580962",
"SKU-36181494",
"SKU-36181550",
"SKU-36181510",
"SKU-36181538",
"SKU-33441792",
"SKU-33441820",
"SKU-33441826",
"SKU-33441831",
"SKU-33441838",
"SKU-33441798",
"SKU-33441802",
"SKU-33441805",
"SKU-33441919",
"SKU-33441931",
"SKU-33441941",
"SKU-22471487",
"SKU-36210818",
"SKU-36210815",
"SKU-36210812",
"SKU-36210822",
"SKU-15420419",
"SKU-15420417",
"SKU-15420421",
"SKU-22471494",
"SKU-15420420",
"SKU-15420422",
"SKU-22471486",
"SKU-36210821",
"SKU-36210817",
"SKU-36210813",
"SKU-36210824",
"SKU-22471480",
"SKU-15420375",
"SKU-15420374",
"SKU-15420376",
"SKU-22471545",
"SKU-22471547",
"SKU-22471481",
"SKU-36210819",
"SKU-36210814",
"SKU-36210811",
"SKU-36210823",
"SKU-22471473",
"SKU-15420349",
"SKU-15420350",
"SKU-15420352",
"SKU-22471629",
"SKU-22471634",
"SKU-39205836",
"SKU-39206333",
"SKU-39206331",
"SKU-39206327",
"SKU-39206326",
"SKU-39206325",
"SKU-39206328",
"SKU-39206339",
"SKU-39206338",
"SKU-39206337",
"SKU-39206340",
"SKU-24064139",
"SKU-24064069",
"SKU-24064070",
"SKU-24064169",
"SKU-24064173",
"SKU-24064180",
"SKU-24064186",
"SKU-24064191",
"SKU-24064194", };
        #endregion

        public CartGeneratorController(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ViewResult Index(CartGeneratorPage currentPage)
        { 

            return View(currentPage);
        }
        

        [HttpPost]
        public ViewResult Index(FormCollection collection)
        {
            var numberOfCart = string.IsNullOrEmpty(collection["numberOfCart"]) ? 1 : int.Parse(collection["numberOfCart"]);
            var numberOfShipment = string.IsNullOrEmpty(collection["numberOfCart"]) ? 1 : int.Parse(collection["numberOfCart"]);
            var numberOfItem = string.IsNullOrEmpty(collection["numberOfCart"]) ? 1 : int.Parse(collection["numberOfCart"]);

            CreateCart(numberOfCart, numberOfShipment, numberOfItem);
            ViewBag.Message = $"{numberOfCart} carts were created!";
            return View();
        }

        private void CreateCart(int numberOfCart, int numberOfShipment, int numberOfItem)
        {
            for (var k = 1; k <= numberOfCart; k++)
            {
                var cart = _orderRepository.LoadOrCreateCart<ICart>(Guid.NewGuid(), _defaultName);

                for (var j = 1; j <= numberOfShipment; j++)
                {
                    var shipment = cart.GetFirstShipment();
                    if (j > 1)
                    {
                        shipment = cart.CreateShipment();
                        cart.AddShipment(shipment);
                    }                

                    for (var i = 1; i <= numberOfItem; i++)
                    {
                        // Adding random entry to cart
                        var entryCode = _listOfEntryCodes.OrderBy(s => Guid.NewGuid()).First();
                        do
                        {
                            entryCode = _listOfEntryCodes.OrderBy(s => Guid.NewGuid()).First();
                        } while (cart.GetAllLineItems().Any(l => l.Code == entryCode));

                        var lineItem = cart.CreateLineItem(entryCode);
                        lineItem.Quantity = 1;
                        lineItem.PlacedPrice = 100;
                        shipment.LineItems.Add(lineItem);
                    }
                }

                var _cartLink = _orderRepository.Save(cart);
            }
        }
    }
}