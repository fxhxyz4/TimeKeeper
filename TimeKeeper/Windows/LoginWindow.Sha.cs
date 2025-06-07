using System.Security.Cryptography;
using TimeKeeper.Modules.DataBase;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper;

public partial class LoginWindow
{
    /// <summary>
    /// Generated sha256 by input password
    /// </summary>
    /// <param name="password"></param>
    /// <returns>hash</returns>
    public string GenerateHash(string password)
    {
        try
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            string hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            return hash;
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.Sha256GenerateErrorMsg);
            return string.Empty;
        }
    }

    /// <summary>
    /// Validate localSha256 with sha256 in database table Admin
    /// </summary>
    /// <param name="inputHash"></param>
    /// <returns>Boolean</returns>
    public bool ValidateHash(string inputHash)
    {
        try
        {
            string? storedHash = AdminRepository.GetAdminHash();
            return inputHash == storedHash;
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.Sha256ValidateErrorMsg);
            return false;
        }
    }
}
