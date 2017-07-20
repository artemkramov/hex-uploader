using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{
    class ECRDevice
    {

        public const int X_REPORT = 10;

        public const int Z_REPORT = 0;

        private HttpClientInstance httpClient = new HttpClientInstance();

        private List<ExpandoObject> paymentTypes;

        public void Connect(string baseAddress, string username, string password)
        {
            this.httpClient.Connect(baseAddress, username, password);
        }

        public dynamic GetState()
        {
            var parameters = new Dictionary<string, string>();
            return httpClient.RequestGet("/cgi/state", parameters, false).Result;
        }

        public dynamic SendPayment(int number, float sum)
        {
            Payment payment = new Payment();
            payment.Set("number", number);
            payment.Set("sum", sum);
            return httpClient.RequestPost("/cgi/chk", payment, false);
        }

        public dynamic SendReport(int reportType)
        {
            var parameters = new Dictionary<string, string>();
            return httpClient.RequestGet("/cgi/proc/printreport?" + reportType.ToString(), parameters, false);
        }

        public void LoadDeviceData()
        {
            this.PaymentTypes = httpClient.RequestGet("/cgi/tbl/Pay", new Dictionary<string,string>(), false).Result;
        }

        public void LoadTranslations()
        {
            try
            {
                var descriptions = httpClient.RequestGet("/desc", new Dictionary<string, string>(), true).Result;
                var defaultLanguage = descriptions.def;
                var byName = (IDictionary<string, object>)descriptions;
                var data = byName[defaultLanguage];
                var errors = data.err;
                foreach (KeyValuePair<string, object> kvp in errors)
                {
                    ECRDictionary.AddTranslations(kvp.Key.ToString(), kvp.Value.ToString());
                }
            }
            catch (Exception) { }
        }

        public HttpClientInstance HttpClient
        {
            private set { httpClient = value; }
            get { return httpClient; }
        }

        public List<ExpandoObject> PaymentTypes
        {
            private set { paymentTypes = value; }
            get { return paymentTypes; }
        }

    }
}
