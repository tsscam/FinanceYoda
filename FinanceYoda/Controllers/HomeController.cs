using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinanceYoda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.RandomQuote = GetRandomQuote();

            return View();
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Yoda said 'Do or Do Not, there is no Try";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string GetRandomQuote()

        {
            //GETTING THE RAW TEXT DATA from JSON
            HttpWebRequest request = WebRequest.CreateHttp("https://andruxnet-random-famous-quotes.p.mashape.com/");

            //request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            //key is used to gain access to the IP
            request.Headers.Add("X-Mashape-Key", "JO4bkhuxbXmshFnHFjLnocW3jFA9p1bgnIbjsnd2uZBpdOEv5y");
            request.ContentType = "application/x-www-form-urlencoded";
            //file type of from the website
            request.Accept = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Getting the response as an object
            StreamReader rd = new StreamReader(response.GetResponseStream());
            //turns object to a string
            string data = rd.ReadToEnd();
            //creates object new quote of string
            JObject RandomQuote = JObject.Parse(data);

            //displays the string
            return RandomQuote["quote"].ToString();

        }

    }
}