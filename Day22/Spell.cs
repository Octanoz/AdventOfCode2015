namespace Day22;
record Spell(string Name, int ManaCost, int Duration = 0, int Damage = 0, int Healing = 0, int Armour = 0, int ManaRecharge = 0);

public enum SpellKey
{
    MagicMissile,
    Drain,
    Shield,
    Poison,
    Recharge
}
