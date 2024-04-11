using Day21;

string monsterFile = @"..\Day21\input.txt";
string[] monsterLines = File.ReadAllLines(monsterFile);
Monster monster = new(int.Parse(monsterLines[0].Split(": ")[1]),
                            int.Parse(monsterLines[1].Split(": ")[1]),
                            int.Parse(monsterLines[2].Split(": ")[1]));

string equipFile = @"..\Day21\equipment.txt";
(List<Weapon> weapons, List<Armour> armour, List<Ring> rings) = Equipment.ParseEquipment(equipFile);

var equipmentCombinations = Equipment.AllCombinations(weapons, armour, rings);

//Results
var (cheapestHero, mostExpensiveLoser) = FightingResults(monster, equipmentCombinations);
Console.WriteLine($"The lowest cost needed to win was {cheapestHero} and the highest cost without winning was {mostExpensiveLoser}.");


(int, int) FightingResults(Monster monster, IEnumerable<Equipment[]> equipmentCombinations)
{
    Dictionary<Hero, int> heroes = new();
    Dictionary<Hero, int> losers = new();
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
        int heroHitpoints = hero.Hitpoints;
        int monsterHitpoints = monster.Hitpoints;

        int equipmentCost = hero.EquipmentValue();
        while (heroHitpoints > 0 && monsterHitpoints > 0)
        {
            monsterHitpoints -= totalHeroDamage; // hero attacks first
            if (monsterHitpoints <= 0)
            {
                heroes.Add(hero, equipmentCost);
            }

            heroHitpoints -= totalMonsterDamage;
            if (heroHitpoints <= 0)
            {
                losers.Add(hero, equipmentCost);
            }
        }
    }

    Console.WriteLine($"{heroes.Count} heroes were able to defeat the monster and {losers.Count} were not.");

    int cheapestHero = heroes.MinBy(kvp => kvp.Value).Value;
    int mostExpensiveLoser = losers.MaxBy(kvp => kvp.Value).Value;

    return (cheapestHero, mostExpensiveLoser);
}