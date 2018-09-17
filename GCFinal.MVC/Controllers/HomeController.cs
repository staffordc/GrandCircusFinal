﻿using GCFinal.Data;
using GCFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCFinal.MVC.Controllers
{
    public class HomeController : Controller
    {
        private Data.GCFinalContext db = new GCFinalContext();
        private readonly TripPackingService _tripPackingService = new TripPackingService();

        public ActionResult Index()
        {
            if(db.PackingItems != null)
            {
                _tripPackingService.EmptyPackingItems();
            }

            return View();
        }

        public ActionResult AboutWhat2Pack()
        {
            ViewBag.Message = "About What2Pack";

            return View();
        }

        public ActionResult AboutDevs()
        {
            ViewBag.Message = "About the Developers";

            return View();
        }
    }
}