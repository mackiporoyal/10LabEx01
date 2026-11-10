using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10LabExercise1
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;

        private BindingSource showProductList;
        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = {
        "Beverages",
        "Bread/Bakery",
        "Canned/Jarred Goods",
        "Dairy",
        "Frozen Goods",
        "Meat",
        "Personal Care",
        "Other"
    };
            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);

                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));

                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = null;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "String Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductName.Focus();
                txtProductName.Clear();
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Number Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                txtQuantity.Clear();
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Currency Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSellPrice.Focus();
                txtSellPrice.Clear();
            }
            finally
            {
            }
            
        }
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
                throw new StringFormatException("Invalid Product Name! Only letters are allowed.");
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]+$"))
                throw new NumberFormatException("Invalid Quantity! Only numeric values are allowed.");
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price, @"^(\d*\.)?\d+$"))
                throw new CurrencyFormatException("Invalid Selling Price! Please enter a valid decimal number.");
            return Convert.ToDouble(price);
        }
    }
}
