namespace SystAnalys_lr1
{
    partial class Nepreriv
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableEnter = new System.Windows.Forms.DataGridView();
            this.buttonAdj = new System.Windows.Forms.Button();
            this.panelChangeR = new System.Windows.Forms.Panel();
            this.valueR = new System.Windows.Forms.NumericUpDown();
            this.btnChanR = new System.Windows.Forms.Button();
            this.lableR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьГрафToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьГрафКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курсорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВершинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьГрафToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.задатьРадиусВершиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборЦветаВершиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оеноВыводаРезультатовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нарисоватьВершинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нарисоватьДугуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПереходнуюМатрицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.произвестиРасчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectButton = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tableEnter)).BeginInit();
            this.panelChangeR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueR)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableEnter
            // 
            this.tableEnter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableEnter.Location = new System.Drawing.Point(4, 3);
            this.tableEnter.Name = "tableEnter";
            this.tableEnter.Size = new System.Drawing.Size(291, 461);
            this.tableEnter.TabIndex = 32;
            // 
            // buttonAdj
            // 
            this.buttonAdj.Location = new System.Drawing.Point(64, 470);
            this.buttonAdj.Name = "buttonAdj";
            this.buttonAdj.Size = new System.Drawing.Size(170, 28);
            this.buttonAdj.TabIndex = 29;
            this.buttonAdj.Text = "Создать матрицу переходов";
            this.buttonAdj.UseVisualStyleBackColor = true;
            this.buttonAdj.Click += new System.EventHandler(this.buttonAdj_Click);
            // 
            // panelChangeR
            // 
            this.panelChangeR.BackColor = System.Drawing.Color.Azure;
            this.panelChangeR.Controls.Add(this.valueR);
            this.panelChangeR.Controls.Add(this.btnChanR);
            this.panelChangeR.Controls.Add(this.lableR);
            this.panelChangeR.Controls.Add(this.label1);
            this.panelChangeR.Location = new System.Drawing.Point(18, 514);
            this.panelChangeR.Name = "panelChangeR";
            this.panelChangeR.Size = new System.Drawing.Size(257, 57);
            this.panelChangeR.TabIndex = 35;
            this.panelChangeR.Visible = false;
            // 
            // valueR
            // 
            this.valueR.Location = new System.Drawing.Point(40, 24);
            this.valueR.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.valueR.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.valueR.Name = "valueR";
            this.valueR.Size = new System.Drawing.Size(125, 20);
            this.valueR.TabIndex = 5;
            this.valueR.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnChanR
            // 
            this.btnChanR.Location = new System.Drawing.Point(171, 20);
            this.btnChanR.Name = "btnChanR";
            this.btnChanR.Size = new System.Drawing.Size(75, 23);
            this.btnChanR.TabIndex = 4;
            this.btnChanR.Text = "Изменить";
            this.btnChanR.UseVisualStyleBackColor = true;
            this.btnChanR.Click += new System.EventHandler(this.button1_Click);
            // 
            // lableR
            // 
            this.lableR.AutoSize = true;
            this.lableR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lableR.Location = new System.Drawing.Point(7, 20);
            this.lableR.Name = "lableR";
            this.lableR.Size = new System.Drawing.Size(27, 25);
            this.lableR.TabIndex = 1;
            this.lableR.Text = "R";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Радиус вершины";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.видToolStripMenuItem,
            this.инструментыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1061, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьГрафToolStripMenuItem,
            this.сохранитьГрафКакToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьГрафToolStripMenuItem
            // 
            this.открытьГрафToolStripMenuItem.Name = "открытьГрафToolStripMenuItem";
            this.открытьГрафToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.открытьГрафToolStripMenuItem.Text = "Открыть граф";
            this.открытьГрафToolStripMenuItem.Click += new System.EventHandler(this.открытьГрафToolStripMenuItem_Click);
            // 
            // сохранитьГрафКакToolStripMenuItem
            // 
            this.сохранитьГрафКакToolStripMenuItem.Name = "сохранитьГрафКакToolStripMenuItem";
            this.сохранитьГрафКакToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.сохранитьГрафКакToolStripMenuItem.Text = "Сохранить граф как...";
            this.сохранитьГрафКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьГрафКакToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.курсорToolStripMenuItem,
            this.удалитьВершинуToolStripMenuItem,
            this.удалитьГрафToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // курсорToolStripMenuItem
            // 
            this.курсорToolStripMenuItem.Name = "курсорToolStripMenuItem";
            this.курсорToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.курсорToolStripMenuItem.Text = "Курсор";
            // 
            // удалитьВершинуToolStripMenuItem
            // 
            this.удалитьВершинуToolStripMenuItem.Name = "удалитьВершинуToolStripMenuItem";
            this.удалитьВершинуToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.удалитьВершинуToolStripMenuItem.Text = "Удалить вершину";
            // 
            // удалитьГрафToolStripMenuItem
            // 
            this.удалитьГрафToolStripMenuItem.Name = "удалитьГрафToolStripMenuItem";
            this.удалитьГрафToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.удалитьГрафToolStripMenuItem.Text = "Удалить граф";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.задатьРадиусВершиныToolStripMenuItem,
            this.выборЦветаВершиныToolStripMenuItem,
            this.оеноВыводаРезультатовToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // задатьРадиусВершиныToolStripMenuItem
            // 
            this.задатьРадиусВершиныToolStripMenuItem.Name = "задатьРадиусВершиныToolStripMenuItem";
            this.задатьРадиусВершиныToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.задатьРадиусВершиныToolStripMenuItem.Text = "Задать радиус вершины";
            this.задатьРадиусВершиныToolStripMenuItem.Click += new System.EventHandler(this.задатьРадиусВершиныToolStripMenuItem_Click);
            // 
            // выборЦветаВершиныToolStripMenuItem
            // 
            this.выборЦветаВершиныToolStripMenuItem.Name = "выборЦветаВершиныToolStripMenuItem";
            this.выборЦветаВершиныToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.выборЦветаВершиныToolStripMenuItem.Text = "Выбор цвета вершины";
            // 
            // оеноВыводаРезультатовToolStripMenuItem
            // 
            this.оеноВыводаРезультатовToolStripMenuItem.Name = "оеноВыводаРезультатовToolStripMenuItem";
            this.оеноВыводаРезультатовToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.оеноВыводаРезультатовToolStripMenuItem.Text = "Окно вывода результатов";
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нарисоватьВершинуToolStripMenuItem,
            this.нарисоватьДугуToolStripMenuItem,
            this.создатьПереходнуюМатрицуToolStripMenuItem,
            this.произвестиРасчетыToolStripMenuItem});
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // нарисоватьВершинуToolStripMenuItem
            // 
            this.нарисоватьВершинуToolStripMenuItem.Name = "нарисоватьВершинуToolStripMenuItem";
            this.нарисоватьВершинуToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.нарисоватьВершинуToolStripMenuItem.Text = "Нарисовать вершину";
            // 
            // нарисоватьДугуToolStripMenuItem
            // 
            this.нарисоватьДугуToolStripMenuItem.Name = "нарисоватьДугуToolStripMenuItem";
            this.нарисоватьДугуToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.нарисоватьДугуToolStripMenuItem.Text = "Нарисовать дугу";
            // 
            // создатьПереходнуюМатрицуToolStripMenuItem
            // 
            this.создатьПереходнуюМатрицуToolStripMenuItem.Name = "создатьПереходнуюМатрицуToolStripMenuItem";
            this.создатьПереходнуюМатрицуToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.создатьПереходнуюМатрицуToolStripMenuItem.Text = "Создать переходную матрицу";
            this.создатьПереходнуюМатрицуToolStripMenuItem.Click += new System.EventHandler(this.buttonAdj_Click);
            // 
            // произвестиРасчетыToolStripMenuItem
            // 
            this.произвестиРасчетыToolStripMenuItem.Name = "произвестиРасчетыToolStripMenuItem";
            this.произвестиРасчетыToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.произвестиРасчетыToolStripMenuItem.Text = "Произвести расчеты";
            this.произвестиРасчетыToolStripMenuItem.Click += new System.EventHandler(this.произвестиРасчетыToolStripMenuItem_Click);
            // 
            // selectButton
            // 
            this.selectButton.Image = global::SystAnalys_lr1.Properties.Resources.cursor;
            this.selectButton.Location = new System.Drawing.Point(11, 166);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(45, 45);
            this.selectButton.TabIndex = 30;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Image = global::SystAnalys_lr1.Properties.Resources.deleteAll;
            this.deleteALLButton.Location = new System.Drawing.Point(11, 453);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(45, 45);
            this.deleteALLButton.TabIndex = 28;
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::SystAnalys_lr1.Properties.Resources.delete;
            this.deleteButton.Location = new System.Drawing.Point(11, 319);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(45, 45);
            this.deleteButton.TabIndex = 27;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.Image = global::SystAnalys_lr1.Properties.Resources.no_translate_detected_318_605902;
            this.drawEdgeButton.Location = new System.Drawing.Point(11, 268);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(45, 45);
            this.drawEdgeButton.TabIndex = 26;
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Image = global::SystAnalys_lr1.Properties.Resources.vertex;
            this.drawVertexButton.Location = new System.Drawing.Point(11, 217);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(45, 45);
            this.drawVertexButton.TabIndex = 25;
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Control;
            this.sheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheet.Location = new System.Drawing.Point(0, 24);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(1061, 907);
            this.sheet.TabIndex = 24;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            this.sheet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseDown);
            this.sheet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseMove);
            this.sheet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectButton);
            this.panel1.Controls.Add(this.drawVertexButton);
            this.panel1.Controls.Add(this.drawEdgeButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.deleteALLButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(62, 907);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.tableEnter);
            this.panel2.Controls.Add(this.buttonAdj);
            this.panel2.Controls.Add(this.panelChangeR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(763, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 907);
            this.panel2.TabIndex = 38;
            // 
            // Nepreriv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Nepreriv";
            this.Size = new System.Drawing.Size(1061, 931);
            ((System.ComponentModel.ISupportInitialize)(this.tableEnter)).EndInit();
            this.panelChangeR.ResumeLayout(false);
            this.panelChangeR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueR)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tableEnter;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button buttonAdj;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Panel panelChangeR;
        private System.Windows.Forms.Label lableR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьГрафToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГрафКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem задатьРадиусВершиныToolStripMenuItem;
        private System.Windows.Forms.Button btnChanR;
        private System.Windows.Forms.NumericUpDown valueR;
        private System.Windows.Forms.ToolStripMenuItem курсорToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВершинуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьГрафToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выборЦветаВершиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оеноВыводаРезультатовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нарисоватьВершинуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нарисоватьДугуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem произвестиРасчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПереходнуюМатрицуToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
