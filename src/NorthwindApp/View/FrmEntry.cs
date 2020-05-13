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
    public partial class FrmEntry : Form
    {
        private readonly ProductController _controller;        
        private readonly bool _isNewData = true;
        private Product _product;

        public FrmEntry(ProductController controller)
        {
            InitializeComponent();
            this.Text = "Tambah Data Produk";
            lblHeader.Text = this.Text;

            _controller = controller;
        }

        public FrmEntry(Product product, ProductController controller)
        {
            InitializeComponent();
            this.Text = "Edit Data Produk";
            lblHeader.Text = this.Text;

            _isNewData = false;
            _product = product;
            _controller = controller;

            txtProductName.Text = _product.product_name;
            txtQuantityPerUnit.Text = _product.qty_per_unit;
            txtUnitPrice.Text = _product.unit_price.ToString();
            txtUnitInStock.Text = _product.unit_in_stock.ToString();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (_isNewData) _product = new Product();

            var unitPrice = txtUnitPrice.Text.Length == 0 ? 0 : Convert.ToSingle(txtUnitPrice.Text);
            var unitInStock = txtUnitInStock.Text.Length == 0 ? 0 : Convert.ToInt32(txtUnitInStock.Text);

            _product.product_name = txtProductName.Text;
            _product.qty_per_unit = txtQuantityPerUnit.Text;
            _product.unit_price = unitPrice;
            _product.unit_in_stock = unitInStock;

            if (_isNewData)
                _controller.Save(_product);
            else
                _controller.Update(_product);

            this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
