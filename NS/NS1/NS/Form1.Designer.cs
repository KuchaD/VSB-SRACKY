namespace NS
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTest = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTrain = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewWeight = new System.Windows.Forms.DataGridView();
            this.Setting = new System.Windows.Forms.GroupBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonLoadXML = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Log = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.labelBias = new System.Windows.Forms.Label();
            this.labelLrate = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrain)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeight)).BeginInit();
            this.Setting.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.Log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1093, 696);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Setting, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.MaximumSize = new System.Drawing.Size(250, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.85637F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.14363F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 229F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 690);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewTest);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 463);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 224);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TestSet";
            // 
            // dataGridViewTest
            // 
            this.dataGridViewTest.AllowUserToAddRows = false;
            this.dataGridViewTest.AllowUserToDeleteRows = false;
            this.dataGridViewTest.AllowUserToOrderColumns = true;
            this.dataGridViewTest.AllowUserToResizeColumns = false;
            this.dataGridViewTest.AllowUserToResizeRows = false;
            this.dataGridViewTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTest.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewTest.MultiSelect = false;
            this.dataGridViewTest.Name = "dataGridViewTest";
            this.dataGridViewTest.ReadOnly = true;
            this.dataGridViewTest.RowHeadersVisible = false;
            this.dataGridViewTest.RowHeadersWidth = 82;
            this.dataGridViewTest.ShowCellErrors = false;
            this.dataGridViewTest.ShowCellToolTips = false;
            this.dataGridViewTest.ShowEditingIcon = false;
            this.dataGridViewTest.ShowRowErrors = false;
            this.dataGridViewTest.Size = new System.Drawing.Size(232, 205);
            this.dataGridViewTest.TabIndex = 3;
            this.dataGridViewTest.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewTrain);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 196);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TrainSet";
            // 
            // dataGridViewTrain
            // 
            this.dataGridViewTrain.AllowUserToAddRows = false;
            this.dataGridViewTrain.AllowUserToDeleteRows = false;
            this.dataGridViewTrain.AllowUserToResizeColumns = false;
            this.dataGridViewTrain.AllowUserToResizeRows = false;
            this.dataGridViewTrain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTrain.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewTrain.MultiSelect = false;
            this.dataGridViewTrain.Name = "dataGridViewTrain";
            this.dataGridViewTrain.ReadOnly = true;
            this.dataGridViewTrain.RowHeadersVisible = false;
            this.dataGridViewTrain.RowHeadersWidth = 82;
            this.dataGridViewTrain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTrain.ShowCellErrors = false;
            this.dataGridViewTrain.ShowCellToolTips = false;
            this.dataGridViewTrain.ShowEditingIcon = false;
            this.dataGridViewTrain.ShowRowErrors = false;
            this.dataGridViewTrain.Size = new System.Drawing.Size(232, 177);
            this.dataGridViewTrain.TabIndex = 2;
            this.dataGridViewTrain.TabStop = false;
            this.dataGridViewTrain.UseWaitCursor = true;
            this.dataGridViewTrain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewWeight);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weight";
            // 
            // dataGridViewWeight
            // 
            this.dataGridViewWeight.AllowUserToAddRows = false;
            this.dataGridViewWeight.AllowUserToDeleteRows = false;
            this.dataGridViewWeight.AllowUserToResizeColumns = false;
            this.dataGridViewWeight.AllowUserToResizeRows = false;
            this.dataGridViewWeight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWeight.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewWeight.MultiSelect = false;
            this.dataGridViewWeight.Name = "dataGridViewWeight";
            this.dataGridViewWeight.ReadOnly = true;
            this.dataGridViewWeight.RowHeadersVisible = false;
            this.dataGridViewWeight.RowHeadersWidth = 82;
            this.dataGridViewWeight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWeight.Size = new System.Drawing.Size(232, 138);
            this.dataGridViewWeight.TabIndex = 1;
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.labelLrate);
            this.Setting.Controls.Add(this.labelBias);
            this.Setting.Controls.Add(this.button1);
            this.Setting.Controls.Add(this.buttonTest);
            this.Setting.Controls.Add(this.buttonStart);
            this.Setting.Controls.Add(this.buttonLoadXML);
            this.Setting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Setting.Location = new System.Drawing.Point(3, 3);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(238, 89);
            this.Setting.TabIndex = 0;
            this.Setting.TabStop = false;
            this.Setting.Text = "Setting";
            this.Setting.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(168, 19);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 3;
            this.buttonTest.Text = "Check";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(87, 19);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Learn";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonLoadXML
            // 
            this.buttonLoadXML.Location = new System.Drawing.Point(6, 19);
            this.buttonLoadXML.Name = "buttonLoadXML";
            this.buttonLoadXML.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadXML.TabIndex = 0;
            this.buttonLoadXML.Text = "LoadXML";
            this.buttonLoadXML.UseVisualStyleBackColor = true;
            this.buttonLoadXML.Click += new System.EventHandler(this.buttonLoadXML_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.Log, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(253, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.20142F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.79857F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(837, 690);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // Log
            // 
            this.Log.Controls.Add(this.richTextBox1);
            this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log.Location = new System.Drawing.Point(3, 466);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(831, 221);
            this.Log.TabIndex = 0;
            this.Log.TabStop = false;
            this.Log.Text = "Log";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(825, 202);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(600, 600);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(600, 600);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelBias
            // 
            this.labelBias.AutoSize = true;
            this.labelBias.Location = new System.Drawing.Point(89, 49);
            this.labelBias.Name = "labelBias";
            this.labelBias.Size = new System.Drawing.Size(33, 13);
            this.labelBias.TabIndex = 5;
            this.labelBias.Text = "Bias: ";
            // 
            // labelLrate
            // 
            this.labelLrate.AutoSize = true;
            this.labelLrate.Location = new System.Drawing.Point(89, 62);
            this.labelLrate.Name = "labelLrate";
            this.labelLrate.Size = new System.Drawing.Size(80, 13);
            this.labelLrate.TabIndex = 6;
            this.labelLrate.Text = "Learning Rate: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 696);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Percepton app";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeight)).EndInit();
            this.Setting.ResumeLayout(false);
            this.Setting.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.Log.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox Setting;
        private System.Windows.Forms.DataGridView dataGridViewWeight;
        private System.Windows.Forms.DataGridView dataGridViewTrain;
        private System.Windows.Forms.DataGridView dataGridViewTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox Log;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonLoadXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelLrate;
        private System.Windows.Forms.Label labelBias;
    }
}

