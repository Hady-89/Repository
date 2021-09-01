using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1
{
    public class MathChains
    {
        public static double[,] ObMatrix(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            double[,] obrm = new double[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    obrm[i, j] = matrix[i, j];
                }
            }

            if (n != m)
            {
                MessageBox.Show("Обратной матрицы не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int[] row = new int[n];
            int[] col = new int[n];

            double[] tempM = new double[n];
            int temp;
            int I_found;
            int J_found;
            double found;
            double abs_found;


            // установиим row и column как вектор изменений.
            for (int k = 0; k < n; k++)
            {
                row[k] = k;
                col[k] = k;
            }

            // начало главного цикла
            for (int k = 0; k < n; k++)
            {
                // найдем наибольший элемент для основы
                found = obrm[row[k], col[k]];
                I_found = k;
                J_found = k;
                for (int i = k; i < n; i++)
                {
                    for (int j = k; j < n; j++)
                    {
                        abs_found = Math.Abs(found);
                        if (Math.Abs(obrm[row[i], col[j]]) > abs_found)
                        {
                            I_found = i;
                            J_found = j;
                            found = obrm[row[i], col[j]];
                        }
                    }
                }

                if (Math.Abs(found) < 1.0E-10)
                {
                    MessageBox.Show("Матрица сингулярна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Перестановка к-ой строки и к-ого столбца с стобцом и строкой, содержащий основной элемент(found основу)
                temp = row[k];
                row[k] = row[I_found];
                row[I_found] = temp;
                temp = col[k];
                col[k] = col[J_found];
                col[J_found] = temp;

                // k-ую строку с учетом перестановок делим на основной элемент (1)
                obrm[row[k], col[k]] = 1.0 / found;

                for (int j = 0; j < n; j++)
                {
                    if (j != k)
                    {
                        obrm[row[k], col[j]] = obrm[row[k], col[j]] * obrm[row[k], col[k]];
                    }
                }

                // Рассчет остальных строк (2)
                for (int i = 0; i < n; i++)
                {
                    if (k != i)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (k != j)
                            {
                                obrm[row[i], col[j]] = obrm[row[i], col[j]] - obrm[row[i], col[k]] * obrm[row[k], col[j]];
                            }
                        }
                        obrm[row[i], col[k]] = -obrm[row[i], col[k]] * obrm[row[k], col[k]];
                    }
                }
            }

            // Переставляем назад rows (3)
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    tempM[col[i]] = obrm[row[i], j];
                }

                for (int i = 0; i < n; i++)
                {
                    obrm[i, j] = tempM[i];
                }
            }

            // Переставляем назад columns (3)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tempM[row[j]] = obrm[i, col[j]];
                }

                for (int j = 0; j < n; j++)
                {
                    obrm[i, j] = tempM[j];
                }
            }

            return obrm;
        }
        //----------------------------------------------------------------------------------
        //public static double[,] Minor(double[,] MassA, int row, int column)// минор
        //{

        //    double[,] buf = new double[MassA.GetLength(0) - 1, MassA.GetLength(0) - 1];
        //    for (int i = 0; i < MassA.GetLength(0); i++)
        //        for (int j = 0; j < MassA.GetLength(1); j++)
        //        {
        //            if ((i != row) || (j != column))
        //            {
        //                if (i > row && j < column) buf[i - 1, j] = MassA[i, j];
        //                if (i < row && j > column) buf[i, j - 1] = MassA[i, j];
        //                if (i > row && j > column) buf[i - 1, j - 1] = MassA[i, j];
        //                if (i < row && j < column) buf[i, j] = MassA[i, j];
        //            }
        //        }
        //    return buf;
        //}
        //---------------------------------------------------------------
        //public static double Determ(double[,] MassA)// детерминант
        //{

        //    double det = 0;
        //    int Rank = MassA.GetLength(1);
        //    if (Rank == 1) det = MassA[0, 0];
        //    if (Rank == 2) det = MassA[0, 0] * MassA[1, 1] - MassA[0, 1] * MassA[1, 0];
        //    if (Rank > 2)
        //    {
        //        for (int j = 0; j < MassA.GetLength(1); j++)
        //        {
        //            det += Math.Pow(-1, 0 + j) * MassA[0, j] * Determ(Minor(MassA, 0, j));
        //        }
        //    }
        //    return det;
        //}
        //------------------------------------------------------------------------
        //public static double[,] Algdop(double[,] MassA)//алгебраическое дополнение
        //{

        //    double[,] dop = new double[MassA.GetLength(0), MassA.GetLength(0)];
        //    for (int i = 0; i < MassA.GetLength(0); i++)
        //        for (int j = 0; j < MassA.GetLength(1); j++)
        //        {
        //            dop[i, j] = Math.Pow(-1, (i + 1) + (j + 1)) * Determ(Minor(MassA, i, j));
        //        }
        //    return dop;
        //}
        //----------------------------------------------------------------
        //public static double[,] Obrmatr(double[,] MassA)//обратная матрица
        //{

        //    double[,] obr = new double[MassA.GetLength(0), MassA.GetLength(0)];
        //    for (int i = 0; i < MassA.GetLength(0); i++)
        //        for (int j = 0; j < MassA.GetLength(1); j++)
        //        {
        //            obr[i, j] = Algdop(MassA)[i, j] / Determ(MassA);
        //        }
        //    return obr;
        //}
        public static double[] Slau(double[,] matrix, int razmer) 
        {
            int razmerM = razmer;
            double[,] MassA = new double[razmerM, razmerM];
            double[,] MassBUF = new double[razmerM, razmerM];
            double[] Bm = new double[razmerM];
            double[] slau = new double[razmerM];
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassA[i, j] = matrix[i, j];
                }
            }
            //Транспонируем матрицу А
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassBUF[i, j] = MassA[j, i];
                }
            }
            //Вычитаем единицу по строкам
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (i == j)
                    {
                        MassBUF[i, j]--;
                    }
                }
            }
            //Заменяем последнюю строку единицей
            for (int j = 0; j < razmerM; j++)
            {
                MassBUF[razmerM - 1, j] = 1;
            }

            Bm[razmerM - 1] = 1;
            double[,] Am = ObMatrix(MassBUF);
            //double[,] Am = new double[razmerM, razmerM];
            //Транспонируем матрицу Аm
            //for (int i = 0; i < razmerM; i++)
            //{
            //    for (int j = 0; j < razmerM; j++)
            //    {
            //        Am[i, j] = AmWT[j, i];
            //    }
            //}
            //Вектор решения СЛАУ - Матрица финальных вероятностей
            // slau = (Am^-1) * Bm
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    slau[i] += Am[i, j] * Bm[j];

                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                slau[i] = Math.Round(slau[i], 2);
            }
            return slau;
        }
        public static double[,] FundMatrixP(double[,] matrix, int razmer) 
        {
            int razmerM = razmer;
            int Onecount = 0;
            double[,] MassA = matrix;
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassA[i, j] = Math.Round(MassA[i, j], 1);
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (MassA[i, j] == 1)
                    {
                        Onecount++;
                    }

                }

            }

            //Получение матрицы Q из канонического представления
            int razm = razmerM;
            int size = razmerM - 1;
            int minirazm = razmerM - Onecount;
            int temp = 0;
            double[,] OLDm = new double[razmerM, razmerM];
            double[,] memB;
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    OLDm[i, j] = MassA[i, j];
                }
            }
            double[,] memBUF = OLDm;
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (OLDm[i, j] == 1)
                    {
                        int row = i;
                        int column = j;
                        double[,] Mtemp = new double[size, size];
                        memB = Mtemp;
                        if (temp != 0)
                        {
                            row = row - temp;
                            column = column - temp;
                        }
                        for (int t = 0; t < razm; t++)
                        {
                            for (int p = 0; p < razm; p++)
                            {
                                if ((t != row) || (p != column))
                                {
                                    if (t > row && p < column)
                                        memB[t - 1, p] = memBUF[t, p];
                                    if (t < row && p > column)
                                        memB[t, p - 1] = memBUF[t, p];
                                    if (t > row && p > column)
                                        memB[t - 1, p - 1] = memBUF[t, p];
                                    if (t < row && p < column)
                                        memB[t, p] = memBUF[t, p];
                                }
                            }
                        }
                        temp++;
                        razm--;
                        size--;
                        memBUF = memB;
                    }
                }
            }
            double[,] Qm = memBUF;
            //Получение матрицы I из канонического представления
            double[,] Imatr1 = new double[minirazm, minirazm];
            for (int i = 0; i < minirazm; i++)
            {
                for (int j = 0; j < minirazm; j++)
                {
                    Imatr1[i, i] = 1;
                }
            }
            //Получение значение I - Q 
            double[,] Pogl = new double[minirazm, minirazm];
            for (int i = 0; i < minirazm; i++)
            {
                for (int j = 0; j < minirazm; j++)
                {
                    Pogl[i, j] = Imatr1[i, j] - Qm[i, j];
                }
            }
            //Получение Фундаментальной матрицы поглощающих цепей
            double[,] PoglF = ObMatrix(Pogl);
            for (int i = 0; i < minirazm; i++)
            {
                for (int j = 0; j < minirazm; j++)
                {
                    PoglF[i, j] = Math.Round(PoglF[i, j], 2);
                }
            }
            return PoglF;
        }
        public static double[] PogtimeMatrix(double[,] matrix, int razmer)
        {
            //Среднее время до поглощения
            int minirazm = razmer;
            double[] Tm = new double[minirazm];
            for (int i = 0; i < minirazm; i++)
            {
                for (int j = 0; j < minirazm; j++)
                {
                    Tm[j] += matrix[j, i];
                }
            }
            for (int i = 0; i < minirazm; i++)
            {
                Tm[i] = Math.Round(Tm[i], 2);
            }
            return Tm;
        }
        public static double[,] FundMatrixE(double[,] matrix, int razmer) 
        {
            int razmerM = razmer;
            double[,] MassA = new double[razmerM, razmerM];
            
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassA[i, j] = matrix[i, j];
                }
            }
            double[] slau = Slau(MassA, razmerM);
            double[,] slau1 = new double[razmerM, razmerM];
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    slau1[i, j] = slau[j];

                }
            }
            double[,] AFmatrix = slau1;
            double[,] Imatrix = new double[razmerM, razmerM];
            double[,] tempM = new double[razmerM, razmerM];
            //Заполнение единичной матрицы Imatrix
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (i == j)
                    {
                        Imatrix[i, j] = 1;
                    }
                }
            }
            //Вычисление значения выражения I - (P - A) -> P - MassA, A - AFmatrix, I - Imatrix
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM[i, j] = Imatrix[i, j] - (MassA[i, j] - AFmatrix[i, j]);
                }
            }
            //Вычисление обратной матрицы и транспонирование (I - (P - A))^-1
            //ErgodF - Фундаментальная матрица эргодической цепи Маркова
            double[,] Ergod = ObMatrix(tempM);
            double[,] ErgodF = new double[razmerM, razmerM];
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    ErgodF[i, j] = Ergod[j, i];
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    ErgodF[i, j] = Math.Round(ErgodF[i, j], 2);
                }
            }
            return ErgodF;
        }
        public static double[,] ErgtimeMatrix(double[,] matrixA, double[,] matrix, int razmer)
        {
            //Определение времени первого достижения
            int razmerM = razmer;
            double[,] tempM = new double[razmerM, razmerM];
            double[,] tempM1 = new double[razmerM, razmerM];
            //------------------------------------------------
            double[,] Imatrix = new double[razmerM, razmerM];
            double[,] E = new double[razmerM, razmerM];
            double[,] Zdg = new double[razmerM, razmerM];
            double[,] D = new double[razmerM, razmerM];
            double[,] M = new double[razmerM, razmerM];
            double[,] ErgodF = matrix;
            //Заполнение единичной матрицы Imatrix
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (i == j)
                    {
                        Imatrix[i, j] = 1;
                    }
                }
            }
            // M = (I - Z + E * Zdg) * D
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM[i, j] = 0;
                    E[i, j] = 1;
                }
            }
            double[] slau = Slau(matrixA, razmerM);
            //Получение матриц D и Zdg
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (i == j)
                    {
                        Zdg[i, j] = ErgodF[i, j];
                        D[i, j] = 1 / slau[i];
                    }
                }
            }
            //Вычисление E * Zdg
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    for (int k = 0; k < razmerM; k++)
                    {
                        tempM[i, j] += E[i, k] * Zdg[k, j];
                    }
                }
            }
            //Вычисление I - Z + E * Zdg
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM1[i, j] = Imatrix[i, j] - ErgodF[i, j] + tempM[i, j];
                }
            }
            //Время первого достижения
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    for (int k = 0; k < razmerM; k++)
                    {
                        M[i, j] += tempM1[i, k] * D[k, j];
                    }
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    M[i, j] = Math.Round(M[i, j], 2);
                }
            }
            return M;
        }
        public static double[,] DisErgtimeMatrix(double[,] matrixA, double[,] matrix, double[,] matrix1, int razmer) 
        {
            int razmerM = razmer;
            double[,] tempM = new double[razmerM, razmerM];
            double[,] tempM1 = new double[razmerM, razmerM];
            double[,] tempM2 = new double[razmerM, razmerM];
            double[,] tempM3 = new double[razmerM, razmerM];
            double[,] Imatrix = new double[razmerM, razmerM];
            double[,] E = new double[razmerM, razmerM];
            double[,] Zdg = new double[razmerM, razmerM];
            double[,] D = new double[razmerM, razmerM];
            double[,] ErgodF = matrix;
            double[,] M = matrix1;
            //Заполнение единичной матрицы Imatrix
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (i == j)
                    {
                        Imatrix[i, j] = 1;
                    }
                }
            }
            double[] slau = Slau(matrixA, razmerM);
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (i == j)
                    {
                        Zdg[i, j] = ErgodF[i, j];
                        D[i, j] = 1 / slau[i];
                    }
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM[i, j] = 0;
                    tempM1[i, j] = 0;
                }
            }
            //Определение дисперсии времени первого достижения
            double[,] W = new double[razmerM, razmerM];
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    for (int k = 0; k < razmerM; k++)
                    {
                        tempM[i, j] += Zdg[i, k] * D[k, j];
                    }
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM1[i, j] = 2 * tempM[i, j];
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM[i, j] = 0;
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM[i, j] = tempM1[i, j] - Imatrix[i, j];
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM1[i, j] = 0;
                }
            }
            // M(2Zdg * D - I)
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    for (int k = 0; k < razmerM; k++)
                    {
                        tempM1[i, j] += M[i, k] * tempM[k, j];
                    }
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM[i, j] = 0;
                }
            }
            // Z * M
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    for (int k = 0; k < razmerM; k++)
                    {
                        tempM[i, j] += ErgodF[i, k] * M[k, j];
                    }
                }
            }
            //(ZM)dg
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (i == j)
                    {
                        tempM2[i, j] = tempM[i, j];
                    }
                }
            }
            //E * (ZM)dg
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    for (int k = 0; k < razmerM; k++)
                    {
                        tempM3[i, j] += E[i, k] * tempM2[k, j];
                    }
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM2[i, j] = 0;
                }
            }
            //Z * M - E * (ZM)dg
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM2[i, j] = tempM[i, j] - tempM3[i, j];
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM[i, j] = 0;
                }
            }
            //2*(Z * M - E * (ZM)dg)
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    tempM[i, j] = 2 * tempM2[i, j];
                }
            }
            //Дисперсия времени первого достижения
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    W[i, j] = tempM1[i, j] + tempM[i, j];
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    W[i, j] = Math.Round(W[i, j], 2);
                }
            }
            return W;
        }
        //public static void Modeling(double[,] matrix, int razmer, int place)
        //{
           
        //    return;
        //}
    }
   
}
