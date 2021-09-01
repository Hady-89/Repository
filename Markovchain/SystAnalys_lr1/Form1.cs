using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SystAnalys_lr1
{
    public partial class Form1 : Form
    {
     

        public Form1()
        {
            InitializeComponent();
            
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {

        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
           
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
           
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            
        }

        //кнопка - матрица смежности
        private void buttonAdj_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {

}

//создание матрицы смежности и вывод в datagrid
private void createAdjAndOut()
{
   
}



private void saveButton_Click(object sender, EventArgs e)
{
   
}

private void sheet_MouseDown(object sender, MouseEventArgs e)
{
  
}

private void sheet_MouseMove(object sender, MouseEventArgs e)
{
    
}

private void sheet_MouseUp(object sender, MouseEventArgs e)
{           

}
    //О программе
    private void about_Click(object sender, EventArgs e)
    {
        aboutForm FormAbout = new aboutForm();
        FormAbout.ShowDialog();
    }

    private void дискретныеЦМToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discret1.BringToFront();
        }

        private void непрерывныеЦМToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nepreriv1.BringToFront();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void начальнаяСтраницаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start1.BringToFront();
            panelstart.BringToFront();
        }

        private void startB_Click(object sender, EventArgs e)
        {
            if (discretB.Checked == true && neperivB.Checked == false)
            {
                discret1.BringToFront();
            }
            else if (discretB.Checked == false && neperivB.Checked == true) 
            {
                nepreriv1.BringToFront();
            }
        }
    }
}
