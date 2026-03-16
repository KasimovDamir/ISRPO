using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackpackApp.Debugging;
using BackpackApp.Models;

namespace BackpackApp.Solver
{
    public static class knapsackSolver
    {
        public static List<Item> Solve(List<Item> items, int maxWeight)
        {
            int n = items.Count;

            DebugLogger.Log($"Начало решения задачи. Предметов: {n}, макс. вес: {maxWeight}");

            int[,] dp = new int[n + 1, maxWeight + 1];

            for (int i = 1; i <= n; i++)
            {
                int weight = items[i - 1].Weight;
                int cost = items[i - 1].Cost;

                for (int w = 0; w <= maxWeight; w++)
                {
                    if (weight <= w)
                    {
                        int include = cost + dp[i - 1, w - weight];
                        int exclude = dp[i - 1, w];

                        dp[i, w] = include > exclude ? include : exclude;
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            DebugLogger.Log($"Максимальная стоимость: {dp[n, maxWeight]}");

            List<Item> result = new List<Item>();
            int remainingWeight = maxWeight;

            for (int i = n; i > 0; i--)
            {
                if (dp[i, remainingWeight] != dp[i - 1, remainingWeight])
                {
                    Item item = items[i - 1];
                    result.Add(item);
                    remainingWeight -= item.Weight;

                    DebugLogger.Log($"Добавлен предмет: {item.Name}");
                }
            }

            return result;
        }
    }
}
