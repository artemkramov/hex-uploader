using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{
    class Entity : IEntity
    {

        protected Dictionary<string, object> properties = new Dictionary<string, object>();

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

        public object Get(string property)
        {
            if (properties.ContainsKey(property))
            {
                return properties[property];
            }
            return null;
        }

        public Dictionary<string, object> GetAttributes()
        {
            return properties;
        }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(properties).ToString();
        }

    }
}
