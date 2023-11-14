
#region Solution 1

/* using System.Security.Cryptography;
using System.Text;

string filePath = @"..\Day4\example1.txt";
string[] input = File.ReadAllLines(filePath);

foreach (var line in input)
{
    int num = 1;
    string hashResult = "";

    while (!hashResult.StartsWith("00000"))
    {
        using (MD5 md5 = MD5.Create())
        {
            string data = line + num.ToString();
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

    Console.WriteLine($"The lowest number to produce 5 starting zeroes for key {line} is: {num - 1}");
} */


#endregion

#region Solution 2

using System.Security.Cryptography;
using System.Text;

string filePath = @"..\Day4\example1.txt";
string[] input = File.ReadAllLines(filePath);

foreach (var line in input)
{
    int num = 1;
    string hashResult = "";

    while (!hashResult.StartsWith("000000"))
    {
        using (MD5 md5 = MD5.Create())
        {
            string data = line + num.ToString();
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

    Console.WriteLine($"The lowest number to produce 5 starting zeroes for key {line} is: {num - 1}");
}

#endregion

