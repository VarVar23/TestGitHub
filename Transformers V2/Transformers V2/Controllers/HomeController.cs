using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Transformers_V2.Models;

namespace Transformers_V2.Controllers
{
    public class HomeController : Controller
    {
        private Transformers_V2.Models.AppContext db;
        public Manufacture mn11;
        public Manufacture mn22;

        public HomeController(Transformers_V2.Models.AppContext appContext)
        {
            db = appContext;


           
        }

        public IActionResult Index()
        {
           

            return View(db.transformers.Include(p=>p.Manufacture).ToList());
            
        }

        public IActionResult AddList()
        {

            if (db.manufactures.Count() == 0)
            {
                
               mn11 = new Manufacture { Name = "first manuf" };
               mn22 = new Manufacture { Name = "second manuf" };
                db.manufactures.Add(mn11);
                db.manufactures.Add(mn22);
                db.SaveChanges();
            }
            else
            {
                mn11 = db.manufactures.ToList()[0];
                mn22 = db.manufactures.ToList()[1];
            }

            Transformer tr1 = new Transformer { Name = "tr1", Manufacture = mn11 };
            Transformer tr2 = new Transformer { Name = "tr2", Manufacture = mn11};
            Transformer tr3 = new Transformer { Name = "tr3", Manufacture = mn22 };
            Transformer tr4 = new Transformer { Name = "tr4", Manufacture = mn22 };
            Transformer tr5 = new Transformer { Name = "tr5", Manufacture = mn11 };
            
            db.transformers.AddRange(new List<Transformer> { tr1, tr2, tr3, tr4, tr5 });
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult DeleteTransformer()
        {
            Transformer trans_for_del = db.transformers.ToList()[db.transformers.Count()-1];
            db.transformers.Remove(trans_for_del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddManufacture(Manufacture mn)
        {
            
            return View();
        }

        public IActionResult AddTransformer(Transformer tr)
        {
                     
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
