using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Nền tảng BlockChain Bệnh nhân";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Thông tin liên hệ Tác giả";

			return View();
		}
	}
}