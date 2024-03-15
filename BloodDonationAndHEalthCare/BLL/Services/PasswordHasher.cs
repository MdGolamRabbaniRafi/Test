using System;
using System.Security.Cryptography;
using System.Text;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
            


        //Random random = new Random();
        //int saltValue = random.Next();
        //string hash = saltValue.ToString();

        //string hashPassword = password + hash;


        //return hashPassword.ToString();

        SHA256 sha256 = SHA256.Create();        
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();

    }
}