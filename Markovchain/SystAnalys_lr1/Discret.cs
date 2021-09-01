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
    public partial class Discret: UserControl
    {
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;

       public float[,] AMatrix; //матрица смежности
        bool isClick = false;
        int selected1; //выбранные вершины, для соединения линиями
        int selected2;
        int numberV = -1;
        int delX = 0;
        int delY = 0;
        int win = 0;
        int mis;
        bool check = false;
        double a;
        double clone;
        int grstep;
        double[,] graphics;
        public Discret()
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
            if (V.Count < 2)
            {
                MessageBox.Show("Постройте цепь." + " " + "Для создания матрицы переходов небходимо построить минимум 2 вершины.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                createAdjAndOut();
                label1.Visible = true;
                tableEnter.Visible = true;
                POGLpanel.Visible = false;
                ERGpanel.Visible = false;
                markovbutton.Enabled = true;
                modelingbutton.Enabled = true;
                float summ;
                mis = 0;
                for (int i = 0; i < V.Count; i++)
                {
                    summ = 0;
                    for (int j = 0; j < V.Count; j++)
                    {
                        summ += AMatrix[i, j];
                        mis = i + 1;

                    }
                    if (summ != 1)
                    {
                        tableEnter.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        MessageBox.Show("Ошибка в строке:" + " " + mis.ToString() + "." + " " + "Сумма значений в строке не должа превышать единицу!" + " " + "Для дальнейших вычислений исправте ошибку!" , " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        button8.Enabled = false;
                        button9.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                    }
                }
                //if (check == true) 
                //{
                //    
                //}
                int sch = 0;
                for (int i = 0; i < V.Count; i++)
                {
                    for (int j = 0; j < V.Count; j++)
                    {
                        if (AMatrix[i, j] == 1)
                        {
                             sch++;
                        }

                    }
                }
                if (sch > 0)
                {
                    POGLpanel.Visible = true;
                }
                else
                {
                    ERGpanel.Visible = true;
                }
            }
           
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //если нажата кнопка "выбрать вершину", ищем степень вершины
            if (selectButton.Enabled == false)
            {
                /* for (int i = 0; i < V.Count; i++)
                 {
                     if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                     {
                         if (isClick)
                         {
                             G.drawVertex(e.X, e.Y, V[i].ToString());
                             sheet.Image = G.GetBitmap();
                             //V[i].x = e.X - V[i].x;
                             // V[i].y = e.Y - V[i].y;
                         }

                     }
                 }*/
            }
            // если нажата кнопка "рисовать вершину"
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
            button8.Enabled = true;
            button9.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            for (int i = 0; i < V.Count; i++)
            {
                tableEnter.Rows[i].HeaderCell.Value = (i + 1).ToString();
                for (int j = 0; j < V.Count; j++)
                {
                    tableEnter[j, i].Value = AMatrix[i, j];
                }
            }
            
        }

        //О программе
        private void about_Click(object sender, EventArgs e)
        {
            aboutForm FormAbout = new aboutForm();
            FormAbout.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (sheet.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sheet.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void sheet_MouseDown(object sender, MouseEventArgs e)
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

        private void sheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClick)
            {
                V[numberV].x = e.X - delX;
                V[numberV].y = e.Y - delY;
                G.clearOne();
                G.drawVertex(V[numberV].x, V[numberV].y, (numberV + 1).ToString());
                G.drawALLGraph(V, E);
                sheet.Image = G.GetBitmap();
            }
        }

        private void sheet_MouseUp(object sender, MouseEventArgs e)
        {
            isClick = false;
            numberV = -1;
        }

        private void удалитьМатрицуПереходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableEnter.Rows.Clear();
            tableEnter.Columns.Clear();
            ERGFGridView.Rows.Clear();
            ERGFGridView.Columns.Clear();
            ERGTIMEGridView.Rows.Clear();
            ERGTIMEGridView.Columns.Clear();
            ERGTDISGridView.Rows.Clear();
            ERGTDISGridView.Columns.Clear();
            POGLFGridView.Rows.Clear();
            POGLFGridView.Columns.Clear();
            POGLTIMEGridView.Rows.Clear();
            ERGFGridView.Visible = false;
            ERGFGridView.Visible = false;
            ERGTIMEGridView.Visible = false;
            ERGTIMEGridView.Visible = false;
            ERGTDISGridView.Visible = false;
            ERGTDISGridView.Visible = false;
            POGLFGridView.Visible = false;
            POGLFGridView.Visible = false;
            POGLTIMEGridView.Visible = false;
        }
        
        
       
        
        private void button2_Click(object sender, EventArgs e)
        {
            G.chanrM();
            textBox1.Text = G.R.ToString();
            G.clearOne();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }
       private void button5_Click(object sender, EventArgs e)
       {
            G.chanrP();
            textBox1.Text = G.R.ToString();
            G.clearOne();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ERGFGridView.Visible = true;
            FundamL.Visible = true;
            POGLFGridView.Visible = false;
            int razmerM = V.Count;
            ERGFGridView.RowCount = razmerM;
            ERGFGridView.ColumnCount = razmerM;
            ERGTIMEGridView.RowCount = razmerM;
            ERGTIMEGridView.ColumnCount = razmerM;
            ERGTDISGridView.RowCount = razmerM;
            ERGTDISGridView.ColumnCount = razmerM;
            double[,] MassA = new double[razmerM, razmerM];
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassA[i, j] = AMatrix[i, j];
                }
            }
            double[,] ErgodF = MathChains.FundMatrixE(MassA, razmerM);
            for (int i = 0; i < ERGFGridView.RowCount; i++)
            {
                for (int j = 0; j < ERGFGridView.ColumnCount; j++)
                {
                    ERGFGridView[j, i].Value = ErgodF[i, j];
                }
            }
            double[,] M = MathChains.ErgtimeMatrix(MassA, ErgodF, razmerM);
            for (int i = 0; i < ERGTIMEGridView.RowCount; i++)
            {
                for (int j = 0; j < ERGTIMEGridView.ColumnCount; j++)
                {
                    ERGTIMEGridView[j, i].Value = M[i, j];
                }
            }
            double[,] W = MathChains.DisErgtimeMatrix(MassA, ErgodF, M, razmerM);
            for (int i = 0; i < ERGTDISGridView.RowCount; i++)
            {
                for (int j = 0; j < ERGTDISGridView.ColumnCount; j++)
                {
                    ERGTDISGridView[j, i].Value = W[i, j];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ERGTIMEGridView.Visible = true;
            ErgTL.Visible = true;
            POGLTIMEGridView.Visible = false;
            PoglTL.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ERGTDISGridView.Visible = true;
            ErgTDL.Visible = true;
            POGLTIMEGridView.Visible = false;
            PoglTL.Visible = false;
        }

      

            //private void button6_Click(object sender, EventArgs e)
            //{
          
            // OpenFileDialog ldialog = new OpenFileDialog();
            //    ldialog.Title = "Загрузить модель";
            //    ldialog.CheckPathExists = true;
            //    ldialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            //    ldialog.ShowHelp = true;
            //    if (ldialog.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //        pictureBox1.Image = new Bitmap(ldialog.FileName);
            //        }
            //        catch
            //        {
            //            MessageBox.Show("Невозможно загрузить файл ", "Ошибка",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}

        //private void button7_Click(object sender, EventArgs e)
        //{
           
        //}

        public void button8_Click(object sender, EventArgs e)
        {
            ERGFGridView.Visible = false;
            FundamL.Visible = true;
            POGLFGridView.Visible = true;
            int razmerM = V.Count;
            double[,] MassA = new double[razmerM, razmerM];
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassA[i, j] = AMatrix[i, j];
                }
            }
            int Onecount1 = 0;
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    if (MassA[i, j] == 1)
                    {
                        Onecount1++;
                    }

                }

            }
            int minirazmer = V.Count - Onecount1;
            POGLFGridView.RowCount = minirazmer;
            POGLFGridView.ColumnCount = minirazmer;
            POGLTIMEGridView.RowCount = minirazmer;
            double[,] PoglF = MathChains.FundMatrixP(MassA, razmerM);
            for (int i = 0; i < POGLFGridView.RowCount; i++)
            {
                for (int j = 0; j < POGLFGridView.ColumnCount; j++)
                {
                    POGLFGridView[j, i].Value = PoglF[i, j];
                }
            }
            double big = 0;
            double[] Tm = MathChains.PogtimeMatrix(PoglF, minirazmer);
            for (int j = 0; j < POGLFGridView.ColumnCount; j++)
            {
                if (big < Tm[j])
                {
                    big = Tm[j];
                    win = j + 1;
                }
                
                
            }
            for (int i = 0; i < POGLTIMEGridView.RowCount; i++)
            {
                POGLTIMEGridView.Rows[i].Cells[0].Value = Tm[i];
            } 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            POGLTIMEGridView.Visible = true;
            PoglTL.Visible = true;
            ERGTIMEGridView.Visible = false;
            ErgTL.Visible = false;
            ERGTDISGridView.Visible = false;
            ErgTDL.Visible = false;
            POGLTIMEGridView.Rows[win - 1].DefaultCellStyle.BackColor = Color.Yellow;
            MessageBox.Show("Поглощающее состояние быстрее достичь из" + " " + win.ToString() + " " + "состояния", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void изменитьРазмерВершинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
                textBox1.Text = G.R.ToString();
                
            }
            else 
            {
                panel2.Visible = false;
                
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
        private void сохранитьГрафКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete("Edge.txt");
            G.saveVertex();
            SaveEg();
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

       

        private void button7_Click(object sender, EventArgs e)
        {
            modelingGrid.Rows.Clear();
            modelingGrid.Columns.Clear();
            modelingGrid1.Rows.Clear();
            modelingGrid1.Columns.Clear();
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            
            int razmerM = V.Count;
            double[,] MassA = new double[razmerM, razmerM];
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassA[i, j] = AMatrix[i, j];
                }
            }
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassA[i, j] = Math.Round(MassA[i, j], 1);
                }
            }
            List<int> vertex = new List<int>();
            List<int> oldvertex = new List<int>();
            List<double> weight = new List<double>();
            List<int> stepgrid = new List<int>();
            List<int> clon = new List<int>();
            List<double> tempweight = new List<double>();
            List<double> rndW = new List<double>();
            List<int> numberV = new List<int>();
            List<int> N = new List<int>();
            List<double> P = new List<double>();
            List<int> Counts = new List<int>();
            Random random = new Random();
            
            double tempCur = 0;
            bool oldsh;
            bool newsh = true;
            bool tempsh;
            bool clonn;
            int steps = Convert.ToInt32(textBox3.Text);
            int step = 0;
            int n = Convert.ToInt32(textBox2.Text) - 1;
            int p = 0;
            double[,] graph = new double[steps, razmerM];

            for (int j = 0; j < razmerM; j++)
            {
                numberV.Add(j + 1);
                N.Add(0);
                P.Add(0);
                Counts.Add(0);
                clon.Add(0);
            }
            for (int i = n; i < razmerM; i = n)
            {
                if (newsh == false)
                {
                    vertex.Add(n + 1);
                    weight.Add(tempCur);
                    step++;
                    stepgrid.Add(step);
                    newsh = true;
                }
                if (step == steps)
                {
                    p = razmerM;
                    n = razmerM;
                }
                tempCur = 1;
                oldsh = false;
                tempsh = false;
                clonn = true;
                tempweight.Clear();
                for (int j = p; j < razmerM; j++)
                {
                    if (tempsh == false)
                    {
                        tempsh = true;
                        a = random.NextDouble();
                        a = Math.Round(a, 2);
                        rndW.Add(a);


                        for (int t = 0; t < razmerM; t++)
                        {
                            tempweight.Add(MassA[i, t]);
                        }
                        for (int t = 0; t < clon.Count(); t++)
                        {
                            for (int r = 0; r < clon.Count(); r++)
                            {
                                if (tempweight[t] == tempweight[r] && tempweight[t] != 0 && t != r)
                                {
                                    clon[r] = r + 1;
                                    clone = tempweight[r];
                                }
                            }
                        }
                        if (clon.Sum() > 0) 
                        {
                            for (int t = 0; t < clon.Count(); t++)
                            {
                                if (clon[t] == 0)
                                {
                                    clon.RemoveAt(t);
                                }

                            }
                        }
                     
                    }

                    if (oldsh == false)
                    {
                        oldvertex.Add(i + 1);
                        Counts[i]++;
                        if (step == 0)
                        {
                            int zerostep = step + 1;
                            float countemp = Counts[i];
                            P[i] = countemp / zerostep;
                            graph[step, i] = P[i];
                        }
                        else
                        {
                            float countemp = Counts[i];
                            P[i] = countemp / (step + 1);
                            graph[step, i] = P[i];
                        }
                        oldsh = true;
                        newsh = false;
                    }
                    if (MassA[i, j] == 1 && i == j)
                    {
                        MessageBox.Show("Достигнуто поглощающее состояние за" + " " + (step + 1).ToString() + " " + "шагов", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        stepgrid.Add(step + 1);
                        newsh = true;
                        step = steps;
                        weight.Add(MassA[i, j]);
                        vertex.Add(j + 1);
                    }
                    else if (tempweight[j] != 0)
                    {
                        if (clon.Count() > 0 && tempweight[j] == clone)
                        {
                            if (a <= clone && clonn == true)
                            {
                                clonn = false;
                                tempCur = tempweight[j];
                                n = j;
                            }
                            else if (a >= clone && a <= (clone * 2))
                            {
                                clonn = false;
                                tempCur = tempweight[j];
                                n = j;
                            }
                            //else if (a >= clone && (clone * (clon.Count() - 1)) < a && a <= clone * (clon.Count()))
                            //{
                            //    clonn = false;
                            //    tempCur = tempweight[j];
                            //    n = j;
                            //}
                        }
                        else if (tempweight[j] == tempweight.Max() && a >= tempweight.Max() && clonn == true)
                        {
                            tempCur = tempweight.Max();
                            n = j;
                        }

                        else if (a <= tempweight[j] && tempweight[j] < tempCur && clonn == true)
                        {
                            tempCur = tempweight[j];
                            n = j;
                        }
                        else if (tempweight[j] == 1 && clonn == true)
                        {
                            tempCur = tempweight[j];
                            n = j;
                        }
                    }


                }
            }
            double[,] MassBUF = new double[razmerM, razmerM];
            double[] slau = new double[razmerM];
            double[] Bm = new double[razmerM];
            for (int i = 0; i < razmerM; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    MassBUF[i, j] = MassA[j, i];
                }
            }
            //---------------------------------Вычитаем единицу по строкам
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
            //---------------------------------Заменяем последнюю строку единицей
            for (int j = 0; j < razmerM; j++)
            {
                MassBUF[razmerM - 1, j] = 1;
            }

            Bm[razmerM - 1] = 1;
            double[,] Am = MathChains.ObMatrix(MassBUF);

            //---------------------------------Вектор решения СЛАУ - Матрица финальных вероятностей
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
                slau[i] = Math.Round(slau[i], 4);
            }
            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j < razmerM; j++)
                {
                    graph[i, j] = Math.Round(graph[i, j], 4);

                }
            }
            graphics = graph;
            grstep = steps;
            int[] ovM = oldvertex.ToArray();
            int[] vM = vertex.ToArray();
            double[] wM = weight.ToArray();
            double[] rwM = rndW.ToArray();
            int[] stM = stepgrid.ToArray();
            int[] number = numberV.ToArray();
            //int[] Ns = N.ToArray();
            double[] Ps = P.ToArray();
            int[] Countss = Counts.ToArray();
            for (int i = 0; i < Ps.GetLength(0); i++)
            {
                Ps[i] = Math.Round(Ps[i], 4);
            }
            
            modelingGrid.RowCount = ovM.GetLength(0);
            modelingGrid.ColumnCount = 5;
            modelingGrid1.RowCount = number.GetLength(0);
            modelingGrid1.ColumnCount = 4;
            for (int i = 0; i < ovM.GetLength(0); i++)
            {
                modelingGrid.Rows[i].Cells[0].Value = stM[i];
                modelingGrid.Rows[i].Cells[1].Value = ovM[i];
                modelingGrid.Rows[i].Cells[2].Value = vM[i];
                modelingGrid.Rows[i].Cells[3].Value = wM[i];
                modelingGrid.Rows[i].Cells[4].Value = rwM[i];

            }
            for (int i = 0; i < number.GetLength(0); i++)
            {
                modelingGrid1.Rows[i].Cells[0].Value = number[i];
                //modelingGrid1.Rows[i].Cells[1].Value = Ns[i];
                modelingGrid1.Rows[i].Cells[2].Value = Ps[i];
                modelingGrid1.Rows[i].Cells[1].Value = Countss[i];
                modelingGrid1.Rows[i].Cells[3].Value = slau[i];

            }
        }

        private void markovbutton_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            else 
            {
                panel4.Visible = true;
                panel3.Visible = false;
            }
           
        }

        private void modelingbutton_Click(object sender, EventArgs e)
        {
            //panel3.Visible = true;
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (paneldraw.Visible == false)
            {
                paneldraw.Visible = true;
                sheet.Visible = false;
            }
            else 
            {
                paneldraw.Visible = false;
                sheet.Visible = true;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (sheet.Visible == false)
            {
                paneldraw.Visible = false;
                sheet.Visible = true;
            }
            else
            {
                paneldraw.Visible = true;
                sheet.Visible = false;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            int error = Convert.ToInt32(textBox4.Text);
            if (error > V.Count)
            {
                MessageBox.Show("Количетсво состояний = " + " " + V.Count + "." + " " + "Введите корректный номер состояния!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                int c = Convert.ToInt32(textBox4.Text) - 1;
                chart.Series[0].Points.Clear();
                if (checkBox.Checked)
                {
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                }
                else 
                {
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                
                chart.Series[0].Color = Color.Red;
                for (int i = 0; i < grstep; i++)
                {
                    if (graphics[i, c] != 0)
                    {
                        double temp = graphics[i, c];
                        chart.Series[0].Points.AddXY(i, temp);
                    }

                }
            }
            
        }

       
    }
    
}
