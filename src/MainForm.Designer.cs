namespace NiGardenScore
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
            this.ratingSchemeDataGridView = new System.Windows.Forms.DataGridView();
            this.RatingText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatingScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatingRated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fileListView = new System.Windows.Forms.ListView();
            this.fileNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addFileButton = new System.Windows.Forms.Button();
            this.btnGenerateTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ratingSchemeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ratingSchemeDataGridView
            // 
            this.ratingSchemeDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ratingSchemeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ratingSchemeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RatingText,
            this.RatingScore,
            this.RatingRated});
            this.ratingSchemeDataGridView.Location = new System.Drawing.Point(12, 277);
            this.ratingSchemeDataGridView.Name = "ratingSchemeDataGridView";
            this.ratingSchemeDataGridView.RowHeadersWidth = 62;
            this.ratingSchemeDataGridView.RowTemplate.Height = 28;
            this.ratingSchemeDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ratingSchemeDataGridView.Size = new System.Drawing.Size(768, 335);
            this.ratingSchemeDataGridView.TabIndex = 0;
            // 
            // RatingText
            // 
            this.RatingText.HeaderText = "Text";
            this.RatingText.MinimumWidth = 8;
            this.RatingText.Name = "RatingText";
            this.RatingText.Width = 150;
            // 
            // RatingScore
            // 
            this.RatingScore.HeaderText = "Punktezahl";
            this.RatingScore.MinimumWidth = 8;
            this.RatingScore.Name = "RatingScore";
            this.RatingScore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RatingScore.Width = 150;
            // 
            // RatingRated
            // 
            this.RatingRated.HeaderText = "Bewertet";
            this.RatingRated.MinimumWidth = 8;
            this.RatingRated.Name = "RatingRated";
            this.RatingRated.Width = 150;
            // 
            // fileListView
            // 
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameColumn,
            this.filePathColumn});
            this.fileListView.GridLines = true;
            this.fileListView.HideSelection = false;
            this.fileListView.Location = new System.Drawing.Point(12, 12);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(768, 208);
            this.fileListView.TabIndex = 1;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.Text = "Datei";
            this.fileNameColumn.Width = 100;
            // 
            // filePathColumn
            // 
            this.filePathColumn.Text = "Pfad";
            this.filePathColumn.Width = 400;
            // 
            // addFileButton
            // 
            this.addFileButton.Location = new System.Drawing.Point(12, 226);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.Size = new System.Drawing.Size(768, 33);
            this.addFileButton.TabIndex = 2;
            this.addFileButton.Text = "Schaugarten hinzufügen";
            this.addFileButton.UseVisualStyleBackColor = true;
            this.addFileButton.Click += new System.EventHandler(this.addFileButton_Click);
            // 
            // btnGenerateTable
            // 
            this.btnGenerateTable.Location = new System.Drawing.Point(12, 618);
            this.btnGenerateTable.Name = "btnGenerateTable";
            this.btnGenerateTable.Size = new System.Drawing.Size(768, 33);
            this.btnGenerateTable.TabIndex = 3;
            this.btnGenerateTable.Text = "Gesamttabelle erstellen";
            this.btnGenerateTable.UseVisualStyleBackColor = true;
            this.btnGenerateTable.Click += new System.EventHandler(this.btnGenerateTable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 664);
            this.Controls.Add(this.btnGenerateTable);
            this.Controls.Add(this.addFileButton);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.ratingSchemeDataGridView);
            this.MaximumSize = new System.Drawing.Size(815, 720);
            this.MinimumSize = new System.Drawing.Size(815, 720);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Schaugartenbewertungen";
            ((System.ComponentModel.ISupportInitialize)(this.ratingSchemeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ratingSchemeDataGridView;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.ColumnHeader fileNameColumn;
        private System.Windows.Forms.ColumnHeader filePathColumn;
        private System.Windows.Forms.Button btnGenerateTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingText;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingScore;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RatingRated;
    }
}

