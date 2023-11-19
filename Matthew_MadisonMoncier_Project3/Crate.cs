using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matthew_MadisonMoncier_Project3
{
    internal class Crate
    {
        public string _id {  get; set; }
        public double _price {  get; set; }
        private Random _random;

        public Crate()
        {
            _random = new Random();
            _price = _random.NextDouble() * (500 - 50) + 50;
            _id = GenerateID();

        }
        /// <summary>
        /// Create a random ID
        /// </summary>
        /// <returns> The ID </returns>
        public string GenerateID()
        {
            string newID = string.Empty;
            string chars = "ABCDEFGHIJKLMNOPKRSTUVWXYZabcdefghigklmnopkrstuvwxyz0123456789";
            char[] newString = new char[8];
            Random random = new Random();
            for (int i = 0; i < newString.Length; i++)
            {
                newString[i] = chars[random.Next(chars.Length)];
            }
            newID = new String(newString);

            return newID;
        }
    }
}
