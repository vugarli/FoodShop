using Microsoft.VisualBasic.CompilerServices;

namespace FoodShop.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id {
        get;
        init;
    }

    public Entity(Guid id)
    {
        Id = id;
    }
    
    public static bool operator==(Entity? first, Entity? second )
    {
        return second != null && first != null && first.Equals(second);
    }
    public static bool operator!=(Entity? first, Entity? second )
    {
        return !(first == second);
    }
    public bool Equals(Entity? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}