using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Forms
{
    using Timer = System.Windows.Forms.Timer;

    public partial class MainForm : Form
    {
        private Universe universe = new Universe();
        private bool isRunning = false;
        private int cellSize = 20;
        private int offsetX = 0, offsetY = 0;
        private float zoom = 1.0f;
        private bool isDragging = false;
        private Point lastMousePos;
        private int[] currentGenomeForBrush = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private ToolStripMenuItem[] tsmiGenesArray = new ToolStripMenuItem[9];

        private bool isUniverseModified = false;
        private Size originalFormSize;
        private Timer gameTimer;

        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;

            this.Load += MainForm_Load;

            tsmiGenesArray[0] = tsmiGene0;
            tsmiGenesArray[1] = tsmiGene1;
            tsmiGenesArray[2] = tsmiGene2;
            tsmiGenesArray[3] = tsmiGene3;
            tsmiGenesArray[4] = tsmiGene4;
            tsmiGenesArray[5] = tsmiGene5;
            tsmiGenesArray[6] = tsmiGene6;
            tsmiGenesArray[7] = tsmiGene7;
            tsmiGenesArray[8] = tsmiGene8;
            for (int i = 0; i < tsmiGenesArray.Length; i++)
            {
                if (tsmiGenesArray[i] != null)
                {
                    tsmiGenesArray[i].CheckedChanged += GeneMenuItem_CheckedChanged;
                }
            }

            tsmiPresetClassic.Click += TsmiPresetClassic_Click;
            tsmiPresetRed.Click += TsmiPresetRed_Click;
            tsmiPresetGreen.Click += TsmiPresetGreen_Click;
            tsmiPresetBlue.Click += TsmiPresetBlue_Click;

            pictureBoxGame.Paint += PictureBoxGame_Paint;
            pictureBoxGame.MouseClick += PictureBoxGame_MouseClick;
            pictureBoxGame.MouseWheel += PictureBoxGame_MouseWheel;
            pictureBoxGame.MouseDown += PictureBoxGame_MouseDown;
            pictureBoxGame.MouseMove += PictureBoxGame_MouseMove;
            pictureBoxGame.MouseUp += PictureBoxGame_MouseUp;

            btnStartPause.Click += BtnStartPause_Click;
            btnStep.Click += BtnStep_Click;
            btnSave.Click += BtnSave_Click;
            btnLoad.Click += BtnLoad_Click;
            bntClear.Click += BntClear_Click;

            btnStart.Click += BtnStart_Click;
            btnAbout.Click += BtnAbout_Click;
            btnExit.Click += BtnExit_Click;
            toolStripBtnAbout.Click += BtnAbout_Click;
            btnBactToMenu.Click += BtnBackToMenu_Click;

            this.KeyDown += MainForm_KeyDown;
            this.Resize += (s, e) => pictureBoxGame.Invalidate();
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            toolStrip1.Visible = false;
            statusStrip1.Visible = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnAbout.Visible = false;
            btnExit.Visible = false;

            toolStrip1.Visible = true;
            statusStrip1.Visible = true;

            this.WindowState = FormWindowState.Maximized;
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            if (isUniverseModified)
            {
                DialogResult result = MessageBox.Show(
                    "У вас есть несохраненные изменения. Вы уверены, что хотите вернутся в меню?",
                    "Предупреждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return;
                }
            }
            isUniverseModified = false;

            if (isRunning)
            {
                isRunning = false;
                btnStartPause.Text = "Старт";
                if (gameTimer != null)
                {
                    gameTimer.Stop();
                    gameTimer.Dispose();
                    gameTimer = null;
                }
            }
            
            universe.cells.Clear();
            universe.Generation = 0;
            
            lbGeneration.Text = "Поколение: 0";
            pictureBoxGame.Invalidate();

            toolStrip1.Visible = false;
            statusStrip1.Visible = false;
            btnStart.Visible = true;
            btnAbout.Visible = true;
            btnExit.Visible = true;

            this.WindowState = FormWindowState.Normal;
            this.Size = originalFormSize;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isUniverseModified)
            {
                DialogResult result = MessageBox.Show(
                    "У вас есть несохраненные изменения. Вы уверены, что хотите выйти?",
                    "Предупреждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Отменяем закрытие формы
                }
            }
        }

        private void InitializeBrushGenomeControls()
        {
            for (int i = 0; i < 9; i++)
            {
                if (tsmiGenesArray[i] != null)
                {
                    tsmiGenesArray[i].CheckedChanged -= GeneMenuItem_CheckedChanged;
                    tsmiGenesArray[i].Checked = (currentGenomeForBrush[i] == 1);
                    tsmiGenesArray[i].CheckedChanged += GeneMenuItem_CheckedChanged;
                }
            }
        }

        private void UpdateBrushGenomeAndPreview()
        {
            for (int i = 0; i < 9; i++)
            {
                if (tsmiGenesArray[i] != null)
                {
                    currentGenomeForBrush[i] = tsmiGenesArray[i].Checked ? 1 : 0;
                }
            }
        }

        private void GeneMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBrushGenomeAndPreview();
        }

        private void TsmiPresetClassic_Click(object sender, EventArgs e)
        {
            currentGenomeForBrush = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            InitializeBrushGenomeControls();
        }

        private void TsmiPresetRed_Click(object sender, EventArgs e)
        {
            currentGenomeForBrush = new int[] { 1, 1, 0, 0, 0, 0, 0, 0, 0 };
            InitializeBrushGenomeControls();
        }

        private void TsmiPresetGreen_Click(object sender, EventArgs e)
        {
            currentGenomeForBrush = new int[] { 0, 0, 1, 1, 0, 0, 0, 0, 0 };
            InitializeBrushGenomeControls();
        }

        private void TsmiPresetBlue_Click(object sender, EventArgs e)
        {
            currentGenomeForBrush = new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 1 };
            InitializeBrushGenomeControls();
        }

        private void BntClear_Click(object sender, EventArgs e)
        {
            universe.cells.Clear();
            universe.Generation = 0;
            isRunning = false;
            isUniverseModified = true;
            btnStartPause.Text = "Старт";
            lbGeneration.Text = "Поколение: 0";
            pictureBoxGame.Invalidate();
        }

        private void PictureBoxGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.ScaleTransform(zoom, zoom);
            e.Graphics.TranslateTransform(offsetX, offsetY);

            foreach (var cellEntry in universe.cells)
            {
                int x = cellEntry.Key.Item1;
                int y = cellEntry.Key.Item2;
                CellData cellData = cellEntry.Value;

                int drawX = x * cellSize;
                int drawY = y * cellSize;

                using (SolidBrush cellBrush = new SolidBrush(cellData.CellColor))
                {
                    e.Graphics.FillRectangle(cellBrush, drawX, drawY, cellSize, cellSize);
                }
                e.Graphics.DrawRectangle(Pens.Gray, drawX, drawY, cellSize, cellSize);
            }
        }

        private void PictureBoxGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || isRunning) return; // Реагируем только на левую кнопку и когда игра на паузе

            float currentCellSize = cellSize;
            int worldX = (int)Math.Floor((e.X / zoom - offsetX * 1.0f) / currentCellSize);
            int worldY = (int)Math.Floor((e.Y / zoom - offsetY * 1.0f) / currentCellSize);

            bool currentState = universe.GetCellState(worldX, worldY);
            if (!currentState)
            {
                universe.SetCellState(worldX, worldY, true, currentGenomeForBrush);
            }
            else
            {
                universe.SetCellState(worldX, worldY, false, null);
            }
            isUniverseModified = true; // Устанавливаем флаг изменения
            pictureBoxGame.Invalidate();
        }

        private void PictureBoxGame_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldZoom = zoom;
            PointF mousePosWorldBeforeZoom = new PointF((e.X / oldZoom - offsetX), (e.Y / oldZoom - offsetY));

            float zoomFactor = 1.1f;
            if (e.Delta > 0) zoom *= zoomFactor;
            else zoom /= zoomFactor;

            zoom = Math.Max(0.1f, Math.Min(zoom, 10.0f));

            offsetX = (int)(e.X / zoom - mousePosWorldBeforeZoom.X);
            offsetY = (int)(e.Y / zoom - mousePosWorldBeforeZoom.Y);

            pictureBoxGame.Invalidate();
        }

        private void PictureBoxGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isDragging = true;
                lastMousePos = e.Location;
                pictureBoxGame.Cursor = Cursors.SizeAll;
            }
        }

        private void PictureBoxGame_MouseMove(object sender, MouseEventArgs e)
        {
            // Логика перетаскивания
            if (isDragging)
            {
                offsetX += (int)((e.X - lastMousePos.X) / zoom);
                offsetY += (int)((e.Y - lastMousePos.Y) / zoom);
                lastMousePos = e.Location;
                pictureBoxGame.Invalidate();
            }

            // Обновление координат курсора в статус-баре
            float currentCellSize = cellSize;
            int worldX = (int)Math.Floor((e.X / zoom - offsetX * 1.0f) / currentCellSize);
            int worldY = (int)Math.Floor((e.Y / zoom - offsetY * 1.0f) / currentCellSize);
            lbCursorCords.Text = $"X: {worldX}, Y: {worldY}";
        }

        private void PictureBoxGame_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isDragging = false;
                pictureBoxGame.Cursor = Cursors.Default;
            }
        }

        private void BtnStartPause_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            btnStartPause.Text = isRunning ? "Пауза" : "Старт";

            if (isRunning)
            {
                if (gameTimer == null)
                {
                    gameTimer = new Timer();
                    gameTimer.Tick += GameTimer_Tick;
                }

                if (!int.TryParse(valueTimerInterval.Text, out int interval) || interval <= 0)
                {
                    interval = 100;
                    valueTimerInterval.Text = interval.ToString();
                }
                gameTimer.Interval = interval;
                gameTimer.Start();
            }
            else
            {
                if (gameTimer != null)
                {
                    gameTimer.Stop();
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                gameTimer.Stop();
                return;
            }

            universe.Step();
            isUniverseModified = true;
            lbGeneration.Text = "Поколение: " + universe.Generation.ToString();
            pictureBoxGame.Invalidate();

            if (!universe.cells.Any())
            {
                isRunning = false;
                gameTimer.Stop();
                btnStartPause.Text = "Старт";
                MessageBox.Show("Все клетки погибли. Симуляция остановлена.", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnStep_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                universe.Step();
                isUniverseModified = true; // Шаг - это изменение
                lbGeneration.Text = "Поколение: " + universe.Generation.ToString();
                pictureBoxGame.Invalidate();

                // Проверка после ручного шага
                if (!universe.cells.Any())
                {
                    MessageBox.Show("Все клетки погибли.", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Game of Life Genome Files (*.gol2)|*.gol2|All Files (*.*)|*.*";
                saveDialog.DefaultExt = "gol2";
                saveDialog.AddExtension = true;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    universe.SaveBinary(saveDialog.FileName);
                    isUniverseModified = false; // Сохранили, флаг сбрасываем
                }
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Game of Life Genome Files (*.gol2)|*.gol2|All Files (*.*)|*.*";
                openDialog.DefaultExt = "gol2";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    if (isRunning)
                    {
                        isRunning = false;
                        btnStartPause.Text = "Старт";
                        if (gameTimer != null) gameTimer.Stop();
                    }
                    universe.LoadBinary(openDialog.FileName);
                    isUniverseModified = false; // Загрузили, флаг сбрасываем
                    lbGeneration.Text = "Поколение: " + universe.Generation.ToString();
                    offsetX = 0;
                    offsetY = 0;
                    zoom = 1.0f;
                    pictureBoxGame.Invalidate();
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            int moveAmount = (int)(20 / zoom);
            bool moved = false;
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) { offsetY += moveAmount; moved = true; }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) { offsetY -= moveAmount; moved = true; }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) { offsetX += moveAmount; moved = true; }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) { offsetX -= moveAmount; moved = true; }

            if (moved)
            {
                pictureBoxGame.Invalidate();
                e.Handled = true;
            }
        }

        private void valueTimerInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}