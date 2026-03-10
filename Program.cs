using System.ComponentModel.Design;

namespace DevicesApp
{
    internal class Program
    {
        //Global Variables
        static string output = "";
        static decimal totalInsurance = 0;
        static int laptopCounter = 0;
        static int desktopCounter = 0;
        static int otherDeviceCounter = 0;
        
        static decimal mostValuableDeviceCost = 0;
        static string mostValuableDevice = "";

        static readonly List<string> STEPS = new List<string> { "Enter the device name", "\nEnter the device Category\n1:   Laptop\n2:   Desktop\n3:   Other", "\nEnter the cost", "Enter the amount of these devices" };
        static readonly List<string> ERRORS = new List<string> { "Please enter four or more characters", "Please enter a value of 1, 2 or 3.", "Please enter a value between 1 and 50000", "Please enter a value between 1 and 5000" };




        static void Main(string[] args)
        {
            //Local variables
            string loop = "";
            decimal totalCost = 0;


            //Display title page
            Console.WriteLine("  _____             _                            \r\n |  __ \\           (_)                           \r\n | |  | | _____   ___  ___ ___                   \r\n | |  | |/ _ \\ \\ / / |/ __/ _ \\                  \r\n | |__| |  __/\\ V /| | (_|  __/                  \r\n |_____/ \\___| \\_/ |_|\\___\\___|                  \r\n |_   _|                                         \r\n   | |  _ __  ___ _   _ _ __ __ _ _ __   ___ ___ \r\n   | | | '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\\r\n  _| |_| | | \\__ \\ |_| | | | (_| | | | | (_|  __/\r\n |_____|_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___|\r\n                                                 \r\n                                                 ");
            Console.WriteLine("Welcome to Device Insurance Calculator\nEnter to continue");
            Console.ReadLine();
            Console.Clear();



            //Add Devices
            while (loop != "q")
            {
                decimal totalDeviceCost = 0;
                totalCost += AddDevice(totalDeviceCost);
                
                Console.WriteLine("\n\nEnter    Add another device\nq        Quit and print summary");
                Console.ForegroundColor = ConsoleColor.White;
                loop = Console.ReadLine();
                Console.ResetColor();

                Console.Clear();
            }



            //Generate insurance summary
            Console.Clear();
            Console.WriteLine(output);
            Console.WriteLine($"Amount of Laptops:   {laptopCounter}\nAmount of Desktops:   {desktopCounter}\nAmount of other devices:   {otherDeviceCounter}\n\n" +
                $"Total cost:   {totalCost:C}\nInsurance value:   {totalInsurance:C}\n" +
                $"Most expensive device is the {mostValuableDevice} at {mostValuableDeviceCost:C}");
            Console.ReadLine();
        }






        //Add one device
        static decimal AddDevice(decimal totalDeviceCost)
        {
            //Local variables
            const decimal INSURANCEDISCOUNT = 0.1m;
            const int DISCOUNTREQUIREMENT = 5;
            const decimal VALUELOSSRATE = 0.95m;

            string deviceName = "";
            decimal deviceCost = 0;
            int deviceAmount = 0;
            string deviceCategory = "";



            //Add device name
            while (deviceName.Length < 4)
            {
                Console.WriteLine(STEPS[0]);
                Console.ForegroundColor = ConsoleColor.White;
                deviceName = Console.ReadLine();
                Console.ResetColor();

                if (deviceName.Length < 4)
                {
                    Console.WriteLine(ERRORS[0]);
                }
            }
            


            //Add the device to a category
            while (deviceCategory != "1" && deviceCategory != "2" && deviceCategory != "3")
            {
                Console.WriteLine(STEPS[1]);
                Console.ForegroundColor = ConsoleColor.White;
                deviceCategory = Console.ReadLine();
                Console.ResetColor();

                if (deviceCategory != "1" && deviceCategory != "2" && deviceCategory != "3")
                {
                    Console.WriteLine(ERRORS[1]);                   
                }
 
            }
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



            //Add a cost to the device
            while (deviceCost < 1 || deviceCost > 50000)
            {
                Console.WriteLine(STEPS[2]);
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    deviceCost = decimal.Parse(Console.ReadLine());
                    Console.ResetColor();
                }
                catch (Exception){}
                
                if (deviceCost < 1 || deviceCost > 50000)
                {
                    Console.ResetColor();
                    Console.WriteLine(ERRORS[2]);
                }
            }
            
            

            //Add the amount of devices
            while (deviceAmount < 1 || deviceAmount > 5000)
            {
                Console.WriteLine(STEPS[3]);
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    deviceAmount = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                }
                catch (Exception){}
                if (deviceAmount < 1 || deviceAmount > 5000)
                {
                    Console.ResetColor();
                    Console.WriteLine(ERRORS[3]);
                }
            }
            


            //Calculate cost
            totalDeviceCost = deviceCost * deviceAmount;

            if (deviceAmount > DISCOUNTREQUIREMENT)
            {
                totalDeviceCost -= (deviceAmount - DISCOUNTREQUIREMENT) * (deviceCost * INSURANCEDISCOUNT);
            }

            //Compare with the current most valuable device
            if (totalDeviceCost > mostValuableDeviceCost)
            {
                mostValuableDeviceCost = totalDeviceCost;
                mostValuableDevice = deviceName;
            }


            //Add devices insurance to the total insurance
            totalInsurance += deviceCost * deviceAmount - totalDeviceCost;



            //Save results to the output
            output += $"\nTotal cost of {deviceAmount} {deviceName} devices:   {totalDeviceCost:C}\n";


            //Calculate 6 month value loss
            output += "Month    Value\n";
            for (int month = 1; month <= 6; month++)
            {
               
                output += $"{month}        {deviceCost:c}\n";    
                deviceCost = deviceCost * VALUELOSSRATE;

            }

            output += $"Device Category: {deviceCategory}\n\n";


            //Return the total pricing of this device
            return totalDeviceCost;
        }


        




    }
}
