using System.ComponentModel.Design;

namespace DevicesApp
{
    internal class Program
    {
        //Global Variables
        static string output = "";
        static int laptopCounter = 0;
        static int desktopCounter = 0;
        static int otherDeviceCounter = 0;
        static float totalInsurance = 0;








        static void Main(string[] args)
        {
            int loop = 1;
            float totalCost = 0f;

            //Display title page
            Console.WriteLine("  _____             _                            \r\n |  __ \\           (_)                           \r\n | |  | | _____   ___  ___ ___                   \r\n | |  | |/ _ \\ \\ / / |/ __/ _ \\                  \r\n | |__| |  __/\\ V /| | (_|  __/                  \r\n |_____/ \\___| \\_/ |_|\\___\\___|                  \r\n |_   _|                                         \r\n   | |  _ __  ___ _   _ _ __ __ _ _ __   ___ ___ \r\n   | | | '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\\r\n  _| |_| | | \\__ \\ |_| | | | (_| | | | | (_|  __/\r\n |_____|_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___|\r\n                                                 \r\n                                                 ");
            Console.WriteLine("Welcome to Device Insurance Calculator\nEnter to continue");
            Console.ReadLine();
            Console.Clear();
            //Add Devices
            while (loop == 1)
            {
                float totalDeviceCost = 0;
                totalCost += AddDevice(totalDeviceCost);

                Console.WriteLine("\n1   Add another device\n2   Quit and print summary");
                loop = int.Parse(Console.ReadLine());
                Console.Clear();
            }

            





            //Generate insurance summary
            Console.Clear();
            Console.WriteLine(output);
            Console.WriteLine($"Total cost:   {totalCost:C}\nInsurance value:   {totalInsurance:C}");
            Console.ReadLine();
        }


        //Add one device
        static float AddDevice(float totalDeviceCost)
        {
            const float INSURANCEDISCOUNT = 0.1f;
            const int DISCOUNTREQUIREMENT = 5;
            const float VALUELOSSRATE = 0.95f;

            string deviceName;
            float deviceCost;
            int deviceAmount;
            string deviceCategory;



            Console.WriteLine("Enter the device name");
            deviceName = Console.ReadLine();


            Console.WriteLine("\nEnter the device Category\n1:   Laptop\n2:   Desktop\n3:   Other");
            deviceCategory = Console.ReadLine();
            switch (deviceCategory)
            {
                case "1":
                    laptopCounter++;
                    deviceCategory = "Laptop";
                    break;
                case "2":
                    desktopCounter++;
                    deviceCategory = "Desktop";
                    break;
                case "3":
                    otherDeviceCounter++;
                    deviceCategory = "Other";
                    break;
                
            }


            Console.WriteLine("\nEnter the cost");
            deviceCost = float.Parse(Console.ReadLine());


            Console.WriteLine("Enter the amount of these devices");
            deviceAmount = int.Parse(Console.ReadLine());



            //Calculate cost
            totalDeviceCost = deviceCost * deviceAmount;
            if (deviceAmount > DISCOUNTREQUIREMENT)
            {
                totalDeviceCost -= (deviceAmount - DISCOUNTREQUIREMENT) * (deviceCost * INSURANCEDISCOUNT);
            }
            

            totalInsurance += deviceCost * deviceAmount - totalDeviceCost;


            //Console.WriteLine($"\nTotal cost of {deviceAmount} {deviceName} devices is {totalDeviceCost:C}\n");
            output += $"\nTotal cost of {deviceAmount} {deviceName} devices:   {totalDeviceCost:C}\n";

            //Print 6 month value loss
            output += "Month    Value\n";
            for (int month = 1; month <= 6; month++)
            {
               
                output += $"{month}        {deviceCost:c}\n";    
                deviceCost = deviceCost * VALUELOSSRATE;

            }

            output += $"Device Category: {deviceCategory}\n\n";
            return totalDeviceCost;
        }






    }
}
