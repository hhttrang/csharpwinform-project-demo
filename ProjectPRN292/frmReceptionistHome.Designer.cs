namespace ProjectPRN292
{
    partial class frmReceptionistHome
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceptionistHome));
            this.btnLogout = new System.Windows.Forms.Button();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.lbSearchroom = new System.Windows.Forms.Label();
            this.btnCustomeMana = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.txtSearchRoom = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("ScriptS", 39.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.DarkOrchid;
            label1.Location = new System.Drawing.Point(84, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(497, 85);
            label1.TabIndex = 7;
            label1.Text = "Hotel Room List";
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnLogout.Location = new System.Drawing.Point(558, 414);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.BackColor = System.Drawing.Color.Gainsboro;
            this.lbWelcome.Font = new System.Drawing.Font("MS Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.LightCoral;
            this.lbWelcome.Location = new System.Drawing.Point(12, 9);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(179, 16);
            this.lbWelcome.TabIndex = 1;
            this.lbWelcome.Text = "This is the welcome";
            // 
            // dgvRooms
            // 
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(38, 152);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(595, 239);
            this.dgvRooms.TabIndex = 2;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellClick);
            // 
            // lbSearchroom
            // 
            this.lbSearchroom.AutoSize = true;
            this.lbSearchroom.BackColor = System.Drawing.Color.LightGray;
            this.lbSearchroom.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearchroom.ForeColor = System.Drawing.Color.IndianRed;
            this.lbSearchroom.Location = new System.Drawing.Point(45, 117);
            this.lbSearchroom.Name = "lbSearchroom";
            this.lbSearchroom.Size = new System.Drawing.Size(116, 16);
            this.lbSearchroom.TabIndex = 4;
            this.lbSearchroom.Text = "Search room:";
            // 
            // btnCustomeMana
            // 
            this.btnCustomeMana.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomeMana.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnCustomeMana.Location = new System.Drawing.Point(38, 413);
            this.btnCustomeMana.Name = "btnCustomeMana";
            this.btnCustomeMana.Size = new System.Drawing.Size(177, 24);
            this.btnCustomeMana.TabIndex = 6;
            this.btnCustomeMana.Text = "Customer Manager";
            this.btnCustomeMana.UseVisualStyleBackColor = true;
            this.btnCustomeMana.Click += new System.EventHandler(this.btnCustomeMana_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewHistory.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnViewHistory.Location = new System.Drawing.Point(403, 414);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(139, 23);
            this.btnViewHistory.TabIndex = 8;
            this.btnViewHistory.Text = "View History";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click_1);
            // 
            // txtSearchRoom
            // 
            this.txtSearchRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchRoom.Location = new System.Drawing.Point(157, 112);
            this.txtSearchRoom.Mask = "000";
            this.txtSearchRoom.Name = "txtSearchRoom";
            this.txtSearchRoom.Size = new System.Drawing.Size(147, 22);
            this.txtSearchRoom.TabIndex = 9;
            this.txtSearchRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchRoom.ValidatingType = typeof(int);
            this.txtSearchRoom.TextChanged += new System.EventHandler(this.txtSearchRoom_TextChanged_1);
            // 
            // frmReceptionistHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(667, 466);
            this.Controls.Add(this.txtSearchRoom);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(label1);
            this.Controls.Add(this.btnCustomeMana);
            this.Controls.Add(this.lbSearchroom);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReceptionistHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Manager for Receptionist";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.Label lbSearchroom;
        private System.Windows.Forms.Button btnCustomeMana;
        public System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.MaskedTextBox txtSearchRoom;
    }
}