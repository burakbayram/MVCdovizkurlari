using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL
{
    public class XMLdataGet
    {
     static   RateContext db = new RateContext();

        public static void TCMBDovizKuruAl()
        {
           
            db.ExchangeRateDatas.RemoveRange(db.ExchangeRateDatas.ToList());
           
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            ExchangeRateData rateData = new ExchangeRateData();
            rateData.Buying =Convert.ToDouble( xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml);
            rateData.Selling=Convert.ToDouble( xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml);
            rateData.CurrencyCode = "USD/TRY";
            rateData.Currency = new Currency();
            rateData.Currency.Unit = 1;
         
            rateData.CurrencyName= xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/CurrencyName").InnerXml;
         //   rateData.CurrencyId = db.Currency.Find(1).Id;
            rateData.CreatedDate = DateTime.Now;
            db.ExchangeRateDatas.Add(rateData);
            db.SaveChanges();
            ExchangeRateData rateData1 = new ExchangeRateData();

            rateData1.Buying = Convert.ToDouble(xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml);
            rateData1.Selling = Convert.ToDouble(xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml);
            rateData.Currency = new Currency();
            rateData.Currency.Unit = 1;
            rateData1.CurrencyCode = "EUR/TRY";
            rateData1.CurrencyName = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/CurrencyName").InnerXml;
            rateData1.CreatedDate = DateTime.Now;
            db.ExchangeRateDatas.Add(rateData1);
            db.SaveChanges();

        }

        public List<ExchangeRateData> datagetir()
        {
            var data = db.ExchangeRateDatas.ToList();
            return data;
        }
        public string datagetir1()
        {
            var data = db.ExchangeRateDatas.Select(x=>x.CreatedDate.ToString()).FirstOrDefault();
            return data;
        }

        public double dovizCevir(string name,double deger)
        {
            if (name.StartsWith("E")&& name.StartsWith("e"))
            {
                name = "EURO";
             
            }
            else if (name.StartsWith("U")&&name.StartsWith("u"))
            {
                name = "US DOLLAR";
            }
            //  ExchangeRateData doviz = new ExchangeRateData();
            var    doviz = db.ExchangeRateDatas.Where(x => x.CurrencyName==name).FirstOrDefault();
            double fiyat = deger * doviz.Selling;
            DovizCevir dvz = new DovizCevir();
            dvz.dovizCinsi = name;
            dvz.Kur = doviz.Selling;
            dvz.ParaMiktari = deger;
            dvz.Total = fiyat;
            db.DovizCevirs.Add(dvz);
            db.SaveChanges();
            return fiyat;
        }

        public List<DovizCevir> dvzGet (){


            return db.DovizCevirs.OrderByDescending(x => x.date).ToList();


        }

    }
}