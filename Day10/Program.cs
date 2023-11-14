#region Solution 1

using System.Text;

// string input = "1";
string input = "1321131112";

string result = LookSay(input, 40);

Console.WriteLine(result.Length);

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


#endregion

#region Solution 2

/* using System.Text;

string input = "1321131112"; //! 492982

string result = LookSay(input, 50);

Console.WriteLine(result.Length);

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
} */

#endregion

#region Morelinq Solution

/* using MoreLinq;

var result = Enumerable.Range(1, 50)
                        .Aggregate("1321131112".Select(c => c - '0')
                        .ToArray(), (acc, _) => acc
                        .GroupAdjacent(n => n)
                        .SelectMany(g => new int[] { g.Count(), g.First() })
                        .ToArray())
                        .Count();

Console.WriteLine(result); */

#endregion

