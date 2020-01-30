using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraBand
{
    class Program
    {
        static void Main(string[] args)
        {
            bool lyckad = false;
            int amountOfCars = 0;
            string userInput;
            List<Car> carList = new List<Car>();
            Console.WriteLine("Hur många bilar ska skapas?");
            userInput = Console.ReadLine().Trim();
            lyckad = int.TryParse(userInput, out amountOfCars);

            while (lyckad == false ||amountOfCars <= 0)
            {
                Console.WriteLine("Skriv in ett korrekt värde över 0!");
                userInput = Console.ReadLine().Trim();
                lyckad = int.TryParse(userInput, out amountOfCars);
            }

            for (int i = 0; i < amountOfCars; i++)
            {
                int cardecider = Utils.rng.Next(2);
                
                if(cardecider == 1)
                {
                    carList.Add(new CleanCar());
                }
                else
                {
                    carList.Add(new ContrabandCar());
                }
            }

            Console.Clear();

            //En enkel loop bara för att kolla att de bilar jag skapar är unika med individuella stats
            /*
            for (int i = 0; i < amountOfCars; i++)
            {
                carList[i].PrintStats();
            }
            */
            while (true)
            {
                Console.WriteLine("Type 'END' to quit the game.");
                Console.WriteLine("Vilken bil vill du titta på? [1 - " + carList.Count() + "]");
                int carDecider;
                userInput = Console.ReadLine().Trim().ToLower();
                if (userInput == "end")
                {
                    break;
                }

                else
                {
                    bool success = int.TryParse(userInput, out carDecider);
                    carDecider--;
                    while (success == false || carDecider < 0 || carDecider >= carList.Count())
                    {
                        Console.WriteLine("Pick a correct value!");
                        userInput = Console.ReadLine().Trim();
                        success = int.TryParse(userInput, out carDecider);
                        carDecider--;

                    }

                    if (carList[carDecider].alreadyChecked == true)
                    {
                        Console.WriteLine("You've already checked this car!");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        carList[carDecider].Examine();
                        Console.ReadLine();
                        Console.Clear();
                    }

                }

            }

            Console.ReadLine();

        }
    }
}
