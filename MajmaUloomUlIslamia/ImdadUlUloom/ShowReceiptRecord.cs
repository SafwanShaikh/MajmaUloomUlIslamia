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
    public partial class ShowReceiptRecord : Form
    {
        private string receiptNumber;
        private string type;
        
        public ShowReceiptRecord()
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

        private void ShowReceiptRecord_Load(object sender, EventArgs e)
        {
            if(type.Equals("OTHER"))
            {
                List<string> otherTypeRecord = DataManipulation.getOtherTypeReceiptRecord(receiptNumber);
                showSlipGridView.Rows.Add(1);
                showSlipGridView.Rows[0].Cells[0].Value = otherTypeRecord[0];
                showSlipGridView.Rows[0].Cells[1].Value = otherTypeRecord[1];
                showSlipGridView.Rows[0].Cells[2].Value = otherTypeRecord[2];
                showSlipGridView.Rows[0].Cells[3].Value = otherTypeRecord[3];
                showSlipGridView.Rows[0].Cells[4].Value = otherTypeRecord[4];
                showSlipGridView.Rows[0].Cells[5].Value = otherTypeRecord[5];
            }
            else
            {
                List<List<string>> studentTypeRecords = DataManipulation.getStudentTypeReceiptRecord(receiptNumber);
                if (studentTypeRecords.Count > 0)
                {
                    showSlipGridView.Rows.Add(studentTypeRecords.Count);
                    int row = 0;
                    foreach (List<string> bookRecord in studentTypeRecords)
                    {
                        int column = 0;
                        foreach (string record in bookRecord)
                        {
                            showSlipGridView.Rows[row].Cells[column].Value = record;
                            column++;
                        }
                        row++;
                    }
                }
            }
        }

        private void editReceiptRecord_Click(object sender, EventArgs e)
        {
            EditReceiptRecord editReceipt = new EditReceiptRecord();
            editReceipt.Id = Convert.ToInt32(showSlipGridView.SelectedRows[0].Cells[0].Value);
            editReceipt.Amount = showSlipGridView.SelectedRows[0].Cells[4].Value.ToString();
            if(!type.Equals("OTHER"))
            {
                editReceipt.Month = showSlipGridView.SelectedRows[0].Cells[7].Value.ToString();
            }
            editReceipt.Type = type;
            editReceipt.ReceiptNumber = ReceiptNumber;
            editReceipt.Year = showSlipGridView.SelectedRows[0].Cells[5].Value.ToString();
            editReceipt.Show();
            this.Close();
        }
    }
}
