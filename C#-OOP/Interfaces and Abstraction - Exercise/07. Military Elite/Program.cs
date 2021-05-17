﻿using MilitaryElite.Interface;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    class Program
    {
        private static List<ISoldier> soldiers = new List<ISoldier>();

        public static void Main()
        {
            ParseInput();
            PrintSoldiers();
        }

        private static void PrintSoldiers()
        {
            foreach (ISoldier soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static void ParseInput()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = inputParts[0];
                switch (type)
                {
                    case "Private":
                        GetPrivate(inputParts);
                        break;
                    case "Spy":
                        GetSpy(inputParts);
                        break;
                    case "LeutenantGeneral":
                        GetLeutenantGeneral(inputParts);
                        break;
                    case "Engineer":
                        GetEngineer(inputParts);
                        break;
                    case "Commando":
                        GetCommando(inputParts);
                        break;
                }
                input = Console.ReadLine();
            }
        }

        private static void GetCommando(string[] inputParts)
        {
            string corp = inputParts[5];
            if (!IsValidCorp(corp))
            {
                return;
            }
            List<IMission> missions = GetMissions(inputParts);
            ICommando commando = new Commando(inputParts[2], inputParts[3], inputParts[1], decimal.Parse(inputParts[4]), corp);
            soldiers.Add((ISoldier)commando);
        }

        private static List<IMission> GetMissions(string[] inputParts)
        {
            List<IMission> missions = new List<IMission>();
            for (int i = 6; i < inputParts.Length - 1; i += 2)
            {
                string state = inputParts[i + 1];
                if (state != "inProgress" && state != "Finished")
                {
                    continue;
                }
                IMission mission = new Mission(inputParts[i], inputParts[i + 1]);
                missions.Add(mission);
            }
            return missions;
        }

        private static void GetEngineer(string[] inputParts)
        {
            string corp = inputParts[5];
            if (!IsValidCorp(corp))
            {
                return;
            }
            List<IRepair> repairs = GetRepairs(inputParts);
            IEngineer engineer = new Engineer(inputParts[2], inputParts[3], inputParts[1], decimal.Parse(inputParts[4]), corp);
            soldiers.Add((ISoldier)engineer);
        }

        private static bool IsValidCorp(string corp)
        {
            if (corp != "Marines" && corp != "Airforces")
            {
                return false;
            }
            return true;
        }

        private static List<IRepair> GetRepairs(string[] inputParts)
        {
            List<IRepair> repairs = new List<IRepair>();
            for (int i = 6; i < inputParts.Length - 1; i += 2)
            {
                IRepair repair = new Repair(inputParts[i], int.Parse(inputParts[i + 1]));
                repairs.Add(repair);
            }
            return repairs;
        }

        private static void GetLeutenantGeneral(string[] inputParts)
        {
            List<string> ids = inputParts.Skip(5).ToList();
            List<ISoldier> privates = new List<ISoldier>();
            foreach (var id in ids)
            {
                privates.Add(soldiers.FirstOrDefault(s => s.Id == id));
            }
            ILieutenantGeneral leutenantGeneral = new LieutenantGeneral(inputParts[2], inputParts[3], inputParts[1], decimal.Parse(inputParts[4]));
            soldiers.Add((ISoldier)leutenantGeneral);
        }

        private static void GetSpy(string[] inputParts)
        {
            ISpy spy = new Spy(inputParts[2], inputParts[3], inputParts[3], int.Parse(inputParts[4]));
            soldiers.Add((ISoldier)spy);
        }

        private static void GetPrivate(string[] inputParts)
        {
            IPrivate @private = new Private(inputParts[2], inputParts[3], inputParts[1], decimal.Parse(inputParts[4]));

            soldiers.Add((ISoldier)@private);
        }
    }
}
