using System;
using System.Collections.Generic;

namespace Heist2TTM
{
    class Program
    {
        static void Main(string[] args)
        {


            Hacker h1 = new Hacker()
            {
                Name = "Theodore",
                SkillLevel = 25,
                PercentageCut = 15
            };

            Hacker h2 = new Hacker()
            {
                Name = "Ivar",
                SkillLevel = 27,
                PercentageCut = 20
            };

            LockSpecialist l1 = new LockSpecialist()
            {
                Name = "Carlton",
                SkillLevel = 6,
                PercentageCut = 5
            };

            LockSpecialist l2 = new LockSpecialist()
            {
                Name = "Louie",
                SkillLevel = 16,
                PercentageCut = 15
            };

            Muscle m1 = new Muscle()
            {
                Name = "Duke",
                SkillLevel = 20,
                PercentageCut = 10
            };

            Muscle m2 = new Muscle()
            {
                Name = "Archer",
                SkillLevel = 30,
                PercentageCut = 20
            };

            List<IRobber> rolodex = new List<IRobber>()
            {
                m1, m2, h1, h2, l1, l2
            };

            BeginHeist(rolodex);
        }
        static void BeginHeist(List<IRobber> team)
        {
            string enteredName = "";
            Console.WriteLine($"Current number of operatives: {team.Count}");
            Console.Write("Enter new team member name: ");
            enteredName = Console.ReadLine();
            while(enteredName != "")
            {
                Console.Write(@"Choose a specialty: 
1) Hacker (Disables alarms)
2) Muscle (Disables/murders guards)
3) Lock Specialist (Cracks the vault): ");
                int enteredType = int.Parse(Console.ReadLine());
                Console.Write("Enter a skill level (1-100): ");
                int enteredSkill = int.Parse(Console.ReadLine());
                Console.Write("Enter the percentage of cut: ");
                int enteredCut = int.Parse(Console.ReadLine());

                if (enteredType == 1)
                {
                    Hacker robber1 = new Hacker()
                    {
                        Name = enteredName,
                        SkillLevel = enteredSkill,
                        PercentageCut = enteredCut
                    };
                    team.Add(robber1);

                }
                if (enteredType == 2)
                {
                    Muscle robber1 = new Muscle()
                    {
                        Name = enteredName,
                        SkillLevel = enteredSkill,
                        PercentageCut = enteredCut
                    };
                    team.Add(robber1);

                }
                if (enteredType == 3)
                {
                    LockSpecialist robber1 = new LockSpecialist()
                    {
                        Name = enteredName,
                        SkillLevel = enteredSkill,
                        PercentageCut = enteredCut
                    };
                    team.Add(robber1);
                }
                foreach (IRobber criminal in team)
                {
                    Console.WriteLine(criminal.Name);
                }
                Console.WriteLine($"Current number of operatives: {team.Count}");
                Console.Write("Enter new team member name: ");
                enteredName = Console.ReadLine();
            }

        }
    }
}
