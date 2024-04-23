namespace Day22;

class GameCharacter
{
    public int Hitpoints { get; set; }
    public int Mana { get; set; }
    public int Damage { get; set; }
    public int Armour { get; set; }

    public GameCharacter(int hitpoints, int mana = 0, int damage = 0, int armour = 0)
    {
        Hitpoints = hitpoints;
        Mana = mana;
        Damage = damage;
        Armour = armour;
    }
}
