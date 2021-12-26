using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoserviceAppication
{
    /// <summary>
    /// Form with information about employees
    /// </summary>
    public partial class EmployeesWindow : Form
    {
        private MySqlDataAdapter sqlAdapter;
        private MySqlCommandBuilder sqlBuilder;
        private DataSet dataSet;
        private bool newRowAdding = false;

        /// <summary>
        /// Parent form
        /// </summary>
        public MainWindow MainForm { get; set; }
        private int lastColumn = 6;

        /// <summary>
        /// Configures the form
        /// </summary>
        public EmployeesWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads data from database into the table when creating the window
        /// </summary>
        public void LoadData()
        {
            try
            {
                sqlAdapter = new MySqlDataAdapter("SELECT *,'Delete' AS `Command` FROM employees", MainForm.DataBase.GetConnection());
                sqlBuilder = new MySqlCommandBuilder(sqlAdapter);
                sqlBuilder.GetDeleteCommand();
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                dataSet = new DataSet();
                sqlAdapter.Fill(dataSet, "employees");
                dataGridView.DataSource = dataSet.Tables["employees"];
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView[lastColumn, i] = new DataGridViewLinkCell();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates the data in the window
        /// </summary>
        public void ReloadData()
        {
            try
            {
                dataSet.Tables["employees"].Clear();
                sqlAdapter.Fill(dataSet, "employees");
                dataGridView.DataSource = dataSet.Tables["employees"];
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView[lastColumn, i] = new DataGridViewLinkCell();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка загрузки!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Change the cell value to "Insert" when the user adds a new row 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridView.Rows.Count - 2;
                    var row = dataGridView.Rows[lastRow];
                    dataGridView[6, lastRow] = new DataGridViewLinkCell();
                    row.Cells["Command"].Value = "Insert";
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Ошибка добавления строки!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Implement the editing of information in the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == lastColumn)
                {
                    string task = dataGridView.Rows[e.RowIndex].Cells[lastColumn].Value.ToString();

                    if (task == "Delete")
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["employees"].Rows[rowIndex].Delete();
                        sqlAdapter.Update(dataSet, "employees");
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView.Rows.Count - 2;
                        DataRow row = dataSet.Tables["employees"].NewRow();
                        row["name"] = dataGridView.Rows[rowIndex].Cells["name"].Value;
                        row["position"] = dataGridView.Rows[rowIndex].Cells["position"].Value;
                        row["salary"] = dataGridView.Rows[rowIndex].Cells["salary"].Value;
                        row["age"] = dataGridView.Rows[rowIndex].Cells["age"].Value;
                        row["phone"] = dataGridView.Rows[rowIndex].Cells["phone"].Value;
                        dataSet.Tables["employees"].Rows.Add(row);
                        dataSet.Tables["employees"].Rows.RemoveAt(dataSet.Tables["employees"].Rows.Count - 1);
                        dataGridView.Rows.RemoveAt(dataGridView.Rows.Count - 2);
                        dataGridView.Rows[e.RowIndex].Cells[lastColumn].Value = "Delete";
                        sqlAdapter.Update(dataSet, "employees");
                        newRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int rowIndex = e.RowIndex;
                        dataSet.Tables["employees"].Rows[rowIndex]["name"] = dataGridView.Rows[rowIndex].Cells["name"].Value;
                        dataSet.Tables["employees"].Rows[rowIndex]["position"] = dataGridView.Rows[rowIndex].Cells["position"].Value;
                        dataSet.Tables["employees"].Rows[rowIndex]["salary"] = dataGridView.Rows[rowIndex].Cells["salary"].Value;
                        dataSet.Tables["employees"].Rows[rowIndex]["age"] = dataGridView.Rows[rowIndex].Cells["age"].Value;
                        dataSet.Tables["employees"].Rows[rowIndex]["phone"] = dataGridView.Rows[rowIndex].Cells["phone"].Value;
                        sqlAdapter.Update(dataSet, "employees");
                        dataGridView.Rows[e.RowIndex].Cells[lastColumn].Value = "Delete";
                    }
                    ReloadData();
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Ошибка удаления!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Change the cell value to "Update" when the user changed a row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                    var editingRow = dataGridView.Rows[rowIndex];
                    dataGridView[lastColumn, rowIndex] = new DataGridViewLinkCell();
                    editingRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Prohibits the introduction of letters and other symbols into cells intended for the introduction of numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dataGridView.CurrentCell.ColumnIndex == 3 || dataGridView.CurrentCell.ColumnIndex == 4)
            {
                var textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        /// <summary>
        /// Registers button clicks by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Loads the data when the form is loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EmployeesWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
