using System;
using System.Collections.Generic;

namespace T03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Druid")
                {
                    heroes.Add(new Druid(heroName));
                }
                else if (heroType == "Paladin")
                {
                    heroes.Add(new Paladin(heroName));
                }
                else if (heroType == "Rogue")
                {
                    heroes.Add(new Rogue(heroName));
                }
                else if (heroType == "Warrior")
                {
                    heroes.Add(new Warrior(heroName));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int totalPower = 0;
            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
