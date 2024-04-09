using System.Text;
using MoreLinq;

string input = "1113222113";

string resultOne = LookSay(input, 40);
Console.WriteLine(resultOne.Length);

string resultTwo = LookSay2(input, 50);
Console.WriteLine(resultTwo.Length);

Console.WriteLine($"Using MoreLinq for part two: {PartTwoMoreLinq(input)}");


string LookSay(string input, int amount)
{
    if (amount == 0)
        return input;

    string previousString = LookSay(input, amount - 1);
    StringBuilder result = new();
    char c = previousString[0];
    int frequency = 0;

    for (int i = 0; i < previousString.Length; i++)
    {
        if (previousString[i] == c)
        {
            frequency++;
        }
        else
        {
            result.Append(frequency).Append(c);
            c = previousString[i];
            frequency = 1;
        }
    }

    result.Append(frequency).Append(c);

    return result.ToString();
}

string LookSay2(string input, int amount)
{
    if (amount == 0)
        return input;

    string previousString = LookSay2(input, amount - 1);
    StringBuilder result = new();
    char c = previousString[0];
    int frequency = 0;

    for (int i = 0; i < previousString.Length; i++)
    {
        if (previousString[i] == c)
        {
            frequency++;
        }
        else
        {
            result.Append(frequency).Append(c);
            c = previousString[i];
            frequency = 1;
        }
    }

    result.Append(frequency).Append(c);

    return result.ToString();
}


int PartTwoMoreLinq(string input) => Enumerable.Range(1, 50)
                                                .Aggregate(input
                                                    .Select(c => c - '0').ToArray(),
                                                        (acc, _) => acc.GroupAdjacent(n => n)
                                                        .SelectMany(g => new int[] { g.Count(), g.First() })
                                                .ToArray())
                                                .Length;

