using System.Security.Cryptography;
using System.Text;

namespace TestedSha256;

class Program
{
    static void Main(string[] args)
    {
        string input = "3962";
        using SHA256 sha256 = SHA256.Create();

        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        string hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();

        Console.WriteLine(hash);
    }
}
