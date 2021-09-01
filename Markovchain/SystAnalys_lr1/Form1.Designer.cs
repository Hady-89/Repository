namespace SystAnalys_lr1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дискретныеЦМToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.непрерывныеЦМToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начальнаяСтраницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.hult = new System.Windows.Forms.ToolTip(this.components);
            this.discret1 = new SystAnalys_lr1.Discret();
            this.nepreriv1 = new SystAnalys_lr1.Nepreriv();
            this.start1 = new SystAnalys_lr1.Start();
            this.panelstart = new System.Windows.Forms.Panel();
            this.startB = new System.Windows.Forms.Button();
            this.neperivB = new System.Windows.Forms.RadioButton();
            this.discretB = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.panelstart.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Azure;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.about});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1830, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.начальнаяСтраницаToolStripMenuItem});
            this.менюToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.менюToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.BackColor = System.Drawing.Color.SlateGray;
            this.создатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дискретныеЦМToolStripMenuItem,
            this.непрерывныеЦМToolStripMenuItem});
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // дискретныеЦМToolStripMenuItem
            // 
            this.дискретныеЦМToolStripMenuItem.BackColor = System.Drawing.Color.SlateGray;
            this.дискретныеЦМToolStripMenuItem.Name = "дискретныеЦМToolStripMenuItem";
            this.дискретныеЦМToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.дискретныеЦМToolStripMenuItem.Text = "Дискретные ЦМ";
            this.дискретныеЦМToolStripMenuItem.Click += new System.EventHandler(this.дискретныеЦМToolStripMenuItem_Click);
            // 
            // непрерывныеЦМToolStripMenuItem
            // 
            this.непрерывныеЦМToolStripMenuItem.BackColor = System.Drawing.Color.SlateGray;
            this.непрерывныеЦМToolStripMenuItem.Name = "непрерывныеЦМToolStripMenuItem";
            this.непрерывныеЦМToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.непрерывныеЦМToolStripMenuItem.Text = "Непрерывные ЦМ";
            this.непрерывныеЦМToolStripMenuItem.Click += new System.EventHandler(this.непрерывныеЦМToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.BackColor = System.Drawing.Color.SlateGray;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // начальнаяСтраницаToolStripMenuItem
            // 
            this.начальнаяСтраницаToolStripMenuItem.BackColor = System.Drawing.Color.SlateGray;
            this.начальнаяСтраницаToolStripMenuItem.Name = "начальнаяСтраницаToolStripMenuItem";
            this.начальнаяСтраницаToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.начальнаяСтраницаToolStripMenuItem.Text = "Начальная страница";
            this.начальнаяСтраницаToolStripMenuItem.Click += new System.EventHandler(this.начальнаяСтраницаToolStripMenuItem_Click);
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(65, 20);
            this.about.Text = "Справка";
            this.about.ToolTipText = "Справка это святое";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // hult
            // 
            this.hult.AutomaticDelay = 5000;
            this.hult.AutoPopDelay = 50000;
            this.hult.InitialDelay = 50000;
            this.hult.ReshowDelay = 10000;
            this.hult.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // discret1
            // 
            this.discret1.BackColor = System.Drawing.Color.SlateGray;
            this.discret1.Location = new System.Drawing.Point(0, 27);
            this.discret1.Name = "discret1";
            this.discret1.Size = new System.Drawing.Size(1830, 1035);
            this.discret1.TabIndex = 17;
            // 
            // nepreriv1
            // 
            this.nepreriv1.AutoScroll = true;
            this.nepreriv1.AutoSize = true;
            this.nepreriv1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.nepreriv1.BackColor = System.Drawing.Color.LightBlue;
            this.nepreriv1.Location = new System.Drawing.Point(0, 27);
            this.nepreriv1.Name = "nepreriv1";
            this.nepreriv1.Size = new System.Drawing.Size(1356, 930);
            this.nepreriv1.TabIndex = 18;
            // 
            // start1
            // 
            this.start1.BackColor = System.Drawing.Color.SlateGray;
            this.start1.Location = new System.Drawing.Point(0, 27);
            this.start1.Name = "start1";
            this.start1.Size = new System.Drawing.Size(1830, 1035);
            this.start1.TabIndex = 19;
            // 
            // panelstart
            // 
            this.panelstart.BackColor = System.Drawing.Color.Transparent;
            this.panelstart.Controls.Add(this.startB);
            this.panelstart.Controls.Add(this.neperivB);
            this.panelstart.Controls.Add(this.discretB);
            this.panelstart.Location = new System.Drawing.Point(666, 362);
            this.panelstart.Name = "panelstart";
            this.panelstart.Size = new System.Drawing.Size(447, 118);
            this.panelstart.TabIndex = 20;
            // 
            // startB
            // 
            this.startB.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.startB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startB.ForeColor = System.Drawing.SystemColors.Info;
            this.startB.Location = new System.Drawing.Point(157, 65);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(132, 41);
            this.startB.TabIndex = 8;
            this.startB.Text = "Начало работы";
            this.startB.UseVisualStyleBackColor = false;
            this.startB.Click += new System.EventHandler(this.startB_Click);
            // 
            // neperivB
            // 
            this.neperivB.AutoSize = true;
            this.neperivB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.neperivB.Location = new System.Drawing.Point(48, 35);
            this.neperivB.Name = "neperivB";
            this.neperivB.Size = new System.Drawing.Size(337, 24);
            this.neperivB.TabIndex = 7;
            this.neperivB.Text = "Цепи Маркова с непрерывным временем";
            this.neperivB.UseVisualStyleBackColor = true;
            // 
            // discretB
            // 
            this.discretB.AutoSize = true;
            this.discretB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discretB.Location = new System.Drawing.Point(48, 5);
            this.discretB.Name = "discretB";
            this.discretB.Size = new System.Drawing.Size(326, 24);
            this.discretB.TabIndex = 6;
            this.discretB.Text = "Цепи Маркова с дискретным временем";
            this.discretB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1830, 1061);
            this.Controls.Add(this.panelstart);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.start1);
            this.Controls.Add(this.discret1);
            this.Controls.Add(this.nepreriv1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Цепи Маркова";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelstart.ResumeLayout(false);
            this.panelstart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolTip hult;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дискретныеЦМToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem непрерывныеЦМToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начальнаяСтраницаToolStripMenuItem;
        private Discret discret1;
        private Nepreriv nepreriv1;
        private Start start1;
        private System.Windows.Forms.Panel panelstart;
        private System.Windows.Forms.Button startB;
        private System.Windows.Forms.RadioButton neperivB;
        private System.Windows.Forms.RadioButton discretB;
    }
}

