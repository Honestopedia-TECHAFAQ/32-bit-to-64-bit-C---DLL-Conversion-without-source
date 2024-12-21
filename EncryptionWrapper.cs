using System;
using System.Runtime.InteropServices;

public static class EncryptionWrapper
{
    // Ensure that these functions are correct for 64-bit architecture
    [DllImport("AihCr25.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Decrypt(string input, int lengthOfInputString, out int errorCode, int nVersionToUse);

    [DllImport("AihCr25.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Encrypt(string input, int lengthOfInputString, out int errorCode, int nAlgorithmVersionToUse);

    // Encrypt method
    public static string Encrypt(string input)
    {
        int errorCode = 0;
        var result = Marshal.PtrToStringAnsi(Encrypt(input, input.Length, out errorCode, 4));  // Default algorithm version 4
        if (errorCode != 0)
        {
            // Enhanced error message with the error code
            Console.WriteLine($"Encryption failed with error code: {errorCode}");
            throw new InvalidOperationException(
                string.Format("Error code {0} when encrypting string \"{1}\"", errorCode, input));
        }
        return result;
    }

    // Overloaded Encrypt method with custom version
    public static string Encrypt(string input, int version2use)
    {
        int errorCode = 0;
        var result = Marshal.PtrToStringAnsi(Encrypt(input, input.Length, out errorCode, version2use));
        if (errorCode != 0)
        {
            // Enhanced error message with the error code
            Console.WriteLine($"Encryption failed with error code: {errorCode}");
            throw new InvalidOperationException(
                string.Format("Error code {0} when encrypting string \"{1}\"", errorCode, input));
        }
        return result;
    }

    // Decrypt method
    public static string Decrypt(string input)
    {
        int errorCode = 0;
        var result = Marshal.PtrToStringAnsi(Decrypt(input, input.Length, out errorCode, -1));  // Default version
        if (errorCode != 0)
        {
            // Enhanced error message with the error code
            Console.WriteLine($"Decryption failed with error code: {errorCode}");
            throw new InvalidOperationException(
                string.Format("Error code {0} when decrypting string \"{1}\"", errorCode, input));
        }
        return result;
    }
}
