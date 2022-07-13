using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplicacion.Models.ViewModels;


namespace WebAplicacion.Controllers
{
    public class SunatController : Controller
    {
        protected string scope = "https://api.sunat.gob.pe/v1/contribuyente/contribuyentes";
        protected string client_id = "ed950066-8132-4be7-84ae-80ece888c0a7";  //7
        protected string client_secret =  "UmzfDQM145lNju91kR293w=="; //UmzfDQM145lNju91kR293w
        // GET: Sunat
        public ActionResult Index()
        {
            return View();
        }
        
        //public String GeneraTokenSunat()
        //{
        //    String tokens = "";
        //    var client = new RestClient("https://api-seguridad.sunat.gob.pe/v1/clientesextranet/"+ client_id + "/oauth2/token/");
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddParameter("grant_type", "client_credentials");
        //    request.AddParameter("scope", scope);
        //    request.AddParameter("client_id", client_id);
        //    request.AddParameter("client_secret", client_secret);
        //    IRestResponse response = client.Execute(request);
        //    //Console.WriteLine(response.Content);
        //    if (response.Content!="")
        //    {
        //        JObject objJSON = JObject.Parse(response.Content);
        //        tokens = objJSON["access_token"].ToString();
        //    }
        //    else
        //    {
        //        tokens = "";
        //    }
                
            

        //    return tokens;


        //}


        // GET: Sunat
        [HttpPost]
        public string ConsultaSunat(SunatViewModel objSunat)
        {
            ////objSunat.NumeroRuc = "20506064814";
            ////objSunat.CodigoComp = "01";
            ////objSunat.NumeroSerie = "F002";
            ////objSunat.Numero = "00014234";
            ////objSunat.FechaEmision = "29/01/2021";
            ////objSunat.Monto = "6.49";
            ////var fec = Convert.ToDateTime(objSunat.FechaEmision).ToString("dd/MM/yyyy");
            String response = "";
            //if (objSunat.FechaEmision.Length>10)
            //{
            //    return "Debe ingresar Fecha Valida.";
            //}
         
            //ComprobanteSunat comprobanteSunat = new ComprobanteSunat();
            ////var valor = comprobanteSunat.IsReCaptchValid();
            ////var objToken=comprobanteSunat.GeneraTokenSunat2();
            //response = comprobanteSunat.ConsultaSunat(client_id, client_secret, objSunat.NumeroRuc,
            //objSunat.CodigoComp, objSunat.NumeroSerie.ToUpper(),
            //objSunat.Numero, Convert.ToDateTime(objSunat.FechaEmision).ToString("dd/MM/yyyy"),
            //objSunat.Monto);
            ////response = comprobanteSunat.ConsultaSunat2(objSunat.NumeroRuc,
            ////objSunat.CodigoComp, objSunat.NumeroSerie.ToUpper(),
            ////objSunat.Numero, Convert.ToDateTime(objSunat.FechaEmision).ToString("dd/MM/yyyy"),
            ////objSunat.Monto);



            return response;
        }

        // GET: Sunat/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Sunat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sunat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sunat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sunat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sunat/Delete/5
        public ActionResult Delete(int id, SunatViewModel objSunat)
        {
            //ComprobanteSunat comprobanteSunat = new ComprobanteSunat();
            //String tokens = comprobanteSunat.ConsultaSunat( client_id, client_secret, "","","","","","");

            String tokens = "";
            String response = "";
            if (tokens != "")
            {

                //var client = new RestClient("https://api.sunat.gob.pe/v1/contribuyente/contribuyentes/20506064814/validarcomprobante");
                var client = new RestClient("https://api.sunat.gob.pe/v1/contribuyente/contribuyentes/" + objSunat.NumeroRuc + "/validarcomprobante");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                //request.AddHeader("Authorization", "Bearer eyJraWQiOiJhcGkuc3VuYXQuZ29iLnBlLmtpZDEwMSIsInR5cCI6IkpXVCIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiJlZDk1MDA2Ni04MTMyLTRiZTctODRhZS04MGVjZTg4OGMwYTciLCJhdWQiOiJbe1wiYXBpXCI6XCJodHRwczpcL1wvYXBpLnN1bmF0LmdvYi5wZVwiLFwicmVjdXJzb1wiOlt7XCJpZFwiOlwiXC92MVwvY29udHJpYnV5ZW50ZVwvY29udHJpYnV5ZW50ZXNcIixcImluZGljYWRvclwiOlwiMFwiLFwiZ3RcIjpcIjAxMDAwMFwifV19XSIsIm5iZiI6MTYxMjM2Mzg0MywiY2xpZW50SWQiOiJlZDk1MDA2Ni04MTMyLTRiZTctODRhZS04MGVjZTg4OGMwYTciLCJpc3MiOiJodHRwczpcL1wvYXBpLXNlZ3VyaWRhZC5zdW5hdC5nb2IucGVcL3YxXC9jbGllbnRlc2V4dHJhbmV0XC9lZDk1MDA2Ni04MTMyLTRiZTctODRhZS04MGVjZTg4OGMwYTdcL29hdXRoMlwvdG9rZW5cLyIsImV4cCI6MTYxMjM2NzQ0MywiZ3JhbnRUeXBlIjoiY2xpZW50X2NyZWRlbnRpYWxzIiwiaWF0IjoxNjEyMzYzODQzfQ.qaQz88ivcd2JbzVl0RykGIhHiv3Efw9W8lNP0q9Sob6MiMtKg0Jvt74GBBL-C1swoLT-vBJo__nMeVm-7puH85z-XnpRs6kB7xxd6fIIJR5o4NhR-WEjA3zjbvqfnhbeRRVdUkWTuP3M1s7SsAadlCpGt8v_Nbm0_Q0g1J1uLQlsfdPiAn5Dh3OvHYZ9XHgwxIznXdJM-VhghtSsaBWbET1S8k_JMPb3JhJQsA84e9MCbcqNwN5PpwWOyJreBhW7KqC7FJZFRSwiFXPicffVXjLsQB6ZlofX38-lHWC1zuPaFEXcHozOZYzpp2YebPesE0bLElL6YExLDnlRp5I_Sg");
                request.AddHeader("Authorization", "Bearer " + tokens);
                request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Cookie", "TS018e7c3c=014dc399cb7d8bc44c437a9c791d131f440eb0d579f8694cea52742883c269ba826c5e79e5b488b22b8e5c27bf126ee7f02cd14a73");
                request.AddParameter("application/json", "{\r\n    \"numRuc\":\"" + objSunat.NumeroRuc + "\",\r\n\t\"codComp\":\"" + objSunat.CodigoComp + "\",\r\n\t\"numeroSerie\":\"" + objSunat.NumeroSerie.ToUpper() + "\",\r\n\t\"numero\":\"" + objSunat.Numero + "\",\r\n\t\"fechaEmision\":\"" + Convert.ToDateTime(objSunat.FechaEmision).ToString("dd/MM/yyyy") + "\",\r\n\t\"monto\":\"" + objSunat.Monto + "\"\r\n}", ParameterType.RequestBody);
                IRestResponse respuesta = client.Execute(request);
                //Console.WriteLine(response.Content);
                response = respuesta.Content;
            }
            else
            {
                response = "Error Generation Token.Verifique su conexion a Internet y/o Credencial.";
            }
            return View();
        }

        // POST: Sunat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
