namespace Matthew_MadisonMoncier_Project3
{
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