using Day22;

string filePath = @"..\Day22\input.txt";
string[] input = File.ReadAllLines(filePath);

int[] monsterStats = { int.Parse(input[0].Split(": ")[1]), int.Parse(input[1].Split(": ")[1]) };
int[] playerStats = { 50, 500 };
// int[] monsterStats = { 14, 8 };
// int[] playerStats = { 10, 250 };

Dictionary<SpellKey, Spell> spells = new()
{
    [SpellKey.MagicMissile] = new("Magic Missile", 53, Damage: 4),
    [SpellKey.Drain] = new("Drain", 73, Damage: 2, Healing: 2),
    [SpellKey.Shield] = new("Shield", 113, 6, Armour: 7),
    [SpellKey.Poison] = new("Poison", 173, 6, 3),
    [SpellKey.Recharge] = new("Recharge", 229, 5, ManaRecharge: 101)
};

Dictionary<SpellKey, int> activeSpells = new();

List<int> manaSpentList = new() { 2000 };
int manaSpent = 0;
while (manaSpentList.Count < 10)
{
    manaSpent = 0;
    GameCharacter player = new(playerStats[0], playerStats[1]);
    GameCharacter monster = new(hitpoints: monsterStats[0], damage: monsterStats[1]);
    activeSpells.Clear();

    //Game loop
    while (player.Hitpoints > 0)
    {
        //Player turn
        player.Hitpoints--; // hard mode (part 2)

        if (player.Hitpoints <= 0)
            break;

        ApplyActiveSpells(player, monster, activeSpells);
        if (monster.Hitpoints <= 0)
        {
            manaSpentList.Add(manaSpent);
            break;
        }

        if (!RandomSpells(player, monster, spells))
        {
            break;
        }

        if (manaSpent > manaSpentList.Min())
            break;

        //Monster turn
        ApplyActiveSpells(player, monster, activeSpells);
        if (monster.Hitpoints <= 0)
        {
            manaSpentList.Add(manaSpent);
            break;
        }

        player.Hitpoints -= monster.Damage - player.Armour;
    }
}

Console.WriteLine(manaSpentList.Min());

bool RandomSpells(GameCharacter player, GameCharacter monster, Dictionary<SpellKey, Spell> spells)
{
    var options = spells.Where(kvp => kvp.Value.ManaCost < player.Mana && !activeSpells.ContainsKey(kvp.Key)).ToList();

    if (options.Count == 0)
        return false;

    Random random = new();
    int choice = random.Next(0, options.Count);
    SpellKey spellKey = options[choice].Key;
    Spell spell = options[choice].Value;

    player.Mana -= spell.ManaCost;
    manaSpent += spell.ManaCost;

    if (spell == spells[SpellKey.MagicMissile])
        monster.Hitpoints -= spell.Damage;
    else if (spell == spells[SpellKey.Drain])
    {
        monster.Hitpoints -= spell.Damage;
        player.Hitpoints += spell.Healing;
    }
    else activeSpells.Add(spellKey, spell.Duration);

    return true;
}

void ApplyActiveSpells(GameCharacter player, GameCharacter monster, Dictionary<SpellKey, int> activeSpells)
{
    if (!activeSpells.Any())
        return;

    foreach (var spellKey in activeSpells.Keys)
    {
        Spell spell = spells[spellKey];
        player.Mana += spell.ManaRecharge;
        monster.Hitpoints -= spell.Damage;

        if (spellKey == SpellKey.Shield)
            player.Armour = spell.Armour;

        activeSpells[spellKey]--;

        if (activeSpells[spellKey] == 0)
        {
            if (spellKey == SpellKey.Shield)
                player.Armour = 0;

            activeSpells.Remove(spellKey);
        }
    }
}


