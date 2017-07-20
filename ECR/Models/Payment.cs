using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{

    /// <summary>
    /// Model for sending of the payment data
    /// </summary>
    class Payment : Entity
    {

        /// <summary>
        /// Form the JSON string
        /// </summary>
        /// <returns></returns>
        public override string ToJson()
        {
            dynamic dataObject = new ExpandoObject();
            dataObject.no = this.Get("number");
            dataObject.sum = this.Get("sum");

            dynamic innerObject = new ExpandoObject();
            innerObject.IO = dataObject;

            dynamic sampleObject = new ExpandoObject();
            sampleObject.IO = new ExpandoObject[] { 
                innerObject
            };
            return JsonConvert.SerializeObject(sampleObject);
        }

    }
}
