using System.Text.RegularExpressions;
using Day15;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day15\example1.txt",
    ["challenge"] = @"..\Day15\input.txt",
};

string[] input = File.ReadAllLines(filePaths["challenge"]);

Regex cookieProperties = new(@"([A-Z]\w+)|([-]?\d+)");
List<Ingredient> ingredients = new();
foreach (var line in input)
{
    string[] parts = cookieProperties.Matches(line).Cast<Match>().Select(match => match.Value).ToArray();
    // [Name] [Capacity] [Durability] [Flavor] [Texture] [Calories]
    ingredients.Add(new Ingredient(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
}

Console.WriteLine($"Total score of the highest scoring cookie: {highestScore(ingredients)}");
Console.WriteLine($"Total score of the highest scoring cookie with 500 calories: {highestScore(ingredients, true)}");

int highestScore(List<Ingredient> ingredients, bool IsPartTwo = false)
{
    Dictionary<string, int> properties = new()
    {
        ["capacity"] = 0,
        ["durability"] = 0,
        ["flavor"] = 0,
        ["texture"] = 0,
        ["calories"] = 0
    };

    int targetSum = 100;
    List<int> totals = new();
    foreach (var combination in CombineFour(targetSum))
    {
        properties["capacity"] = Math.Max(0, combination[0] * ingredients[0].Capacity +
                                                        (combination[1] * ingredients[1].Capacity) +
                                                        (combination[2] * ingredients[2].Capacity) +
                                                        (combination[3] * ingredients[3].Capacity));

        properties["durability"] = Math.Max(0, combination[0] * ingredients[0].Durability +
                                                        (combination[1] * ingredients[1].Durability) +
                                                        (combination[2] * ingredients[2].Durability) +
                                                        (combination[3] * ingredients[3].Durability));

        properties["flavor"] = Math.Max(0, combination[0] * ingredients[0].Flavor +
                                                    (combination[1] * ingredients[1].Flavor) +
                                                    (combination[2] * ingredients[2].Flavor) +
                                                    (combination[3] * ingredients[3].Flavor));

        properties["texture"] = Math.Max(0, combination[0] * ingredients[0].Texture +
                                                        (combination[1] * ingredients[1].Texture) +
                                                        (combination[2] * ingredients[2].Texture) +
                                                        (combination[3] * ingredients[3].Texture));

        properties["calories"] = Math.Max(0, combination[0] * ingredients[0].Calories +
                                                        (combination[1] * ingredients[1].Calories) +
                                                        (combination[2] * ingredients[2].Calories) +
                                                        (combination[3] * ingredients[3].Calories));

        if (IsPartTwo)
        {
            if (properties["calories"] == 500)
            {
                totals.Add(properties["capacity"] * properties["durability"] * properties["flavor"] * properties["texture"]);
            }
        }
        else totals.Add(properties["capacity"] * properties["durability"] * properties["flavor"] * properties["texture"]);
    }

    return totals.Max();

}


IEnumerable<int[]> CombineFour(int target)
{
    for (int a = 0; a <= target; a++)
        for (int b = 0; b <= target - a; b++)
            for (int c = 0; c <= target - b - a; c++)
                yield return new[] { a, b, c, target - a - b - c };
}



