using System;

namespace TextUtilLib.NameReverser
{
    public class ArrayReverseNameReverser : INameReverser
    {
        /// <summary>
        /// Reverses a given input string using the built in Array.Reverse function
        /// </summary>
        public string Reverse(string input)
        {
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
