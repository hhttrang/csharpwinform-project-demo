namespace ProjectPRN292
{
    partial class frmHistory
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
            System.Windows.Forms.Label lbRoom;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistory));
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearchHistory = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            lbRoom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRoom
            // 
            lbRoom.AutoSize = true;
            lbRoom.BackColor = System.Drawing.Color.Transparent;
            lbRoom.Font = new System.Drawing.Font("ScriptS", 39.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            lbRoom.ForeColor = System.Drawing.Color.DarkOrchid;
            lbRoom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            lbRoom.Location = new System.Drawing.Point(135, 9);
            lbRoom.Name = "lbRoom";
            lbRoom.Size = new System.Drawing.Size(477, 85);
            lbRoom.TabIndex = 26;
            lbRoom.Text = "Booking History";
            // 
            // dgvHistory
            // 
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(32, 131);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.Size = new System.Drawing.Size(692, 299);
            this.dgvHistory.TabIndex = 0;
            // 
            // lbSearch
            // 
            this.lbSearch.Font = new System.Drawing.Font("MS PGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lbSearch.Location = new System.Drawing.Point(29, 97);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(100, 23);
            this.lbSearch.TabIndex = 2;
            this.lbSearch.Text = "Search:";
            // 
            // txtSearchHistory
            // 
            this.txtSearchHistory.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchHistory.Location = new System.Drawing.Point(113, 97);
            this.txtSearchHistory.Name = "txtSearchHistory";
            this.txtSearchHistory.Size = new System.Drawing.Size(178, 23);
            this.txtSearchHistory.TabIndex = 3;
            this.txtSearchHistory.TextChanged += new System.EventHandler(this.txtSearchHistory_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.MediumOrchid;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(717, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(36, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(754, 461);
            this.Controls.Add(lbRoom);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSearchHistory);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.dgvHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking History";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearchHistory;
        private System.Windows.Forms.Button btnCancel;
    }
}