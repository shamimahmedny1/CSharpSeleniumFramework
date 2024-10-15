using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.utilities
{
    class GenerateUserData
    {
        private static readonly Random _random = new Random();

        // Method to generate a random first name
        public string GenerateRandomFirstName()
        {
            string[] firstNames = { "John", "Jane", "Michael", "Sarah", "David", "Emily" };
            return firstNames[_random.Next(firstNames.Length)];
        }

        // Method to generate a random last name
        public string GenerateRandomLastName()
        {
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia" };
            return lastNames[_random.Next(lastNames.Length)];
        }

        // Method to generate a random email
        public string GenerateRandomEmail()
        {
            string emailDomain = "@example.com";
            string randomString = Guid.NewGuid().ToString("n").Substring(0, 8);
            return $"{randomString}{emailDomain}";
        }

        // Method to generate a random password
        public string GenerateRandomPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = chars[_random.Next(chars.Length)];
            }
            return new string(password);
        }

        // Method to randomly select gender
        public string GenerateRandomGender()
        {
            string[] genders = { "Male", "Female" };
            return genders[_random.Next(genders.Length)];
        }

        // Optional: Generate and display all details
        public void GenerateRandomUserDetails()
        {
            Console.WriteLine($"First Name: {GenerateRandomFirstName()}");
            Console.WriteLine($"Last Name: {GenerateRandomLastName()}");
            Console.WriteLine($"Email: {GenerateRandomEmail()}");
            Console.WriteLine($"Password: {GenerateRandomPassword()}");
            Console.WriteLine($"Gender: {GenerateRandomGender()}");
        }
        
    }


}

