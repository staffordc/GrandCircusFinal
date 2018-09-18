using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GCFinal.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return this.HttpNotFound();
        }

        public ActionResult NotAuthorized()
        {
            throw new HttpException((int)HttpStatusCode.Unauthorized, "Test Unauthorized");
        }

        public ActionResult ServerError()
        {
            throw new HttpException((int)HttpStatusCode.InternalServerError, "Test Server Error");
        }

        public ActionResult RegularException()
        {
            throw new Exception("Test Exception");
        }
    }
}