using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGrocery;

namespace Grocery_Queuing_System
{
    public partial class frmPOS : Form
    {
        int queue = 1;
        double overallPrice = 0;
        double cash = 0;
        double change = 0;

        Transaction tr = new Transaction();

        public frmPOS()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = new Product(txtName.Text, cmbType.Text, double.Parse(txtPrice.Text));
                Transaction trans = new Transaction(prod, Convert.ToInt32(Quantity.Value));

                overallPrice += trans.getTotalPrice();
                lblTotalPrice.Text = trans.getTotalPrice().ToString();
                lblQueu.Text = queue++.ToString();
                lblOverall.Text = overallPrice.ToString();

                MessageBox.Show("You ordered " + txtName.Text + "\n Price: " + txtPrice.Text
                    + "\n Quantity: " + Quantity.Value,
                "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Input all fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPrice.Clear();
            cmbType.ResetText();
            Quantity.ResetText();
            lblTotalPrice.ResetText();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }

        private void frmPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Close the System?", "Message",
             MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtCash.Text != "")
            {

                if (cash < overallPrice)
                {
                    cash = double.Parse(txtCash.Text);

                    overallPrice += tr.getTotalPrice();
                    change = cash - overallPrice;
                    lblChange.Text = change.ToString();

                    MessageBox.Show("Your change is " + lblChange.Text, "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Give exact amount of cash", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCash.Clear();
                    txtCash.Focus();
                }
            }
            else
            {
                MessageBox.Show("Input a cash", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCash.Focus();
            }
        }
    }
}
