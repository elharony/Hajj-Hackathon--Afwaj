using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AFWAJ.Services
{
    public class DataAccess
    {
        public delegate void FireAlert(string title, string alert);
        public event FireAlert fireAlert;

        private static readonly DataAccess sharedNetworkService = new DataAccess();

        public static DataAccess sharedService()
        {
            return sharedNetworkService;
        }
        public async Task<string> SendSOAPRequestAsync(string url, string action, Dictionary<string, string> parameters, string soapAction = null, bool useSOAP12 = false)
        {
            // Create the SOAP envelope
            var xmlStr = (useSOAP12)
                    ? @"
                    <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                      xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                      xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                      <soap12:Body>
                        <{0} xmlns=""http://tempuri.org/"">{2}</{0}>
                      </soap12:Body>
                    </soap12:Envelope>"
                    : @"
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" 
                        xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                        xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                        <soap:Body>
                           <{0} xmlns=""http://tempuri.org/"">{2}</{0}>
                        </soap:Body>
                    </soap:Envelope>";
            string parms = string.Join(string.Empty, parameters.Select(kv => String.Format("<{0}>{1}</{0}>", kv.Key, kv.Value)).ToArray());
            string xmlstring = String.Format(xmlStr, action, new Uri(url).Authority + "/", parms);
            TextReader s = new StringReader(xmlstring);

            XDocument soapEnvelopeXml = XDocument.Load(s);

            // Create the web request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            if (soapAction != null) webRequest.Headers["SOAPAction"] = soapAction;
            webRequest.ContentType = (useSOAP12) ? "application/soap+xml;charset=\"utf-8\"" : "text/xml;charset=\"utf-8\"";
            webRequest.Accept = (useSOAP12) ? "application/soap+xml" : "text/xml";
            webRequest.Method = "POST";

            // Insert SOAP envelope
            using (Stream stream = await webRequest.GetRequestStreamAsync())
            {
                soapEnvelopeXml.Save(stream);
            }

            // Send request and retrieve result
            string result;
            using (WebResponse response = await webRequest.GetResponseAsync())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    result = rd.ReadToEnd();
                }
            }
            // var ss = JsonValue.Parse(result);
           // UserDialogs.Instance.HideLoading();

            return GetSoapResponse(result, useSOAP12);

        }

        public string GetSoapResponse(string SoapResult, bool useSOAP12)
        {
            XDocument xDoc = XDocument.Load(new StringReader(SoapResult));
            string NS = (useSOAP12) ? "http://www.w3.org/2003/05/soap-envelope" : "http://schemas.xmlsoap.org/soap/envelope/";
            var unwrappedResponse = xDoc.Descendants((XNamespace)NS + "Body").First().Value;
            //var model = JsonConvert.DeserializeObject(unwrappedResponse, ModelType);


            return unwrappedResponse;
        }
    }
}