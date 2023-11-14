
#region Solution 1

/* using System.Text.RegularExpressions;

// string filePath = @"..\Day5\example1.txt";
string filePath = @"..\Day5\input.txt";
string[] input = File.ReadAllLines(filePath);

Regex badPairs = new(@"(ab)|(cd)|(pq)|(xy)");
Regex threeVowels = new(@"(?:.*[aeiou].*){3,}");
Regex repeatingCharacter = new(@"(.)\1");

int naughty = 0;
int nice = 0;
foreach (var line in input)
{
    if (badPairs.IsMatch(line))
    {
        naughty++;
        continue;
    }

    if (threeVowels.IsMatch(line) && repeatingCharacter.IsMatch(line))
    {
        nice++;
    }
    else naughty++;

}

Console.WriteLine($"Naugthy: {naughty}, Nice: {nice}");

//? 162 is too low */

#endregion

#region Solution 2

using System.Text.RegularExpressions;

// string filePath = @"..\Day5\example1.txt";
// string filePath = @"..\Day5\example2.txt";
string filePath = @"..\Day5\input.txt";
string[] input = File.ReadAllLines(filePath);

Regex repeatingPairs = new(@"(..).*\1");
Regex repeatingCharacter = new(@"(.).\1");

int naughty = 0;
int nice = 0;
foreach (var line in input)
{
    if (repeatingPairs.IsMatch(line) && repeatingCharacter.IsMatch(line))
    {
        nice++;
    }
    else naughty++;
}

Console.WriteLine($"Naugthy: {naughty}, Nice: {nice}");


#endregion

