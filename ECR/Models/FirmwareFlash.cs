using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ECR.Models
{

    /// <summary>
    /// Entity for method '/cgi/fw_burn'
    /// </summary>
    class FirmwareFlash : Entity
    {

        /// <summary>
        /// Form the JSON string
        /// </summary>
        /// <returns></returns>
        public override string ToJson()
        {
            dynamic dataObject = new ExpandoObject();
            return JsonConvert.SerializeObject(dataObject);
        }

    }
}
