using System;

namespace ObjectModel
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
