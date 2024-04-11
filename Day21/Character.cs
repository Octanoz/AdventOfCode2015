namespace Day21;

record Hero(Weapon Weapon, Armour? Armour = null, Ring? Ring1 = null, Ring? Ring2 = null, int Hitpoints = 100)
{
    public int EquipmentValue() => Weapon.Cost + (Armour?.Cost ?? 0) + (Ring1?.Cost ?? 0) + (Ring2?.Cost ?? 0);
}

record Monster(int Hitpoints, int Damage, int Armour);
