using System;

namespace Ebd.Domain.Core.Entities
{
    public interface IEntity<TKey> where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
