using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Sdk;

namespace Advisor.ObjectModel
{
    public class ObjectModelHelper
    {
        public static RvPark NewRvPark(string name, string desc)
        {
            var park = new RvPark
            {
                Name = name,
                Description = desc,
            };

            SetDefault(park);

            return park;
        }

        private static void SetDefault(Entity entity)
        {
            entity.Created = DateTime.UtcNow;
            entity.LastUpdated = DateTime.UtcNow;
        }
    }
}
