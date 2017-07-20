using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{

    /// <summary>
    /// Interface for the POST JSON model
    /// </summary>
    interface IEntity
    {

        /// <summary>
        /// Converts all internal data to JSON string
        /// </summary>
        /// <returns></returns>
        string ToJson();

    }
}
