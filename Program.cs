namespace DevicesApp
{
    internal class Program
    {
        //Global Variables
        static string output = "";
        static void Main(string[] args)
        {
            int loop = 0;
            float totalCost = 0;
            //Display title page
            Console.Write("                                                                                                                                                       \r\n                                                                                                                                                       \r\n████▄  ▄▄▄▄▄ ▄▄ ▄▄ ▄▄  ▄▄▄▄ ▄▄▄▄▄   ██ ▄▄  ▄▄  ▄▄▄▄ ▄▄ ▄▄ ▄▄▄▄   ▄▄▄  ▄▄  ▄▄  ▄▄▄▄ ▄▄▄▄▄   ▄█████  ▄▄▄  ▄▄     ▄▄▄▄ ▄▄ ▄▄ ▄▄     ▄▄▄ ▄▄▄▄▄▄ ▄▄▄  ▄▄▄▄  \r\n██  ██ ██▄▄  ██▄██ ██ ██▀▀▀ ██▄▄    ██ ███▄██ ███▄▄ ██ ██ ██▄█▄ ██▀██ ███▄██ ██▀▀▀ ██▄▄    ██     ██▀██ ██    ██▀▀▀ ██ ██ ██    ██▀██  ██  ██▀██ ██▄█▄ \r\n████▀  ██▄▄▄  ▀█▀  ██ ▀████ ██▄▄▄   ██ ██ ▀██ ▄▄██▀ ▀███▀ ██ ██ ██▀██ ██ ▀██ ▀████ ██▄▄▄   ▀█████ ██▀██ ██▄▄▄ ▀████ ▀███▀ ██▄▄▄ ██▀██  ██  ▀███▀ ██ ██ \r\n                                                                                                                                                       ");
            Console.WriteLine("Welcome to Device Insurance Calculator\nEnter to continue");
            Console.ReadLine();

            //Add Devices
            while (loop == 1)
            {
                float totalDeviceCost = 0;
                AddDevice(totalDeviceCost);


                
                totalCost += totalDeviceCost;

                Console.WriteLine("1   Add another device\n2,   Quit and print summary\n");
            }

            //Calculate total cost





            //Generate insurance summary



        }


        //Add one device
        static float AddDevice(float totalDeviceCost)
        {
            Console.WriteLine("Enter the device name");

            Console.WriteLine("Enter the device Category");

            Console.WriteLine("Enter the cost");

            Console.WriteLine("Enter the amount of these devices");

            //Calculate cost
           
            //Print 6 month value loss
            for (int i = 0; i > 6; i++)
            {
                Console.WriteLine($"Month {i}");
                Console.WriteLine($"{totalDeviceCost}");

            }
            return totalDeviceCost;
        }






    }
}
