using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1
{
    class Vertex
    {
        public int x, y;

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Edge
    {
        public int v1, v2;

        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Pen whitePen;
        Graphics gr;
        Font fo;
        Brush br, bro;
        PointF point;
        //Point p1, p2;        
        public int R = 17; //радиус окружности вершины
        List<string> P = new List<string>();
        List<string> FileCoor = new List<string>();
        string[] str2;
        int q1=0, q2=0;
        public float index = 1.90F;

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            blackPen.CustomEndCap = new AdjustableArrowCap(R - 10, R - 10);
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            whitePen = new Pen(Color.White);
            whitePen.Width = 2;
            whitePen.CustomEndCap = new AdjustableArrowCap(R - 10, R - 10);
            darkGoldPen = new Pen(Color.LightSkyBlue);
            darkGoldPen.Width = 2;
            darkGoldPen.CustomEndCap = new AdjustableArrowCap(R-10, R-10);
            fo = new Font("Arial", (R-5));
            br = Brushes.Black;
            bro = Brushes.White;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void chanrM() 
        {
            if (R > 10)
            {
                R--;
                if(R < 12)
                {
                    index = 2;
                }
            }
            else 
            {
                MessageBox.Show("Минимально допустимый размер", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void chanrP()
        {
            if (R < 25)
            {
                R++;
                if (R > 12)
                {
                    index = 1.92F;
                }
            }
            else
            {
                MessageBox.Show("Максимально допустимый размер", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearSheet()
        {
            gr.Clear(Color.White);
            FileCoor.Clear();
            P.Clear();
        }
        public void clearSheetLoad()
        {
            gr.Clear(Color.White);
            FileCoor.Clear();            
        }

        public void clearOne()
        {
            gr.Clear(Color.White);
        }
        public void addP(List<string> listP)
        {
            for(int i=0; i<listP.Count; i++)
            {
                P.Add(listP[i]);
            }
        }

        public void drawVertex(int x, int y, string number)
        {
            blackPen.CustomEndCap = new AdjustableArrowCap(R - 10, R - 10);
            if (!FileCoor.Contains(x + " " + y + " " + " " + number))
            {
                for (int i = 0; i < FileCoor.Count; i++)
                {
                    string[] nums = FileCoor[i].Split(new char[] { ' ' });
                    if (nums[2] == number)
                    {
                        FileCoor.RemoveAt(i);
                    }
                }
                FileCoor.Add(x + " " + y + " " + number);
            }
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - R+9, y - R+9);  //цифры в центре вершин
            fo = new Font("Arial", R-5);
            gr.DrawString(number, fo, br, point);
        }

        public int countStr(string namefile)
        {
            str2 = System.IO.File.ReadAllLines(namefile);
            return str2.Length;
        }
        public int xInVertex()
        {
            string[] list = str2[q1].Split(new char[] { ' ' });
            int x = Convert.ToInt32(list[0]);
            q1++;
            return x;
        }
        public int yInVertex()
        {
            string[] list = str2[q2].Split(new char[] { ' ' });
            int y = Convert.ToInt32(list[1]);
            q2++;
            return y;
        }
        public void zeroQ()
        {
            q1 = 0;
            q2 = 0;
        }

        public void saveVertex()
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить как...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = "Text Files(*.TXT)|";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filename = savedialog.FileName;
                    System.IO.File.Delete(filename);
                    for (int i = 0; i < FileCoor.Count; i++)
                    {
                        System.IO.File.AppendAllText(filename, FileCoor[i] + "\r\n");
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else return;
        }

        public string[,] loadEg()
        {
            string[] countS = System.IO.File.ReadAllLines("Edge.TXT"); //кочество строк
            string[,] matrixEdge = new string[countS.Length, countS.Length];
            for(int i=0; i<countS.Length; i++)
            {
                string[] countElement = countS[i].Split(new char[] { ' ' });
                for (int j=0; j<countS.Length; j++)
                {
                    matrixEdge[i, j] = countElement[j];
                }
            }
            return matrixEdge;
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void DelWT(int i)
        {
            P.RemoveAt(i);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E)
        {
            fo = new Font("Arial", (R - 5));
            Request rq = new Request();
            if (E.v1 == E.v2)
            {
                rq.ShowDialog();
                string i = rq.wt.Text;
                if (!string.IsNullOrEmpty(i))
                {
                    gr.DrawArc(darkGoldPen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R)); //петля координаты                                              
                    P.Add(rq.wt.Text);
                    gr.DrawString(i, fo, br, point);
                }
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
            }
            else
            {
                rq.ShowDialog();
                string i = rq.wt.Text;//      добавить ебучек в if'ы для смещения координат
                if (!string.IsNullOrEmpty(i))
                {
                    if (V1.x > V2.x && V1.y > V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x + R, V2.y);
                    }
                    else if (V1.x > V2.x && V1.y < V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x + R, V2.y);
                    }
                    else if (V1.x < V2.x && V1.y > V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x - R, V2.y);
                    }
                    else if (V1.x < V2.x && V1.y < V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x - R, V2.y);
                    }
                    else if (V1.x == V2.x && V1.y > V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y);
                    }
                    else if (V1.x == V2.x && V1.y < V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y);
                    }
                    else if (V1.x > V2.x && V1.y == V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x + R, V2.y);
                    }
                    else if (V1.x < V2.x && V1.y == V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x - R, V2.y);
                    }
                    point = new PointF((V1.x + V2.x) / index, (V1.y + V2.y) / index); // координаты цифры на дуге
                    P.Add(rq.wt.Text);
                    gr.DrawString(i, fo, br, point); // ребро дуга                    
                    gr.DrawString(i, fo, br, point); // ребро дуга   
                }
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
            }
        }


        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                fo = new Font("Arial", (R - 5));
                if (E[i].v1 == E[i].v2)
                {
                    gr.DrawArc(darkGoldPen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R)); //петля                    
                    gr.DrawString(P[i], fo, br, point);
                }
                else
                {
                    if (V[E[i].v1].x > V[E[i].v2].x && V[E[i].v1].y > V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x + R, V[E[i].v2].y + 5);
                    }
                    else if (V[E[i].v1].x > V[E[i].v2].x && V[E[i].v1].y < V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x + R, V[E[i].v2].y - 5);
                    }
                    else if (V[E[i].v1].x < V[E[i].v2].x && V[E[i].v1].y > V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x - R, V[E[i].v2].y + 5);
                    }
                    else if (V[E[i].v1].x < V[E[i].v2].x && V[E[i].v1].y < V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x - R, V[E[i].v2].y - 5);
                    }
                    else if (V[E[i].v1].x == V[E[i].v2].x && V[E[i].v1].y > V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y + 5);
                    }
                    else if (V[E[i].v1].x == V[E[i].v2].x && V[E[i].v1].y < V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y - 5);
                    }
                    else if (V[E[i].v1].x > V[E[i].v2].x && V[E[i].v1].y == V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x + R, V[E[i].v2].y);
                    }
                    else if (V[E[i].v1].x > V[E[i].v2].x && V[E[i].v1].y == V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x - R, V[E[i].v2].y);
                    }
                    point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / index, (V[E[i].v1].y + V[E[i].v2].y) / index); // ребро дуга
                    gr.DrawString(P[i], fo, br, point);
                }
            }
            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, (i + 1).ToString());
            }
        }
        public void drawString (string st)
        {
            gr.Clear(Color.White);
            point = new PointF(60, 0); 
            gr.DrawString(st, fo, br, point);
        }

        //заполняет матрицу смежности
        public void fillAdjacencyMatrix(int numberV, List<Edge> E, float[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < numberV; j++)
                    matrix[i, j] = 0;

            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, E[i].v2] = float.Parse(P[i]);
            }

        }

        public void changeR (int r)
        {
            R = r;
        }

    }
}