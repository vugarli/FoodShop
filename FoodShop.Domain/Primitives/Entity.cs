﻿using Microsoft.VisualBasic.CompilerServices;

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
        if (first is null || second is null) return false;
        return first.Equals(second);
    }
    public static bool operator!=(Entity? first, Entity? second )
    {
        if (first is null || second is null) return false;
        return !(first == second);
    }
    public bool Equals(Entity? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }
    

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}