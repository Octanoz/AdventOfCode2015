using System.Text.Json;

const string JSON = @"..\Day12\input.json";

Console.WriteLine($"The sum of all numbers in the JSON file is {PartOne(JSON)}");
Console.WriteLine($"The sum of all numbers excluding property \"red\" is {PartTwo(JSON)}");

int PartOne(string JSON)
{
    List<int> numbers = new();
    List<string> colors = new();
    ReadOnlySpan<byte> jsonSpan = File.ReadAllBytes(JSON);

    Utf8JsonReader reader = new(jsonSpan);

    while (reader.Read())
    {
        JsonTokenType tokenType = reader.TokenType;

        switch (tokenType)
        {
            case JsonTokenType.Number:
                numbers.Add(reader.GetInt32());
                break;
        }
    }

    return numbers.Sum();
}

int PartTwo(string JSON)
{
    string input = File.ReadAllText(JSON);

    int result = IterateJson(JsonDocument.Parse(input).RootElement);

    int IterateJson(JsonElement element) => element.ValueKind switch
    {
        JsonValueKind.Object when element.EnumerateObject().Any(el => el.Value.ValueKind == JsonValueKind.String && el.Value.GetString() == "red") => 0,
        JsonValueKind.Object => element.EnumerateObject().Select(el => IterateJson(el.Value)).Sum(),
        JsonValueKind.Array => element.EnumerateArray().Select(IterateJson).Sum(),
        JsonValueKind.Number => element.GetInt32(),
        _ => 0
    };

    return result;
}
