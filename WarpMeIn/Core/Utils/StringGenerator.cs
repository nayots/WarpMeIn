using System;
using WarpMeIn.Core.Utils.Contracts;

namespace WarpMeIn.Core.Utils
{
    public class StringGenerator : IGenerator
    {
        private const string ALPHANUMERIC =
       "0123456789" +
       "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
       "abcdefghijklmnopqrstuvwxyz";

        private readonly Random rnd = new Random();

        /// <summary>Generates a string with the desired length made of random alphanumeric characters.
        /// </summary>
        public string Generate(int length)
        {
            string s = string.Empty;
            while (s.Length < length)
            {
                s += ALPHANUMERIC[rnd.Next(0, ALPHANUMERIC.Length - 1)];
            }

            return s;
        }
    }     
}
