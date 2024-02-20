using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vigenère_Cipher
{
    internal class Program
    {
        private static char[] letterArray = new char[128];

        static Program()
        {
            for (int i = 0; i < 128; i++)
            {
                letterArray[i] = (char)i;
            }
        }

        public static string Encrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0, j = 0; i < text.Length; i++)
            {
                char c = text[i];

                int cIndex = Array.IndexOf(letterArray, c);
                int kIndex = Array.IndexOf(letterArray, key[j]);
                if (cIndex == -1 || kIndex == -1) continue;

                result.Append((char)(((c + key[j]) % 128)));
                j = (j + 1) % key.Length;
            }
            return result.ToString();
        }

        public static string Decrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0, j = 0; i < text.Length; i++)
            {
                char c = text[i];

                int cIndex = Array.IndexOf(letterArray, c);
                int kIndex = Array.IndexOf(letterArray, key[j]);
                if (cIndex == -1 || kIndex == -1) continue; // Skip if character not found (optional handling)


                result.Append((char)(((c - key[j] + 128) % 128)));
                j = (j + 1) % key.Length;
            }
            return result.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text to encrypt:");
            string originalText = Console.ReadLine();

            Console.WriteLine("Enter the encryption key:");
            string key = Console.ReadLine();

            if (string.IsNullOrEmpty(key))
            {
                Console.WriteLine("Key cannot be empty.");
                return;
            }

            string encryptedText = Encrypt(originalText, key);
            string decryptedText = Decrypt(encryptedText, key);

            Console.WriteLine("Original: " + originalText);
            Console.WriteLine("Encrypted: " + encryptedText);
            Console.WriteLine("Decrypted: " + decryptedText);
            Console.ReadKey();
        }
    }
}
