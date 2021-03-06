﻿using System;
using System.Collections.Generic;
using System.Linq;

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
                SkillLevel = 100,
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
                SkillLevel = 100,
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
                SkillLevel = 100,
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
            while (enteredName != "")
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

            Random r = new Random();
            int generatedAlarmScore = r.Next(0, 101);
            int generatedVaultScore = r.Next(0, 101);
            int generatedSecurityGuardScore = r.Next(0, 101);
            int generatedCashOnHand = r.Next(50000, 1000001);

            Bank suntrust = new Bank()
            {
                AlarmScore = generatedAlarmScore,
                VaultScore = generatedVaultScore,
                SecurityGuardScore = generatedSecurityGuardScore,
                CashOnHand = generatedCashOnHand
            };

            Console.WriteLine($"Bank Cash on Hand: {suntrust.CashOnHand}");

            List<Scores> bankScores = new List<Scores>() {
                new Scores() {ScoreType = "Alarm Score", ScoreValue = generatedAlarmScore},
                new Scores() {ScoreType = "Vault Score", ScoreValue = generatedVaultScore},
                new Scores() {ScoreType = "Security Guard Score", ScoreValue = generatedSecurityGuardScore}
            };

            List<Scores> ScoreList = bankScores.OrderByDescending(bankScore => bankScore.ScoreValue).ToList();

            Console.WriteLine($"The strongest point is the {ScoreList.First().ScoreType} and the weakest point is the {ScoreList.Last().ScoreType}");

            foreach (IRobber criminal in team)
            {
                Console.Write(team.IndexOf(criminal));
                Console.Write($". {criminal.Name}");
                Console.Write($": {criminal.Specialty}");
                Console.Write($" has a skill level of {criminal.SkillLevel}");
                Console.Write($", and a {criminal.PercentageCut}% cut.");
                Console.WriteLine("");

            }

            List<IRobber> crew = new List<IRobber>();

            int cutTotal = 100;
            int foreverZero = 0;
            while (foreverZero == 0)
            {
                Console.Write("Enter Team Member Number: ");
                string chosenCriminal = Console.ReadLine();
                if (chosenCriminal == "")
                {
                    break;
                }
                int criminalIndex = Int32.Parse(chosenCriminal);
                crew.Add(team[criminalIndex]);

                cutTotal = cutTotal - team[criminalIndex].PercentageCut;
                Console.WriteLine($"Cut Remaining: {cutTotal}");

                team.RemoveAt(criminalIndex);

                foreach (IRobber criminal in team)
                {
                    if (criminal.PercentageCut <= cutTotal)
                    {
                        Console.Write(team.IndexOf(criminal));
                        Console.Write($". {criminal.Name}");
                        Console.Write($": {criminal.Specialty}");
                        Console.Write($" has a skill level of {criminal.SkillLevel}");
                        Console.Write($", and a {criminal.PercentageCut}% cut.");
                        Console.WriteLine("");
                    }
                }

            }
            foreach (IRobber member in crew)
            {
                member.PerformSkill(suntrust);
            }

            if (suntrust.IsSecure)
            {
                Console.WriteLine("Failure. You have brought shame on yourself and your family!");
            }
            else
            {
                Console.WriteLine("Success! You robbed a bank, good job loser.");

                foreach (IRobber member in crew)
                {
                    Console.WriteLine($"{member.Name} gets ${Convert.ToDouble(suntrust.CashOnHand) * (Convert.ToDouble(member.PercentageCut) / 100)}");
                }

                Console.WriteLine($"You Get ${Convert.ToDouble(suntrust.CashOnHand) * (Convert.ToDouble(cutTotal) / 100)}");
            }
        }

    }
}
