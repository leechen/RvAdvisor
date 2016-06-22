using System;
using Advisor.Sdk;

namespace Advisor.ObjectModel
{
    public class RvPark : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Phone { get; set; }
        public int Capacity { get; set; }

        public virtual Address Address { get; set;}
    }
}
