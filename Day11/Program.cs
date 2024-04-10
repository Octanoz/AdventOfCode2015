using System.Text.RegularExpressions;

Dictionary<string, string> inputs = new()
{
    ["test1"] = "abcdefgh",
    ["test2"] = "ghijklmn",
    ["input"] = "cqjxjnds",
    ["input2"] = "cqjxxyzz"
};

Console.WriteLine($"Santa's next password should be {NextValidPassword(inputs["input"])}");
Console.WriteLine($"The password after that should be {NextValidPassword(inputs["input2"])}");

string NextValidPassword(string input)
{
    char[] password = input.ToCharArray();

    do
    {
        AddOne(password);
    } while (!IsValidPassword(password));

    return new string(password);
}

void AddOne(char[] password)
{
    for (int i = password.Length - 1; i >= 0; i--)
    {
        if (password[i] == 'z')
        {
            password[i] = 'a';
        }
        else
        {
            password[i]++;
            break;
        }
    }
}

bool IsValidPassword(char[] password)
{
    Regex pairs = new(@"(\w)\1.*(\w)\2");
    Regex illegal = new(@"(i|l|o)");
    string checkString = new(password);

    if (illegal.IsMatch(checkString))
        return false;

    bool inSequence = false;
    for (int i = 0; i < checkString.Length - 2; i++)
    {
        if (password[i + 1] == password[i] + 1 && password[i + 2] == password[i] + 2)
        {
            inSequence = true;
            break;
        }
    }

    if (!inSequence)
        return false;

    return pairs.IsMatch(checkString);
}




