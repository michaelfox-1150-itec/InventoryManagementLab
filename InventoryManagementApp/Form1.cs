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
            lstItems.Items.Add(new ListViewItem(new string[] { txtNewProduct.Text, txtQuantity.Text }));
            txtNewProduct.Clear();
            txtQuantity.Clear();
            
          
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
            ListViewItem item = lstItems.SelectedItems[0];
            item.SubItems[0].Text = editProduct;
            item.SubItems[1].Text = editQuantity;


        }
    }
}
