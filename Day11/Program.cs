using System.Text.RegularExpressions;

// string test1 = "abcdefgh";
// string test2 = "ghijklmn";
// string input = "hxbxwxba";
string input2 = "hxbxxyzz";

Regex pairs = new(@"(\w)\1.*(\w)\2");
Regex illegal = new(@"(i|l|o)");

string result = NextValidPassword(input2);

Console.WriteLine(result);

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




