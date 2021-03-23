using System;

namespace Easy.Common.Shared.Entities
{
    public abstract class AggregateRoot : Entity, IAggregateRoot<long>, IConcurrency
    {
        public byte[] RowVersion { get; set; }
    }
}