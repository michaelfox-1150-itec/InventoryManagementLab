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
        
        


        public frmInventory()
        {
            InitializeComponent();
            // Create form, generates a listview box with two columns that represent the name of a product
            // and the quantity value for each product added.
            lstItems.View = View.Details;
            lstItems.Columns.Add("Product");
            lstItems.Columns.Add("Quantity");
            lstItems.Items.Add(new ListViewItem(new string[] { "Shirt", "12"}));
            lstItems.Items.Add(new ListViewItem(new string[] { "Pants", "15" }));
            lstItems.Items.Add(new ListViewItem(new string[] { "Shoes", "3" }));
            
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        { // Close button function, closes the form.
          
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { // Button function for adding a product to the ListView.
          // String, Double and Bool values declared for data validation.
          // Two if-else-elseif checks, first checks for empty text box for product name
          // second checks for a valid numerical value.
            string quantityValue = txtQuantity.Text;
            double validQuantity;
            bool isValid = double.TryParse(quantityValue, out validQuantity);
            if (txtNewProduct.Text == "")
            { // If nothing is entered in the product textbox, shows message declaring one needs to be added.
                MessageBox.Show("Please enter a valid product name.", 
                            "No Product Declared");
                txtNewProduct.Focus();
            }

            else if (isValid == false)
            { // If a valid numerical parse is not present, shows message box declaring such.
                MessageBox.Show("Please enter a valid numeric quantity.",
                                "Invalid quantity.");
                txtQuantity.Focus();
            }
             // Valid entries in both text boxes allows add function to continue.
             // Adds product/quantity pairing into listview box.
            else{
            lstItems.Items.Add(new ListViewItem(new string[] { txtNewProduct.Text, txtQuantity.Text }));
            txtNewProduct.Clear();
            txtQuantity.Clear();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        { // Removes item(s) in listview based on click selection and executed by pressing the remove button.
            foreach(ListViewItem item in lstItems.SelectedItems)
            {
                item.Remove();
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string editProduct = txtNewProduct.Text;
            string editQuantity = txtQuantity.Text;

            
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {

        }

        private void txtNewProduct_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        }
    }

