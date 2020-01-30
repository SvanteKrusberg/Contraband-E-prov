using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraBand
{
    class Car
    {
        //Variablar som ärvs av de andra bilklasserna
        public string carType;
        public int passengers;
        public int contrabandAmount;
        public bool alreadyChecked;

        //Vill ju använda min Utils.rng.Next() egentligen men fine I'll do this too >:(
        public static Random generator = new Random();

        //Inte världens finaste eller smartaste lösning, men den gör vad den ska göra
        public bool Examine()
        {
            alreadyChecked = true;
            //Om bilen har ContraBand så körs algoritmen som bestämmer om man ska se det eller inte, om inte så returnerar
            // den bara false direkt
            if(contrabandAmount > 0)
            {
                //Om bilen har Contraband så skapas ett slumpvärde mellan 0-99
                int chanceToMiss = generator.Next(100);

                //Här är en if sats, som med olika värden beroende på antal Contraband har olika hög sannolikhet att
                // returnera true och säga hur mycket ContraBand som fanns. Chansen att hitta 1 Contraband är låg och sedan
                // stiger den med jämna mellanrum
                if(contrabandAmount == 1)
                {
                    //Sedan är det samma logik för alla contrabandAmount, med skilnad att chansen att hitta godset ökar
                    //Om det slumpmässiga värdet är större än x så hittas inget och om inte så hittar man Contraband.
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

        //En metod bara för att kolla att jag skapar nya bilar rätt och att bilarna blir unika
        //Användes för testning, används inte i riktiga programmet.
        public void PrintStats()
        {
            Console.WriteLine("Passengers: " + passengers);
            Console.WriteLine("Contraband: " + contrabandAmount);
            Console.WriteLine(carType);

        }

    }
}
