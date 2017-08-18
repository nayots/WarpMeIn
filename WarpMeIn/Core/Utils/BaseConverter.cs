using System;
using System.Collections.Generic;
using System.Linq;
using WarpMeIn.Core.Utils.Contracts;

namespace WarpMeIn.Core.Utils
{
    public class BaseConverter : IBaseConverter
    {

        private const string ALPHANUMERIC =
       "0123456789" +
       "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
       "abcdefghijklmnopqrstuvwxyz";

        private readonly Random rnd = new Random();

        public string ToBase(long input, string baseChars = ALPHANUMERIC, int desiredLength = 5)
        {
            string r = string.Empty;
            int targetBase = baseChars.Length;
            do
            {
                r = string.Format("{0}{1}",
                    baseChars[(int)(input % targetBase)],
                    r);
                input /= targetBase;
            } while (input > 0);

            return r.PadLeft(desiredLength, '0');
        }

        public long FromBase(string input, string baseChars = ALPHANUMERIC)
        {
            int srcBase = baseChars.Length;
            long id = 0;
            string r = new string(input.ToCharArray().Reverse().ToArray());

            for (int i = 0; i < r.Length; i++)
            {
                int charIndex = baseChars.IndexOf(r[i]);
                id += charIndex * (long)Math.Pow(srcBase, i);
            }

            return id;
        }
    }
}
