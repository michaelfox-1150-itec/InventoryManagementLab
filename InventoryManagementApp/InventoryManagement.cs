// This program tracks inventory data and allows for updates.
// Group #4
// Mark Fox, Jarid Wagner, Michael Fox
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
        // Creates initial list of products in an array.
        string[] items = { "T-Shirt", "Jeans", "Socks" };
        


        public frmInventory()
        {
            InitializeComponent();
            // Initializes listview properties and content.
            lstItems.View = View.Details;
            lstItems.Columns.Add("Product");
            lstItems.Columns.Add("Quantity");
            lstItems.Items.Add(new ListViewItem(new string[] { "Shirt", "12"}));
            lstItems.Items.Add(new ListViewItem(new string[] { "Pants", "15" }));
            lstItems.Items.Add(new ListViewItem(new string[] { "Shoes", "3" }));
            // Selects whole row instead of first column
            lstItems.FullRowSelect = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Closes program.
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Adds exception handling
            try
            {
                // Checks if inputs are valid
                if (isThere(txtNewProduct, "Product", lblProduct) == true && isThere(txtQuantity, "Quantity", lblQuantity) == true)
                    if (isGoodData(txtQuantity, "Quantity", lblQuantity) == true)
                    {
                    // Adds listview entry with textbox values
                    lstItems.Items.Add(new ListViewItem(new string[] { txtNewProduct.Text, txtQuantity.Text }));
                    // Clears textboxes
                    txtNewProduct.Clear();
                    txtQuantity.Clear();
                    }
            }
            // Catch for unknown exceptions
            catch (Exception)
            {
                MessageBox.Show("An error has occurred.", "Error");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Loops through selected listview items and removes them.
            foreach (ListViewItem item in lstItems.SelectedItems)
            {
                item.Remove();
            }           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Adds exception handling
            try
            {
                // Checks if inputs are valid
                if (isThere(txtNewProduct, "Product", lblProduct) == true && isThere(txtQuantity, "Quantity", lblQuantity) == true)
                    if (isGoodData(txtQuantity, "Quantity", lblQuantity) == true)
                    {
                    // Converts textbox values to strings
                    string editProduct = txtNewProduct.Text;
                    string editQuantity = txtQuantity.Text;
                    // Sets variable for selected listview item
                    ListViewItem item = lstItems.SelectedItems[0];
                    // Updates subitems of selected item
                    item.SubItems[0].Text = editProduct;
                    item.SubItems[1].Text = editQuantity;
                    }
            }
            // Catch for unselected item
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an item to edit.", "No item selected");
            }

            // Catch for unknown exceptions
            catch (Exception)
            {
                MessageBox.Show("An error has occurred.", "Error");
            }
        }

        private bool isThere (TextBox vtextbox, string vname, Label vlabel)
        {
            // Checks if textbox is empty or not
            if (vtextbox.Text == "")
            {
                MessageBox.Show(vname + " is empty. Try again.", "Missing Entry");
                vtextbox.Focus();
                wrong(vlabel);
                return false;
            }
            correct(vlabel);
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

        private bool isGoodData(TextBox vtextbox, string vname, Label vlabel)
        {
            // Checks the validity of the input.
            if (!isNumber(vtextbox, vname))
            {
                wrong(vlabel);
                return false;
            }
            if (!isGoodRange(vtextbox, vname))
            {
                wrong(vlabel);
                return false;
            }
            correct(vlabel);
            return true;
        }
        private void correct(Label vlabel)
        {
            // Adds checkmark to label and formats.
            vlabel.Text = "\u2714";
            vlabel.ForeColor = System.Drawing.Color.Green;
        }

        private void wrong(Label vlabel)
        {
            // Adds X to label and formats.
            vlabel.Text = "\uAB57";
            vlabel.ForeColor = System.Drawing.Color.Red;
        }

    }
}

