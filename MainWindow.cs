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
    /// Parent form
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Entity of database
        /// </summary>
        public DataBase dataBase = null;

        /// <summary>
        /// List of clients
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Returns database
        /// </summary>
        public DataBase DataBase { get { return dataBase; } }
        
        /// <summary>
        /// Configures the form
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Customers = new List<Customer>();
        }

        /// <summary>
        /// Open a new window with the field for entering information about a new client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void addCardToolMenu_Click(object sender, EventArgs e)
        {
            var cardAddWindow = new AddCardWindow() { MainForm = this };
            cardAddWindow.Show();
        }

        /// <summary>
        /// Updates the information in the window
        /// </summary>
        public void UpdateShortCards()
        {
            dataBase.UpdateData(Customers);
            for (int i = 0; i < cardsPanel.Controls.Count; i++)
            {
                cardsPanel.Controls[i].Hide();
                cardsPanel.Controls[i].Dispose();
            }
            cardsPanel.Controls.Clear();
            for (int i = 0; i < Customers.Count; i++)
            {
                var shortCard = new ShortCard(Customers[i]) { ParentForm = this };
                cardsPanel.Controls.Add(shortCard);
            }
        }

        /// <summary>
        /// Open a new window to display the list of details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowDetailsMenuItem_Click(object sender, EventArgs e)
        {
            var detailsWindow = new DetailsWindow() { MainForm = this };
            detailsWindow.Show();
        }

        /// <summary>
        /// Configures the connection to the database and updates the information in the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_Load(object sender, EventArgs e)
        {
            dataBase = new DataBase();
            dataBase.OpenConnection();
            UpdateShortCards();
        }

        /// <summary>
        /// Open a new window to display the list of employees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowEmployeesMenuItem_Click(object sender, EventArgs e)
        {
            var employeesWindow = new EmployeesWindow() { MainForm = this };
            employeesWindow.Show();
        }
    }
}
