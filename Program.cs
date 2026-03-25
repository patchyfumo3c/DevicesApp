using System.ComponentModel.Design;

namespace DevicesApp
{
    internal class Program
    {
        //Global Variables
        static string mostValuableDevice = "";
        static decimal totalInsurance = 0, mostValuableDeviceCost = 0,  totalCost = 0;
        static int laptopCounter = 0, desktopCounter = 0, otherDeviceCounter = 0, deviceCount = 0;

        static readonly List<string> STEPS = new List<string> { "Enter the device name", "\nEnter the device Category\n1:   Laptop\n2:   Desktop\n3:   Other", "\nEnter the cost", "Enter the amount of these devices" };
        static readonly List<string> ERRORS = new List<string> { "Please enter four or more characters", "Please enter a value of 1, 2 or 3.", "Please enter a value between 1 and 50000", "Please enter a value between 1 and 5000" };
        static List<string> deviceNames = new List<string> {""};
        static List<decimal> deviceCosts = new List<decimal> {1};


        //Main method
        static void Main(string[] args)
        {
            //Local variables
            string loop = "", output = "";
            decimal totalDeviceCost;

            //Display title page
            Console.WriteLine("  _____             _                            \r\n |  __ \\           (_)                           \r\n | |  | | _____   ___  ___ ___                   \r\n | |  | |/ _ \\ \\ / / |/ __/ _ \\                  \r\n | |__| |  __/\\ V /| | (_|  __/                  \r\n |_____/ \\___| \\_/ |_|\\___\\___|                  \r\n |_   _|                                         \r\n   | |  _ __  ___ _   _ _ __ __ _ _ __   ___ ___ \r\n   | | | '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\\r\n  _| |_| | | \\__ \\ |_| | | | (_| | | | | (_|  __/\r\n |_____|_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___|\r\n                                                 \r\n                                                 ");
            Console.WriteLine("Welcome to Device Insurance Calculator\nEnter to continue");
            Console.ReadLine();
            Console.Clear();



            //Add Devices
            while (loop != "q")
            {
                totalDeviceCost = 0;

                //Add the output of a single device to the end output
                deviceCount++;
                output += AddDevice(totalDeviceCost);
                
                Console.WriteLine("\n\nEnter    Add another device\nq        Quit and print summary");
                Console.ForegroundColor = ConsoleColor.White;
                loop = Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }



            //Generate insurance summary
            Console.WriteLine(output);
            Console.WriteLine($"------------Summary------------\nAmount of Laptops:   {laptopCounter}\nAmount of Desktops:   {desktopCounter}\nAmount of other devices:   {otherDeviceCounter}\n\n" +
                $"Total cost:   {totalCost:C}\nInsurance value:   {totalInsurance:C}\n" +
                $"Most expensive device is the {mostValuableDevice} at {mostValuableDeviceCost:C}");
            Console.ReadLine();
        }






        //Add one device
        static string AddDevice(decimal totalDeviceCost)
        {
            //Local variables
            string deviceCategory = "", deviceSummary = "";
            int deviceAmount = 0;
          
            const decimal VALUELOSSRATE = 0.95m;


            //Add device name
            Console.WriteLine($"Device {deviceCount}\n");
            Console.WriteLine(STEPS[0]);

            Console.ForegroundColor = ConsoleColor.White;
            deviceNames.Add(Console.ReadLine());
            Console.ResetColor();

            while (deviceNames[deviceCount].Length < 4)
            {
                Console.WriteLine(ERRORS[0]);
                Console.WriteLine(STEPS[0]);

                Console.ForegroundColor = ConsoleColor.White;
                deviceNames[deviceCount] = Console.ReadLine();
                Console.ResetColor();

            }




            



            //Add a cost to the device
            Console.WriteLine(STEPS[2]);

            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                deviceCosts.Add(decimal.Parse(Console.ReadLine()));
                Console.ResetColor();
            }
            catch (Exception)
            {
                deviceCosts.Add(0);
            }
            while (deviceCosts[deviceCount] < 1 || deviceCosts[deviceCount] > 50000)
            {
                Console.ResetColor();
                Console.WriteLine(ERRORS[2]);
                Console.WriteLine(STEPS[2]);

                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    deviceCosts[deviceCount] = decimal.Parse(Console.ReadLine());
                    Console.ResetColor();
                }
                catch (Exception){}
            }




            //Add the amount of devices
            Console.WriteLine(STEPS[3]);
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                deviceAmount = int.Parse(Console.ReadLine());
                Console.ResetColor();
            }
            catch (Exception){}
            while (deviceAmount < 1 || deviceAmount > 5000)
            {
                Console.ResetColor();
                Console.WriteLine(ERRORS[3]);
                Console.WriteLine(STEPS[3]);
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    deviceAmount = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                }
                catch (Exception){}
            }



            //Add the device to a category
            Console.WriteLine(STEPS[1]);

            Console.ForegroundColor = ConsoleColor.White;
            deviceCategory = Console.ReadLine();
            Console.ResetColor();

            while (deviceCategory != "1" && deviceCategory != "2" && deviceCategory != "3")
            {
                Console.WriteLine(ERRORS[1]);
                Console.WriteLine(STEPS[1]);

                Console.ForegroundColor = ConsoleColor.White;
                deviceCategory = Console.ReadLine();
                Console.ResetColor();

            }

            switch (deviceCategory)
            {
                case "1":
                    laptopCounter += deviceAmount;
                    deviceCategory = "Laptop";
                    break;
                case "2":
                    desktopCounter += deviceAmount;
                    deviceCategory = "Desktop";
                    break;
                case "3":
                    otherDeviceCounter += deviceAmount;
                    deviceCategory = "Other";
                    break;
            }


            //Calculate cost
            totalDeviceCost += Calculate(totalDeviceCost, deviceAmount);

            //Add to total cost
            totalCost += totalDeviceCost;

            //Save results to the output
            deviceSummary += $"\nTotal cost of {deviceAmount} {deviceNames[deviceCount]} devices:   {totalDeviceCost:C}\n";

            //Calculate 6 month value loss
            deviceSummary += "Month    Value\n";
            for (int month = 1; month <= 6; month++)
            {

                deviceSummary += $"{month}        {deviceCosts[deviceCount]:c}\n";
                deviceCosts[deviceCount] = deviceCosts[deviceCount] * VALUELOSSRATE;

            }
            deviceSummary += $"Device Category: {deviceCategory}\n\n";



            return deviceSummary;

        }






        static decimal Calculate(decimal totalDeviceCost,  int deviceAmount)
        {
            //Local variables
            const decimal INSURANCEDISCOUNT = 0.1m;
            const int DISCOUNTREQUIREMENT = 5;


            //Calculate cost
            totalDeviceCost = deviceCosts[deviceCount] * deviceAmount;
            if (deviceAmount > DISCOUNTREQUIREMENT)
            {
                //If there is over 5 devices, apply the discount
                //total cost of all devices - how many devices the insurance discount applies to * the amount saved of a device with the insurance discount.
                totalDeviceCost -= (deviceAmount - DISCOUNTREQUIREMENT) * (deviceCosts[deviceCount] * INSURANCEDISCOUNT);
            }

            //Compare with the current most valuable device
            if (totalDeviceCost > mostValuableDeviceCost)
            {
                mostValuableDeviceCost = totalDeviceCost;
                mostValuableDevice = deviceNames[deviceCount];
            }



            //Add devices insurance to the total insurance
            totalInsurance += deviceCosts[deviceCount] * deviceAmount - totalDeviceCost;

            
            return totalDeviceCost;
        }
    }
}
