using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shorty.Core
{
    public class BaseConverter : IConverter
    {

        private readonly char[] _baseCharSet = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x'
        };

        public string Encode(int id)
        {
            if (id ==0) throw new ArgumentOutOfRangeException("id", "Should not be 0");

            var result = new StringBuilder();
            int targetBase = _baseCharSet.Length;

            do
            {
                int charIndex = id%targetBase;
                result.Append(_baseCharSet[charIndex]);
                id = id/targetBase;

            } while (id > 0);

            var resultArray = result.ToString().ToCharArray();
            Array.Reverse(resultArray);
            return new string(resultArray);
        }

        public int Decode(string hexId)
        {

            var hexArray = hexId.ToCharArray();

            //declare array to hold the values. 
            var accumulator = new int[hexArray.Length];

            int unit = 0;
            // we start at the 1's 
            for (int i = hexArray.Length - 1; i >= 0; i--)
            {
                // 
                var itemValue = Array.IndexOf(_baseCharSet, hexArray[i]);
                int multiplier = (int) Math.Pow(_baseCharSet.Length, unit);

                // add this to the accumulator. 
                accumulator[unit] = multiplier*itemValue;

                // increment the unit value
                unit ++;

            }

            return accumulator.Sum();
        }
    }
}