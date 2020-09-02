using System.Collections.Generic;

namespace TextUtilLib.NameReverser
{
    public class NaiveNameReverser : INameReverser
    {
        /// <summary>
        /// Reverses a given input string.
        ///
        /// Pushes the characters of the input string on a stack.
        /// Since a stack is a last in first out datastructure, converting it to an array yields the string in reverse.
        /// </summary>
        public string Reverse(string input)
        {
            var charStack = new Stack<char>();
            foreach (var c in input.ToCharArray())
                charStack.Push(c);
            
            return new string(charStack.ToArray());
        }
    }
}
