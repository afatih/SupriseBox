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
            var selectedBoxesInBasket = Helper.ShoppingList.GetBoxesInBasket();
            ViewBag.selectedBoxesInBasket = selectedBoxesInBasket;

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
    }
}