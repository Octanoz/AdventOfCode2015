using Day21;

string monsterFile = @"..\Day21\input.txt";
string[] monsterLines = File.ReadAllLines(monsterFile);
Monster monster = new(int.Parse(monsterLines[0].Split(": ")[1]),
                            int.Parse(monsterLines[1].Split(": ")[1]),
                            int.Parse(monsterLines[2].Split(": ")[1]));

List<Weapon> weapons = new();
List<Armour> armour = new();
List<Ring> rings = new();
string equipFile = @"..\Day21\equipment.txt";
using (StreamReader sr = new(equipFile))
{
    while (!sr.EndOfStream)
    {
        string currentLine = sr.ReadLine()!;
        if (currentLine.Contains("Weapons:"))
        {
            currentLine = sr.ReadLine()!;
            while (currentLine != "")
            {
                string[] parts = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                weapons.Add(new(parts[0], int.Parse(parts[1]), int.Parse(parts[2])));
                currentLine = sr.ReadLine()!;
            }
        }
        currentLine = sr.ReadLine()!;

        if (currentLine.Contains("Armor:"))
        {
            currentLine = sr.ReadLine()!;
            while (currentLine != "")
            {
                string[] parts = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                armour.Add(new(parts[0], int.Parse(parts[1]), int.Parse(parts[3])));
                currentLine = sr.ReadLine()!;
            }
        }
        currentLine = sr.ReadLine()!;

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
}

List<Equipment[]> equipmentCombinations = new();
foreach (Weapon weapon in weapons)
{
    foreach (Armour? armourPiece in new Armour?[] { null }.Concat(armour))
    {
        equipmentCombinations.Add(new Equipment[] { weapon, armourPiece! });

        for (int i = 0; i < rings.Count; i++)
        {
            equipmentCombinations.Add(new Equipment[] { weapon, armourPiece!, rings[i] });

            for (int j = i + 1; j < rings.Count; j++)
            {
                equipmentCombinations.Add(new Equipment[] { weapon, armourPiece!, rings[i], rings[j] });
            }
        }
    }
}

Dictionary<Hero, int> winningHeroes = new();
Dictionary<Hero, int> losingHeroes = new();
foreach (var equipmentSet in equipmentCombinations)
{
    Hero hero = equipmentSet.Length switch
    {
        1 => new((Weapon)equipmentSet[0]),
        2 => new((Weapon)equipmentSet[0], (Armour)equipmentSet[1]),
        3 => new((Weapon)equipmentSet[0], (Armour)equipmentSet[1], (Ring)equipmentSet[2]),
        4 => new((Weapon)equipmentSet[0], (Armour)equipmentSet[1], (Ring)equipmentSet[2], (Ring)equipmentSet[3]),
        _ => throw new InvalidOperationException(nameof(equipmentSet))
    };

    int totalHeroDamage = Math.Max(1, hero.Weapon.Damage + (hero.Ring1?.Damage ?? 0) + (hero.Ring2?.Damage ?? 0) - monster.Armour);
    int totalHeroArmour = (hero.Armour?.Armor ?? 0) + (hero.Ring1?.Armor ?? 0) + (hero.Ring2?.Armor ?? 0);
    int totalMonsterDamage = Math.Max(1, monster.Damage - totalHeroArmour);

    if (totalHeroDamage >= totalMonsterDamage)
    {
        int equipmentCost = hero.EquipmentValue();
        winningHeroes.Add(hero, equipmentCost);
    }
    else
    {
        int equipmentCost = hero.EquipmentValue();
        losingHeroes.Add(hero, equipmentCost);
    }
}

Console.WriteLine($"There were {equipmentCombinations.Count} possible equipment sets.");
Console.WriteLine($"{winningHeroes.Count} heroes were able to defeat the monster and {losingHeroes.Count} were not.");

var cheapestHero = winningHeroes.MinBy(kvp => kvp.Value).Value;
var mostExpensiveLoser = losingHeroes.MaxBy(kvp => kvp.Value).Value;

Console.WriteLine($"\nThe lowest cost needed to win was {cheapestHero} and the highest cost without winning was {mostExpensiveLoser}.");

record Monster(int Hitpoints, int Damage, int Armour);
