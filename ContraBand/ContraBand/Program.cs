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

            //En enkel loop bara för att kolla att de bilar jag skapar är unika med individuella stats
            /*
            for (int i = 0; i < amountOfCars; i++)
            {
                carList[i].PrintStats();
            }
            */

            Console.WriteLine("Yay" + " " + amountOfCars);
            Console.ReadLine();

        }
    }
}
