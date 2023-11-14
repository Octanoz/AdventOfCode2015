namespace Day15;

class Ingredient
{
    public Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
    {
        Name = name;
        Capacity = capacity;
        Durability = durability;
        Flavor = flavor;
        Texture = texture;
        Calories = calories;
    }

    public string Name { get; set; }
    public int Capacity { get; set; }
    public int Durability { get; set; }
    public int Flavor { get; set; }
    public int Texture { get; set; }
    public int Calories { get; set; }


}