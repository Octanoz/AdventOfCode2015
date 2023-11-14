
#region Solution 1
/* using Day2;

// string filePath = @"..\Day2\example1.txt";
string filePath = @"..\Day2\input.txt";

string[] input = File.ReadAllLines(filePath);
int total = 0;

foreach (var line in input)
{
    int[] dimensions = line.Split('x').Select(int.Parse).ToArray();

    int result = Wrapping.PaperNeeded(dimensions[0], dimensions[1], dimensions[2]);
    total += result;
}

Console.WriteLine(total); */

#endregion

#region Solution 2

using Day2;

// string filePath = @"..\Day2\example1.txt";
string filePath = @"..\Day2\input.txt";

string[] input = File.ReadAllLines(filePath);
int total = 0;

foreach (var line in input)
{
    int[] dimensions = line.Split('x').Select(int.Parse).ToArray();

    int result = Wrapping.RibbonNeeded(dimensions[0], dimensions[1], dimensions[2]);
    total += result;
}

Console.WriteLine(total);

#endregion

