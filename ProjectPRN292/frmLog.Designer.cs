namespace ProjectPRN292
{
    partial class frmLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearchLog = new System.Windows.Forms.TextBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            lbRoom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRoom
            // 
            lbRoom.AutoSize = true;
            lbRoom.BackColor = System.Drawing.Color.Transparent;
            lbRoom.Font = new System.Drawing.Font("ScriptS", 39.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            lbRoom.ForeColor = System.Drawing.Color.DarkOrchid;
            lbRoom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            lbRoom.Location = new System.Drawing.Point(65, 36);
            lbRoom.Name = "lbRoom";
            lbRoom.Size = new System.Drawing.Size(306, 85);
            lbRoom.TabIndex = 27;
            lbRoom.Text = "Hotel Log";
            // 
            // lbSearch
            // 
            this.lbSearch.Font = new System.Drawing.Font("MS PGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lbSearch.Location = new System.Drawing.Point(23, 121);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(100, 23);
            this.lbSearch.TabIndex = 3;
            this.lbSearch.Text = "Search:";
            // 
            // txtSearchLog
            // 
            this.txtSearchLog.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchLog.Location = new System.Drawing.Point(93, 121);
            this.txtSearchLog.Name = "txtSearchLog";
            this.txtSearchLog.Size = new System.Drawing.Size(178, 23);
            this.txtSearchLog.TabIndex = 4;
            this.txtSearchLog.TextChanged += new System.EventHandler(this.txtSearchLog_TextChanged);
            // 
            // dgvLog
            // 
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Location = new System.Drawing.Point(26, 147);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.Size = new System.Drawing.Size(379, 321);
            this.dgvLog.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.MediumOrchid;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(394, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(36, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(430, 492);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(lbRoom);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.txtSearchLog);
            this.Controls.Add(this.lbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Log";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearchLog;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Button btnCancel;
    }
}