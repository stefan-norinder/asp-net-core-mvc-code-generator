using System;

namespace Example.Models
{
    public class Entity
    {
        public virtual int Id { get; set; }

        public override bool Equals(object obj)
        {
            var castedObj = obj as Entity;
            if (castedObj == null) throw new ArgumentException(obj.GetType().Name);
            if (BothEntitiesAreNew(castedObj)) return false;
            return Id == castedObj.Id;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        private bool BothEntitiesAreNew(Entity castedObj)
        {
            return Id == 0 && castedObj.Id == 0;
        }
    }
}
