using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajmaUloomUlIslamia
{
    public partial class editReceiptRecord : Form
    {
        private string receiptNumber;
        private string type;
        private string transactionDate;
        private int dakhlaNumber;

        
        public editReceiptRecord()
        {
            InitializeComponent();
        }

        public string ReceiptNumber
        {
            get
            {
                return receiptNumber;
            }

            set
            {
                receiptNumber = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string TransactionDate
        {
            get
            {
                return transactionDate;
            }

            set
            {
                transactionDate = value;
            }
        }

        public int DakhlaNumber
        {
            get
            {
                return dakhlaNumber;
            }

            set
            {
                dakhlaNumber = value;
            }
        }

        private void editReceiptRecord_Load(object sender, EventArgs e)
        {
            receiptNumberLabelER.Text = ReceiptNumber.ToString();
            if(type.Equals("STUDENT FEE"))
            {
                otherFeePanel.Visible = false;
                newStuddentPanel.Visible = false;
                List<List<string>> studentTypeRecords = DataManipulation.getStudentTypeReceiptRecord(receiptNumber);
                
                foreach (List<string> studentTypeRecord in studentTypeRecords)
                {
                    int columnCount = 0;
                    string feeType = "";
                    foreach(String record in studentTypeRecord)
                    {
                        if(columnCount == 0)
                        {
                            checkedCheckbox(record);
                            feeType = record;
                        }

                        if(columnCount == 1)
                        {
                            transactionYearTB.Text = record;
                        }

                        if(columnCount == 2)
                        {
                            checkedCheckbox(record);
                        }

                        if(columnCount == 3)
                        {
                            if(feeType.Equals("DAKHLA FEE"))
                            {
                                dakhlaFeeTB.Text = record;
                            }
                            else if(feeType.Equals("COURSE FEE"))
                            {
                                courseFeeTB.Text = record;
                            }
                            else if(feeType.Equals("MONTHLY FEE"))
                            {
                                monthlyFeeTB.Text = record;
                            }
                        }

                        columnCount++;
                    }
                }
            }
            else if(type.Equals("OTHER"))
            {
                monthlyFeePanel.Visible = false;
                newStuddentPanel.Visible = false;
                otherCB.Checked = true;
                newStudentCB.Visible = false;
                List<string> otherTypeRecord = DataManipulation.getOtherTypeReceiptRecord(receiptNumber);
                transactionAmountTB.Text = otherTypeRecord[0];
                transactionYearTB.Text = otherTypeRecord[1];
            }
        }

        private void updateReceipt_Click(object sender, EventArgs e)
        {
            if(type.Equals("OTHER"))
            {
                double transactionAmount = Double.Parse(transactionAmountTB.Text);
                string transactionYear = transactionYearTB.Text;
                DataManipulation.updateOtherTypeReceiptRecord(transactionAmount, transactionYear, receiptNumber);
                MessageBox.Show("Data Updated Successfully");
                this.Close();
                
            }

            if(type.Equals("STUDENT FEE"))
            {
                //if (newStudentCB.Checked == false && otherCB.Checked == false)
                //{
                //    List<string> months = getCheckedMonths();
                //    double monthlyFee = Double.Parse(monthlyFeeTB.Text);
                //    string studentFeeYear = transactionYearTB.Text;
                //    string studentFeeType = "MONTHLY FEE";
                //    try
                //    {
                //        double transactionAmount = submitMonthlyFees(months, monthlyFee, studentFeeYear, receiptNumber, studentFeeType, transactionDate, dakhlaNumber);
                //        if (!transactionAmount.Equals(0.0))
                //        {
                //            //DataManipulation.doTransaction(studentFeeYear, transactionAmount, slipNumber, "STUDENT FEE", studentFeeDate);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.ToString());
                //    }
                //    LandingPage newPage = new LandingPage();
                //    this.Hide();
                //    newPage.Show();
                //    newPage.mainTab.SelectedIndex = 6;

                //}
            }
        }

        //private double submitMonthlyFees(List<String> months, double monthlyFee, string studentFeeYear, string slipNumber, string studentFeeType, string studentFeeDate, int dakhlaNumber)
        //{
        //    //Boolean flag = false;
        //    double transactionAmount = 0.0;
        //    foreach (string month in months)
        //    {
        //        Boolean status = DataManipulation.submitMonthlyfee(month, monthlyFee, studentFeeYear, slipNumber, studentFeeType, studentFeeDate, dakhlaNumber);
        //        if (status)
        //        {
        //            transactionAmount += monthlyFee;
        //            //flag = true;
        //            MessageBox.Show("کی فیس جمع ہو گئی ہے۔ " + month);
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    //if (flag)
        //    //{
        //    //    return transactionAmount;
        //    //    //DataManipulation.doTransaction(studentFeeYear, transactionAmount, slipNumber, "STUDENT FEE", studentFeeDate);
        //    //    //DataManipulation.updateReceipt();
        //    //}

        //    return transactionAmount;
        //}

        private void checkedCheckbox(string month)
        {
            switch (month)
            {
                case "JANUARY":
                    monthJan.Checked = true;
                    break;
                case "FEBRUARY":
                    monthFab.Checked = true;
                    break;
                case "MARCH":
                    monthMarch.Checked = true;
                    break;
                case "APRIL":
                    monthApr.Checked = true;
                    break;
                case "MAY":
                    monthMay.Checked = true;
                    break;
                case "JUNE":
                    monthJune.Checked = true;
                    break;
                case "JULY":
                    monthJuly.Checked = true;
                    break;
                case "AUGUST":
                    monthAug.Checked = true;
                    break;
                case "SEPTEMBER":
                    monthSept.Checked = true;
                    break;
                case "OCTOBER":
                    monthOct.Checked = true;
                    break;
                case "NOVEMBER":
                    monthNov.Checked = true;
                    break;
                case "DECEMBER":
                    monthDec.Checked = true;
                    break;
                case "DAKHLA FEE":
                    newStuddentPanel.Visible = true;
                    newStudentCB.Checked = true;
                    break;
                case "COURSE FEE":
                    newStuddentPanel.Visible = true;
                    newStudentCB.Checked = true;
                    break;
                case "MONTHLY FEE":
                    
                    break;
            }
        }

        private List<string> getCheckedMonths()
        {
            List<string> months = new List<string>();

            if (monthJan.Checked == true)
            {
                months.Add("JANUARY");
            }

            if (monthFab.Checked == true)
            {
                months.Add("FEBRUARY");
            }

            if (monthMarch.Checked == true)
            {
                months.Add("MARCH");
            }

            if (monthApr.Checked == true)
            {
                months.Add("APRIL");
            }

            if (monthMay.Checked == true)
            {
                months.Add("MAY");
            }

            if (monthJune.Checked == true)
            {
                months.Add("JUNE");
            }

            if (monthJuly.Checked == true)
            {
                months.Add("JULY");
            }

            if (monthAug.Checked == true)
            {
                months.Add("AUGUST");
            }

            if (monthSept.Checked == true)
            {
                months.Add("SEPTEMBER");
            }

            if (monthOct.Checked == true)
            {
                months.Add("OCTOBER");
            }

            if (monthNov.Checked == true)
            {
                months.Add("NOVEMBER");
            }

            if (monthDec.Checked == true)
            {
                months.Add("DECEMBER");
            }

            return months;
        }
    }
}
