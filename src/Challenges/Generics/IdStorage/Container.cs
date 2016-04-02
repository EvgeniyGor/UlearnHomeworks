using System;

namespace Generics.IdStorage
{
    internal class Container
    {
        public Guid Id { get; set; }
        public object Object { get; set; }
        public Type Type { get; set; }
    }
}