#region Solution 1

/* using System.Text.RegularExpressions;

// string filePath = @"..\Day8\example1.txt";
string filePath = @"..\Day8\input.txt";
string[] input = File.ReadAllLines(filePath);

Regex accentSlash = new(@"(\\"")(?<!""$)|(\\\\)");
Regex hex = new(@"(\\x\d{2})");
Regex all = new(@"(\\"")(?<!""$)|(\\\\)|(\\x[0-f]{2})");

int total = 0;

foreach (var line in input)
{
    int len = line.Length;

    string correctedString = all.Replace(line, "z");

    Console.WriteLine(line);
    Console.WriteLine(correctedString);
    Console.WriteLine("================");

    int inMemory = correctedString.Length - 2;
    total += len - inMemory;
}

Console.WriteLine(total); */

#endregion

#region Solution 2

using System.Text.RegularExpressions;

// string filePath = @"..\Day8\example1.txt";
string filePath = @"..\Day8\input.txt";
string[] input = File.ReadAllLines(filePath);

Regex accent = new(@"(\\"")(?<!""$)");
Regex slash = new(@"(\\)");

int total = 0;

foreach (var line in input)
{
    int len = line.Length;

    string newLine = accent.Replace(line, "1234");
    newLine = slash.Replace(newLine, "12");

    int encoded = 4 + (newLine.Length - line.Length);

    total += encoded;
}

Console.WriteLine(total);

#endregion

