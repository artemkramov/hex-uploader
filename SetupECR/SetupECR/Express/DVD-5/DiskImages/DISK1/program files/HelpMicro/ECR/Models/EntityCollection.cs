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
    class EntityCollection : IEntity
    {
        private List<Entity> collection = new List<Entity>();

        public void Add(Entity _entity)
        {
            collection.Add(_entity);
        }

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
