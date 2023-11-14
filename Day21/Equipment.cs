namespace Day21;

abstract class Equipment
{
    protected Equipment(string name, int cost, int damage, int armor)
    {
        Name = name;
        Cost = cost;
        Damage = damage;
        Armor = armor;
    }

    public string Name { get; set; }
    public int Cost { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
}
class Weapon : Equipment
{
    public Weapon(string name, int cost, int damage) : base(name, cost, damage, 0)
    {
    }
}

class Armour : Equipment
{
    public Armour(string name, int cost, int armor) : base(name, cost, 0, armor)
    {
    }
}

class Ring : Equipment
{
    public Ring(string name, int cost, int damage, int armor) : base(name, cost, damage, armor)
    {
    }
}