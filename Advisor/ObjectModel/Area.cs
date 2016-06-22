using System;
using System.ComponentModel.DataAnnotations;
using Advisor.Sdk;

namespace Advisor.ObjectModel
{
    public class Area : Entity
    {
        [MaxLength(64)]
        public string City { get; set; }

        [MaxLength(64)]
        public string State { get; set; }

        [MaxLength(64)]
        public string StateCode { get; set; }
    }
}
