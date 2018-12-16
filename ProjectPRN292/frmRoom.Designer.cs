namespace ProjectPRN292
{
    partial class frmRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoom));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMaxPerson = new System.Windows.Forms.MaskedTextBox();
            this.txtPricePer = new System.Windows.Forms.MaskedTextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBookingId = new System.Windows.Forms.TextBox();
            lbRoom = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRoom
            // 
            resources.ApplyResources(lbRoom, "lbRoom");
            lbRoom.BackColor = System.Drawing.Color.Transparent;
            lbRoom.ForeColor = System.Drawing.Color.DarkOrchid;
            lbRoom.Name = "lbRoom";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this.txtMaxPerson);
            this.panel1.Controls.Add(this.txtPricePer);
            this.panel1.Controls.Add(this.cbStatus);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIDNumber);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // txtMaxPerson
            // 
            resources.ApplyResources(this.txtMaxPerson, "txtMaxPerson");
            this.txtMaxPerson.Name = "txtMaxPerson";
            this.txtMaxPerson.ValidatingType = typeof(int);
            // 
            // txtPricePer
            // 
            resources.ApplyResources(this.txtPricePer, "txtPricePer");
            this.txtPricePer.Name = "txtPricePer";
            // 
            // cbStatus
            // 
            resources.ApplyResources(this.cbStatus, "cbStatus");
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            resources.GetString("cbStatus.Items"),
            resources.GetString("cbStatus.Items1"),
            resources.GetString("cbStatus.Items2")});
            this.cbStatus.Name = "cbStatus";
            // 
            // cbType
            // 
            resources.ApplyResources(this.cbType, "cbType");
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            resources.GetString("cbType.Items"),
            resources.GetString("cbType.Items1")});
            this.cbType.Name = "cbType";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label1.Name = "label1";
            // 
            // txtIDNumber
            // 
            resources.ApplyResources(this.txtIDNumber, "txtIDNumber");
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.ReadOnly = true;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.ForeColor = System.Drawing.Color.MediumOrchid;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnBooking
            // 
            resources.ApplyResources(this.btnBooking, "btnBooking");
            this.btnBooking.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnPayment
            // 
            resources.ApplyResources(this.btnPayment, "btnPayment");
            this.btnPayment.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnCancelBooking
            // 
            resources.ApplyResources(this.btnCancelBooking, "btnCancelBooking");
            this.btnCancelBooking.ForeColor = System.Drawing.Color.Indigo;
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ForeColor = System.Drawing.Color.MediumOrchid;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBookingId
            // 
            resources.ApplyResources(this.txtBookingId, "txtBookingId");
            this.txtBookingId.Name = "txtBookingId";
            this.txtBookingId.ReadOnly = true;
            // 
            // frmRoom
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.txtBookingId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(lbRoom);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRoom";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDNumber;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnBooking;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox txtPricePer;
        private System.Windows.Forms.MaskedTextBox txtMaxPerson;
        private System.Windows.Forms.TextBox txtBookingId;
    }
}