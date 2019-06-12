using Bll.Abstract.EntityType;
using Common;
using DTOs.DTOModels;
using DTOs.DTOModels.ComplexDTOs;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class ShoppingController : Controller
    {
        IBoxService _bs;
        // GET: Shopping
        public ShoppingController(IBoxService bs)
        {
            _bs = bs;
        }
        public ActionResult ShoppingCard(int BoxID)
        {
            ServiceResult result = Helper.ShoppingList.AddBox(BoxID);
            ServiceResult<BoxDTO> result2 = _bs.GetBoxById(BoxID);
            var s = Session["sepet"]; //key=boxID, value=sepette kaç tane kutu var
            return Json(new { status = result.State, message = result.Message, box = result2.Result.BoxName, }, JsonRequestBehavior.AllowGet);
        }
        
        //Sepetteki kutuların bilgilerini gösterir 
        public ActionResult ShoppingCardDetail()
        {
            List<BoxDTO> boxes = new List<BoxDTO>();
            var boxIDs = Helper.ShoppingList.GetBoxesKeysInBasket();

            foreach (var boxID in boxIDs)
            {
                try
                {
                    var serviceResult = _bs.GetBoxById(boxID);
                    if (serviceResult.State == ProcessStateEnum.Success)
                    {
                        boxes.Add(serviceResult.Result);
                       
                    }
                    else
                    {
                        return Content("Bir Hata Oluştu!");
                    }
                }
                catch (Exception ex)
                {

                    return Content(ex.Message);
                }

            }
            return View(boxes);
        }



    }
}