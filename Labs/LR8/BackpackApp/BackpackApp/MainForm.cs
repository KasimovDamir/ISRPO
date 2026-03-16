using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackpackApp.Database;
using BackpackApp.Debugging;
using BackpackApp.Models;
using BackpackApp.Solver;

namespace BackpackApp
{
    public partial class MainForm : Form
    {
        private List<Item> originalItems;
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            listViewBackpack.View = View.Details;
            listViewBackpack.FullRowSelect = true;
            listViewBackpack.GridLines = true;

            listViewBackpack.Columns.Add("Название", 150);
            listViewBackpack.Columns.Add("Вес", 70);
            listViewBackpack.Columns.Add("Стоимость", 100);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DatabaseHelper.InitializeDatabase();

            originalItems = DatabaseHelper.GetItems();

            ShowItems(originalItems);
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            DebugLogger.Log("Нажата кнопка Решить");

            int maxWeight;

            if (!int.TryParse(textBoxWeight.Text, out maxWeight))
            {
                MessageBox.Show("Введите корректный вес", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Решение приведено в таблице!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DebugLogger.LogItems(originalItems, "Исходные данные");
            DebugLogger.Log($"Максимальный вес рюкзака: {maxWeight}");

            using (new ExecutionTimer("Решение задачи о рюкзаке"))
            {
                var result = knapsackSolver.Solve(originalItems, maxWeight);

                DebugLogger.LogItems(result, "Результат решения");

                ShowItems(result);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ShowItems(originalItems);
        }

        private void ShowItems(List<Item> items)
        {
            listViewBackpack.Items.Clear();

            foreach (var item in items)
            {
                ListViewItem row = new ListViewItem(item.Name);
                row.SubItems.Add(item.Weight.ToString());
                row.SubItems.Add(item.Cost.ToString());

                listViewBackpack.Items.Add(row);
            }

            DebugLogger.Log($"Отображено {items.Count} предметов");
        }
    }
}
