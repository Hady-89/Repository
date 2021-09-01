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
    public partial class Nepreriv : UserControl
    {
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;

        float[,] AMatrix; //матрица смежности
        bool isClick = false;
        int selected1; //выбранные вершины, для соединения линиями
        int selected2;
        int numberV = -1;
        int delX = 0;
        int delY = 0;

        public Nepreriv()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edge>();
            sheet.Image = G.GetBitmap();
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            // G.clearSheet();
            // G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;

        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            // G.clearSheet();
            // G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            // G.clearSheet();
            // G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            // G.clearSheet();
            // G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet();
                sheet.Image = G.GetBitmap();
            }
        }

        //кнопка - матрица смежности
        private void buttonAdj_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                G.drawVertex(e.X, e.Y, V.Count.ToString());
                sheet.Image = G.GetBitmap();
            }
            //если нажата кнопка "рисовать ребро"
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2));
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1]);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }
            //если нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                // ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].v1 == E[i].v2) //если это петля
                        {
                            if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                G.DelWT(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    G.DelWT(i);
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    G.clearOne();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        //создание матрицы смежности и вывод в datagrid
        private void createAdjAndOut()
        {
            AMatrix = new float[V.Count, V.Count];
            G.fillAdjacencyMatrix(V.Count, E, AMatrix);
            int col = 0;
            int row = 0;
            bool error = false;
            for (int i = 0; i < AMatrix.GetLength(0); i++)
            {
                row = 0; col = 0;
                for (int j = 0; j < AMatrix.GetLength(0); j++)
                {
                    if (AMatrix[i, j] != 0)
                    {
                        row++;
                    }
                    if (AMatrix[j, i] != 0)
                    {
                        col++;
                    }
                }
                if (row == 0 && col == 0)
                {
                    error = true;
                    break;
                }
            }
            if (error == false)
            {
                tableEnter.Rows.Clear();
                tableEnter.Columns.Clear();

                for (int i = 1; i <= V.Count; i++)
                {
                    var colum = new DataGridViewColumn();
                    colum.HeaderText = i.ToString();
                    colum.Width = 50;
                    colum.CellTemplate = new DataGridViewTextBoxCell();
                    tableEnter.Columns.Add(colum);
                }

                tableEnter.Rows.Add(V.Count - 1);
                for (int i = 0; i < V.Count; i++)
                {
                    tableEnter.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    for (int j = 0; j < V.Count; j++)
                    {
                        tableEnter[j, i].Value = AMatrix[i, j];
                    }
                }
            }
            else
            {
                MessageBox.Show("Граф составлен некорректно");
            }
        }

        //О программе
        private void about_Click(object sender, EventArgs e)
        {
            aboutForm FormAbout = new aboutForm();
            FormAbout.ShowDialog();
        }

        private void sheet_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectButton.Enabled == false)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        isClick = true;
                        delX = e.X - V[i].x;
                        delY = e.Y - V[i].y;
                        numberV = i;
                    }
                }
            }
        }

        private void sheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectButton.Enabled == false)
            {
                if (isClick)
                {
                    V[numberV].x = e.X - delX;
                    V[numberV].y = e.Y - delY;
                    G.clearOne();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        private void sheet_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectButton.Enabled == false)
            {
                isClick = false;
                numberV = -1;
            }
        }

        public void SaveEg()
        {
            System.IO.File.Delete("Edge.txt");
            string strAMatrix = string.Empty;
            for (int i = 0; i < AMatrix.GetLength(0); i++)
            {
                strAMatrix = string.Empty;
                for (int j = 0; j < AMatrix.GetLength(1); j++)
                {
                    strAMatrix += AMatrix[i, j] + " ";
                }
                System.IO.File.AppendAllText("Edge.TXT", strAMatrix + "\r\n");
            }
            MessageBox.Show("Файл успешно сохранен");

        }

        private void задатьРадиусВершиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelChangeR.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            G.clearSheetLoad();
            G.changeR(Convert.ToInt32(valueR.Value));
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        public double[,] SLAY()
        {
            double[,] matrixSLAY = new double[V.Count, V.Count];
            double exit;
            for (int i = 0; i < V.Count; i++)
            {
                exit = 0;
                for (int j = 0; j < V.Count; j++)
                {
                    if (i != V.Count - 1)
                    {
                        if (AMatrix[i, j] > 0)
                        {
                            exit += AMatrix[i, j];
                        }
                        if (i != j)
                        {
                            matrixSLAY[i, j] = AMatrix[j, i];
                        }
                    }
                    else
                    {
                        matrixSLAY[i, j] = 1;
                    }
                }
                if (exit != 0)
                {
                    matrixSLAY[i, i] = -exit;
                }
            }
            return matrixSLAY;
        }


        public static double[,] Minor(double[,] MassA, int row, int column)// минор
        {

            double[,] buf = new double[MassA.GetLength(0) - 1, MassA.GetLength(0) - 1];
            for (int i = 0; i < MassA.GetLength(0); i++)
                for (int j = 0; j < MassA.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) buf[i - 1, j] = MassA[i, j];
                        if (i < row && j > column) buf[i, j - 1] = MassA[i, j];
                        if (i > row && j > column) buf[i - 1, j - 1] = MassA[i, j];
                        if (i < row && j < column) buf[i, j] = MassA[i, j];
                    }
                }
            return buf;
        }
        //---------------------------------------------------------------
        public static double Determ(double[,] MassA)// детерминант
        {

            double det = 0;
            int Rank = MassA.GetLength(1);
            if (Rank == 1) det = MassA[0, 0];
            if (Rank == 2) det = MassA[0, 0] * MassA[1, 1] - MassA[0, 1] * MassA[1, 0];
            if (Rank > 2)
            {
                for (int j = 0; j < MassA.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * MassA[0, j] * Determ(Minor(MassA, 0, j));
                }
            }
            return det;
        }
        //------------------------------------------------------------------------
        public static double[,] Algdop(double[,] MassA)//алгебраическое дополнение
        {

            double[,] dop = new double[MassA.GetLength(0), MassA.GetLength(0)];
            for (int i = 0; i < MassA.GetLength(0); i++)
                for (int j = 0; j < MassA.GetLength(1); j++)
                {
                    dop[i, j] = Math.Pow(-1, (i + 1) + (j + 1)) * Determ(Minor(MassA, i, j));
                }
            return dop;
        }
        //----------------------------------------------------------------
        public static double[,] Obrmatr(double[,] MassA)//обратная матрица
        {

            double[,] obr = new double[MassA.GetLength(0), MassA.GetLength(0)];
            for (int i = 0; i < MassA.GetLength(0); i++)
                for (int j = 0; j < MassA.GetLength(1); j++)
                {
                    obr[i, j] = Algdop(MassA)[i, j] / Determ(MassA);
                }
            return obr;
        }

        private void произвестиРасчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] MassA = SLAY();
            double[,] Obr = new double[V.Count, V.Count];
            double[] slau = new double[V.Count];
            double[] b = new double[V.Count];
            b[V.Count - 1] = 1;
            for (int i = 0; i < V.Count; i++)
            {
                for (int j = 0; j < V.Count; j++)
                {
                    Obr[i, j] = Obrmatr(MassA)[i, j];
                }
            }
            for (int j = 0; j < V.Count; j++)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    slau[j] += Obr[i, j] * b[i];
                }
            }
            string str = string.Empty;
            for (int j = 0; j < V.Count; j++)
            {
                slau[j] = Math.Round(slau[j], 3);
                str += "p" + (j+1) + "=" + slau[j] + "\r\n";
            }
            G.drawString(str);
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        private void открытьГрафToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V.Clear();
            E.Clear();
            G.clearSheetLoad();
            List<string> forP = new List<string>();
            string filename = string.Empty;
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Title = "Открыть...";
            opendialog.CheckPathExists = true;
            opendialog.Filter = "Text Files(*.TXT)|";
            opendialog.ShowHelp = true;
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = opendialog.FileName;
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так при открытии файла", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                for (int i = 0; i < G.countStr(filename); i++)
                {
                    int kx = G.xInVertex();
                    int ky = G.yInVertex();
                    V.Add(new Vertex(kx, ky));
                }
                G.zeroQ();
                string[,] matrixE = G.loadEg();
                for (int i = 0; i < matrixE.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixE.GetLength(0); j++)
                    {
                        if (double.TryParse(matrixE[i, j], out double p) && p > 0)
                        {
                            forP.Add(matrixE[i, j]);
                            E.Add(new Edge(i, j));
                        }
                    }
                }
                G.addP(forP);
                G.drawALLGraph(V, E);
                sheet.Image = G.GetBitmap();
            }
            else return;
        }

        private void сохранитьГрафКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete("Edge.txt");
            G.saveVertex();
            SaveEg();
        }
    }
}
