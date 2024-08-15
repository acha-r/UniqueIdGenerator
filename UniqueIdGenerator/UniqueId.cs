using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueIdentifier
{
    public static class UniqueId
    {
        private static readonly CryptoRandom _rand = new CryptoRandom();
        private static readonly string _randomChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_";
        private static readonly int _maxAttempts = 100;

        /// <summary>
        /// Generates a uniques id based on existing ids from user
        /// </summary>
        /// <param name="existingIds"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string Generate(HashSet<string> existingIds, int length = 11)
        {
            int attempts = 0;

            while (attempts < _maxAttempts)
            {
                string newId = new string(Enumerable.Repeat(_randomChars, length)
                    .Select(s => s[_rand.Next(s.Length)])
                    .ToArray());

                if (!existingIds.Contains(newId))
                {
                    return newId;
                }
                attempts++;
            }
            throw new InvalidOperationException("Could not generate unique id");
        }
    }
}