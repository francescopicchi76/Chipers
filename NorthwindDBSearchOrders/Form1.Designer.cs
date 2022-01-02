
namespace NorthwindDBSearchOrders
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.orderIDTB = new System.Windows.Forms.TextBox();
            this.orderDatefromDTP = new System.Windows.Forms.DateTimePicker();
            this.productNameCB = new System.Windows.Forms.ComboBox();
            this.employeeNameCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.shipperNameCB = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.orderDateToDTP = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(295, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "SEARCH ORDERS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search by order ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Search by order date FROM:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Search by product name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Search by shipper name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Search by employee last name:";
            // 
            // orderIDTB
            // 
            this.orderIDTB.Location = new System.Drawing.Point(301, 81);
            this.orderIDTB.Name = "orderIDTB";
            this.orderIDTB.Size = new System.Drawing.Size(266, 22);
            this.orderIDTB.TabIndex = 6;
            this.orderIDTB.TextChanged += new System.EventHandler(this.orderIDTB_TextChanged);
            // 
            // orderDatefromDTP
            // 
            this.orderDatefromDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.orderDatefromDTP.Location = new System.Drawing.Point(301, 129);
            this.orderDatefromDTP.Name = "orderDatefromDTP";
            this.orderDatefromDTP.Size = new System.Drawing.Size(151, 22);
            this.orderDatefromDTP.TabIndex = 7;
            this.orderDatefromDTP.Value = new System.DateTime(2022, 1, 2, 0, 0, 0, 0);
            this.orderDatefromDTP.ValueChanged += new System.EventHandler(this.orderDateFromDTP_ValueChanged);
            // 
            // productNameCB
            // 
            this.productNameCB.FormattingEnabled = true;
            this.productNameCB.Location = new System.Drawing.Point(301, 225);
            this.productNameCB.Name = "productNameCB";
            this.productNameCB.Size = new System.Drawing.Size(266, 24);
            this.productNameCB.TabIndex = 9;
            this.productNameCB.SelectedIndexChanged += new System.EventHandler(this.productNameCB_SelectedIndexChanged);
            // 
            // employeeNameCB
            // 
            this.employeeNameCB.FormattingEnabled = true;
            this.employeeNameCB.Location = new System.Drawing.Point(301, 275);
            this.employeeNameCB.Name = "employeeNameCB";
            this.employeeNameCB.Size = new System.Drawing.Size(266, 24);
            this.employeeNameCB.TabIndex = 10;
            this.employeeNameCB.SelectedIndexChanged += new System.EventHandler(this.employeeNameCB_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button1.Location = new System.Drawing.Point(716, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 66);
            this.button1.TabIndex = 11;
            this.button1.Text = "START SEARCH";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 334);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(837, 223);
            this.dataGridView1.TabIndex = 12;
            // 
            // shipperNameCB
            // 
            this.shipperNameCB.FormattingEnabled = true;
            this.shipperNameCB.Location = new System.Drawing.Point(301, 175);
            this.shipperNameCB.Name = "shipperNameCB";
            this.shipperNameCB.Size = new System.Drawing.Size(266, 24);
            this.shipperNameCB.TabIndex = 13;
            this.shipperNameCB.SelectedIndexChanged += new System.EventHandler(this.shipperNameCB_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(716, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 36);
            this.button2.TabIndex = 14;
            this.button2.Text = "RESET";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(552, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 15;
            // 
            // orderDateToDTP
            // 
            this.orderDateToDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.orderDateToDTP.Location = new System.Drawing.Point(533, 129);
            this.orderDateToDTP.Name = "orderDateToDTP";
            this.orderDateToDTP.Size = new System.Drawing.Size(151, 22);
            this.orderDateToDTP.TabIndex = 16;
            this.orderDateToDTP.Value = new System.DateTime(2022, 1, 2, 12, 28, 24, 0);
            this.orderDateToDTP.ValueChanged += new System.EventHandler(this.orderDateToDTP_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(479, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "TO:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 583);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.orderDateToDTP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.shipperNameCB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.employeeNameCB);
            this.Controls.Add(this.productNameCB);
            this.Controls.Add(this.orderDatefromDTP);
            this.Controls.Add(this.orderIDTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SearchOrders";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox orderIDTB;
        private System.Windows.Forms.DateTimePicker orderDatefromDTP;
        private System.Windows.Forms.ComboBox productNameCB;
        private System.Windows.Forms.ComboBox employeeNameCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox shipperNameCB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker orderDateToDTP;
        private System.Windows.Forms.Label label8;
    }
}

