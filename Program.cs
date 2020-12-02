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

            Console.WriteLine(rolodex[0].Name);
        }
    }
}
