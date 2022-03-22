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

            decimal sumEfficiency;

            for (int testCount = 1; testCount < 6; testCount++)
            {
                Console.WriteLine($"-------- Test {testCount} --------\n");
                
                Console.WriteLine("Enter chemical number.");
                chemicalName.Add(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("Enter germ count.");

                int startGermCount = Convert.ToInt32(Console.ReadLine());

                Random rndm = new Random();

                int endGermCount = rndm.Next(0, 150);

                decimal chemicalEfficiency = (startGermCount - endGermCount) / 30;

                chemicalEfficiency = Math.Round(chemicalEfficiency, 3);
            }


            
                
            
                
            
            












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
