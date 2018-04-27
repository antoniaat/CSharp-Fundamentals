﻿using System.Collections.Generic;
using System.Linq;

namespace Last_Army.Core
{
    public class SoldierController
    {
        public static void SoldierChangesAfterSuccessfulMission(Dictionary<string, List<Soldier>> army, Mission mission, string rankerType)
        {
            foreach (var soldier in army[rankerType])
            {
                soldier.Motivation -= mission.DecreasingMotivation;
                soldier.Endurance -= mission.DecreasingEndurance;
                soldier.IncreaseSuccessMissionCounter();
            }
        }

        public static void SoldierChangesAfterFailedMission(Dictionary<string, List<Soldier>> army,
            Mission mission, string rankerType)
        {
            foreach (var soldier in army[rankerType])
            {
                soldier.IncreaseFailedMissionCounter();
            }
        }

        public static void TeamGetBonus(Dictionary<string, List<Soldier>> army, string rankerType)
        {
            foreach (var soldiers in army[rankerType])
            {
                soldiers.GetBonus();
            }
        }

        public static void TeamComesBackFromVacation(Dictionary<string, List<Soldier>> army, string rankerType)
        {
            foreach (var soldiers in army[rankerType])
            {
                soldiers.ComeBackFromVacation();
                soldiers.MakeStatsFull();
            }
        }

        public static void TeamGoesOnVacation(Dictionary<string, List<Soldier>> army, string rankerType)
        {
            foreach (var soldiers in army[rankerType])
            {
                soldiers.Regenerate();
            }
        }

        public static void TeamRegenerate(Dictionary<string, List<Soldier>> army, string rankerType)
        {
            army[rankerType].ForEach(r => r.Regenerate());
        }

        public static bool CheckSoldiersMotivationAndEndurance(Mission mission, Dictionary<string, List<Soldier>> army, string s)
        {
            if (army[mission.RequiredTeam].Average(m => m.Motivation) < mission.MotivationNeeded
                || army[mission.RequiredTeam].Average(e => e.Endurance) < mission.EnduranceRequired)
            {
                return false;
            }
            return true;
        }

        public static bool DoWeHaveAllNeededWeaponsForTheMission(Dictionary<string, List<Ammunition>> wearHouse,
            Dictionary<string, List<Soldier>> army, string soldireType, Mission mission)
        {
            foreach (var weapon in mission.MissionWeapons)
            {
                string weaponName = weapon.Name;

                // проверяваме дали изобщо имаме такива оръжия
                if (!wearHouse.ContainsKey(weaponName))
                {
                    return false;
                }

                int weaponIndex = wearHouse[weaponName].FindIndex(w => w.Name.Equals(weaponName));

                //проверка дали оръжието което се иска от нас, нищо че го има в склада войника е обучен да го използва
                if (!army[soldireType][0].Weapons.Contains(weaponName))
                {
                    return false;
                }
                // проверяваме дали броя оръжия които имаме отговаря на броя на хората в екипа
                if (army[soldireType].Count > wearHouse[weaponName][weaponIndex].Number)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CanEverySoldierCarryOnTheNeededWeapons(Dictionary<string, List<Soldier>> army, List<Ammunition> missionWeapons, string soldierGroup)
        {
            foreach (var soldier in army[soldierGroup])
            {
                if (!soldier.CanCarryWeaponsTotalWeight(missionWeapons))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsTheTeamOnVacation(Dictionary<string, List<Soldier>> army, string soldierGroup)
        {
            foreach (var soldier in army[soldierGroup])
            {
                if (soldier.OnVacation)
                {
                    return true;
                }
            }
            return false;
        }
    }
}