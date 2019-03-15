using LeadsUI.Models;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LeadsManagementDataModel model = new LeadsManagementDataModel();
            model.PopulateFieldsTest();

            return View(model);
        }

        public ActionResult Search()
        {
            TestWebApiCtrlController tc = new TestWebApiCtrlController();
            IEnumerable<string> ret = tc.Get();

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}