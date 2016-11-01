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
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string quantityValue = txtQuantity.Text;
            double validQuantity;
            bool isValid = double.TryParse(quantityValue, out validQuantity);
            if (txtNewProduct.Text == "")
            {
                MessageBox.Show("Please enter a valid product name.", 
                            "No Product Declared");
            txtNewProduct.Focus();
            }

            else if (isValid == false)
            {
                MessageBox.Show("Please enter a valid numeric quantity.",
                                "Invalid quantity.");
            }
            
            else{
            lstItems.Items.Add(new ListViewItem(new string[] { txtNewProduct.Text, txtQuantity.Text }));
            txtNewProduct.Clear();
            txtQuantity.Clear();
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

