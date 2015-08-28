using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using MultipleConnectionString.Repositories;
using MultipleConnectionString.Utilities;

namespace MultipleConnectionString.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IMessageRepository _messageRepo;
        public HomeController()//IMessageRepository messageRepo)
        {
            //_messageRepo = messageRepo;
        }

        //
        // GET: /Home/

        public ActionResult NormalDependencyInjection()
        {
            
            var service = DependencyResolver.Current.GetService<IMessageService>();
            //var chineseService = _container.Resolve<IMessageService>(new NamedParameter("serviceName", "chinese"));
            var param = new NamedParameter("Name", "chinese");
            var resolveNamed = new ResolvedParameter((p, c) => p.Name == "chinese_service", (p, c) => c.ResolveNamed<IMessageRepository>("chinese"));
            var chineseService = AutofacDependencyResolver.Current.ResolveByNamed<IMessageService>("chinese_service");
            return View();
        }
        public ActionResult Index()
        {
            return View();
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