using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineApp
{
    public partial class MainForm : Form
    {
        private LineDatabase _lineDb;
        public MainForm()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = -1;

            _lineDb = new LineDatabase();
            _lineDb.Initialize();

            lineGridView.DataSource = _lineDb.Lines;
        }

        private void onlyPositive_Click(object sender, EventArgs e) {
            lineGridView.DataSource = _lineDb.Lines.Where(x => x.Point1.x > 0 && x.Point1.y > 0 && x.Point2.x > 0 && x.Point2.y > 0).ToList();
        }

        private void resetButton_Click(object sender, EventArgs e) {
            lineGridView.DataSource = _lineDb.Lines;
            comboBox1.SelectedIndex = -1;
            searchTextBox.Text = string.Empty;

        }

        private void sortButton_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex == 0){
                lineGridView.DataSource = _lineDb.Lines
                    .OrderBy(x => x.Point1.x)
                    .ThenBy(x => x.Point2.x)
                    .ThenBy(x => x.Point1.y)
                    .ThenBy(x => x.Point2.y).ToList();
            }
            else {
                lineGridView.DataSource = _lineDb.Lines
                    .OrderByDescending(x => x.Point1.x)
                    .ThenByDescending(x => x.Point2.x)
                    .ThenByDescending(x => x.Point1.y)
                    .ThenByDescending(x => x.Point2.y).ToList();
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e) {
            lineGridView.DataSource = _lineDb.Lines.Where(x =>
                x.Point1.ToString().Contains(searchTextBox.Text)
                || x.Point2.ToString().Contains(searchTextBox.Text)
            ).ToList();
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = (!char.IsNumber(e.KeyChar)
                && e.KeyChar != '\b')
                || e.KeyChar == '/'
                || e.KeyChar == '*'
                || e.KeyChar == ','
                || e.KeyChar == '.'
                || e.KeyChar == '+';
        }
    }
}
