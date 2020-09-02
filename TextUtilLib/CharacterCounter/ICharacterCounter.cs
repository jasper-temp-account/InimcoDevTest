namespace TextUtilLib
{
    public interface ICharacterCounter
    {
        /// <summary>
        /// Returns the amount of vowel in a given string
        /// </summary>
        int GetAmountOfVowels(string input);

        /// <summary>
        /// Returns the amount of consonants in a given string
        /// </summary>
        int GetAmountOfConsonants(string input);
    }
}