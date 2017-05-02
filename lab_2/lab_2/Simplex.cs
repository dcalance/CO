using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Simplex
    {
        double[][] simplexArray;
        public Simplex(double[][] inputArr)
        {
            simplexArray = new double[inputArr.Length][];
            for (int i = 0; i < inputArr.Length; i++)
            {
                simplexArray[i] = new double[inputArr[i].Length + inputArr.Length];
                for (int counter = 0; counter < simplexArray[i].Length; counter++)
                {
                    if (counter > inputArr[i].Length - 2)
                    {
                        simplexArray[i][counter] = (i == counter - inputArr[i].Length + 1) ? 1 : 0;
                    }
                    else
                    {
                        simplexArray[i][counter] = inputArr[i][counter];
                    }
                }
                simplexArray[i][simplexArray[i].Length - 1] = inputArr[i][inputArr[i].Length - 1];
            }
            for (int i = 0; i < inputArr[inputArr.Length - 1].Length; i++)
            {
                simplexArray[simplexArray.Length - 1][i] *= -1;
            }
            simplexArray[2][0] = 1;
            simplexArray[2][5] = -1;
            simplexArray[2][7] = 0.5;
            solve();
        }

        void solve()
        {
            int[] finalArrIndexes = new int[simplexArray.Length - 1];
            while (simplexArray[simplexArray.Length - 1].Min() < 0)
            {
                int minPivotIndex = 0;
                double minPivotValue = simplexArray[simplexArray.Length - 1][0];

                for (int i = 1; i < simplexArray[simplexArray.Length - 1].Length; i++)
                {
                    if (simplexArray[simplexArray.Length - 1][i] < minPivotValue)
                    {
                        minPivotValue = simplexArray[simplexArray.Length - 1][i];
                        minPivotIndex = i;
                    }
                }

                double minRowValue = simplexArray[0][minPivotIndex];
                int minRowIndex = 0;

                for (int i = 1; i < simplexArray.Length - 1; i++)
                {
                    if (simplexArray[i][minPivotIndex] != 0 && simplexArray[i][simplexArray[i].Length - 1] / simplexArray[i][minPivotIndex] < simplexArray[minRowIndex][simplexArray[minRowIndex].Length - 1] / minRowValue)
                    {
                        minRowValue = simplexArray[i][minPivotIndex];
                        minRowIndex = i;
                    }
                }

                for (int i = 0; i < simplexArray[minRowIndex].Length; i++)
                {
                    simplexArray[minRowIndex][i] /= minRowValue;
                }
                finalArrIndexes[minRowIndex] = minPivotIndex;

                for (int rows = 0; rows < simplexArray.Length; rows++)
                {
                    double nr = simplexArray[rows][minPivotIndex];
                    for (int cols = 0; cols < simplexArray[rows].Length; cols++)
                    {
                        if (rows != minRowIndex)
                        {
                            simplexArray[rows][cols] += simplexArray[minRowIndex][cols] * -nr;
                        }
                    }
                }
            }
            double[] finalValues = new double[simplexArray[simplexArray.Length - 1].Length / 2];
            for (int i = 0; i < finalArrIndexes.Length; i++)
            {
                finalValues[finalArrIndexes[i]] = simplexArray[i][simplexArray[i].Length - 1];
            }
        }
    }
}
