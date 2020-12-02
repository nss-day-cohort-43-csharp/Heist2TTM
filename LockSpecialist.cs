using System;
namespace Heist2TTM
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; } = "LockSpecialist";

        public void PerformSkill(Bank bank)
        {
            bank.VaultScore = bank.VaultScore - SkillLevel;
            Console.WriteLine($"{this.Name} is breaking the vault's lock. Decreased vault score by {this.SkillLevel}");
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{this.Name} has broken the vault's lock!");
            }
        }
    }
}