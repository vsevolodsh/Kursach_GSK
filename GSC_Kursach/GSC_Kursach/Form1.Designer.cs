namespace GSC_Kursach
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxPrimitive = new System.Windows.Forms.ComboBox();
            this.comboBoxColour = new System.Windows.Forms.ComboBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.trackBarTurn = new System.Windows.Forms.TrackBar();
            this.labelValueOfAngel = new System.Windows.Forms.Label();
            this.buttonTurn = new System.Windows.Forms.Button();
            this.comboBoxTMO = new System.Windows.Forms.ComboBox();
            this.buttonTMO = new System.Windows.Forms.Button();
            this.buttonMirror = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(45, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(901, 502);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // comboBoxPrimitive
            // 
            this.comboBoxPrimitive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxPrimitive.FormattingEnabled = true;
            this.comboBoxPrimitive.Items.AddRange(new object[] {
            "Линия",
            "Кубический сплайн",
            "Фигура 4",
            "Стрелка 2"});
            this.comboBoxPrimitive.Location = new System.Drawing.Point(98, 543);
            this.comboBoxPrimitive.Name = "comboBoxPrimitive";
            this.comboBoxPrimitive.Size = new System.Drawing.Size(121, 23);
            this.comboBoxPrimitive.TabIndex = 2;
            this.comboBoxPrimitive.Text = "Примитив";
            this.comboBoxPrimitive.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrimitive_SelectedIndexChanged);
            // 
            // comboBoxColour
            // 
            this.comboBoxColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxColour.FormattingEnabled = true;
            this.comboBoxColour.Items.AddRange(new object[] {
            "Черный",
            "Красный",
            "Зеленый",
            "Синий"});
            this.comboBoxColour.Location = new System.Drawing.Point(425, 543);
            this.comboBoxColour.Name = "comboBoxColour";
            this.comboBoxColour.Size = new System.Drawing.Size(121, 23);
            this.comboBoxColour.TabIndex = 3;
            this.comboBoxColour.Text = "Цвет";
            this.comboBoxColour.SelectedIndexChanged += new System.EventHandler(this.comboBoxColour_SelectedIndexChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.Location = new System.Drawing.Point(1019, 544);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(110, 22);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Items.AddRange(new object[] {
            "Рисование",
            "Геометр. преобразования",
            "ТМО"});
            this.comboBoxOperation.Location = new System.Drawing.Point(749, 543);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(121, 23);
            this.comboBoxOperation.TabIndex = 5;
            this.comboBoxOperation.Text = "Операция";
            this.comboBoxOperation.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperation_SelectedIndexChanged);
            // 
            // trackBarTurn
            // 
            this.trackBarTurn.Location = new System.Drawing.Point(952, 12);
            this.trackBarTurn.Maximum = 360;
            this.trackBarTurn.Name = "trackBarTurn";
            this.trackBarTurn.Size = new System.Drawing.Size(261, 45);
            this.trackBarTurn.TabIndex = 6;
            this.trackBarTurn.Scroll += new System.EventHandler(this.trackBarTurn_Scroll);
            // 
            // labelValueOfAngel
            // 
            this.labelValueOfAngel.AutoSize = true;
            this.labelValueOfAngel.Location = new System.Drawing.Point(1027, 51);
            this.labelValueOfAngel.Name = "labelValueOfAngel";
            this.labelValueOfAngel.Size = new System.Drawing.Size(100, 15);
            this.labelValueOfAngel.TabIndex = 7;
            this.labelValueOfAngel.Text = "Угол поворота: 0";
            // 
            // buttonTurn
            // 
            this.buttonTurn.Location = new System.Drawing.Point(1027, 87);
            this.buttonTurn.Name = "buttonTurn";
            this.buttonTurn.Size = new System.Drawing.Size(102, 33);
            this.buttonTurn.TabIndex = 8;
            this.buttonTurn.Text = "Поворот";
            this.buttonTurn.UseVisualStyleBackColor = true;
            this.buttonTurn.Click += new System.EventHandler(this.buttonTurn_Click);
            // 
            // comboBoxTMO
            // 
            this.comboBoxTMO.FormattingEnabled = true;
            this.comboBoxTMO.Items.AddRange(new object[] {
            "Пересечение",
            "Симметрическая разность"});
            this.comboBoxTMO.Location = new System.Drawing.Point(1019, 176);
            this.comboBoxTMO.Name = "comboBoxTMO";
            this.comboBoxTMO.Size = new System.Drawing.Size(123, 23);
            this.comboBoxTMO.TabIndex = 9;
            this.comboBoxTMO.Text = "ТМО";
            this.comboBoxTMO.SelectedIndexChanged += new System.EventHandler(this.comboBoxTMO_SelectedIndexChanged);
            // 
            // buttonTMO
            // 
            this.buttonTMO.Location = new System.Drawing.Point(1019, 215);
            this.buttonTMO.Name = "buttonTMO";
            this.buttonTMO.Size = new System.Drawing.Size(129, 37);
            this.buttonTMO.TabIndex = 10;
            this.buttonTMO.Text = "Выполнить ТМО";
            this.buttonTMO.UseVisualStyleBackColor = true;
            this.buttonTMO.Click += new System.EventHandler(this.buttonTMO_Click);
            // 
            // buttonMirror
            // 
            this.buttonMirror.Location = new System.Drawing.Point(975, 311);
            this.buttonMirror.Name = "buttonMirror";
            this.buttonMirror.Size = new System.Drawing.Size(220, 38);
            this.buttonMirror.TabIndex = 11;
            this.buttonMirror.Text = "Выполнить зеркально отражение\r\n";
            this.buttonMirror.UseVisualStyleBackColor = true;
            this.buttonMirror.Click += new System.EventHandler(this.buttonMirror_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 610);
            this.Controls.Add(this.buttonMirror);
            this.Controls.Add(this.buttonTMO);
            this.Controls.Add(this.comboBoxTMO);
            this.Controls.Add(this.buttonTurn);
            this.Controls.Add(this.labelValueOfAngel);
            this.Controls.Add(this.trackBarTurn);
            this.Controls.Add(this.comboBoxOperation);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.comboBoxColour);
            this.Controls.Add(this.comboBoxPrimitive);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Lab_1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTurn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboBoxPrimitive;
        private ComboBox comboBoxColour;
        private Button buttonClear;
        private ComboBox comboBoxOperation;
        private TrackBar trackBarTurn;
        private Label labelValueOfAngel;
        private Button buttonTurn;
        private ComboBox comboBoxTMO;
        private Button buttonTMO;
        private Button buttonMirror;
    }
}