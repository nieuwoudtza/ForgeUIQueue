namespace ForgeUIQueue
{
    partial class CfrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CfrmMain));
            this.btnQueue = new System.Windows.Forms.Button();
            this.dgvQueue = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrompt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSteps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPrompts = new System.Windows.Forms.Label();
            this.txtPrompts = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.lblSteps = new System.Windows.Forms.Label();
            this.numSteps = new System.Windows.Forms.NumericUpDown();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.picWeb = new System.Windows.Forms.PictureBox();
            this.picSkip = new System.Windows.Forms.PictureBox();
            this.picState = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picState)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQueue
            // 
            this.btnQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQueue.Location = new System.Drawing.Point(847, 162);
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.Size = new System.Drawing.Size(75, 31);
            this.btnQueue.TabIndex = 5;
            this.btnQueue.Text = "Queue";
            this.btnQueue.UseVisualStyleBackColor = true;
            this.btnQueue.Click += new System.EventHandler(this.BtnQueue_Click);
            // 
            // dgvQueue
            // 
            this.dgvQueue.AllowUserToAddRows = false;
            this.dgvQueue.AllowUserToDeleteRows = false;
            this.dgvQueue.AllowUserToResizeColumns = false;
            this.dgvQueue.AllowUserToResizeRows = false;
            this.dgvQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cPrompt,
            this.cWidth,
            this.cHeight,
            this.cSteps,
            this.cCount});
            this.dgvQueue.Location = new System.Drawing.Point(0, 203);
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.RowHeadersVisible = false;
            this.dgvQueue.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueue.Size = new System.Drawing.Size(934, 366);
            this.dgvQueue.TabIndex = 6;
            this.dgvQueue.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvQueue_CellEndEdit);
            this.dgvQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvQueue_KeyDown);
            this.dgvQueue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvQueue_MouseDown);
            this.dgvQueue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DgvQueue_MouseUp);
            // 
            // cID
            // 
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cID.Visible = false;
            // 
            // cPrompt
            // 
            this.cPrompt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPrompt.HeaderText = "Prompt";
            this.cPrompt.Name = "cPrompt";
            this.cPrompt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cWidth
            // 
            this.cWidth.HeaderText = "Width";
            this.cWidth.Name = "cWidth";
            this.cWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cWidth.Width = 80;
            // 
            // cHeight
            // 
            this.cHeight.HeaderText = "Height";
            this.cHeight.Name = "cHeight";
            this.cHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cHeight.Width = 80;
            // 
            // cSteps
            // 
            this.cSteps.HeaderText = "Steps";
            this.cSteps.Name = "cSteps";
            this.cSteps.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cSteps.Width = 80;
            // 
            // cCount
            // 
            this.cCount.HeaderText = "Count";
            this.cCount.Name = "cCount";
            this.cCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cCount.Width = 80;
            // 
            // lblPrompts
            // 
            this.lblPrompts.AutoSize = true;
            this.lblPrompts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPrompts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompts.Location = new System.Drawing.Point(12, 41);
            this.lblPrompts.Name = "lblPrompts";
            this.lblPrompts.Size = new System.Drawing.Size(54, 13);
            this.lblPrompts.TabIndex = 0;
            this.lblPrompts.Text = "Prompt(s):";
            this.lblPrompts.Click += new System.EventHandler(this.LblPrompts_Click);
            // 
            // txtPrompts
            // 
            this.txtPrompts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrompts.Location = new System.Drawing.Point(72, 38);
            this.txtPrompts.Multiline = true;
            this.txtPrompts.Name = "txtPrompts";
            this.txtPrompts.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrompts.Size = new System.Drawing.Size(850, 118);
            this.txtPrompts.TabIndex = 0;
            this.txtPrompts.WordWrap = false;
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(169, 170);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width:";
            // 
            // numWidth
            // 
            this.numWidth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numWidth.Location = new System.Drawing.Point(218, 167);
            this.numWidth.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(84, 20);
            this.numWidth.TabIndex = 1;
            this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numWidth.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(323, 170);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 0;
            this.lblHeight.Text = "Height:";
            // 
            // numHeight
            // 
            this.numHeight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numHeight.Location = new System.Drawing.Point(372, 168);
            this.numHeight.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(84, 20);
            this.numHeight.TabIndex = 2;
            this.numHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numHeight.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // lblSteps
            // 
            this.lblSteps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSteps.AutoSize = true;
            this.lblSteps.Location = new System.Drawing.Point(477, 170);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(37, 13);
            this.lblSteps.TabIndex = 0;
            this.lblSteps.Text = "Steps:";
            // 
            // numSteps
            // 
            this.numSteps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numSteps.Location = new System.Drawing.Point(526, 168);
            this.numSteps.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numSteps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSteps.Name = "numSteps";
            this.numSteps.Size = new System.Drawing.Size(84, 20);
            this.numSteps.TabIndex = 3;
            this.numSteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSteps.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(72, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(850, 20);
            this.txtPath.TabIndex = 6;
            this.txtPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPath.Leave += new System.EventHandler(this.TxtPath_Leave);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(12, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path:";
            this.lblPath.Click += new System.EventHandler(this.LblPath_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(631, 170);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(38, 13);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count:";
            // 
            // numCount
            // 
            this.numCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numCount.Location = new System.Drawing.Point(680, 168);
            this.numCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(84, 20);
            this.numCount.TabIndex = 4;
            this.numCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // picWeb
            // 
            this.picWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picWeb.Image = global::ForgeUIQueue.Properties.Resources.Web;
            this.picWeb.Location = new System.Drawing.Point(69, 173);
            this.picWeb.Name = "picWeb";
            this.picWeb.Size = new System.Drawing.Size(30, 30);
            this.picWeb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWeb.TabIndex = 7;
            this.picWeb.TabStop = false;
            this.toolTip.SetToolTip(this.picWeb, "Web Interface");
            this.picWeb.Click += new System.EventHandler(this.PicWeb_Click);
            // 
            // picSkip
            // 
            this.picSkip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSkip.Image = global::ForgeUIQueue.Properties.Resources.Skip;
            this.picSkip.Location = new System.Drawing.Point(35, 173);
            this.picSkip.Name = "picSkip";
            this.picSkip.Size = new System.Drawing.Size(30, 30);
            this.picSkip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSkip.TabIndex = 7;
            this.picSkip.TabStop = false;
            this.toolTip.SetToolTip(this.picSkip, "Skip");
            this.picSkip.Click += new System.EventHandler(this.PicSkip_Click);
            // 
            // picState
            // 
            this.picState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picState.Image = global::ForgeUIQueue.Properties.Resources.Pause;
            this.picState.Location = new System.Drawing.Point(1, 173);
            this.picState.Name = "picState";
            this.picState.Size = new System.Drawing.Size(30, 30);
            this.picState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picState.TabIndex = 7;
            this.picState.TabStop = false;
            this.toolTip.SetToolTip(this.picState, "Pause");
            this.picState.Click += new System.EventHandler(this.PicState_Click);
            // 
            // CfrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 569);
            this.Controls.Add(this.picWeb);
            this.Controls.Add(this.picSkip);
            this.Controls.Add(this.picState);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.numSteps);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblSteps);
            this.Controls.Add(this.txtPrompts);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblPrompts);
            this.Controls.Add(this.dgvQueue);
            this.Controls.Add(this.btnQueue);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(815, 445);
            this.Name = "CfrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgeUI Queue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CfrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.CfrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQueue;
        private System.Windows.Forms.DataGridView dgvQueue;
        private System.Windows.Forms.Label lblPrompts;
        private System.Windows.Forms.TextBox txtPrompts;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.NumericUpDown numSteps;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.PictureBox picState;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrompt;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSteps;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCount;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox picSkip;
        private System.Windows.Forms.PictureBox picWeb;
    }
}

