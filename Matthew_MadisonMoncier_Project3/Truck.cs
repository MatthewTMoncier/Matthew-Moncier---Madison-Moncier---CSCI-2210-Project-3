using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Matthew_MadisonMoncier_Project3
{
    internal class Truck
    {
        public string _driver {  get; private set; }
        public string _deliveryCompany { get; private set; }
        public Stack<Crate> _crates { get; private set; }

        public Truck()
        {
            _crates = new Stack<Crate>(25);
            Random randy = new Random();
            for(int i = randy.Next(25); i < 25; i++)
            {
                Load();
            }
            _driver = RandomDriver();
            _deliveryCompany = RandomCompany();
        }

        public void Load()
        {
            _crates.Push(new Crate());
        }
        public Crate Unload()
        {
            return _crates.Pop();
        }
        /// <summary>
        /// Make a random driver name
        /// </summary>
        /// <returns> Driver name </returns>
        public string RandomDriver()
        {
            string driverName = String.Empty;

            string[] firstNames = { "Matthew", "Kyle", "Jordan", "Eric", "Tyree", "Jackson", "Isaiah", "Demario", "Lyndon", "Ash" };
            string[] lastNames = { "Dodd", "Whittemore", "Jimenez", "Ford", "Smith", "Rogers", "Howard", "Chang", "Freeman", "Mosley", "Fulkerson"};

            Random random = new Random();

            driverName = firstNames[random.Next(firstNames.Length)] + " " + lastNames[random.Next(lastNames.Length)];
            return driverName;

        }
        /// <summary>
        /// Generates a random delivery company
        /// </summary>
        /// <returns> The company generated </returns>
        public string RandomCompany()
        {
            string companyName = String.Empty;
            string[] potentialNames = { "UPS", "FedEx", "Amazon", "Fast Delivery", "Kilgore's Delivery" };
            
            Random random = new Random();
            companyName = potentialNames[random.Next(potentialNames.Length)];
            return companyName;
        }
    }
}
