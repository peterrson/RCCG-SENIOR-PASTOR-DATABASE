namespace CGOSECELDERDATABASE
{
    partial class EmployeeDueRetirementList
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
            this.RetireeGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.RetireeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // RetireeGrid
            // 
            this.RetireeGrid.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.RetireeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RetireeGrid.Location = new System.Drawing.Point(12, 12);
            this.RetireeGrid.Name = "RetireeGrid";
            this.RetireeGrid.Size = new System.Drawing.Size(753, 337);
            this.RetireeGrid.TabIndex = 0;
            this.RetireeGrid.DoubleClick += new System.EventHandler(this.RetireeGrid_DoubleClick);
            // 
            // EmployeeDueRetirementList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(777, 372);
            this.Controls.Add(this.RetireeGrid);
            this.Name = "EmployeeDueRetirementList";
            this.Text = "EmployeeDueRetirementList";
            this.Load += new System.EventHandler(this.EmployeeDueRetirementList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RetireeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RetireeGrid;
    }
}