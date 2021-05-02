namespace WindowsFormsApp1
{
    partial class SettingsForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.updateTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.saveBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.chooseFolderBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orientationBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.collectionBtn = new System.Windows.Forms.Button();
            this.photoCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sortByBox = new System.Windows.Forms.ComboBox();
            this.photosPerPage = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.updateTimeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photosPerPage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update time interval (min)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateTimeInterval
            // 
            this.updateTimeInterval.Location = new System.Drawing.Point(145, 13);
            this.updateTimeInterval.Name = "updateTimeInterval";
            this.updateTimeInterval.Size = new System.Drawing.Size(55, 20);
            this.updateTimeInterval.TabIndex = 1;
            this.updateTimeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 225);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitBtn.Location = new System.Drawing.Point(132, 225);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // chooseFolderBtn
            // 
            this.chooseFolderBtn.Location = new System.Drawing.Point(132, 39);
            this.chooseFolderBtn.Name = "chooseFolderBtn";
            this.chooseFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.chooseFolderBtn.TabIndex = 4;
            this.chooseFolderBtn.Text = "Choose";
            this.chooseFolderBtn.UseVisualStyleBackColor = true;
            this.chooseFolderBtn.Click += new System.EventHandler(this.chooseFolderBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wallpaper folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Topics";
            // 
            // orientationBox
            // 
            this.orientationBox.FormattingEnabled = true;
            this.orientationBox.Location = new System.Drawing.Point(132, 102);
            this.orientationBox.Name = "orientationBox";
            this.orientationBox.Size = new System.Drawing.Size(75, 21);
            this.orientationBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Orientation";
            // 
            // collectionBtn
            // 
            this.collectionBtn.Location = new System.Drawing.Point(132, 68);
            this.collectionBtn.Name = "collectionBtn";
            this.collectionBtn.Size = new System.Drawing.Size(75, 23);
            this.collectionBtn.TabIndex = 9;
            this.collectionBtn.Text = "Choose";
            this.collectionBtn.UseVisualStyleBackColor = true;
            this.collectionBtn.Click += new System.EventHandler(this.collectionBtn_Click);
            // 
            // photoCount
            // 
            this.photoCount.Location = new System.Drawing.Point(145, 163);
            this.photoCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.photoCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.photoCount.Name = "photoCount";
            this.photoCount.Size = new System.Drawing.Size(55, 20);
            this.photoCount.TabIndex = 10;
            this.photoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.photoCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Download photos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Sort by";
            // 
            // sortByBox
            // 
            this.sortByBox.FormattingEnabled = true;
            this.sortByBox.Location = new System.Drawing.Point(132, 132);
            this.sortByBox.Name = "sortByBox";
            this.sortByBox.Size = new System.Drawing.Size(75, 21);
            this.sortByBox.TabIndex = 13;
            // 
            // photosPerPage
            // 
            this.photosPerPage.Location = new System.Drawing.Point(145, 194);
            this.photosPerPage.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.photosPerPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.photosPerPage.Name = "photosPerPage";
            this.photosPerPage.Size = new System.Drawing.Size(55, 20);
            this.photosPerPage.TabIndex = 14;
            this.photosPerPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.photosPerPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Photos per page";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitBtn;
            this.ClientSize = new System.Drawing.Size(219, 260);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.photosPerPage);
            this.Controls.Add(this.sortByBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.photoCount);
            this.Controls.Add(this.collectionBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.orientationBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseFolderBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.updateTimeInterval);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updateTimeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photosPerPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown updateTimeInterval;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button chooseFolderBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox orientationBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button collectionBtn;
        private System.Windows.Forms.NumericUpDown photoCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox sortByBox;
        private System.Windows.Forms.NumericUpDown photosPerPage;
        private System.Windows.Forms.Label label7;
    }
}

