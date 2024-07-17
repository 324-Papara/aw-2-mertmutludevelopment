using System;

namespace Para.Base.Entity
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
        public string InsertUser { get; set; } = "System";
    }
}