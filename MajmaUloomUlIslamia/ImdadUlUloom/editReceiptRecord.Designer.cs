namespace MajmaUloomUlIslamia
{
    partial class EditReceiptRecord
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
            this.editRecordBtn = new System.Windows.Forms.Button();
            this.monthListER = new System.Windows.Forms.ComboBox();
            this.amountER = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // editRecordBtn
            // 
            this.editRecordBtn.BackColor = System.Drawing.Color.Navy;
            this.editRecordBtn.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editRecordBtn.ForeColor = System.Drawing.Color.White;
            this.editRecordBtn.Location = new System.Drawing.Point(90, 192);
            this.editRecordBtn.Name = "editRecordBtn";
            this.editRecordBtn.Size = new System.Drawing.Size(98, 43);
            this.editRecordBtn.TabIndex = 77;
            this.editRecordBtn.Text = "تبدیل کریں";
            this.editRecordBtn.UseVisualStyleBackColor = false;
            this.editRecordBtn.Click += new System.EventHandler(this.editRecordBtn_Click);
            // 
            // monthListER
            // 
            this.monthListER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.monthListER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.monthListER.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthListER.FormattingEnabled = true;
            this.monthListER.Items.AddRange(new object[] {
            "JANUARY",
            "FEBRUARY",
            "MARCH",
            "APRIL",
            "MAY",
            "JUNE",
            "JULY",
            "AUGUST",
            "SEPTEMBER",
            "OCTOBER",
            "NOVEMBER",
            "DECEMBER"});
            this.monthListER.Location = new System.Drawing.Point(65, 58);
            this.monthListER.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.monthListER.Name = "monthListER";
            this.monthListER.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.monthListER.Size = new System.Drawing.Size(146, 33);
            this.monthListER.TabIndex = 78;
            // 
            // amountER
            // 
            this.amountER.Font = new System.Drawing.Font("Alvi Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountER.Location = new System.Drawing.Point(65, 124);
            this.amountER.Name = "amountER";
            this.amountER.Size = new System.Drawing.Size(146, 33);
            this.amountER.TabIndex = 79;
            this.amountER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EditReceiptRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(285, 290);
            this.Controls.Add(this.amountER);
            this.Controls.Add(this.monthListER);
            this.Controls.Add(this.editRecordBtn);
            this.Name = "EditReceiptRecord";
            this.Text = "تبدیل رسید";
            this.Load += new System.EventHandler(this.EditReceiptRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editRecordBtn;
        private System.Windows.Forms.ComboBox monthListER;
        private System.Windows.Forms.TextBox amountER;
    }
}