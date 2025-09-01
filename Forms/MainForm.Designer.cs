namespace Forms // Ensure this namespace matches your project
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnStartPause = new System.Windows.Forms.ToolStripButton();
            this.btnStep = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.lbtimerInterval = new System.Windows.Forms.ToolStripLabel();
            this.valueTimerInterval = new System.Windows.Forms.ToolStripTextBox();
            this.bntClear = new System.Windows.Forms.ToolStripButton();
            this.tsddbGenomeBrush = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiPresetClassic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPresetRed = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPresetGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPresetBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiGene0 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGene1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGene2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGene3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGene4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGene5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGene6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGene7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGene8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.btnBactToMenu = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxGame = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbGeneration = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbCursorCords = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartPause,
            this.btnStep,
            this.btnSave,
            this.btnLoad,
            this.lbtimerInterval,
            this.valueTimerInterval,
            this.bntClear,
            this.tsddbGenomeBrush,
            this.toolStripBtnAbout,
            this.btnBactToMenu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1336, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnStartPause
            // 
            this.btnStartPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStartPause.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnStartPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(66, 29);
            this.btnStartPause.Text = "Старт";
            // 
            // btnStep
            // 
            this.btnStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStep.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(163, 29);
            this.btnStep.Text = "Следующий шаг";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 29);
            this.btnSave.Text = "Сохранить";
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoad.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(104, 29);
            this.btnLoad.Text = "Загрузить";
            // 
            // lbtimerInterval
            // 
            this.lbtimerInterval.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbtimerInterval.Name = "lbtimerInterval";
            this.lbtimerInterval.Size = new System.Drawing.Size(141, 29);
            this.lbtimerInterval.Text = "Интервал (мс)";
            // 
            // valueTimerInterval
            // 
            this.valueTimerInterval.Font = new System.Drawing.Font("Tahoma", 12F);
            this.valueTimerInterval.Name = "valueTimerInterval";
            this.valueTimerInterval.Size = new System.Drawing.Size(100, 32);
            this.valueTimerInterval.Text = "100";
            this.valueTimerInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valueTimerInterval_KeyPress);
            // 
            // bntClear
            // 
            this.bntClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bntClear.Font = new System.Drawing.Font("Tahoma", 12F);
            this.bntClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(98, 29);
            this.bntClear.Text = "Сбросить";
            // 
            // tsddbGenomeBrush
            // 
            this.tsddbGenomeBrush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbGenomeBrush.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPresetClassic,
            this.tsmiPresetRed,
            this.tsmiPresetGreen,
            this.tsmiPresetBlue,
            this.toolStripSeparator1,
            this.tsmiGene0,
            this.tsmiGene1,
            this.tsmiGene2,
            this.tsmiGene3,
            this.tsmiGene4,
            this.tsmiGene5,
            this.tsmiGene6,
            this.tsmiGene7,
            this.tsmiGene8});
            this.tsddbGenomeBrush.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tsddbGenomeBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbGenomeBrush.Name = "tsddbGenomeBrush";
            this.tsddbGenomeBrush.Size = new System.Drawing.Size(146, 29);
            this.tsddbGenomeBrush.Text = "Кисть генома";
            // 
            // tsmiPresetClassic
            // 
            this.tsmiPresetClassic.Name = "tsmiPresetClassic";
            this.tsmiPresetClassic.Size = new System.Drawing.Size(451, 28);
            this.tsmiPresetClassic.Text = "Пресет: Классический (Чёрный)";
            // 
            // tsmiPresetRed
            // 
            this.tsmiPresetRed.Name = "tsmiPresetRed";
            this.tsmiPresetRed.Size = new System.Drawing.Size(451, 28);
            this.tsmiPresetRed.Text = "Пресет: Одинокий (Красный)";
            // 
            // tsmiPresetGreen
            // 
            this.tsmiPresetGreen.Name = "tsmiPresetGreen";
            this.tsmiPresetGreen.Size = new System.Drawing.Size(451, 28);
            this.tsmiPresetGreen.Text = "Пресет: Сбалансированный (Зелёный)";
            // 
            // tsmiPresetBlue
            // 
            this.tsmiPresetBlue.Name = "tsmiPresetBlue";
            this.tsmiPresetBlue.Size = new System.Drawing.Size(451, 28);
            this.tsmiPresetBlue.Text = "Пресет: Общительный (Синий)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(448, 6);
            // 
            // tsmiGene0
            // 
            this.tsmiGene0.CheckOnClick = true;
            this.tsmiGene0.Name = "tsmiGene0";
            this.tsmiGene0.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene0.Text = "Ген 0 (0 Соседей)";
            // 
            // tsmiGene1
            // 
            this.tsmiGene1.CheckOnClick = true;
            this.tsmiGene1.Name = "tsmiGene1";
            this.tsmiGene1.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene1.Text = "Ген 1 (1 Сосед)";
            // 
            // tsmiGene2
            // 
            this.tsmiGene2.CheckOnClick = true;
            this.tsmiGene2.Name = "tsmiGene2";
            this.tsmiGene2.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene2.Text = "Ген 2 (2 Соседа)";
            // 
            // tsmiGene3
            // 
            this.tsmiGene3.CheckOnClick = true;
            this.tsmiGene3.Name = "tsmiGene3";
            this.tsmiGene3.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene3.Text = "Ген 3 (3 Соседа)";
            // 
            // tsmiGene4
            // 
            this.tsmiGene4.CheckOnClick = true;
            this.tsmiGene4.Name = "tsmiGene4";
            this.tsmiGene4.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene4.Text = "Ген 4 (4 Соседа)";
            // 
            // tsmiGene5
            // 
            this.tsmiGene5.CheckOnClick = true;
            this.tsmiGene5.Name = "tsmiGene5";
            this.tsmiGene5.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene5.Text = "Ген 5 (5 Соседей)";
            // 
            // tsmiGene6
            // 
            this.tsmiGene6.CheckOnClick = true;
            this.tsmiGene6.Name = "tsmiGene6";
            this.tsmiGene6.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene6.Text = "Ген 6 (6 Соседей)";
            // 
            // tsmiGene7
            // 
            this.tsmiGene7.CheckOnClick = true;
            this.tsmiGene7.Name = "tsmiGene7";
            this.tsmiGene7.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene7.Text = "Ген 7 (7 Соседей)";
            // 
            // tsmiGene8
            // 
            this.tsmiGene8.CheckOnClick = true;
            this.tsmiGene8.Name = "tsmiGene8";
            this.tsmiGene8.Size = new System.Drawing.Size(451, 28);
            this.tsmiGene8.Text = "Ген 8 (8 Соседей)";
            // 
            // toolStripBtnAbout
            // 
            this.toolStripBtnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnAbout.Font = new System.Drawing.Font("Tahoma", 12F);
            this.toolStripBtnAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAbout.Image")));
            this.toolStripBtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAbout.Name = "toolStripBtnAbout";
            this.toolStripBtnAbout.Size = new System.Drawing.Size(90, 29);
            this.toolStripBtnAbout.Text = "Справка";
            // 
            // btnBactToMenu
            // 
            this.btnBactToMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBactToMenu.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnBactToMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnBactToMenu.Image")));
            this.btnBactToMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBactToMenu.Name = "btnBactToMenu";
            this.btnBactToMenu.Size = new System.Drawing.Size(170, 29);
            this.btnBactToMenu.Text = "Вернутся в меню";
            // 
            // pictureBoxGame
            // 
            this.pictureBoxGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxGame.Location = new System.Drawing.Point(0, 32);
            this.pictureBoxGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxGame.Name = "pictureBoxGame";
            this.pictureBoxGame.Size = new System.Drawing.Size(1336, 515);
            this.pictureBoxGame.TabIndex = 1;
            this.pictureBoxGame.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbGeneration,
            this.lbCursorCords});
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1336, 30);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbGeneration
            // 
            this.lbGeneration.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbGeneration.Name = "lbGeneration";
            this.lbGeneration.Size = new System.Drawing.Size(135, 24);
            this.lbGeneration.Text = "Поколение: 0";
            // 
            // lbCursorCords
            // 
            this.lbCursorCords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbCursorCords.Name = "lbCursorCords";
            this.lbCursorCords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbCursorCords.Size = new System.Drawing.Size(54, 24);
            this.lbCursorCords.Text = "X: Y:";
            this.lbCursorCords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCursorCords.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnStart.Location = new System.Drawing.Point(476, 101);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(432, 111);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAbout.Location = new System.Drawing.Point(476, 252);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(432, 111);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "Справка о игре";
            this.btnAbout.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnExit.Location = new System.Drawing.Point(476, 400);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(432, 111);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 577);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBoxGame);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game of Life";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnStartPause;
        private System.Windows.Forms.ToolStripButton btnStep;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.PictureBox pictureBoxGame;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbGeneration;
        private System.Windows.Forms.ToolStripLabel lbtimerInterval;
        private System.Windows.Forms.ToolStripTextBox valueTimerInterval;
        private System.Windows.Forms.ToolStripButton bntClear;

        private System.Windows.Forms.ToolStripDropDownButton tsddbGenomeBrush;
        private System.Windows.Forms.ToolStripMenuItem tsmiPresetClassic;
        private System.Windows.Forms.ToolStripMenuItem tsmiPresetRed;
        private System.Windows.Forms.ToolStripMenuItem tsmiPresetGreen;
        private System.Windows.Forms.ToolStripMenuItem tsmiPresetBlue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene0;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene1;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene2;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene3;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene4;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene5;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene6;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene7;
        private System.Windows.Forms.ToolStripMenuItem tsmiGene8;
        private System.Windows.Forms.ToolStripButton toolStripBtnAbout;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripButton btnBactToMenu;
        private System.Windows.Forms.ToolStripStatusLabel lbCursorCords;
    }
}