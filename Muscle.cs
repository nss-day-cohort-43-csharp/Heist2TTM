using System;
namespace Heist2TTM
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; } = "Muscle";

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
            Console.WriteLine($"{this.Name} is killing the guards. Decreased security guard score by {this.SkillLevel}");
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{this.Name} has straight up murdered all the guards! Yikes!");
            }
        }
    }
}