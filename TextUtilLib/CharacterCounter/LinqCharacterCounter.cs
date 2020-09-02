using System;
using System.Linq;

namespace TextUtilLib
{
    public class LinqCharacterCounter : ICharacterCounter
    {
        public int GetAmountOfVowels(string input)
        {
            return GetCharacterCount(input, "aeiou");
        }

        public int GetAmountOfConsonants(string input)
        {
            return GetCharacterCount(input, "bcdfghjklmnpqrstvwxyz");
        }

        private static int GetCharacterCount(string input, string charactersToFilterOn)
        {
            return input.Count(c => charactersToFilterOn.Contains(char.ToLower(c)));
        }
    }
}