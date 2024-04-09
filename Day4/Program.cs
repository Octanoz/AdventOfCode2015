using System.Text;
using System.Security.Cryptography;

Console.WriteLine($"The lowest number to produce 5 starting zeroes for key 'yzbqklnj' is: {PartOne("00000")}");
Console.WriteLine($"The lowest numnber to produce 6 starting zeroes for key 'yzbqklnj' is: {PartTwo("000000")}");

int PartOne(string zeroes)
{
    int num = 1;
    string hashResult = "";
    string input = "yzbqklnj";

    while (!hashResult.StartsWith(zeroes))
    {
        using (MD5 md5 = MD5.Create())
        {
            string data = input + num.ToString();
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = MD5.HashData(dataBytes);
            StringBuilder sb = new();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            hashResult = sb.ToString();
        }

        num++;
    }

    return num - 1;
}

int PartTwo(string zeroes)
{
    int num = 1;
    string hashResult = "";
    string input = "yzbqklnj";

    while (!hashResult.StartsWith(zeroes))
    {
        using (MD5 md5 = MD5.Create())
        {
            string data = input + num.ToString();
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = MD5.HashData(dataBytes);
            StringBuilder sb = new();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            hashResult = sb.ToString();
        }

        num++;
    }

    return num - 1;
}

