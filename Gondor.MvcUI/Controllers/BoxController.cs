using Bll.Abstract.ComplexType;
using Bll.Abstract.EntityType;
using Common;
using DTOs.DTOModels;
using DTOs.DTOModels.ComplexDTOs;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class BoxController : Controller
    {
        IBoxService _bs;
        IBoxBoxTypeService _bbts;
        IBoxTypeService _bts;

        public BoxController(IBoxService bs,IBoxBoxTypeService bbts,IBoxTypeService bts)
        {
            _bs = bs;
            _bbts = bbts;
            _bts = bts;
        }

        [Route("box/listbox")]
        public ActionResult ListBox()
        {
            var model = _bs.GetBoxes().Result;
            return View(model);
        }

        [Route("box/addbox")]
        public ActionResult AddBox()
        {
            var boxtypes = _bbts.GetAllBoxTypesWithBox().Result;
            return View(boxtypes);
        }

        [Route("box/addbox")]
        [HttpPost]
        public ActionResult AddBox(BoxDTO box)
        {
            if (!ModelState.IsValid)
            {
                return View("AddBox", box);
            }
            var model = _bs.AddBox(box);

            return Content(model.State.ToString());
        }

        public ActionResult SingleBox(int id)
        {
            var selectedBoxesInBasket = Helper.ShoppingList.GetBoxesInBasket();
            ViewBag.selectedBoxesInBasket = selectedBoxesInBasket;

            var model = _bbts.GetBoxBoxType(id);
            

            if (model.Result!=null)
            {
                return View(model.Result);
            }
           
            return HttpNotFound();

        }

        [Route("box/addbox")]
        public ActionResult UpdateBox(int id)
        {
            var boxtypes = _bbts.GetAllBoxTypesWithBox().Result;
            return View(boxtypes);
        }


        public ActionResult BoxesMainPage()
        {
            var model = _bs.GetBoxes().Result;
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }


    }
}