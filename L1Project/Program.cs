using System;

namespace ChemicalApp
{
    class Program
    {



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
                    Console.WriteLine("Testing Chemical");
                }
                else if(userChoice.Equals("stop"))
                {
                    flag_main = false;
                    Console.WriteLine("Thank you for using HI-Jean chemical testing app");
                }
                else
                {
                    Console.WriteLine("ERROR: Please enter a correct choice");
                }
                    

                

            }



        }
    }
}
