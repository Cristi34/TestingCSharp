using CustomerLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCustomerUI
{
    public partial class fCustomerScreen : Form
    {
        public fCustomerScreen()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerBase custbase = null;
            if (cbCustomerType.SelectedIndex == 0)
            {
                custbase = new Lead();
            }
            else
            {
                custbase = new Customer();
            }
            custbase.CustomerName = tbCustomerName.Text;
            custbase.Address = rtbAddress.Text;
            custbase.PhoneNumber = tbPhoneNumber.Text;
            custbase.BillDate = Convert.ToDateTime(tbBillDate.Text);
            custbase.BillAmount = Convert.ToDecimal(tbBillAmount.Text);
        }
    }
}
