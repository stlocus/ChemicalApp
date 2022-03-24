// Imports
using System;
using System.Collections.Generic;

namespace ChemicalApp
{
    class Program
    {
        // Global variables
        static List<int> chemicalName = new List<int>();
        // Methods

        // Tests the effiency of a chemical
        // Component 2
        static void ChemicalChoice()
        {
            Console.WriteLine("----------------------------------------------------\n" +
                "Welcome to the chemical testing area. Please make a choice.\n" +
                "----------------------------------------------------\n" +
                "1. Hand Sanitiser\n" +
                "2. Household Spray\n" +
                "3. Chlorine\n" +
                "4. Bleach\n");

            Console.WriteLine("Enter chemical number.");
            chemicalName.Add(Convert.ToInt32(Console.ReadLine()));

            decimal sumEfficiency = 0;
            
            
            for (int testCount = 1; testCount < 6; testCount++)
            {
                Console.WriteLine($"-------- Test {testCount} --------\n");

                Random rndm = new Random();

                int startGermCount = rndm.Next(1, 150);

                Console.WriteLine($"Press <ENTER> to initiate test {testCount}.\n" +
                    $"-----------------------------------------");

                Console.ReadLine();
                
                int endGermCount = rndm.Next(0, startGermCount);

                decimal chemicalEfficiency = (decimal)(startGermCount - endGermCount) / 30;

                chemicalEfficiency = Math.Round(chemicalEfficiency, 3);

                Console.WriteLine($"Chemical Efficiency " +
                    $"for test {testCount}: {chemicalEfficiency}");

                sumEfficiency += chemicalEfficiency;

            }

            decimal finalEfficientRating = sumEfficiency / 5;
            finalEfficientRating = Math.Round(finalEfficientRating, 3);

            Console.WriteLine($"The final efficiency rating is {finalEfficientRating}");
        }




        // Component 1
        // start or press run
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("------------------------------------------------------\n" +
                "Welcome to the Hi-Jean chemical testing app!\n" +
                "This app is used to test germ removel effectiveness\nof certain chemicals.\n" +
                "------------------------------------------------------");

            bool flag_main = true;

            while (flag_main)
            {
                Console.WriteLine("Press <Enter> to start an experiment, or type 'stop' to quit.");

                string userChoice = Console.ReadLine();
                if(userChoice.Equals("")) 
                {
                    ChemicalChoice();
                    Console.WriteLine("");
                }
                else if(userChoice.Equals("stop"))
                {
                    flag_main = false;
                    Console.WriteLine("Thank you for using the HI-Jean chemical testing app");
                }
                else
                {
                    Console.WriteLine("ERROR: Please enter a correct choice");
                }
                



            }



        }
    }
}
