namespace MajmaUloomUlIslamia
{
    partial class StudentMonthlyFeePage
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.monthlyFeeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Alvi Nastaleeq", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "ماہانہ فیس";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("1 MUHAMMADI QURANIC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(81, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 37);
            this.textBox1.TabIndex = 1;
            // 
            // monthlyFeeButton
            // 
            this.monthlyFeeButton.BackColor = System.Drawing.Color.Navy;
            this.monthlyFeeButton.Font = new System.Drawing.Font("Alvi Nastaleeq", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlyFeeButton.ForeColor = System.Drawing.Color.White;
            this.monthlyFeeButton.Location = new System.Drawing.Point(112, 203);
            this.monthlyFeeButton.Name = "monthlyFeeButton";
            this.monthlyFeeButton.Size = new System.Drawing.Size(97, 49);
            this.monthlyFeeButton.TabIndex = 2;
            this.monthlyFeeButton.Text = "محفوظ کیجئے";
            this.monthlyFeeButton.UseVisualStyleBackColor = false;
            // 
            // StudentMonthlyFeePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(318, 300);
            this.Controls.Add(this.monthlyFeeButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentMonthlyFeePage";
            this.Text = "ماہانہ فیس";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button monthlyFeeButton;
    }
}