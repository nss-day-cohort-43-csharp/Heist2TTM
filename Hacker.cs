using System;
namespace Heist2TTM
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; } = "Hacker";

        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore = bank.AlarmScore - SkillLevel;
            Console.WriteLine($"{this.Name} is hacking the alarm system. Decreased alarm score by {this.SkillLevel}");
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{this.Name} has disabled the alarm system!");
            }
        }
    }
}