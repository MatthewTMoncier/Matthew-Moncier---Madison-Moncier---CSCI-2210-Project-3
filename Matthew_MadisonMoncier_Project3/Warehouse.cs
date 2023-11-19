using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matthew_MadisonMoncier_Project3
{
    internal class Warehouse
    {
        List<Dock> docks;
        Queue<Truck> entrance;

        public Warehouse(int dockNum)
        {
            docks = new List<Dock>(dockNum);
            for(int i = 0; i < docks.Capacity; i++) 
            {
                Dock dock = new Dock();
                docks.Add(dock);
            }
            entrance = new Queue<Truck>();
        }
        /// <summary>
        /// Write data to a CSV file
        /// </summary>
        /// <param name="time"> Current time increment </param>
        /// <param name="crate"> Crate unloaded </param>
        /// <param name="truck"> Truck crate came from </param>
        /// <param name="scenario"> What situation in happening at the dock </param>
        public void WriteToCSV(int time, Crate crate, Truck truck, string scenario)
        {
            var str = $"{time}, {truck._driver}, {truck._deliveryCompany}, {crate._id}, {crate._price}, {scenario}";

            var filePath = @"..\..\..\WorkhouseData.csv";

            File.AppendAllText(filePath, str);
        }
        /// <summary>
        /// Check if docks have trucks in line
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            foreach(var dock in docks)
            {
                if(dock._Line.Count > 0)
                {
                    return false;
                }
            }
            return true;
        }


        public void Run()
        {
            double truckChance = 0;
            Truck newTruck = null;
            decimal totalCrateCost = 0;
            int longestLine = 0;
            int longestLineIndex = 0;
            decimal operatingCost = 0;
            int totalCrateUnloaded = 0;
            int trucksProcessed = 0;
            decimal revenue = 0;
            int timeUsed = 0;
            int timeUnused = 0;
            int timer = 0;
            // Random Truck Chance
            for(int i = 0; i < 48 || !IsEmpty(); i++)
            {
                if(i < 47)
                {
                    truckChance = 0;

                    if (i < 24)
                    {
                        truckChance = (i + 1) / (double)36;
                    }
                    else if (i >= 24)
                    {
                        truckChance = (48 - i) / (double)36;
                    }
                    Random randomTruck = new Random();
                    if (randomTruck.NextDouble() < truckChance)
                    {
                        newTruck = new Truck();
                        entrance.Enqueue(newTruck);
                    }
                }
               
                // If truck generates, add to a dock line
                if(entrance.Count != 0)
                {
                    int indexer = 0;
                    while(entrance.Count != 0) 
                    {
                        
                        // If all dock lines are equal, add truck to first dock
                        if(indexer == docks.Count - 1)
                        {
                            docks[0].JoinLine(entrance.Dequeue());
                            
                        }
                        else if (docks[indexer]._Line.Count > docks[indexer + 1]._Line.Count)
                        {
                            docks[indexer + 1].JoinLine(entrance.Dequeue());
                            
                        }
                        indexer++;
                    }
                }
                // Find longest dock line
                for (int k = 0; k < docks.Count - 1; k++)
                {
                    
                    if (longestLine < docks[k]._Line.Count)
                    {
                        longestLine = docks[k]._Line.Count;
                        longestLineIndex = k + 1;
                    }
                }
                // Unload a crate from any docks with trucks
                for (int j = 0; j < docks.Count; j++)
                {
                    if (docks[j]._Line.Count != 0)
                    {
                        Crate crateTracker = docks[j]._Line.Peek().Unload();
                        totalCrateCost += (decimal)crateTracker._price;
                        docks[j]._TotalSales += crateTracker._price;
                        if (docks[j]._Line.Peek()._crates.Count != 0)
                        {
                            WriteToCSV(timer, crateTracker, docks[j]._Line.Peek(), "Truck has more crates to unload.\n");
                        }
                        else if (docks[j]._Line.Peek()._crates.Count == 0 && docks[j]._Line.Count == 1)
                        {
                            WriteToCSV(timer, crateTracker, docks[j]._Line.Peek(), "Truck was unloaded no more trucks to unload.\n");
                            docks[j].SendOff();
                            trucksProcessed++;

                        }
                        else if(docks[j]._Line.Peek()._crates.Count == 0)
                        {
                            WriteToCSV(timer, crateTracker, docks[j]._Line.Peek(), "Truck was unloaded new truck in dock already.\n");
                            docks[j].SendOff();
                            trucksProcessed++;
                        }
                        
                        docks[j]._TimeInUse++;
                        docks[j]._TotalCrates++;
                        
                    }
                    // if dock has no trucks, increase time not used
                    else if (docks[j]._Line.Count == 0)
                    {
                        docks[j]._TimeNotInUse++;
                    }
                }
                timer++;
                // Create report on final rotation
                if (i >= 47 && IsEmpty()) 
                {
                 
                    StringBuilder sb = new StringBuilder();
                    foreach (Dock dock in docks)
                    {
                        totalCrateUnloaded += dock._TotalCrates;

                    }
                    decimal averageCrateCost = totalCrateCost / totalCrateUnloaded;
                    decimal averageTruckCost = totalCrateCost / trucksProcessed;
                    sb.Append($"Number of docks: {docks.Count}\n");
                    sb.Append($"Longest Dock Line: {longestLine} trucks at dock {longestLineIndex}\n");
                    sb.Append($"Total crate value: {string.Format("{0:0.00}", totalCrateCost)}\n");
                    sb.Append($"Total crates unloaded: {totalCrateUnloaded}\n");
                    sb.Append($"Trucks processed: {trucksProcessed}\n");
                    sb.Append($"Average cost of crate: {string.Format("{0:0.00}", averageCrateCost)}\n");
                    sb.Append($"Average value of truck: {string.Format("{0:0.00}", averageTruckCost)}\n");
                    int indicator = 1;
                    operatingCost = timer * 100;
                    foreach (Dock dock in docks)
                    {
                        timeUsed += dock._TimeInUse;
                        
                        sb.Append("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                        sb.Append($"Time used of Dock {indicator}: {dock._TimeInUse}\n");
                        sb.Append($"Time unused of Dock {indicator}: {dock._TimeNotInUse}\n");
                        sb.Append($"Operating cost of Dock {indicator}: {operatingCost}\n");
                        sb.Append("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                        indicator++;
                    }
                    sb.Append($"Average time of Dock usage: {timeUsed / docks.Count}\n");
                    revenue = totalCrateCost - operatingCost;
                    sb.Append($"Total revenue of warehouse: {string.Format("{0:0.00}",revenue)}\n");
                    Console.WriteLine(sb);

                }
               

            }
        }
        
    }
}
