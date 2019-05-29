using Bll.Abstract.EntityType;
using Common;
using DTOs.DTOModels;
using DTOs.DTOModels.ComplexDTOs;
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
            Helper.ShoppingList.AddBox(BoxID);
            var s = Session["sepet"]; //key=boxID, value=sepette kaç tane kutu var
            return View();
        }


    }
}