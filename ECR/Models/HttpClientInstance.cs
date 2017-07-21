using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ECR.Events;
using System.Net;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Collections;

namespace ECR.Models
{

    /// <summary>
    /// Wrapper for http client
    /// </summary>
    class HttpClientInstance
    {

        /// <summary>
        /// Http client
        /// </summary>
        private static HttpClient client = null;

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
        /// Username string
        /// </summary>
        public string username;

        /// <summary>
        /// Password string
        /// </summary>
        public string password;

        /// <summary>
        /// URL of the device
        /// </summary>
        public string baseAddress;

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
        /// Initialize HttpClient and provide it with credentials for the device access
        /// </summary>
        /// <param name="_baseAddress"></param>
        /// <param name="_username"></param>
        /// <param name="_password"></param>
        public void Connect(string _baseAddress, string _username, string _password)
        {
            username = _username;
            password = _password;
            baseAddress = _baseAddress;
            baseAddress = baseAddress.Trim().TrimEnd('/');
            var credentialCache = new CredentialCache();
            credentialCache.Add(
              new Uri(baseAddress),
              "Digest", 
              new NetworkCredential(username, password)
            );

            client = new HttpClient(new HttpClientHandler { Credentials = credentialCache, PreAuthenticate = true });
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.ExpectContinue = false;
        }

        /// <summary>
        /// Provide GET request with parameters
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="parameters"></param>
        /// <param name="isGzip"></param>
        /// <returns></returns>
        public async Task<dynamic> RequestGet(string endPoint, Dictionary<string, string> parameters, bool isGzip)
        {
            dynamic data = null;
            /**
             * Append the query string
             */ 
            endPoint += BuildURLParametersString(parameters);
            try
            {
                HttpResponseMessage response = await client.GetAsync(endPoint).ConfigureAwait(true);
                response.EnsureSuccessStatusCode();

                /**
                 * Read response as byte array
                 */
                var buffer = await response.Content.ReadAsByteArrayAsync();
                var byteArray = buffer.ToArray();
                if (isGzip)
                {
                    byteArray = Decompress(byteArray);
                }
                string jsonRawData;
                
                /**
                 * Check if the string contains the BOM character
                 * */
                if (byteArray.Length >= 3 && byteArray[0] == 0xEF && byteArray[1] == 0xBB && byteArray[2] == 0xBF)
                    jsonRawData = Encoding.UTF8.GetString(byteArray, 3, byteArray.Length - 3);
                else
                    jsonRawData = Encoding.UTF8.GetString(byteArray);
                
                var converter = new ExpandoObjectConverter();
                try
                {
                    data = JsonConvert.DeserializeObject<ExpandoObject>(jsonRawData, converter);
                    var isError = false;
                    var errorKey = "";
                    var properties = (IDictionary<string, object>)data;
                    /**
                     * Investigate the response for the error availability
                     */ 
                    if (properties.ContainsKey("err"))
                    {
                        if (properties["err"] is IList)
                        {
 
                        }
                        if (properties["err"] is string)
                        {
                            isError = true;
                            errorKey = properties["err"].ToString();
                        }
                    }
                    if (isError)
                    {
                        var errorMessage = ECRDictionary.GetTranslation(errorKey);
                        HttpErrorEventArgs args = new HttpErrorEventArgs();
                        args.Message = errorMessage;
                        OnHttpError(args);
                    }
                }
                catch (Exception)
                {
                    data = JsonConvert.DeserializeObject<List<ExpandoObject>>(jsonRawData, converter);
                }
                return data;
            }
            catch (Exception e)
            {
                HttpErrorEventArgs args = new HttpErrorEventArgs();
                args.Message = e.Message;
                OnHttpError(args);
                return data;
            } 
        }

        /// <summary>
        /// Sanitaize JSON
        /// </summary>
        /// <param name="uglyJson"></param>
        /// <returns></returns>
        private string SanitizeReceivedJson(string uglyJson)
        {
            var sb = new StringBuilder(uglyJson);
            sb.Replace("\\\t", "\t");
            sb.Replace("\\\n", "\n");
            sb.Replace("\\\r", "\r");
            return sb.ToString();
        }

        /// <summary>
        /// Decompress got data from gzip
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            const int BUFFER_SIZE = 256;
            byte[] tempArray = new byte[BUFFER_SIZE];
            List<byte[]> tempList = new List<byte[]>();
            int count = 0, length = 0;
            MemoryStream ms = new MemoryStream(data);
            ms.ReadByte();
            ms.ReadByte();
            DeflateStream ds = new DeflateStream(ms, CompressionMode.Decompress);
            while ((count = ds.Read(tempArray, 0, BUFFER_SIZE)) > 0)
            {
                if (count == BUFFER_SIZE)
                {
                    tempList.Add(tempArray);
                    tempArray = new byte[BUFFER_SIZE];
                }
                else
                {
                    byte[] temp = new byte[count];
                    Array.Copy(tempArray, 0, temp, 0, count);
                    tempList.Add(temp);
                }
                length += count;
            }
            byte[] retVal = new byte[length];
            count = 0;
            foreach (byte[] temp in tempList)
            {
                Array.Copy(temp, 0, retVal, count, temp.Length);
                count += temp.Length;
            }
            return retVal;
        }

        /// <summary>
        /// Send binary data to the chosen endpoint
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public async Task<dynamic> RequestPostUploadFile(string endPoint, byte[] buffer)
        {
            dynamic data = null;
            try
            {

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, endPoint);

                requestMessage.Content = new ByteArrayContent(buffer);
                HttpResponseMessage response = await client.SendAsync(requestMessage).ConfigureAwait(continueOnCapturedContext: false);
                var jsonRawData = await response.Content.ReadAsStringAsync();
                data = ParseResponse(jsonRawData);
                return data;
            }
            catch (Exception e)
            {
                HttpErrorEventArgs args = new HttpErrorEventArgs();
                args.Message = e.Message;
                OnHttpError(args);
                return data;
            }
        }

        /// <summary>
        /// Make POST request
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="parameters"></param>
        /// <param name="isPatchRequest"></param>
        /// <returns></returns>
        public async Task<dynamic> RequestPost(string endPoint, IEntity parameters, bool isPatchRequest)
        {
            dynamic data = null;
            string jsonData = parameters.ToJson();
            try
            {

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, endPoint);
                
                requestMessage.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");               
                
                if (isPatchRequest)
                {
                    requestMessage.Headers.Add("X-HTTP-Method-Override", "PATCH");
                }
                HttpResponseMessage response = await client.SendAsync(requestMessage).ConfigureAwait(continueOnCapturedContext: false);
                var jsonRawData = await response.Content.ReadAsStringAsync();
                data = ParseResponse(jsonRawData);
                return data;
            }
            catch (Exception e)
            {
                HttpErrorEventArgs args = new HttpErrorEventArgs();
                args.Message = e.Message;
                OnHttpError(args);
                return data;
            }
        }

        /// <summary>
        /// Parse response from the server
        /// </summary>
        /// <param name="jsonRawData"></param>
        /// <returns></returns>
        private dynamic ParseResponse(dynamic jsonRawData)
        {
            dynamic data = null;
            var converter = new ExpandoObjectConverter();
            try
            {
                data = JsonConvert.DeserializeObject<ExpandoObject>(jsonRawData, converter);
                try
                {
                    if (data.err.e != null)
                    {
                        var errorMessage = ECRDictionary.GetTranslation(data.err.e);
                        HttpErrorEventArgs args = new HttpErrorEventArgs();
                        args.Message = errorMessage;
                        OnHttpError(args);
                    }
                }
                catch (Exception) { }
            }
            catch (Exception)
            {
                data = JsonConvert.DeserializeObject<List<ExpandoObject>>(jsonRawData, converter);
            }
            return data;
        }

        /// <summary>
        /// Build query string
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static String BuildURLParametersString(Dictionary<string, string> parameters)
        {
            UriBuilder uriBuilder = new UriBuilder();
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var urlParameter in parameters)
            {
                query[urlParameter.Key] = urlParameter.Value;
            }
            uriBuilder.Query = query.ToString();
            return uriBuilder.Query;
        }
         
    }
}
