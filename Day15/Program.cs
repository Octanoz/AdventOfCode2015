using System.Text.RegularExpressions;
using Day15;

// string filePath = @"..\Day15\example1.txt";
string filePath = @"..\Day15\input.txt";
string[] input = File.ReadAllLines(filePath);

const int nrOfIngredients = 4;
Regex properties = new(@"([A-Z]\w+)|([-]?\d+)");
List<Ingredient> ingredients = new();
foreach (var line in input)
{
    string[] parts = properties.Matches(line).Cast<Match>().Select(match => match.Value).ToArray();
    // [Name] [Capacity] [Durability] [Flavor] [Texture] [Calories]
    // ingredients[index++] = new int[] { int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]) };
    ingredients.Add(new Ingredient(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
}

Dictionary<string, int> props = new()
{
    ["capacity"] = 0,
    ["durability"] = 0,
    ["flavor"] = 0,
    ["texture"] = 0,
    ["calories"] = 0
};

int targetSum = 100;
List<long> totals = new();
foreach (var combination in CombineFour(targetSum))
{
    props["capacity"] = Math.Max(0, combination[0] * ingredients[0].Capacity +
                                                    (combination[1] * ingredients[1].Capacity) +
                                                    (combination[2] * ingredients[2].Capacity) +
                                                    (combination[3] * ingredients[3].Capacity));

    props["durability"] = Math.Max(0, combination[0] * ingredients[0].Durability +
                                                    (combination[1] * ingredients[1].Durability) +
                                                    (combination[2] * ingredients[2].Durability) +
                                                    (combination[3] * ingredients[3].Durability));

    props["flavor"] = Math.Max(0, combination[0] * ingredients[0].Flavor +
                                                (combination[1] * ingredients[1].Flavor) +
                                                (combination[2] * ingredients[2].Flavor) +
                                                (combination[3] * ingredients[3].Flavor));

    props["texture"] = Math.Max(0, combination[0] * ingredients[0].Texture +
                                                    (combination[1] * ingredients[1].Texture) +
                                                    (combination[2] * ingredients[2].Texture) +
                                                    (combination[3] * ingredients[3].Texture));

    props["calories"] = Math.Max(0, combination[0] * ingredients[0].Calories +
                                                    (combination[1] * ingredients[1].Calories) +
                                                    (combination[2] * ingredients[2].Calories) +
                                                    (combination[3] * ingredients[3].Calories));

    if (props["calories"] == 500)
        totals.Add(props["capacity"] * props["durability"] * props["flavor"] * props["texture"]);
}

Console.WriteLine($"Highest value = {totals.Max()}");


IEnumerable<int[]> CombineFour(int target)
{
    for (int a = 0; a <= target; a++)
        for (int b = 0; b <= target - a; b++)
            for (int c = 0; c <= target - b - a; c++)
                yield return new[] { a, b, c, target - a - b - c };
}



