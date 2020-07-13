using System;

namespace Friends.Domain.Entity
{
    public class EntityBase
    {
        public int Id { get; protected set; }
        public bool IsNew => Id == 0;
    }
}
