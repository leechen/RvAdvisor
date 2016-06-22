using System;
using System.ComponentModel.DataAnnotations;
using Advisor.Sdk;

namespace Advisor.ObjectModel
{
    public class Address : Entity
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }

        public float Latitude { get; set; }
        public float longitude { get; set; }

        [MaxLength(64)]
        public string ZipCode { get; set; }

        public virtual Area Area { get; set; }
    }
}
