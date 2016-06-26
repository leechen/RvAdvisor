using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Advisor.Sdk;

namespace Advisor.ObjectModel
{
    public class RvPark : Entity
    {
        [Index("IX_RvPark", 1, IsUnique = true)]
        [MaxLength(128)]
        [Required]
        public string Name { get; set; }

        [Index("IX_RvPark", 2, IsUnique = true)]
        [MaxLength(32)]
        [Required]
        public string Phone { get; set; }

        public string Description { get; set; }
        public int Capacity { get; set; }

        public virtual Address Address { get; set;}
    }
}
