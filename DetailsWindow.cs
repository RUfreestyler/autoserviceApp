using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoserviceAppication
{
    /// <summary>
    /// Form with information about details
    /// </summary>
    public class DetailsWindow : Form
    {
        private DataGridView dataGridView;
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
        public DetailsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configures the form
        /// </summary>
        public void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(834, 461);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            this.dataGridView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            // 
            // DetailsWindow
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.dataGridView);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "DetailsWindow";
            this.Load += new System.EventHandler(this.DetailsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Loads data from database into the table when creating the window
        /// </summary>
        public void LoadData()
        {
            try
            {
                sqlAdapter = new MySqlDataAdapter("SELECT *,'Delete' AS `Command` FROM details",MainForm.DataBase.GetConnection());
                sqlBuilder = new MySqlCommandBuilder(sqlAdapter);
                sqlBuilder.GetDeleteCommand();
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                dataSet = new DataSet();
                sqlAdapter.Fill(dataSet, "details");
                dataGridView.DataSource = dataSet.Tables["details"];
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
                dataSet.Tables["details"].Clear();
                sqlAdapter.Fill(dataSet, "details");
                dataGridView.DataSource = dataSet.Tables["details"];
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
        /// Loads the data when the form is loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DetailsWindow_Load(object sender, EventArgs e)
        {
            LoadData();
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
                if(e.ColumnIndex == lastColumn)
                {
                    string task = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();

                    if(task == "Delete")
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView.Rows.RemoveAt(rowIndex);
                        dataSet.Tables["details"].Rows[rowIndex].Delete();
                        sqlAdapter.Update(dataSet, "details");
                    } 
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView.Rows.Count - 2;
                        DataRow row = dataSet.Tables["details"].NewRow();
                        row["detail_producer"] = dataGridView.Rows[rowIndex].Cells["detail_producer"].Value;
                        row["detail_name"] = dataGridView.Rows[rowIndex].Cells["detail_name"].Value;
                        row["detail_description"] = dataGridView.Rows[rowIndex].Cells["detail_description"].Value;
                        row["detail_amount"] = dataGridView.Rows[rowIndex].Cells["detail_amount"].Value;
                        row["detail_price"] = dataGridView.Rows[rowIndex].Cells["detail_price"].Value;
                        dataSet.Tables["details"].Rows.Add(row);
                        dataSet.Tables["details"].Rows.RemoveAt(dataSet.Tables["details"].Rows.Count - 1);
                        dataGridView.Rows.RemoveAt(dataGridView.Rows.Count - 2);
                        dataGridView.Rows[e.RowIndex].Cells[lastColumn].Value = "Delete";
                        sqlAdapter.Update(dataSet, "details");
                        newRowAdding = false;
                    } 
                    else if (task == "Update")
                    {
                        int rowIndex = e.RowIndex;
                        dataSet.Tables["details"].Rows[rowIndex]["detail_producer"] = dataGridView.Rows[rowIndex].Cells["detail_producer"].Value;
                        dataSet.Tables["details"].Rows[rowIndex]["detail_name"] = dataGridView.Rows[rowIndex].Cells["detail_name"].Value;
                        dataSet.Tables["details"].Rows[rowIndex]["detail_description"] = dataGridView.Rows[rowIndex].Cells["detail_description"].Value;
                        dataSet.Tables["details"].Rows[rowIndex]["detail_amount"] = dataGridView.Rows[rowIndex].Cells["detail_amount"].Value;
                        dataSet.Tables["details"].Rows[rowIndex]["detail_price"] = dataGridView.Rows[rowIndex].Cells["detail_price"].Value;
                        sqlAdapter.Update(dataSet, "details");
                        dataGridView.Rows[e.RowIndex].Cells[6].Value = "Delete";
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
        /// Change the cell value to "Insert" when the user adds a new row 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if(newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridView.Rows.Count - 2;
                    var row = dataGridView.Rows[lastRow];
                    dataGridView[lastColumn, lastRow] = new DataGridViewLinkCell();
                    row.Cells["Command"].Value = "Insert";
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Ошибка добавления строки!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(newRowAdding == false)
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
            if(dataGridView.CurrentCell.ColumnIndex == 4 || dataGridView.CurrentCell.ColumnIndex == 5)
            {
                var textBox = e.Control as TextBox;
                if(textBox != null)
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
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
