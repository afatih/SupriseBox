using Bll.Abstract.EntityType;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class BasketController : Controller
    {
        IBoxService _bs;

        public BasketController(IBoxService bs)
        {
            _bs = bs;
        }
        // GET: Basket
        public ActionResult BoxesInBasket()
        {
            var selectedBoxesKeys = Helper.ShoppingList.GetBoxesKeysInBasket();
            List<BoxDTO> selectedBoxes=new List<BoxDTO>();
            foreach (var item in selectedBoxesKeys)
            {
                var result = _bs.GetBoxById(item);
                if (result.State== Common.ProcessStateEnum.Success)
                {
                    selectedBoxes.Add( result.Result);
                }
            }
            return View(selectedBoxes);
        }


        //Kutu bilgileri ve miktarları List<OrderDetails> olarak static sınıf icerisindeki item propertisine yazıldı.
        //Daha sonra ödeme işleminin son adımı olan CheckOut sayfasına Yönlendirildi.
        [HttpPost]
        public ActionResult BoxesInBasket(FormCollection formColl)
        {
            for (int i = 0; i < formColl.Count/2; i++)
            {
                int pID = Convert.ToInt32(formColl["shcartID-" + i + ""]);
                var box=_bs.GetBoxById(pID);
                var orderDetail = new OrderDetailDTO()
                {
                    BoxID = box.Result.ID,
                    BoxName=box.Result.BoxName,
                    UnitPrice = box.Result.Price,
                    BoxAmount = Convert.ToInt32(formColl["qty-" + i + ""]),
                    TotalAmount = box.Result.Price * Convert.ToInt32(formColl["qty-" + i + ""])
                };
                if (Helper.ShoppingDetails.items== null)
                {
                    Helper.ShoppingDetails.items = new List<OrderDetailDTO>();
                }
                Helper.ShoppingDetails.items.Add(orderDetail);
            }
            return RedirectToAction("Index","CheckOut");
        }

    }
}