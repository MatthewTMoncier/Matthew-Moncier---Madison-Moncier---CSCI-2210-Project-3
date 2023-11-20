using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matthew_MadisonMoncier_Project3
{
    /**
*-------------------------------------------------------
*  File Name: Dock.cs
*  Project Name: Project 3 Warehouse Simulation
*-------------------------------------------------------
*  Author's name and email: Tanner Moncier, monciermt@etsu.edu, Madison Moncier, monciermp@etsu.edu
*  Course Section: CSCI-2210
*  Creation Date: 11/05/2023
*-------------------------------------------------------
*/
    internal class Dock
    {
        public string _Id { get; private set; }
        public Queue<Truck> _Line {  get; private set; }
        public double _TotalSales { get; set; }
        public int _TotalCrates { get; set; }
        public int _TotalTrucks {  get; set; }
        public int _TimeInUse { get; set; }
        public int _TimeNotInUse {  get; set; }

        public Dock()
        {
            _Id = GenerateID();
            _Line = new Queue<Truck>();
            _TotalSales = 0;
            _TotalCrates = 0;
            _TotalTrucks = 0;
            _TimeInUse = 0;
            _TimeNotInUse = 0;
        }
        /// <summary>
        /// Put a truck in the line
        /// </summary>
        /// <param name="truck"> The truck to insert</param>
        public void JoinLine(Truck truck)
        {
            _Line.Enqueue(truck);
        }
        /// <summary>
        /// Send a truck out of the line
        /// </summary>
        /// <returns></returns>
        public Truck SendOff()
        {
            _TotalTrucks++;
            return _Line.Dequeue();
        }
        /// <summary>
        /// Create a random ID
        /// </summary>
        /// <returns> Random ID </returns>
        public string GenerateID()
        {
            string newID = string.Empty;
            string chars = "ABCDEFGHIJKLMNOPKRSTUVWXYZabcdefghigklmnopkrstuvwxyz0123456789";
            char[] newString = new char[8];
            Random random = new Random();
            for(int i = 0; i < newString.Length; i++)
            {
                newString[i] = chars[random.Next(chars.Length)];
            }
            newID = new String(newString);
         
            return newID;
        }
          

    }
}
