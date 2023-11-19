using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matthew_MadisonMoncier_Project3
{
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
        public void JoinLine(Truck truck)
        {
            _Line.Enqueue(truck);
        }
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
