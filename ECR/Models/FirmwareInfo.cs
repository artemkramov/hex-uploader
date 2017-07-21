using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ECR.Models
{

    /// <summary>
    /// Entity for method '/cgi/fw_version'
    /// </summary>
    class FirmwareInfo : Entity
    {
        /// <summary>
        /// Form the JSON string
        /// </summary>
        /// <returns></returns>
        public override string ToJson()
        {
            dynamic dataObject = new ExpandoObject();
            dataObject.fw_guid = this.Get("FirmwareGUID");
            dataObject.fw_version = this.Get("Version");
            dataObject.fw_descr = this.Get("Description");

            return JsonConvert.SerializeObject(dataObject);
        }
    }
}
