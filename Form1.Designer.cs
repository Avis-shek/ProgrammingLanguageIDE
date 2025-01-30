namespace ProgrammingLanguageIDE
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NavigationPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.MaximizeBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeCodeRichText = new System.Windows.Forms.RichTextBox();
            this.BackgrounfPanel = new System.Windows.Forms.Panel();
            this.ErrorRichBox = new System.Windows.Forms.RichTextBox();
            this.error = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CommandLine = new System.Windows.Forms.RichTextBox();
            this.consoleText = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OutputArea = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.SuccessMessagePnl = new System.Windows.Forms.Panel();
            this.successMgxPicBox = new System.Windows.Forms.PictureBox();
            this.PopUpBtn = new CustomControls.RJControls.RJButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.executeBtn = new CustomControls.RJControls.RJButton();
            this.Validate = new CustomControls.RJControls.RJButton();
            this.NavigationPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.BackgrounfPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuccessMessagePnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.successMgxPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NavigationPanel
            // 
            this.NavigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NavigationPanel.Controls.Add(this.flowLayoutPanel1);
            this.NavigationPanel.Controls.Add(this.minimizeBtn);
            this.NavigationPanel.Controls.Add(this.MaximizeBtn);
            this.NavigationPanel.Controls.Add(this.closeBtn);
            this.NavigationPanel.Controls.Add(this.menuStrip1);
            this.NavigationPanel.Location = new System.Drawing.Point(-3, -7);
            this.NavigationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.NavigationPanel.Name = "NavigationPanel";
            this.NavigationPanel.Size = new System.Drawing.Size(2009, 72);
            this.NavigationPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(917, 14);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(144, 8);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimizeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.Location = new System.Drawing.Point(1222, 19);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(25, 32);
            this.minimizeBtn.TabIndex = 2;
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // MaximizeBtn
            // 
            this.MaximizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.MaximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MaximizeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.MaximizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("MaximizeBtn.Image")));
            this.MaximizeBtn.Location = new System.Drawing.Point(1284, 16);
            this.MaximizeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBtn.Name = "MaximizeBtn";
            this.MaximizeBtn.Size = new System.Drawing.Size(32, 35);
            this.MaximizeBtn.TabIndex = 1;
            this.MaximizeBtn.UseVisualStyleBackColor = false;
            this.MaximizeBtn.Click += new System.EventHandler(this.MaximizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.closeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.BackgroundImage")));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.closeBtn.Location = new System.Drawing.Point(1356, 19);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(32, 32);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.gitToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2009, 72);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDown = this.contextMenuStrip1;
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(103, 68);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.OwnerItem = this.fileToolStripMenuItem;
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 80);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(147, 38);
            this.saveToolStripMenuItem.Text = "Save ";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(147, 38);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewToolStripMenuItem.Image")));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(117, 68);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(116, 68);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolsToolStripMenuItem.Image")));
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(121, 68);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(106, 68);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // gitToolStripMenuItem
            // 
            this.gitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gitToolStripMenuItem.Image")));
            this.gitToolStripMenuItem.Name = "gitToolStripMenuItem";
            this.gitToolStripMenuItem.Size = new System.Drawing.Size(96, 68);
            this.gitToolStripMenuItem.Text = "Git";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.debugToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("debugToolStripMenuItem.Image")));
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(138, 68);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // typeCodeRichText
            // 
            this.typeCodeRichText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.typeCodeRichText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.typeCodeRichText.ForeColor = System.Drawing.Color.White;
            this.typeCodeRichText.Location = new System.Drawing.Point(9, 151);
            this.typeCodeRichText.Margin = new System.Windows.Forms.Padding(0);
            this.typeCodeRichText.Name = "typeCodeRichText";
            this.typeCodeRichText.Size = new System.Drawing.Size(669, 444);
            this.typeCodeRichText.TabIndex = 2;
            this.typeCodeRichText.Text = "";
            this.typeCodeRichText.SelectionChanged += new System.EventHandler(this.typeCodeRichText_SelectionChanged);
            // 
            // BackgrounfPanel
            // 
            this.BackgrounfPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgrounfPanel.Controls.Add(this.ErrorRichBox);
            this.BackgrounfPanel.Controls.Add(this.error);
            this.BackgrounfPanel.Controls.Add(this.pictureBox1);
            this.BackgrounfPanel.Controls.Add(this.errorText);
            this.BackgrounfPanel.Location = new System.Drawing.Point(13, 614);
            this.BackgrounfPanel.Name = "BackgrounfPanel";
            this.BackgrounfPanel.Size = new System.Drawing.Size(697, 240);
            this.BackgrounfPanel.TabIndex = 3;
            // 
            // ErrorRichBox
            // 
            this.ErrorRichBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ErrorRichBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ErrorRichBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ErrorRichBox.ForeColor = System.Drawing.Color.Red;
            this.ErrorRichBox.Location = new System.Drawing.Point(-4, 52);
            this.ErrorRichBox.Name = "ErrorRichBox";
            this.ErrorRichBox.ReadOnly = true;
            this.ErrorRichBox.Size = new System.Drawing.Size(779, 215);
            this.ErrorRichBox.TabIndex = 3;
            this.ErrorRichBox.Text = "Errors will be displayed here ....";
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.Location = new System.Drawing.Point(60, 11);
            this.error.Name = "error";
            this.error.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.error.Size = new System.Drawing.Size(111, 41);
            this.error.TabIndex = 2;
            this.error.Text = "Errors";
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // errorText
            // 
            this.errorText.AutoSize = true;
            this.errorText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorText.Image = ((System.Drawing.Image)(resources.GetObject("errorText.Image")));
            this.errorText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.errorText.Location = new System.Drawing.Point(217, 34);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(0, 31);
            this.errorText.TabIndex = 0;
            this.errorText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.CommandLine);
            this.panel1.Controls.Add(this.consoleText);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(746, 641);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 194);
            this.panel1.TabIndex = 7;
            // 
            // CommandLine
            // 
            this.CommandLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.CommandLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.CommandLine.ForeColor = System.Drawing.Color.Green;
            this.CommandLine.Location = new System.Drawing.Point(3, 48);
            this.CommandLine.Name = "CommandLine";
            this.CommandLine.Size = new System.Drawing.Size(649, 146);
            this.CommandLine.TabIndex = 3;
            this.CommandLine.Text = "Type Command Here\n";
            this.CommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandLine_KeyDown);
            this.CommandLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CommandLine_MouseDown);
            // 
            // consoleText
            // 
            this.consoleText.AutoSize = true;
            this.consoleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleText.Location = new System.Drawing.Point(70, 11);
            this.consoleText.Name = "consoleText";
            this.consoleText.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.consoleText.Size = new System.Drawing.Size(208, 37);
            this.consoleText.TabIndex = 2;
            this.consoleText.Text = "Command Line";
            this.consoleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(7, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 45);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(217, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 31);
            this.label4.TabIndex = 0;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(716, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(681, 50);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 11);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(120, 42);
            this.label3.TabIndex = 2;
            this.label3.Text = "Output";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(7, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(217, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 31);
            this.label5.TabIndex = 0;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OutputArea
            // 
            this.OutputArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.OutputArea.Location = new System.Drawing.Point(716, 159);
            this.OutputArea.Name = "OutputArea";
            this.OutputArea.Size = new System.Drawing.Size(682, 463);
            this.OutputArea.TabIndex = 10;
            this.OutputArea.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(1381, 199);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(8, 8);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // SuccessMessagePnl
            // 
            this.SuccessMessagePnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.SuccessMessagePnl.Controls.Add(this.successMgxPicBox);
            this.SuccessMessagePnl.Controls.Add(this.PopUpBtn);
            this.SuccessMessagePnl.Location = new System.Drawing.Point(716, 159);
            this.SuccessMessagePnl.Name = "SuccessMessagePnl";
            this.SuccessMessagePnl.Size = new System.Drawing.Size(479, 68);
            this.SuccessMessagePnl.TabIndex = 12;
            this.SuccessMessagePnl.Visible = false;
            // 
            // successMgxPicBox
            // 
            this.successMgxPicBox.BackColor = System.Drawing.Color.PaleGreen;
            this.successMgxPicBox.Image = ((System.Drawing.Image)(resources.GetObject("successMgxPicBox.Image")));
            this.successMgxPicBox.Location = new System.Drawing.Point(20, 0);
            this.successMgxPicBox.Name = "successMgxPicBox";
            this.successMgxPicBox.Size = new System.Drawing.Size(52, 57);
            this.successMgxPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.successMgxPicBox.TabIndex = 1;
            this.successMgxPicBox.TabStop = false;
            // 
            // PopUpBtn
            // 
            this.PopUpBtn.AutoSize = true;
            this.PopUpBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.PopUpBtn.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.PopUpBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.PopUpBtn.BorderRadius = 10;
            this.PopUpBtn.BorderSize = 0;
            this.PopUpBtn.FlatAppearance.BorderSize = 0;
            this.PopUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PopUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PopUpBtn.ForeColor = System.Drawing.Color.Black;
            this.PopUpBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PopUpBtn.Location = new System.Drawing.Point(-11, -8);
            this.PopUpBtn.Name = "PopUpBtn";
            this.PopUpBtn.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.PopUpBtn.Size = new System.Drawing.Size(336, 66);
            this.PopUpBtn.TabIndex = 0;
            this.PopUpBtn.Text = "Button";
            this.PopUpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PopUpBtn.TextColor = System.Drawing.Color.Black;
            this.PopUpBtn.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // executeBtn
            // 
            this.executeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.executeBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.executeBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.executeBtn.BorderRadius = 15;
            this.executeBtn.BorderSize = 0;
            this.executeBtn.FlatAppearance.BorderSize = 0;
            this.executeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.executeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeBtn.ForeColor = System.Drawing.Color.Black;
            this.executeBtn.Image = ((System.Drawing.Image)(resources.GetObject("executeBtn.Image")));
            this.executeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.executeBtn.Location = new System.Drawing.Point(581, 108);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(97, 40);
            this.executeBtn.TabIndex = 13;
            this.executeBtn.Text = "Run";
            this.executeBtn.TextColor = System.Drawing.Color.Black;
            this.executeBtn.UseVisualStyleBackColor = false;
            this.executeBtn.Click += new System.EventHandler(this.executeBtn_Click_1);
            // 
            // Validate
            // 
            this.Validate.BackColor = System.Drawing.Color.PaleGreen;
            this.Validate.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.Validate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Validate.BorderRadius = 15;
            this.Validate.BorderSize = 0;
            this.Validate.FlatAppearance.BorderSize = 0;
            this.Validate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Validate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Validate.ForeColor = System.Drawing.Color.Black;
            this.Validate.Image = ((System.Drawing.Image)(resources.GetObject("Validate.Image")));
            this.Validate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Validate.Location = new System.Drawing.Point(448, 105);
            this.Validate.Name = "Validate";
            this.Validate.Size = new System.Drawing.Size(127, 43);
            this.Validate.TabIndex = 14;
            this.Validate.Text = "Validate";
            this.Validate.TextColor = System.Drawing.Color.Black;
            this.Validate.UseVisualStyleBackColor = false;
            this.Validate.Click += new System.EventHandler(this.Validate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.closeBtn;
            this.ClientSize = new System.Drawing.Size(1440, 866);
            this.Controls.Add(this.Validate);
            this.Controls.Add(this.executeBtn);
            this.Controls.Add(this.SuccessMessagePnl);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.OutputArea);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BackgrounfPanel);
            this.Controls.Add(this.typeCodeRichText);
            this.Controls.Add(this.NavigationPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.NavigationPanel.ResumeLayout(false);
            this.NavigationPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.BackgrounfPanel.ResumeLayout(false);
            this.BackgrounfPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.SuccessMessagePnl.ResumeLayout(false);
            this.SuccessMessagePnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.successMgxPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NavigationPanel;
        private System.Windows.Forms.Button MaximizeBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel BackgrounfPanel;
        private System.Windows.Forms.Label errorText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox CommandLine;
        private System.Windows.Forms.Label consoleText;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.RichTextBox ErrorRichBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel SuccessMessagePnl;
        private System.Windows.Forms.Timer timer1;
        public CustomControls.RJControls.RJButton PopUpBtn;
        private System.Windows.Forms.PictureBox successMgxPicBox;
        public System.Windows.Forms.PictureBox OutputArea;
        private System.Windows.Forms.Timer timer2;
        protected internal System.Windows.Forms.RichTextBox typeCodeRichText;
        private CustomControls.RJControls.RJButton executeBtn;
        private CustomControls.RJControls.RJButton Validate;
    }
}

