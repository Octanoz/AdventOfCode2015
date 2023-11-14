
#region Solution 1

/* // string filePath = @"..\Day1\example1.txt";
string filePath = @"..\Day1\input.txt";

int floor = File.ReadAllText(filePath).Sum(c => c == '(' ? 1 : -1);
Console.WriteLine($"Floor: {floor}"); */


#endregion

#region Solution 2

/* string filePath = @"..\Day1\input.txt";
string[] input = File.ReadAllLines(filePath);

Stack<char> openingP = new();
Stack<char> closingP = new();

string line = input[0];

for (int i = 0; i < line.Length; i++)
{
    if (line[i] == '(')
    {
        openingP.Push(line[i]);
    }
    else closingP.Push(line[i]);

    if (openingP.Count - closingP.Count == -1)
    {
        Console.WriteLine(i + 1);
        break;
    }
} */

#endregion

#region Morelinq Solution 2

using MoreLinq;

string filePath = @"..\Day1\input.txt";

int basement = File.ReadAllText(filePath).Scan(0, (f, c) => c == '(' ? f + 1 : f - 1).Select((Floor, Index) => new { Floor, Index }).First(f => f.Floor == -1).Index;

Console.WriteLine($"First time in the basement is at index: {basement}");

#endregion