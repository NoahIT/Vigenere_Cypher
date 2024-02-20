using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigenère_Cipher
{
    internal class Program
    {
        //dda
        public static string Encrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0, j = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c < 'A' || c > 'Z') continue;
                result.Append((char)((c + key[j] - 2 * 'A') % 26 + 'A'));
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
                if (c < 'A' || c > 'Z') continue;
                result.Append((char)((c - key[j] + 26) % 26 + 'A'));
                j = (j + 1) % key.Length;
            }
            return result.ToString();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text to encrypt:");
            string originalText = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter the encryption key:");
            string key = Console.ReadLine().ToUpper();

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
