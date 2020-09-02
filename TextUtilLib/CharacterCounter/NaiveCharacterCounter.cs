namespace TextUtilLib
{

    public class NaiveCharacterCounter : ICharacterCounter
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
            var counter = 0;
            
            foreach (var c in input)
            {
                foreach (var vowel in charactersToFilterOn)
                {
                    if (c == vowel)
                        counter++;
                }
            }

            return counter;
        }
    }
}