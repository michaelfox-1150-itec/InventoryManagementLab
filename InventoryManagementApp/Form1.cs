using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementApp
{
    public partial class frmInventory : Form
    {
        string[] items = { "T-Shirt", "Jeans", "Socks" };
        


        public frmInventory()
        {
            InitializeComponent();

            lstItems.View = View.Details;
            lstItems.Columns.Add("Product");
            lstItems.Columns.Add("Quantity");
            lstItems.Items.Add(new ListViewItem(new string[] { "Shirt", "12"}));
            lstItems.Items.Add(new ListViewItem(new string[] { "Pants", "15" }));
            lstItems.Items.Add(new ListViewItem(new string[] { "Shoes", "3" }));
            // Selects whole row instead of first column
            lstItems.FullRowSelect = true;
            txtNewProduct.Focus();
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (isThere(txtNewProduct, "Product") == true && isGoodData(txtQuantity, "Quantity") == true)
                {
                    lstItems.Items.Add(new ListViewItem(new string[] { txtNewProduct.Text, txtQuantity.Text }));
                    txtNewProduct.Clear();
                    txtQuantity.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occurred.", "Error");
            }

            
          
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lstItems.SelectedItems)
            {
                item.Remove();
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (isThere(txtNewProduct, "Product") == true && isGoodData(txtQuantity, "Quantity") == true)
                {
                    string editProduct = txtNewProduct.Text;
                    string editQuantity = txtQuantity.Text;
                    ListViewItem item = lstItems.SelectedItems[0];
                    item.SubItems[0].Text = editProduct;
                    item.SubItems[1].Text = editQuantity;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an item to edit.", "No item selected");
            }

            catch (Exception)
            {
                MessageBox.Show("An error has occurred.", "Error");
            }
        }

        private bool isThere (TextBox vtextbox, string vname)
        {
            // Checks if textbox is empty or not
            if (vtextbox.Text == "")
            {
                MessageBox.Show(vname + " is empty. Try again.", "Missing Entry");
                vtextbox.Focus();
                return false;
            }
            return true;
        }

        private bool isNumber(TextBox vtextbox, string vname)
        {
            // Checks if textbox value can be converted correctly
            int number = 0;
            if (Int32.TryParse(vtextbox.Text, out number))
                return true;
            else
            {
                MessageBox.Show(vname + " isn't an integer number. Try again.", "Incorrect Entry");
                vtextbox.Focus();
                return false;
            }
        }
        private bool isGoodRange(TextBox vtextbox, string vname, int vmin = 0, int vmax = 500)
        {
            // Checks if textbox value is within the specified range.
            int number = Convert.ToInt32(vtextbox.Text);
            if (number < vmin || number > vmax)
            {
                MessageBox.Show(vname + " needs to be a number " + vmin.ToString() + " - " + vmax.ToString("n0"), "Out of Range");
                vtextbox.Focus();
                return false;
            }
            return true;
        }

        private bool isGoodData (TextBox vtextbox, string vname)
        {
            // Checks the validity of the input.
            if (!isThere(vtextbox,vname))
                return false;
            if (!isNumber(vtextbox, vname))
                return false;
            if (!isGoodRange(vtextbox, vname))
                return false;
            return true;
        }
    }
}

