using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{

    /// <summary>
    /// Collection of JSON models
    /// </summary>
    class EntityCollection : IEntity
    {
        /// <summary>
        /// Collection of entities
        /// </summary>
        private List<Entity> collection = new List<Entity>();

        /// <summary>
        /// Add the entity to collection
        /// </summary>
        /// <param name="_entity"></param>
        public void Add(Entity _entity)
        {
            collection.Add(_entity);
        }

        /// <summary>
        /// Convert the collection of entites to JSON string
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            var propertiesList = new List<object>();
            foreach (Entity entity in collection)
            {
                var attributes = entity.GetAttributes();
                var expandObject = new ExpandoObject();
                var expandCollection = (ICollection<KeyValuePair<string, object>>)expandObject;

                foreach (var property in attributes)
                {
                    expandCollection.Add(property);
                }
                propertiesList.Add(expandCollection);
            }
            var json = JsonConvert.SerializeObject(propertiesList);
            return json;
        }

    }
}
