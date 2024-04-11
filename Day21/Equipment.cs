namespace Day21;

abstract class Equipment
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }

    protected Equipment(string name, int cost, int damage, int armor)
    {
        Name = name;
        Cost = cost;
        Damage = damage;
        Armor = armor;
    }

    public static (List<Weapon>, List<Armour>, List<Ring>) ParseEquipment(string equipFile)
    {
        List<Weapon> weapons = new();
        List<Armour> armour = new();
        List<Ring> rings = new();

        using StreamReader sr = new(equipFile);
        while (!sr.EndOfStream)
        {
            string currentLine = sr.ReadLine()!;
            if (currentLine.Contains("Weapons:"))
            {
                currentLine = sr.ReadLine()!;
                while (!String.IsNullOrEmpty(currentLine))
                {
                    string[] parts = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    weapons.Add(new(parts[0], int.Parse(parts[1]), int.Parse(parts[2])));
                    currentLine = sr.ReadLine()!;
                }
            }

            if (currentLine.Contains("Armor:"))
            {
                currentLine = sr.ReadLine()!;
                while (!String.IsNullOrEmpty(currentLine))
                {
                    string[] parts = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    armour.Add(new(parts[0], int.Parse(parts[1]), int.Parse(parts[3])));
                    currentLine = sr.ReadLine()!;
                }
            }

            if (currentLine.Contains("Rings:"))
            {
                currentLine = sr.ReadLine()!;
                while (!String.IsNullOrEmpty(currentLine))
                {
                    currentLine = currentLine.Replace(" +", "+");
                    string[] parts = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    rings.Add(new(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                    currentLine = sr.ReadLine()!;
                }
            }
        }

        return (weapons, armour, rings);
    }

    public static IEnumerable<Equipment[]> AllCombinations(List<Weapon> weapons, List<Armour> armour, List<Ring> rings)
    {
        foreach (Weapon weapon in weapons)
        {
            foreach (Armour? armourPiece in new Armour?[] { null }.Concat(armour))
            {
                yield return new Equipment[] { weapon, armourPiece! };

                for (int i = 0; i < rings.Count; i++)
                {
                    yield return new Equipment[] { weapon, armourPiece!, rings[i] };

                    for (int j = i + 1; j < rings.Count; j++)
                    {
                        yield return new Equipment[] { weapon, armourPiece!, rings[i], rings[j] };
                    }
                }
            }
        }
    }

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