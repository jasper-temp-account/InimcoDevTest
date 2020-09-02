using System.Collections.Generic;
using TextUtilLib;
using TextUtilLib.JsonSerializer;
using TextUtilLib.NameReverser;

namespace DeveloperTest.Console
{
    class Program
    {
        // Prompts the user for their name, social skills and social media accounts.
        // Prints out the amound of vowels / consonants in their name, their name in reverse, and all data serialized in JSON.
        static void Main()
        {
            System.Console.Write("Enter your firstname: ");
            var firstName = System.Console.ReadLine();

            System.Console.Write("Enter your lastname: ");
            var lastName = System.Console.ReadLine();

            var socialSkills = AskSocialSkills();
            var socialMediaAccounts = AskSocialMediaAccounts();

            string fullName = firstName + " " + lastName;

            ICharacterCounter characterCounter = new LinqCharacterCounter();
            System.Console.WriteLine("Amount of vowels in first + last name: " + characterCounter.GetAmountOfVowels(fullName));
            System.Console.WriteLine("Amount of consonants in first + last name: " + characterCounter.GetAmountOfConsonants(fullName));

            INameReverser nameReverser = new ArrayReverseNameReverser();
            System.Console.WriteLine("Your name reversed is: " + nameReverser.Reverse(fullName));

            IJsonSerializer jsonSerializer = new Utf8JsonSerializer();
            System.Console.WriteLine("Your data serialized in json: " + jsonSerializer.Serialize<Person>(
                new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SocialSkills = socialSkills,
                    SocialMediaAccounts = socialMediaAccounts
                }
            ));
        }

        /// <summary>
        /// Prompts the user for their social skills in a loop.
        /// Enter 'q' to leave the loop.
        /// </summary>
        private static string[] AskSocialSkills()
        {
            List<string> socialSkills = new List<string>();

            char charRead = ' ';
            while (charRead != 'q')
            {
                System.Console.Write("Enter social skills (q to quit): ");
                var socialSkill = System.Console.ReadLine();

                if (socialSkill.Length == 1)
                {
                    charRead = socialSkill[0];
                    if (charRead == 'q')
                        break;
                }

                socialSkills.Add(socialSkill);

            }

            return socialSkills.ToArray();
        }

        /// <summary>
        /// Prompts the user for their social media accounts
        /// </summary>
        private static string[] AskSocialMediaAccounts()
        {
            string[] socialMediaAccounts = new string[3];

            System.Console.Write("Enter your Facebook URL: ");
            socialMediaAccounts[0] = System.Console.ReadLine();

            System.Console.Write("Enter your LinkedIn URL: ");
            socialMediaAccounts[1] = System.Console.ReadLine();

            System.Console.Write("Enter your Twitter URL: ");
            socialMediaAccounts[2] = System.Console.ReadLine();

            return socialMediaAccounts;
        }
    }
}
