namespace ProjectPRN292
{
    partial class frmStaffHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaffHome));
            this.lbSearchroom = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.btnCustomeMana = new System.Windows.Forms.Button();
            this.btnRecepMana = new System.Windows.Forms.Button();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
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
            label1.Location = new System.Drawing.Point(87, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(497, 85);
            label1.TabIndex = 12;
            label1.Text = "Hotel Room List";
            // 
            // lbSearchroom
            // 
            this.lbSearchroom.AutoSize = true;
            this.lbSearchroom.BackColor = System.Drawing.Color.LightGray;
            this.lbSearchroom.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearchroom.ForeColor = System.Drawing.Color.LightSalmon;
            this.lbSearchroom.Location = new System.Drawing.Point(47, 113);
            this.lbSearchroom.Name = "lbSearchroom";
            this.lbSearchroom.Size = new System.Drawing.Size(116, 16);
            this.lbSearchroom.TabIndex = 5;
            this.lbSearchroom.Text = "Search room:";
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnLogout.Location = new System.Drawing.Point(558, 398);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvRooms
            // 
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(38, 139);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(595, 239);
            this.dgvRooms.TabIndex = 8;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellClick);
            // 
            // btnCustomeMana
            // 
            this.btnCustomeMana.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomeMana.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnCustomeMana.Location = new System.Drawing.Point(50, 384);
            this.btnCustomeMana.Name = "btnCustomeMana";
            this.btnCustomeMana.Size = new System.Drawing.Size(207, 24);
            this.btnCustomeMana.TabIndex = 9;
            this.btnCustomeMana.Text = "Customer Manager";
            this.btnCustomeMana.UseVisualStyleBackColor = true;
            this.btnCustomeMana.Click += new System.EventHandler(this.btnCustomeMana_Click);
            // 
            // btnRecepMana
            // 
            this.btnRecepMana.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecepMana.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnRecepMana.Location = new System.Drawing.Point(50, 414);
            this.btnRecepMana.Name = "btnRecepMana";
            this.btnRecepMana.Size = new System.Drawing.Size(207, 24);
            this.btnRecepMana.TabIndex = 11;
            this.btnRecepMana.Text = "Receptionist Manager";
            this.btnRecepMana.UseVisualStyleBackColor = true;
            this.btnRecepMana.Click += new System.EventHandler(this.btnRecepMana_Click);
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
            this.lbWelcome.TabIndex = 13;
            this.lbWelcome.Text = "This is the welcome";
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewHistory.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnViewHistory.Location = new System.Drawing.Point(412, 386);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(140, 23);
            this.btnViewHistory.TabIndex = 14;
            this.btnViewHistory.Text = "View History";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click_1);
            // 
            // btnLog
            // 
            this.btnLog.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnLog.Location = new System.Drawing.Point(412, 415);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(140, 23);
            this.btnLog.TabIndex = 15;
            this.btnLog.Text = "View Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // txtSearchRoom
            // 
            this.txtSearchRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchRoom.Location = new System.Drawing.Point(154, 111);
            this.txtSearchRoom.Mask = "000";
            this.txtSearchRoom.Name = "txtSearchRoom";
            this.txtSearchRoom.Size = new System.Drawing.Size(137, 22);
            this.txtSearchRoom.TabIndex = 16;
            this.txtSearchRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchRoom.ValidatingType = typeof(int);
            this.txtSearchRoom.TextChanged += new System.EventHandler(this.txtSearchRoom_TextChanged_1);
            // 
            // frmStaffHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.txtSearchRoom);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(label1);
            this.Controls.Add(this.btnRecepMana);
            this.Controls.Add(this.btnCustomeMana);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lbSearchroom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmStaffHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Manager for Staff";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbSearchroom;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.Button btnCustomeMana;
        private System.Windows.Forms.Button btnRecepMana;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.MaskedTextBox txtSearchRoom;
    }
}