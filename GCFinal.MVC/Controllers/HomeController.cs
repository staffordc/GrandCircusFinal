using GCFinal.Data;
using GCFinal.Services;
using System.Web.Mvc;

namespace GCFinal.MVC.Controllers
{
    public class HomeController : Controller
    {
        private Data.GCFinalContext db = new GCFinalContext();
        private readonly TripPackingService _tripPackingService = new TripPackingService();

        public ActionResult Index()
        {
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