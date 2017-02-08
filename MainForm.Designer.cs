namespace Sample
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
                if( engine != null ) {
                    unloadEngine( ref engine );
                    engine = null;
                }
			}
			base.Dispose( disposing );
		}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.goButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripText = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.imagesFolderTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.documentDefinitionPathTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.restoreDefaultsButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.treeView = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.prevButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkCarimbos = new System.Windows.Forms.CheckBox();
            this.checkBoxDeskew = new System.Windows.Forms.CheckBox();
            this.checkBoxRotate90 = new System.Windows.Forms.CheckBox();
            this.documentoDefListBox = new System.Windows.Forms.CheckedListBox();
            this.checkBoxBin = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.classButton = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(128, 237);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(202, 31);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Process image";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripText});
            this.statusStrip.Location = new System.Drawing.Point(0, 669);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1332, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "Ready";
            // 
            // toolStripText
            // 
            this.toolStripText.Name = "toolStripText";
            this.toolStripText.Size = new System.Drawing.Size(39, 17);
            this.toolStripText.Text = "Ready";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(846, 498);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // imagesFolderTextBox
            // 
            this.imagesFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagesFolderTextBox.Location = new System.Drawing.Point(12, 26);
            this.imagesFolderTextBox.Name = "imagesFolderTextBox";
            this.imagesFolderTextBox.Size = new System.Drawing.Size(613, 20);
            this.imagesFolderTextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(628, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Imagens";
            // 
            // documentDefinitionPathTextBox
            // 
            this.documentDefinitionPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentDefinitionPathTextBox.Location = new System.Drawing.Point(14, 77);
            this.documentDefinitionPathTextBox.Name = "documentDefinitionPathTextBox";
            this.documentDefinitionPathTextBox.Size = new System.Drawing.Size(608, 20);
            this.documentDefinitionPathTextBox.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(628, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 21);
            this.button2.TabIndex = 4;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Document Definition (.fcdot Dir):";
            // 
            // restoreDefaultsButton
            // 
            this.restoreDefaultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreDefaultsButton.Location = new System.Drawing.Point(508, 103);
            this.restoreDefaultsButton.Name = "restoreDefaultsButton";
            this.restoreDefaultsButton.Size = new System.Drawing.Size(114, 25);
            this.restoreDefaultsButton.TabIndex = 5;
            this.restoreDefaultsButton.Text = "Restore defaults";
            this.restoreDefaultsButton.UseVisualStyleBackColor = true;
            this.restoreDefaultsButton.Click += new System.EventHandler(this.restoreDefaultsButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.HotTracking = true;
            this.treeView.Location = new System.Drawing.Point(3, 16);
            this.treeView.Name = "treeView";
            this.treeView.Scrollable = false;
            this.treeView.ShowLines = false;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(447, 489);
            this.treeView.TabIndex = 0;
            this.treeView.Visible = false;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(122, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "Not Recognized";
            this.label3.Visible = false;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Controls.Add(this.label4);
            this.panel.Location = new System.Drawing.Point(12, 134);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(850, 502);
            this.panel.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(519, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 31);
            this.label4.TabIndex = 17;
            this.label4.Text = "No Images Found";
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prevButton.Enabled = false;
            this.prevButton.Location = new System.Drawing.Point(719, 640);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(70, 23);
            this.prevButton.TabIndex = 6;
            this.prevButton.Text = "<<";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(647, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tela teste ABBYY Engine 10.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkCarimbos);
            this.groupBox1.Controls.Add(this.checkBoxDeskew);
            this.groupBox1.Controls.Add(this.checkBoxRotate90);
            this.groupBox1.Controls.Add(this.documentoDefListBox);
            this.groupBox1.Controls.Add(this.checkBoxBin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(663, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 131);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // checkCarimbos
            // 
            this.checkCarimbos.AutoSize = true;
            this.checkCarimbos.Location = new System.Drawing.Point(550, 15);
            this.checkCarimbos.Name = "checkCarimbos";
            this.checkCarimbos.Size = new System.Drawing.Size(64, 17);
            this.checkCarimbos.TabIndex = 24;
            this.checkCarimbos.Text = "Carimbo";
            this.checkCarimbos.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeskew
            // 
            this.checkBoxDeskew.AutoSize = true;
            this.checkBoxDeskew.Location = new System.Drawing.Point(470, 16);
            this.checkBoxDeskew.Name = "checkBoxDeskew";
            this.checkBoxDeskew.Size = new System.Drawing.Size(65, 17);
            this.checkBoxDeskew.TabIndex = 23;
            this.checkBoxDeskew.Text = "Deskew";
            this.checkBoxDeskew.UseVisualStyleBackColor = true;
            // 
            // checkBoxRotate90
            // 
            this.checkBoxRotate90.AutoSize = true;
            this.checkBoxRotate90.Location = new System.Drawing.Point(333, 16);
            this.checkBoxRotate90.Name = "checkBoxRotate90";
            this.checkBoxRotate90.Size = new System.Drawing.Size(122, 17);
            this.checkBoxRotate90.TabIndex = 22;
            this.checkBoxRotate90.Text = "Rotate 90o. Imagem";
            this.checkBoxRotate90.UseVisualStyleBackColor = true;
            // 
            // documentoDefListBox
            // 
            this.documentoDefListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentoDefListBox.FormattingEnabled = true;
            this.documentoDefListBox.Location = new System.Drawing.Point(5, 38);
            this.documentoDefListBox.Name = "documentoDefListBox";
            this.documentoDefListBox.Size = new System.Drawing.Size(643, 79);
            this.documentoDefListBox.TabIndex = 21;
            // 
            // checkBoxBin
            // 
            this.checkBoxBin.AutoSize = true;
            this.checkBoxBin.Location = new System.Drawing.Point(216, 16);
            this.checkBoxBin.Name = "checkBoxBin";
            this.checkBoxBin.Size = new System.Drawing.Size(106, 17);
            this.checkBoxBin.TabIndex = 20;
            this.checkBoxBin.Text = "Binarizar Imagem";
            this.checkBoxBin.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.classButton);
            this.groupBox2.Controls.Add(this.goButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.treeView);
            this.groupBox2.Location = new System.Drawing.Point(868, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 508);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(790, 640);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(70, 23);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = ">>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // classButton
            // 
            this.classButton.Location = new System.Drawing.Point(128, 268);
            this.classButton.Name = "classButton";
            this.classButton.Size = new System.Drawing.Size(202, 31);
            this.classButton.TabIndex = 17;
            this.classButton.Text = "Classify image";
            this.classButton.UseVisualStyleBackColor = true;
            this.classButton.Click += new System.EventHandler(this.classButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1332, 691);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.restoreDefaultsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.documentDefinitionPathTextBox);
            this.Controls.Add(this.imagesFolderTextBox);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(931, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monster sample";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripText;    
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox imagesFolderTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox documentDefinitionPathTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button restoreDefaultsButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.CheckBox checkBoxBin;
        private System.Windows.Forms.CheckedListBox documentoDefListBox;
        private System.Windows.Forms.CheckBox checkBoxRotate90;
        private System.Windows.Forms.CheckBox checkBoxDeskew;
        private System.Windows.Forms.CheckBox checkCarimbos;
        private System.Windows.Forms.Button classButton;
    }
}