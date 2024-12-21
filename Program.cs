using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataToEncrypt = "Done!";

            string encrypted = EncryptionWrapper.Encrypt(dataToEncrypt);
            Console.WriteLine($"Encrypted: {encrypted}");

            string decrypted = EncryptionWrapper.Decrypt(encrypted);
            Console.WriteLine($"Decrypted: {decrypted}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
