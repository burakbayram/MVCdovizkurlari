using BLL;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {
        XMLdataGet XMLdata = new XMLdataGet();
       
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult _doviz()
        {
            XMLdataGet.TCMBDovizKuruAl();
      
            var liste = XMLdata.datagetir();
            var doviz = XMLdata.datagetir1();
            ViewBag.doviz = doviz;
            return View(liste);

        }

        public ActionResult _Cevir()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult _Cevir(string cins, string deger, string Total)
        {
            if (cins != "" && deger != "")
            {
                Total = XMLdata.dovizCevir(cins, Convert.ToDouble(deger)).ToString();
                ViewBag.Total = Total;
                return View();
            }
            else return View();
        }
        public ActionResult _Veriler()
        {
           
           List<DovizCevir> liste= XMLdata.dvzGet();
            return View(liste);
        }
    }
}