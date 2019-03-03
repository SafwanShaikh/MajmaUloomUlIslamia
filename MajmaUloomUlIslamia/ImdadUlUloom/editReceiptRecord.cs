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
    public partial class EditReceiptRecord : Form
    {

        private String month;
        private String amount;
        private String type;
        private String receiptNumber;
        private int id;
        private String year;


        public string Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }

        public string Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
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

        public String ReceiptNumber
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

        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public EditReceiptRecord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void EditReceiptRecord_Load(object sender, EventArgs e)
        {
            amountER.Text = Amount;
            monthListER.Text = Month;
        }

        private void editRecordBtn_Click(object sender, EventArgs e)
        {
            DataManipulation.updateFeeRecord(Double.Parse(amountER.Text), monthListER.Text, type, id, year);
            if(!type.Equals("OTHER"))
            {
                DataManipulation.updateTransaction(receiptNumber);
            }
            this.Close();

        }
    }
}
