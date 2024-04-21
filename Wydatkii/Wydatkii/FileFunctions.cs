using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Wydatkii
{
    public static class FileFunctions
    {
        public static string Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"Costs4.txt");
        public static void SaveCosts(List<Cost> costsList)
        {
            List<string> costsString = new List<string>();
            foreach (Cost cost in costsList)
            {
                costsString.Add(cost.ID + ";" + cost.Name + ";" + cost.Value + ";" + cost.Date);
            }
            File.WriteAllLines(Path, costsString);
        }
        public static List<Cost> ReadCosts()
        {
            List<string> costsString = File.ReadAllLines(Path).ToList();
            List<Cost> costs = new List<Cost>();
            foreach (string item in costsString)
            {
                costs.Add(new Cost(int.Parse(item.Split(';')[0]), item.Split(';')[1], decimal.Parse(item.Split(';')[2]), Convert.ToDateTime(item.Split(';')[3])));
            }
            return costs ;
        }
        public static void AddCost(Cost cost)
        {
            List<Cost> costs = ReadCosts();
            if(costs.Count == 0)
            {
                cost.ID = 0;
            }
            else
            {
                cost.ID = costs.Last().ID + 1;
            }
            costs.Add(cost);
            SaveCosts(costs);
        }
        public static void RemoveCost(Cost cost)
        {
            List<Cost> costs = ReadCosts();
            foreach (Cost item in costs)
            {
                if(cost.ID == item.ID)
                {
                    costs.Remove(item);
                    break;
                }
            }
            SaveCosts(costs);
        }
    }
}
