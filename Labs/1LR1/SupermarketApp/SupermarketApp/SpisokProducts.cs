using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SupermarketApp
{
    public partial class SpisokProducts : Form
    {
        private string connectionString = @"Data Source=LUM1E\SQLLUM1E;Initial Catalog=ProductsBD;Integrated Security=True";
        private List<Product> products = new List<Product>();
        public SpisokProducts()
        {
            InitializeComponent();
            LoadProducts();
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        private void LoadProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name, price FROM products";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    products.Clear();
                    comboBoxProducts.Items.Clear();

                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        };
                        products.Add(product);
                        comboBoxProducts.Items.Add($"{product.Name} - {product.Price} руб.");
                    }
                    reader.Close();

                    if (comboBoxProducts.Items.Count > 0)
                        comboBoxProducts.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}\n\nПроверьте подключение к БД.",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedIndex >= 0 && comboBoxProducts.SelectedIndex < products.Count)
            {
                Product selectedProduct = products[comboBoxProducts.SelectedIndex];
                listAddProducts.Items.Add($"{selectedProduct.Name} - {selectedProduct.Price} руб.");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listAddProducts.Items.Clear();
            textBoxResult.Clear();
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (var item in listAddProducts.Items)
            {
                string itemText = item.ToString();
                int priceStart = itemText.LastIndexOf("-") + 1;
                int priceEnd = itemText.IndexOf("руб.") - 1;

                if (priceStart > 0 && priceEnd > priceStart)
                {
                    string priceText = itemText.Substring(priceStart, priceEnd - priceStart).Trim();
                    if (decimal.TryParse(priceText, out decimal price))
                    {
                        total += price;
                    }
                }
            }

            textBoxResult.Text = total.ToString("F2") + " руб.";
        }
    }
}
