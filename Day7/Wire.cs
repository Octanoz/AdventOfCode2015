namespace Day7;

class Wire : IEquatable<Wire>
{
    public Wire(string name, ushort strength)
    {
        Name = name;
        Strength = strength;
    }

    public string Name { get; set; }
    public ushort Strength { get; set; }

    public bool Equals(Wire? other)
    {
        if (other is null)
            return false;

        return Name.Equals(other.Name);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj is not Wire objAsWire)
            return false;
        else return Equals(objAsWire);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override string ToString()
    {
        return $"[{Name}, {Strength}]";
    }
}

