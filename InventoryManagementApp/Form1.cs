using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            lstItems.Columns.Add("Quantity");
            lstItems.Columns.Add("Product");
            //lstItems.Items.Add(new ListViewItem(new string[] { "12", "Shirt"}));
            // lstItems.Items.Add(new ListViewItem(new string[] { "15", "Pants" }));
            // lstItems.Items.Add(new ListViewItem(new string[] { "3", "Shoes" }));
            
        }

        private void lstItems_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
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
            lstItems.Items.Add(new ListViewItem(new string[] { txtQuantity.Text, txtNewProduct.Text }));
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
           //Edit button function that edits the values of the listview item selected and replaces them with the textbox values. 
           try
            {
                lstItems.SelectedItems[0].SubItems[1].Text = txtNewProduct.Text;
                lstItems.SelectedItems[0].SubItems[0].Text = txtQuantity.Text;
            }
            catch { }

            
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {

        }

        private void txtNewProduct_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {  //Save listview data to embedded .txt file.
            MessageBox.Show("Are you sure you want to save these changes?", "Save",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (MessageBox.Show("Are you sure you want to save these changes?", "Save",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var tw = new StreamWriter(@"C:\\Users\Mike\Source\repos\inventorymanagementlab\inventorymanagementapp\resources\textfile1.txt"))
                {
                    foreach (ListViewItem item in lstItems.Items)
                    {
                        tw.WriteLine(item.Text);
                    }
                }

            }
            
        }
      }
    }
    

