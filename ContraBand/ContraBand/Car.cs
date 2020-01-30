using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraBand
{
    class Car
    {
        public string carType;

        public int passengers;
        public int contrabandAmount;
        public bool alreadyChecked;
        public static Random generator = new Random();

        public bool Examine()
        {
            alreadyChecked = true;
            if(contrabandAmount > 0)
            {
                int chanceToMiss = generator.Next(100);
                if(contrabandAmount == 1)
                {
                    if(chanceToMiss > 10)
                    {
                        Console.WriteLine("You found nothing.");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(contrabandAmount + " Contraband found!");
                        return true;
                    }

                }
                else if(contrabandAmount == 2)
                {
                    if(chanceToMiss > 30)
                    {
                        Console.WriteLine("You found nothing.");
                        return false;

                    }
                    else
                    {
                        Console.WriteLine(contrabandAmount + " Contraband found!");
                        return true;
                    }

                }
                else if(contrabandAmount == 3)
                {
                    if(chanceToMiss > 50)
                    {
                        Console.WriteLine("You found nothing.");
                        return false;

                    }
                    else
                    {
                        Console.WriteLine(contrabandAmount + " Contraband found!");
                        return true;

                    }
                }
                else
                {
                    if (chanceToMiss > 70)
                    {
                        Console.WriteLine("You found nothing.");
                        return false;

                    }
                    else
                    {
                        Console.WriteLine(contrabandAmount + " Contraband found!");
                        return true;

                    }

                }

            }
            else
            {
                Console.WriteLine("You found nothing.");
                return false;
            }

        }

        //en metod bara för att kolla att jag skapar nya bilar rätt och att bilarna blir unika
        public void PrintStats()
        {
            Console.WriteLine("Passengers: " + passengers);
            Console.WriteLine("Contraband: " + contrabandAmount);
            Console.WriteLine(carType);

        }

    }
}
