namespace Heist2TTM
{
    public interface IRobber
    {
        string Name { get; set; }
        int SkillLevel { get; set; }
        int PercentageCut { get; set; }
        string Specialty { get; }
        void PerformSkill(Bank bank);
    }
}

