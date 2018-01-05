namespace CGOSECELDERDATABASE
{
    partial class EmployeeDueAward
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
            this.AwardGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AwardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AwardGrid
            // 
            this.AwardGrid.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.AwardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AwardGrid.Location = new System.Drawing.Point(12, 12);
            this.AwardGrid.Name = "AwardGrid";
            this.AwardGrid.Size = new System.Drawing.Size(757, 337);
            this.AwardGrid.TabIndex = 0;
            this.AwardGrid.DoubleClick += new System.EventHandler(this.AwardGrid_DoubleClick_1);
            // 
            // EmployeeDueAward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(781, 372);
            this.Controls.Add(this.AwardGrid);
            this.Name = "EmployeeDueAward";
            this.Text = "EmployeeDueAwardList";
            this.Load += new System.EventHandler(this.EmployeeDueAward_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AwardGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AwardGrid;
    }
}