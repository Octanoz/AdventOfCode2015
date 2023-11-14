// string filePath = @"..\Day23\example1.txt";
string filePath = @"..\Day23\input.txt";
string[] input = File.ReadAllLines(filePath);

var (a, b) = (0, 0);
for (int i = 0; i < input.Length; i++)
{
    string[] parts = input[i].Split(' ');

    if (input[i].Contains('a'))
    {
        switch (parts[0])
        {
            case "jio":
                if (a == 1)
                {
                    i += int.Parse(parts[2]) - 1;
                }
                break;
            case "jie":
                if (a % 2 == 0)
                {
                    i += int.Parse(parts[2]) - 1;
                }
                break;
            case "inc":
                a++;
                break;
            case "tpl":
                a *= 3;
                break;
            case "hlf":
                a /= 2;
                break;
            default:
                throw new InvalidDataException($"{parts[0]}");
        }
    }
    else if (input[i].Contains('b'))
    {
        if (input[i].StartsWith("inc"))
        {
            b++;
        }
    }
    else
    {
        i += int.Parse(parts[1]) - 1;
    }
}

Console.WriteLine($"Final value of a: {a}");
Console.WriteLine($"Final value of b: {b}");


