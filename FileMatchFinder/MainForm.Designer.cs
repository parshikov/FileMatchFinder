namespace FilesMatchFinder
{
    partial class fileFinderMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileFinderMainForm));
            this.torrentDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.fileSourceTextBox = new System.Windows.Forms.TextBox();
            this.chooseCollectionFolderButton = new System.Windows.Forms.Button();
            this.chooseTorrentFolderButton = new System.Windows.Forms.Button();
            this.recursiveTorrentSearchCheckbox = new System.Windows.Forms.CheckBox();
            this.fileDestinationTextBox = new System.Windows.Forms.TextBox();
            this.torrentFolderPathLabel = new System.Windows.Forms.Label();
            this.fileCollectionPathLabel = new System.Windows.Forms.Label();
            this.sortedFilesPathLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyFileCheckbox = new System.Windows.Forms.CheckBox();
            this.chooseDestinationFolderButton = new System.Windows.Forms.Button();
            this.resulDataGrid = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileProc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultLabel = new System.Windows.Forms.Label();
            this.torrentFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.sourceFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.destinationFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resulDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // torrentDirectoryTextBox
            // 
            this.torrentDirectoryTextBox.Location = new System.Drawing.Point(171, 19);
            this.torrentDirectoryTextBox.Name = "torrentDirectoryTextBox";
            this.torrentDirectoryTextBox.Size = new System.Drawing.Size(307, 20);
            this.torrentDirectoryTextBox.TabIndex = 1;
            // 
            // fileSourceTextBox
            // 
            this.fileSourceTextBox.Location = new System.Drawing.Point(171, 45);
            this.fileSourceTextBox.Name = "fileSourceTextBox";
            this.fileSourceTextBox.Size = new System.Drawing.Size(307, 20);
            this.fileSourceTextBox.TabIndex = 3;
            // 
            // chooseCollectionFolderButton
            // 
            this.chooseCollectionFolderButton.Location = new System.Drawing.Point(487, 43);
            this.chooseCollectionFolderButton.Name = "chooseCollectionFolderButton";
            this.chooseCollectionFolderButton.Size = new System.Drawing.Size(75, 23);
            this.chooseCollectionFolderButton.TabIndex = 4;
            this.chooseCollectionFolderButton.Text = "Обзор...";
            this.chooseCollectionFolderButton.UseVisualStyleBackColor = true;
            this.chooseCollectionFolderButton.Click += new System.EventHandler(this.chooseCollectionFolderButton_Click);
            // 
            // chooseTorrentFolderButton
            // 
            this.chooseTorrentFolderButton.Location = new System.Drawing.Point(487, 17);
            this.chooseTorrentFolderButton.Name = "chooseTorrentFolderButton";
            this.chooseTorrentFolderButton.Size = new System.Drawing.Size(75, 23);
            this.chooseTorrentFolderButton.TabIndex = 2;
            this.chooseTorrentFolderButton.Text = "Обзор...";
            this.chooseTorrentFolderButton.UseVisualStyleBackColor = true;
            this.chooseTorrentFolderButton.Click += new System.EventHandler(this.chooseTorrentFolderButton_Click);
            // 
            // recursiveTorrentSearchCheckbox
            // 
            this.recursiveTorrentSearchCheckbox.AutoSize = true;
            this.recursiveTorrentSearchCheckbox.Location = new System.Drawing.Point(9, 152);
            this.recursiveTorrentSearchCheckbox.Name = "recursiveTorrentSearchCheckbox";
            this.recursiveTorrentSearchCheckbox.Size = new System.Drawing.Size(176, 17);
            this.recursiveTorrentSearchCheckbox.TabIndex = 7;
            this.recursiveTorrentSearchCheckbox.Text = "Искать торренты рекурсивно";
            this.recursiveTorrentSearchCheckbox.UseVisualStyleBackColor = true;
            // 
            // fileDestinationTextBox
            // 
            this.fileDestinationTextBox.Location = new System.Drawing.Point(171, 71);
            this.fileDestinationTextBox.Name = "fileDestinationTextBox";
            this.fileDestinationTextBox.Size = new System.Drawing.Size(307, 20);
            this.fileDestinationTextBox.TabIndex = 5;
            // 
            // torrentFolderPathLabel
            // 
            this.torrentFolderPathLabel.AutoSize = true;
            this.torrentFolderPathLabel.Location = new System.Drawing.Point(51, 22);
            this.torrentFolderPathLabel.Name = "torrentFolderPathLabel";
            this.torrentFolderPathLabel.Size = new System.Drawing.Size(114, 13);
            this.torrentFolderPathLabel.TabIndex = 7;
            this.torrentFolderPathLabel.Text = "Папка с торрентами:";
            // 
            // fileCollectionPathLabel
            // 
            this.fileCollectionPathLabel.AutoSize = true;
            this.fileCollectionPathLabel.Location = new System.Drawing.Point(40, 48);
            this.fileCollectionPathLabel.Name = "fileCollectionPathLabel";
            this.fileCollectionPathLabel.Size = new System.Drawing.Size(125, 13);
            this.fileCollectionPathLabel.TabIndex = 8;
            this.fileCollectionPathLabel.Text = "Папка для сортировки:";
            // 
            // sortedFilesPathLabel
            // 
            this.sortedFilesPathLabel.AutoSize = true;
            this.sortedFilesPathLabel.Location = new System.Drawing.Point(6, 74);
            this.sortedFilesPathLabel.Name = "sortedFilesPathLabel";
            this.sortedFilesPathLabel.Size = new System.Drawing.Size(159, 13);
            this.sortedFilesPathLabel.TabIndex = 10;
            this.sortedFilesPathLabel.Text = "Папка для отсортированного:";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(487, 169);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startButton);
            this.groupBox1.Controls.Add(this.copyFileCheckbox);
            this.groupBox1.Controls.Add(this.chooseDestinationFolderButton);
            this.groupBox1.Controls.Add(this.torrentFolderPathLabel);
            this.groupBox1.Controls.Add(this.recursiveTorrentSearchCheckbox);
            this.groupBox1.Controls.Add(this.torrentDirectoryTextBox);
            this.groupBox1.Controls.Add(this.fileDestinationTextBox);
            this.groupBox1.Controls.Add(this.sortedFilesPathLabel);
            this.groupBox1.Controls.Add(this.chooseTorrentFolderButton);
            this.groupBox1.Controls.Add(this.fileCollectionPathLabel);
            this.groupBox1.Controls.Add(this.chooseCollectionFolderButton);
            this.groupBox1.Controls.Add(this.fileSourceTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 198);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // copyFileCheckbox
            // 
            this.copyFileCheckbox.AutoSize = true;
            this.copyFileCheckbox.Location = new System.Drawing.Point(9, 175);
            this.copyFileCheckbox.Name = "copyFileCheckbox";
            this.copyFileCheckbox.Size = new System.Drawing.Size(237, 17);
            this.copyFileCheckbox.TabIndex = 8;
            this.copyFileCheckbox.Text = "Копировать файлы вместо перемещения";
            this.copyFileCheckbox.UseVisualStyleBackColor = true;
            // 
            // chooseDestinationFolderButton
            // 
            this.chooseDestinationFolderButton.Location = new System.Drawing.Point(487, 69);
            this.chooseDestinationFolderButton.Name = "chooseDestinationFolderButton";
            this.chooseDestinationFolderButton.Size = new System.Drawing.Size(75, 23);
            this.chooseDestinationFolderButton.TabIndex = 6;
            this.chooseDestinationFolderButton.Text = "Обзор...";
            this.chooseDestinationFolderButton.UseVisualStyleBackColor = true;
            this.chooseDestinationFolderButton.Click += new System.EventHandler(this.chooseDestinationFolderButton_Click);
            // 
            // resulDataGrid
            // 
            this.resulDataGrid.AllowUserToAddRows = false;
            this.resulDataGrid.AllowUserToDeleteRows = false;
            this.resulDataGrid.AllowUserToOrderColumns = true;
            this.resulDataGrid.AllowUserToResizeRows = false;
            this.resulDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resulDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resulDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.fileProc});
            this.resulDataGrid.Location = new System.Drawing.Point(13, 239);
            this.resulDataGrid.Name = "resulDataGrid";
            this.resulDataGrid.Size = new System.Drawing.Size(567, 207);
            this.resulDataGrid.TabIndex = 10;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Файл";
            this.FileName.Name = "FileName";
            // 
            // fileProc
            // 
            this.fileProc.FillWeight = 25F;
            this.fileProc.HeaderText = "Выполнено";
            this.fileProc.Name = "fileProc";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(9, 223);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(62, 13);
            this.resultLabel.TabIndex = 0;
            this.resultLabel.Text = "Результат:";
            // 
            // torrentFolderBrowser
            // 
            this.torrentFolderBrowser.ShowNewFolderButton = false;
            // 
            // sourceFolderBrowser
            // 
            this.sourceFolderBrowser.ShowNewFolderButton = false;
            // 
            // fileFinderMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 458);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resulDataGrid);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fileFinderMainForm";
            this.Text = "FilesMatchFinder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resulDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox torrentDirectoryTextBox;
        private System.Windows.Forms.TextBox fileSourceTextBox;
        private System.Windows.Forms.Button chooseCollectionFolderButton;
        private System.Windows.Forms.Button chooseTorrentFolderButton;
        private System.Windows.Forms.CheckBox recursiveTorrentSearchCheckbox;
        private System.Windows.Forms.TextBox fileDestinationTextBox;
        private System.Windows.Forms.Label torrentFolderPathLabel;
        private System.Windows.Forms.Label fileCollectionPathLabel;
        private System.Windows.Forms.Label sortedFilesPathLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button chooseDestinationFolderButton;
        private System.Windows.Forms.CheckBox copyFileCheckbox;
        private System.Windows.Forms.DataGridView resulDataGrid;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileProc;
        private System.Windows.Forms.FolderBrowserDialog torrentFolderBrowser;
        private System.Windows.Forms.FolderBrowserDialog sourceFolderBrowser;
        private System.Windows.Forms.FolderBrowserDialog destinationFolderBrowser;
    }
}

