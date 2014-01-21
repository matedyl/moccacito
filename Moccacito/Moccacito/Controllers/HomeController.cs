using Moccacito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moccacito.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public ActionResult Clients()
        //{
        //    ClientsViewModel model = new ClientsViewModel();
        //    using (var database = new ModelContainer())
        //    {
        //        model.Clients = database.ClientSet;
        //        //model.Clients = database.ClientSet.Where(m => m.Name.StartsWith("L")).Where(n => n.Id < 6).ToList();
        //    }
        //    //model.Clients = new List<Client>();
        //    //model.Clients.Add(new Client()
        //    //{
        //    //    Id = 1,
        //    //    Name = "Zbyszek",
        //    //    Email = "zbyszek@onet.pl"
        //    //}
        //    //);

        //    return View(model);

        //}
    }
}
