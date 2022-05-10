// Imports
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ChemicalApp
{
    class Program
    {
        // Global variables
        static readonly List<string> CHEMICALNAMES = new List<string>() {"Hand Sanitiser", "Household Spray", "Chlorine", "Bleach"};
        static List<int> chosenChemicals = new List<int>();
        static List<decimal> chemicalEfficiencies = new List<decimal>();
        // Methods

        // sort chemcial efficiencies in a ascending order
        static void EfficiencySortAsc()
        {
            for (int leftPointer = 0; leftPointer < chemicalEfficiencies.Count-1; leftPointer++)
            {
                for (int rightPointer = leftPointer+1; rightPointer < chemicalEfficiencies.Count; rightPointer++)
                {
                    if (chemicalEfficiencies[leftPointer] > chemicalEfficiencies[rightPointer])
                    {
                        decimal tempEfficiency = chemicalEfficiencies[leftPointer];
                        chemicalEfficiencies[leftPointer] = chemicalEfficiencies[rightPointer];
                        chemicalEfficiencies[rightPointer] = tempEfficiency;

                        int tempChemical = chosenChemicals[leftPointer];
                        chosenChemicals[leftPointer] = chosenChemicals[rightPointer];
                        chosenChemicals[rightPointer] = tempChemical;
                    }
                }
            }
        }

        // Checks to see if user enters int between a range of values
        static int CheckInt(string question, int min, int max)
        {
            string ERROR_MSG = ("--------------------------------------------------\n" +
                $"ERROR: Enter a valid number between {min} and {max}.\n"+
                "--------------------------------------------------");
            while (true)
            {
                try
                {
                    Console.WriteLine(question);

                    int userInt = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }
                    else
                    {
                        Console.WriteLine(ERROR_MSG);
                    }

                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine(ERROR_MSG);
                }

            }
        }
            // Checking if chemical has been tested
            
        
            static int validateChemical()
        {
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------\n" +
                "Welcome to the chemical testing area. Please make a choice.\n" +
                "-----------------------------------------------------------\n" +
                $"1. {CHEMICALNAMES[0]}\n" +
                $"2. {CHEMICALNAMES[1]}\n" +
                $"3. {CHEMICALNAMES[2]}\n" +
                $"4. {CHEMICALNAMES[3]}\n");

                int chemicalIndex = CheckInt("Enter chemical number:", 1, 4) - 1;

                if (chosenChemicals.Contains(chemicalIndex))
                {
                    Console.WriteLine("-----------------------------------------\n\n" +
                        "This chemical has already been tested.\n");
                }
                else
                {
                    return chemicalIndex;
                }
            }
            
        }




            // Tests the effiency of a chemical
            // Component 2
            static void ChemicalChoice()
        {
            

            chosenChemicals.Add(validateChemical());

            decimal sumEfficiency = 0;


            for (int testCount = 1; testCount < 6; testCount++)
            {
                // Displaying the name of the most recently added chemical from our chosen chemical list
                Console.WriteLine($"-------- Test {testCount} : {CHEMICALNAMES[chosenChemicals[chosenChemicals.Count - 1]]} --------\n");

                Random rndm = new Random();

                int startGermCount = rndm.Next(1, 150);


                bool testFlag = true;
                while (testFlag)
                {

                    Console.WriteLine($"Press <ENTER> to initiate test {testCount}.\n\n" +
                        $"-----------------------------------------");

                    string proceed = Console.ReadLine();

                    if (proceed.Equals(""))
                    {
                        int endGermCount = rndm.Next(0, startGermCount);

                        decimal chemicalEfficiency = (decimal)(startGermCount - endGermCount) / 30;

                        chemicalEfficiency = Math.Round(chemicalEfficiency, 3);

                        Console.WriteLine($"Chemical Efficiency " +
                            $"for test {testCount}: {chemicalEfficiency}\n");

                        sumEfficiency += chemicalEfficiency;

                        testFlag = false;
                    }
                    else
                    {
                        Console.WriteLine("----------------------------\n"+
                            "Error: Please press <ENTER>\n"+
                            "----------------------------   ");
                    }
                }
            }

                decimal finalEfficientRating = sumEfficiency / 5;
                chemicalEfficiencies.Add(Math.Round(finalEfficientRating, 3));

                Console.WriteLine($"The final efficiency rating for {CHEMICALNAMES[chosenChemicals[chosenChemicals.Count - 1]]} is {finalEfficientRating}");
               
            
            
            

                
               

        }




        // Component 1
        // start or press run
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("------------------------------------------------------\n" +
                "Welcome to the Hi-Jean chemical testing app!\n" +
                "This app is used to test germ removel effectiveness\nof certain chemicals.\n" +
                "To use the program you must follow these steps:\n" +
                "1. Firstly press <ENTER> as instructed to start the program\n" +
                "2. Then enter a number that corresponds with a chemical\n" +
                "3. Then you must initiate a test by pressing the <Enter> key\n" +
                "4. Repeat the testing 5 times.\n" +
                "5. The end result is the chemical effeciency,\n   THE LOWER THE NUMBER THE MORE EFFECTIVE IT IS AT NEUTRALIZING GERMS.\n" +
                "-------------------------------------------------------------");

            bool flagMain = true;

            while (flagMain)


            {
                Console.WriteLine("Press <Enter> to start an experiment, or type 'stop' to quit.\n"+
                    "-------------------------------------------------------------");

                string userChoice = Console.ReadLine();
                if(userChoice.Equals("") && chosenChemicals.Count<CHEMICALNAMES.Count) 
                {
                    ChemicalChoice();
                    Console.WriteLine("");
                }
                else if(userChoice.Equals("stop") || chosenChemicals.Count == CHEMICALNAMES.Count)
                {

                    if (chosenChemicals.Count == CHEMICALNAMES.Count)
                    {
                        Console.WriteLine("You have tested all chemicals.\n"+
                            "---------------------------------\n"+
                            "LOWER VALUE MEANS MORE EFFECTIVE.\n"+
                            "---------------------------------");
                    }
                    flagMain = false;

                    EfficiencySortAsc();


                    Console.WriteLine("Most effective chemicals.\n");

                    for (int chemIndex = 0; chemIndex < chosenChemicals.Count; chemIndex++)
                    {
                        Console.WriteLine($"{chemIndex +1}. {CHEMICALNAMES[chosenChemicals[chemIndex]]} {chemicalEfficiencies[chemIndex]}\n");
                    }

                    Console.WriteLine("Thank you for using the HI-Jean chemical testing app");
                }
                else
                {
                    Console.WriteLine("------------------------------------\n"+
                        "ERROR: Please enter a correct choice\n"+
                        "------------------------------------");
                }
                



            }



        }
    }
}
