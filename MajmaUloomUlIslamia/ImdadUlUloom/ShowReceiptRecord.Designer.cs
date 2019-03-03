namespace MajmaUloomUlIslamia
{
    partial class ShowReceiptRecord
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
            this.showSlipGridView = new System.Windows.Forms.DataGridView();
            this.editReceiptRecord = new System.Windows.Forms.Button();
            this.feeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slipNumberRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionTypeRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionAmountRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionYearRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeTypeRB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.showSlipGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // showSlipGridView
            // 
            this.showSlipGridView.AllowUserToAddRows = false;
            this.showSlipGridView.AllowUserToDeleteRows = false;
            this.showSlipGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.showSlipGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.showSlipGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showSlipGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.feeId,
            this.slipNumberRB,
            this.transactionTypeRB,
            this.transactionDateRB,
            this.transactionAmountRB,
            this.transactionYearRB,
            this.feeTypeRB,
            this.feeMonth});
            this.showSlipGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.showSlipGridView.Location = new System.Drawing.Point(62, 24);
            this.showSlipGridView.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.showSlipGridView.MultiSelect = false;
            this.showSlipGridView.Name = "showSlipGridView";
            this.showSlipGridView.ReadOnly = true;
            this.showSlipGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.showSlipGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showSlipGridView.Size = new System.Drawing.Size(746, 280);
            this.showSlipGridView.TabIndex = 75;
            // 
            // editReceiptRecord
            // 
            this.editReceiptRecord.BackColor = System.Drawing.Color.Navy;
            this.editReceiptRecord.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editReceiptRecord.ForeColor = System.Drawing.Color.White;
            this.editReceiptRecord.Location = new System.Drawing.Point(62, 313);
            this.editReceiptRecord.Name = "editReceiptRecord";
            this.editReceiptRecord.Size = new System.Drawing.Size(98, 43);
            this.editReceiptRecord.TabIndex = 76;
            this.editReceiptRecord.Text = "تبدیل کریں";
            this.editReceiptRecord.UseVisualStyleBackColor = false;
            this.editReceiptRecord.Click += new System.EventHandler(this.editReceiptRecord_Click);
            // 
            // feeId
            // 
            this.feeId.HeaderText = "آئی ڈی";
            this.feeId.Name = "feeId";
            this.feeId.ReadOnly = true;
            this.feeId.Width = 50;
            // 
            // slipNumberRB
            // 
            this.slipNumberRB.HeaderText = "رسید نمبر";
            this.slipNumberRB.Name = "slipNumberRB";
            this.slipNumberRB.ReadOnly = true;
            this.slipNumberRB.Width = 50;
            // 
            // transactionTypeRB
            // 
            this.transactionTypeRB.HeaderText = "قسم";
            this.transactionTypeRB.Name = "transactionTypeRB";
            this.transactionTypeRB.ReadOnly = true;
            this.transactionTypeRB.Width = 90;
            // 
            // transactionDateRB
            // 
            this.transactionDateRB.HeaderText = "تاریخ";
            this.transactionDateRB.Name = "transactionDateRB";
            this.transactionDateRB.ReadOnly = true;
            this.transactionDateRB.Width = 90;
            // 
            // transactionAmountRB
            // 
            this.transactionAmountRB.HeaderText = "رقم";
            this.transactionAmountRB.Name = "transactionAmountRB";
            this.transactionAmountRB.ReadOnly = true;
            this.transactionAmountRB.Width = 70;
            // 
            // transactionYearRB
            // 
            this.transactionYearRB.HeaderText = "سال";
            this.transactionYearRB.Name = "transactionYearRB";
            this.transactionYearRB.ReadOnly = true;
            this.transactionYearRB.Width = 50;
            // 
            // feeTypeRB
            // 
            this.feeTypeRB.HeaderText = "فیس کی قسم";
            this.feeTypeRB.Name = "feeTypeRB";
            this.feeTypeRB.ReadOnly = true;
            this.feeTypeRB.Width = 150;
            // 
            // feeMonth
            // 
            this.feeMonth.HeaderText = "مہینہ";
            this.feeMonth.Name = "feeMonth";
            this.feeMonth.ReadOnly = true;
            this.feeMonth.Width = 150;
            // 
            // ShowReceiptRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(864, 368);
            this.Controls.Add(this.editReceiptRecord);
            this.Controls.Add(this.showSlipGridView);
            this.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "ShowReceiptRecord";
            this.Text = "رسید ریکارڈ";
            this.Load += new System.EventHandler(this.ShowReceiptRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showSlipGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView showSlipGridView;
        private System.Windows.Forms.Button editReceiptRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn slipNumberRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionTypeRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionAmountRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionYearRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeTypeRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeMonth;
    }
}