namespace Matthew_MadisonMoncier_Project3
{
    /**
*-------------------------------------------------------
*  File Name: Program.cs
*  Project Name: Project 3 Warehouse Simulation
*-------------------------------------------------------
*  Author's name and email: Tanner Moncier, monciermt@etsu.edu, Madison Moncier, monciermp@etsu.edu
*  Course Section: CSCI-2210
*  Creation Date: 11/05/2023
*-------------------------------------------------------
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i <= 15;  i++)
            {
                Warehouse warehouse = new Warehouse(i);
                warehouse.Run();
                Thread.Sleep(1000);
            }

            


        }
    }
}