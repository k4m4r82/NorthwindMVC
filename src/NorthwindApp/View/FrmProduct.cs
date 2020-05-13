using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NorthwindApp.Model.Entity;
using NorthwindApp.Controller;

namespace NorthwindApp.View
{
    public partial class FrmProduct : Form, IBaseView<Product>
    {
        private readonly ProductController _controller;
        private IList<Product> _listOfProduct = new List<Product>();

        public FrmProduct()
        {
            InitializeComponent();
            InisialisasiListView();

            _controller = new ProductController(this);
            _controller.LoadData();
        }

        private void InisialisasiListView()
        {            
            lvwProduct.View = System.Windows.Forms.View.Details;
            lvwProduct.FullRowSelect = true;
            lvwProduct.GridLines = true;

            lvwProduct.Columns.Add("No.", 40, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Product name", 400, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Quantity per unit", 150, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Unit price", 80, HorizontalAlignment.Right);
            lvwProduct.Columns.Add("Unit in stock", 80, HorizontalAlignment.Right);
        }

        private void FillToListView(bool addData, Product product)
        {
            if (addData)
            {
                var noUrut = lvwProduct.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(product.product_name);
                item.SubItems.Add(product.qty_per_unit);
                item.SubItems.Add(product.unit_price.ToString());
                item.SubItems.Add(product.unit_in_stock.ToString());

                lvwProduct.Items.Add(item);
                _listOfProduct.Add(product);
            }
            else
            {
                var row = lvwProduct.SelectedIndices[0];

                var itemRow = lvwProduct.Items[row];
                itemRow.SubItems[1].Text = product.product_name;
                itemRow.SubItems[2].Text = product.qty_per_unit;
                itemRow.SubItems[3].Text = product.unit_price.ToString();
                itemRow.SubItems[4].Text = product.unit_in_stock.ToString();
            }
        }        

        private void btnTambah_Click(object sender, EventArgs e)
        {
            var frmEntry = new FrmEntry(_controller);
            frmEntry.ShowDialog();
        }

        private void btnPerbaiki_Click(object sender, EventArgs e)
        {
            if (lvwProduct.SelectedItems.Count > 0)
            {
                var row = lvwProduct.SelectedIndices[0];
                var product = _listOfProduct[row];

                var frmEntry = new FrmEntry(product, _controller);
                frmEntry.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwProduct.SelectedItems.Count > 0)
            {
                var row = lvwProduct.SelectedIndices[0];
                var product = _listOfProduct[row];

                string msg = "Apakah data product '" + product.product_name + "' ingin dihapus ?";
                if (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    _controller.Delete(product);
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih");
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        # region implement abstract method interface IBaseView

        public void OnLoadData(IList<Product> list)
        {
            lvwProduct.Items.Clear();

            foreach (var product in list)
            {
                FillToListView(true, product);
            }
        }               

        public void OnSaved(Product obj)
        {
            FillToListView(true, obj);
        }

        public void OnUpdated(Product obj)
        {
            FillToListView(false, obj);
        }

        public void OnDeleted(Product obj)
        {
            var row = lvwProduct.SelectedIndices[0];
            var itemRow = lvwProduct.Items[row];

            _listOfProduct.Remove(obj);            
            lvwProduct.Items.Remove(itemRow);

            // refresh no urut
            var noUrut = 1;
            foreach (ListViewItem item in lvwProduct.Items)
            {
                item.Text = noUrut.ToString();
                noUrut++;
            }
        }

        public void OnFailed(string msg)
        {
            MessageBox.Show(msg);
        }

        #endregion

    }
}
