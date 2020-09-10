using System;
using System.Collections.Generic;

namespace Utility
{
    public class MathUtility
    {
        public static double QuadractiFormulaPlus(double A, double B, double C)
        {
            if((B * B) - (4 * A * C) < 0){ throw new ArgumentException("The answer will be null."); }
            if (A.Equals(0)) { return -C / B; }
            return (-B + Math.Sqrt((B * B) - (4 * A * C))) / (2 * A);
        }

        private static Random rand_box_muller = new Random();
        public static double BoxMuMuller(double ave = 0, double sigma = 1)
        {
            //var rnd = new Random();
            double X = rand_box_muller.NextDouble();
            double Y = rand_box_muller.NextDouble();

            return sigma * Math.Sqrt(-2.0 * Math.Log(X)) * Math.Cos(2.0 * Math.PI * Y) + ave;
            //sigma * Math.Sqrt(-2.0 * Math.Log(X)) * Math.Sin(2.0 * Math.PI * Y) + ave;
        }

        public static int WeightedPick(IReadOnlyList<float> pList)
        {
            float totalWeight = 0f;
            int pick = 0;

            // トータルの重みを計算する
            for (int i = 0; i < pList.Count; i++)
            {
                totalWeight += pList[i];
            }

            // 抽選する
            //int rnd = rand() % totalWeight;
            float rnd = UnityEngine.Random.Range(0f, totalWeight);

            for (int i = 0; i < pList.Count; i++)
            {
                if (rnd < pList[i])
                {
                    // 抽選対象決定
                    pick = i;
                    break;
                }

                // 次の対象を調べる
                rnd -= pList[i];
            }

            return pick;
        }
    }
}
