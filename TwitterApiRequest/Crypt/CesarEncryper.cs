using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterApiRequest.Crypt
{
    public static class CesarEncryper
    {
        static int dif = 13;

        public static string Encrypt(string word)
        {
            string encryptedWord = "";
            for (int i = 0; i < word.Length; i++)
            {
                int ASCII = (int)word[i];
                int ASCIIC = ASCII + dif;
                encryptedWord += Char.ConvertFromUtf32(ASCIIC);
            }
            return encryptedWord;
        }

        public static string Deencrypt(string word)
        {
            string deencryptedWord = "";
            for (int i = 0; i < word.Length; i++)
            {
                int ASCII = (int)word[i];
                int ASCIIC = ASCII - dif;
                deencryptedWord += Char.ConvertFromUtf32(ASCIIC);
            }
            return deencryptedWord;
        }
    }
}
