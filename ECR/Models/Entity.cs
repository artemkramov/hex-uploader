using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{

    /// <summary>
    /// Model for sending of JSON post data
    /// </summary>
    class Entity : IEntity
    {

        /// <summary>
        /// List of properties
        /// </summary>
        protected Dictionary<string, object> properties = new Dictionary<string, object>();

        /// <summary>
        /// Set the property by property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        public void Set(string property, object value)
        {
            if (!properties.ContainsKey(property))
            {
                properties.Add(property, value);
            }
            else
            {
                properties[property] = value;
            }
        }

        /// <summary>
        /// Get property by key
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public object Get(string property)
        {
            if (properties.ContainsKey(property))
            {
                return properties[property];
            }
            return null;
        }

        /// <summary>
        /// Get ths list of properties
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetAttributes()
        {
            return properties;
        }

        /// <summary>
        /// Convert model to JSON string
        /// </summary>
        /// <returns></returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(properties).ToString();
        }

    }
}
