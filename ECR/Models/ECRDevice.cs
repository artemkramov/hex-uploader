using ECR.Events;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECR.Models
{

    /// <summary>
    /// Entity for working with device data
    /// </summary>
    class ECRDevice
    {

        /// <summary>
        /// Constant for sending of the X report
        /// </summary>
        public const int X_REPORT = 10;

        /// <summary>
        /// Constant for sending of the Z report
        /// </summary>
        public const int Z_REPORT = 0;

        /// <summary>
        /// Constant which indicates the success response during the hardware update
        /// </summary>
        private const int RESPONSE_SUCCESS = 0;

        /// <summary>
        /// Http client for request sending
        /// </summary>
        private HttpClientInstance httpClient = new HttpClientInstance();

        /// <summary>
        /// Payment types of device
        /// </summary>
        private List<ExpandoObject> paymentTypes;

        /// <summary>
        /// Departments of device
        /// </summary>
        private List<ExpandoObject> departments;

        /// <summary>
        /// Groups of device
        /// </summary>
        private List<ExpandoObject> groups;

        /// <summary>
        /// Taxes of device
        /// </summary>
        private List<ExpandoObject> taxes;

        /// <summary>
        /// Validator entity
        /// </summary>
        private Validator validator = new Validator();

        /// <summary>
        /// Handler of the http error event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void HttpErrorHandler(object sender, HttpErrorEventArgs e);

        /// <summary>
        /// Event of the http error
        /// </summary>
        public event HttpErrorHandler HttpErrorEvent;

        /// <summary>
        /// Method triggered on the http error
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnHttpError(HttpErrorEventArgs e)
        {
            if (HttpErrorEvent != null)
                HttpErrorEvent(this, e);
        }

        /// <summary>
        /// Initialize http client data with the credentials
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Connect(string baseAddress, string username, string password)
        {
            this.httpClient.Connect(baseAddress, username, password);
        }

        /// <summary>
        /// Get current state info
        /// </summary>
        /// <returns></returns>
        public dynamic GetState()
        {
            var parameters = new Dictionary<string, string>();
            return httpClient.RequestGet("/cgi/state", parameters, false).Result;
        }

        /// <summary>
        /// Send payment data
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public dynamic SendPayment(int number, float sum)
        {
            Payment payment = new Payment();
            payment.Set("number", number);
            payment.Set("sum", sum);
            return httpClient.RequestPost("/cgi/chk", payment, false);
        }

        /// <summary>
        /// Send general payment data
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public dynamic SendPaymentGeneral(PaymentGeneral payment)
        {
            return httpClient.RequestPost("/cgi/chk", payment, false);
        }

        public async void UploadHexFile(IntelHex intelHex)
        {
            FirmwareInfo firmwareInfo = new FirmwareInfo();
            firmwareInfo.Set("Version", intelHex.Headers.Version);
            firmwareInfo.Set("Description", intelHex.Headers.Description);
            firmwareInfo.Set("FirmwareGUID",intelHex.Headers.FirmwareGUID);
            Task<dynamic> task = this.SendFirmwareInfo(firmwareInfo);
            dynamic result = await task;
            ResponseFirmware responseFirmwareInfo = ParseFirmwareInfoResponse(result);
            if (responseFirmwareInfo.IsSuccess)
            {
                
            }
            
        }

        public ResponseFirmware ParseFirmwareInfoResponse(dynamic response)
        {
            ResponseFirmware responseFirmware = new ResponseFirmware();
            responseFirmware.Error = "";
            responseFirmware.IsSuccess = false;
            try
            {
                if (response != null)
                {
                    if (response.fw_info_error != null)
                    {
                        responseFirmware = CheckFirmwareFieldForError(response.fw_info_error);
                    }
                }
            }
            catch (Exception ex) { responseFirmware.Error = "System error: " + ex.Message; }
            return responseFirmware;
        }

        public ResponseFirmware ParseFirmwareUploadResponse(dynamic response)
        {
            ResponseFirmware responseFirmware = new ResponseFirmware();
            responseFirmware.Error = "";
            responseFirmware.IsSuccess = false;
            try
            {
                if (response != null)
                {
                    if (response.fw_upload_error != null)
                    {
                        responseFirmware = CheckFirmwareFieldForError(response.fw_upload_error);
                    }
                }
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
            return responseFirmware;
        }

        public ResponseFirmware ParseFirmwareResponseBurn(dynamic response)
        {
            ResponseFirmware responseFirmware = new ResponseFirmware();
            responseFirmware.Error = "";
            responseFirmware.IsSuccess = false;
            try
            {
                if (response != null)
                {
                    if (response.fw_burn_error != null)
                    {
                        responseFirmware = CheckFirmwareFieldForError(response.fw_burn_error);
                    }
                }
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
            return responseFirmware;
        }

        public ResponseFirmware CheckFirmwareFieldForError(dynamic field)
        {
            ResponseFirmware response = new ResponseFirmware();
            response.IsSuccess = true;
            response.Error = "";
            try
            {
                int responseCode = int.Parse(field);
                if (responseCode != RESPONSE_SUCCESS)
                {
                    response.IsSuccess = false;
                    response.Error = ECRDictionary.GetTranslation(field);
                    return response;
                }
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Error = ECRDictionary.GetTranslation(field);
                return response;
            }
            return response;
        }

        public void ShowError(string message)
        {
            HttpErrorEventArgs args = new HttpErrorEventArgs();
            args.Message = message;
            OnHttpError(args);
        }

        /// <summary>
        /// Send firmware info
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public dynamic SendFirmwareInfo(FirmwareInfo info)
        {
            return httpClient.RequestPost("/cgi/fw_version", info, false).Result;
        }

        /// <summary>
        /// Send HEX file to cash register
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public dynamic SendHexFile(byte[] buffer)
        {
            return httpClient.RequestPostUploadFile("/cgi/fw_upload", buffer).Result;
        }

        public dynamic Flash()
        {
            return httpClient.RequestPost("/cgi/fw_burn", new FirmwareFlash(), false).Result;
        }

        public dynamic GetInformation()
        {
            var parameters = new Dictionary<string, string>();
            return httpClient.RequestGet("/cgi/fw_version", parameters, false).Result;
        }

        /// <summary>
        /// Send report by the appropriate type 
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        public dynamic SendReport(int reportType)
        {
            var parameters = new Dictionary<string, string>();
            return httpClient.RequestGet("/cgi/proc/printreport?" + reportType.ToString(), parameters, false);
        }

        /// <summary>
        /// Load all necessary device data
        /// </summary>
        public void LoadDeviceData()
        {
            
        }

        /// <summary>
        /// Load all error translations from device
        /// </summary>
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

        /// <summary>
        /// Return the application cultural info (decimal point type etc.)
        /// </summary>
        /// <returns></returns>
        public CultureInfo GetDefaultCulturalInfo()
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = this.validator.GetDecimalDelimiter();
            return ci;
        }


        /// <summary>
        /// HttpClient property
        /// </summary>
        public HttpClientInstance HttpClient
        {
            private set { httpClient = value; }
            get { return httpClient; }
        }

        /// <summary>
        /// PaymentTypes property
        /// </summary>
        public List<ExpandoObject> PaymentTypes
        {
            private set { paymentTypes = value; }
            get { return paymentTypes; }
        }

        /// <summary>
        /// Departments property
        /// </summary>
        public List<ExpandoObject> Departments
        {
            private set { departments = value; }
            get { return departments; }
        }

        /// <summary>
        /// Groups property
        /// </summary>
        public List<ExpandoObject> Groups
        {
            private set { groups = value; }
            get { return groups; }
        }

        /// <summary>
        /// Taxes property
        /// </summary>
        public List<ExpandoObject> Taxes
        {
            private set { taxes = value; }
            get { return taxes; }
        }

    }

    public class ResponseFirmware
    {

        private bool isSuccess;
        private string error;

        public bool IsSuccess
        {
            set { this.isSuccess = value; }
            get { return this.isSuccess; }
        }

        public string Error
        {
            set { this.error = value; }
            get { return this.error; }
        }

    }

}
