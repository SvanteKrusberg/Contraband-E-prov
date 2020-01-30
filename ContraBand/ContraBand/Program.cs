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
            //Skapar en lista för alla bilar
            List<Car> carList = new List<Car>();
            Console.WriteLine("Hur många bilar ska skapas?");

            //Jag använder .Trim() och .ToLower() för att eliminera risker av att användaren håller på och äcklar sig med
            //versaler och mellanrum :)
            userInput = Console.ReadLine().Trim();
            lyckad = int.TryParse(userInput, out amountOfCars);

            //Denna körs så länge Try.Parsen returnerar false (den returnerar även 0 om användaren ger ett inkorrekt värde
            //så skulle räcka med amountOfCars <= 0 men jag känner better safe than sorry)
            while (lyckad == false ||amountOfCars <= 0)
            {
                Console.WriteLine("Skriv in ett korrekt värde över 0!");
                userInput = Console.ReadLine().Trim();
                lyckad = int.TryParse(userInput, out amountOfCars);
            }

            //Efter att användaren bestämt hur många bilar som ska skapas så körs denna loop så många gånger
            //Den här loopen lägger då till en ny bil i listan varje gång loopen körs, alltså skapas rätt antal bilar
            for (int i = 0; i < amountOfCars; i++)
            {
                //Ett slumpvärde som bestämmer om bilen ska vara "Clean" eller ha Contraband
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

            //Tömmer konsolen så att det inte blir förvirrande för användaren :)
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

                //Skapar en cardecider som används senare
                int carDecider;

                userInput = Console.ReadLine().Trim().ToLower();

                //En if som kollar om användaren skriver in "end" och om den gär det så bryts loopen, en lat lösning jag vet
                //men det är ett e-prov och enkla lösningar känns bra :)
                if (userInput == "end")
                {
                    break;
                }
                //sedan om användaren inte skrivit in end som svar så kollar den om användaren skrev in ett korrekt värde eller inte.
                //nej man får inte avsluta spelet om man inte skrev end direkt de får skylla sig själva >:(
                else
                {
                    bool success = int.TryParse(userInput, out carDecider);
                    //Tar minus 1 på användarens svar, detta för att inte förvirra den med knasig programmerings
                    // indexering. Detta gör att den kan skriva 1 för att välja carList[0]
                    carDecider--;
                    while (success == false || carDecider < 0 || carDecider >= carList.Count())
                    {
                        Console.WriteLine("Pick a correct value!");
                        userInput = Console.ReadLine().Trim();
                        success = int.TryParse(userInput, out carDecider);
                        carDecider--;

                    }

                    //En if som kollar om bilen redan är checkad, om inte så körs .Examine()
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

            //Obligatorisk ReadLine i slutet av varje program :)
            Console.ReadLine();

        }
    }
}
