using System.Collections;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;


#region Solution 1

/* List<int> numbers = new();
List<string> colors = new();
const string JSON = @"..\Day12\input.json";
// string input = File.ReadAllText(JSON);
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

Console.WriteLine($"Sum of all numbers = {numbers.Sum()}"); */

#endregion

#region Solution 2

const string JSON = @"..\Day12\input.json";
string input = File.ReadAllText(JSON);

int result = IterateJson(JsonDocument.Parse(input).RootElement);

Console.WriteLine($"Sum of all numbers excluding property \"red\": {result}");

int IterateJson(JsonElement element) => element.ValueKind switch
{
    JsonValueKind.Object when element.EnumerateObject().Any(el => el.Value.ValueKind == JsonValueKind.String && el.Value.GetString() == "red") => 0,
    JsonValueKind.Object => element.EnumerateObject().Select(el => IterateJson(el.Value)).Sum(),
    JsonValueKind.Array => element.EnumerateArray().Select(IterateJson).Sum(),
    JsonValueKind.Number => element.GetInt32(),
    _ => 0
};


#endregion

