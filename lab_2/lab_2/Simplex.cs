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
        int[] cbIndex;
        double[] zjcj;
        bool noSolution = false;
        public Simplex(double[][] inputArr, int varsCount)
        {
            int artificialVarsCount = 0;
            cbIndex = new int[inputArr.Length - 1];
            for (int i = 0; i < cbIndex.Length; i++)
            {
                cbIndex[i] = -1;
            }

            for (int rows = 0; rows < inputArr.Length - 1; rows++)
            {
                for (int cols = varsCount; cols < inputArr[rows].Length - 1; cols++)
                {
                    if (inputArr[rows][cols] == -1)
                    {
                        artificialVarsCount += 1;
                        cbIndex[rows] = inputArr[rows].Length - 2 + artificialVarsCount;
                    }
                }
            }
            if (artificialVarsCount > 0)
            {
                simplexArray = generatePhaseOneArr(inputArr, artificialVarsCount, varsCount);
                solve();
                for (int i = 0; i < cbIndex.Length; i++)
                {
                    if(cbIndex[i] > inputArr.Length)
                    {
                        noSolution = true;
                        return;
                    }
                }
                simplexArray = generatePhaseTwoArr(inputArr, varsCount);
                solve();
            }
            else
            {
                simplexArray = inputArr;
                for (int i = 0; i < cbIndex.Length; i++)
                {
                    cbIndex[i] = varsCount + i;
                }
                solve();
            }
        }
        public double[] getData()
        {
            double[] result = new double[cbIndex.Length + 1];
            double profit = 0;
            for (int i = 0; i < cbIndex.Length; i++)
            {
                if (cbIndex[i] <= cbIndex.Length - 1)
                {
                    result[cbIndex[i]] = simplexArray[i][simplexArray[i].Length - 1];
                    profit += simplexArray[simplexArray.Length - 1][cbIndex[i]] * result[cbIndex[i]];
                }
            }
            result[result.Length - 1] = profit;
            return result;
        }
        double[][] generatePhaseTwoArr(double[][] inputArr, int varsCount)
        {
            double[][] tempArray = new double[inputArr.Length][];
            for (int rows = 0; rows < inputArr.Length; rows++)
            {
                tempArray[rows] = new double[inputArr[rows].Length];
                for (int cols = 0; cols < inputArr[rows].Length; cols++)
                {
                    if (rows == inputArr.Length - 1)
                    {
                        tempArray[rows][cols] = inputArr[rows][cols];
                    }
                    else
                    {
                        tempArray[rows][cols] = simplexArray[rows][cols];
                    }
                }
                tempArray[rows][tempArray[rows].Length - 1] = simplexArray[rows][simplexArray[rows].Length - 1];
            }

            for (int i = 0; i < cbIndex.Length; i++)
            {
                cbIndex[i] = varsCount + i;
            }
            return tempArray;
        }
        double[][] generatePhaseOneArr(double[][] inputArr, int artificialVarsCount, int varsCount)
        {
            double[][] finalArr = new double[inputArr.Length][];
            for (int rows = 0; rows < inputArr.Length - 1; rows++)
            {
                finalArr[rows] = new double[inputArr[rows].Length + artificialVarsCount];
                for (int cols = 0; cols < inputArr[rows].Length - 1; cols++)
                {
                    finalArr[rows][cols] = inputArr[rows][cols];
                }
                finalArr[rows][finalArr[rows].Length - 1] = inputArr[rows][inputArr[rows].Length - 1];
            }
            finalArr[finalArr.Length - 1] = new double[inputArr[inputArr.Length - 1].Length + artificialVarsCount];
            for (int i = 0; i < cbIndex.Length; i++)
            {
                if (cbIndex[i] != -1)
                {
                    finalArr[i][cbIndex[i]] = 1;
                    finalArr[finalArr.Length - 1][cbIndex[i]] = -1;
                }
                else
                {
                    cbIndex[i] = varsCount + i;
                }
            }

            return finalArr;
        }
        void solve()
        {
            zjcj = getZjcj();
            while (zjcj.Min() < 0)
            {
                int pivotCol = getMinCol();
                int pivotRow = getMinRow(pivotCol);
                transform(pivotCol, pivotRow);
                zjcj = getZjcj();
            }
        }
        void transform(int pivotCol, int pivotRow)
        {
            cbIndex[pivotRow] = pivotCol;

            if (simplexArray[pivotRow][pivotCol] != 1)
            {
                double nr = simplexArray[pivotRow][pivotCol];
                for (int i = 0; i < simplexArray[pivotRow].Length; i++)
                {
                    simplexArray[pivotRow][i] /= nr;
                }
            }

            for (int rows = 0; rows < simplexArray.Length - 1; rows++)
            {
                if (rows == pivotRow)
                    continue;
                double nr = simplexArray[rows][pivotCol];
                for (int cols = 0; cols < simplexArray[rows].Length; cols++)
                {
                    simplexArray[rows][cols] += -nr * simplexArray[pivotRow][cols];
                }
            }
        }
        int getMinCol()
        {
            int minColIndex = 0;
            double minColValue = zjcj[0];
            for (int i = 1; i < zjcj.Length; i++)
            {
                if (zjcj[i] < minColValue)
                {
                    minColIndex = i;
                    minColValue = zjcj[i];
                }
            }
            return minColIndex;
        }
        int getMinRow(int minColIndex)
        {
            int minRowIndex = -1;
            double minRowValue = -1;
            for (int i = 0; i < simplexArray.Length - 1; i++)
            {
                if (simplexArray[i][minColIndex] > 0)
                {
                    minRowIndex = i;
                    minRowValue = simplexArray[i][simplexArray[i].Length - 1] / simplexArray[i][minColIndex];
                    break;
                }
            }
            if (minRowIndex != -1)
            {
                for (int i = minRowIndex; i < simplexArray.Length - 1; i++)
                {
                    double nr = simplexArray[i][simplexArray[i].Length - 1] / simplexArray[i][minColIndex];
                    if (simplexArray[i][minColIndex] > 0 && nr < minRowValue)
                    {
                        minRowValue = nr;
                        minRowIndex = i;
                    }
                }
                return minRowIndex;
            }
            else
            {
                return -1;
            }
        }
        double[] getZjcj()
        {
            double[] zjcj = new double[simplexArray[0].Length - 1];
            for (int cols = 0; cols < simplexArray[0].Length - 1; cols++)
            {
                double nr = 0;
                for (int rows = 0; rows < simplexArray.Length - 1; rows++)
                {
                    nr += simplexArray[rows][cols] * simplexArray[simplexArray.Length - 1][cbIndex[rows]];
                }
                zjcj[cols] = nr - simplexArray[simplexArray.Length - 1][cols];
            }
            return zjcj;
        }
    }
}
