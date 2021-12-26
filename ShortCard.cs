using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoserviceAppication
{
    /// <summary>
    /// Control for displaying data
    /// </summary>
    public class ShortCard : FlowLayoutPanel
    {
        private TextBox cardIdBox;
        private TextBox markBox;
        private TextBox modelBox;
        private TextBox licensePlateBox;
        private TextBox clientNameBox;
        private Button deleteButton;

        /// <summary>
        /// Parent form
        /// </summary>
        public MainWindow ParentForm { get; set; }

        /// <summary>
        /// Entity of client
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Configures a control
        /// </summary>
        /// <param name="customer"></param>
        public ShortCard(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            SetData();
        }

        /// <summary>
        /// Configures a control
        /// </summary>
        public void InitializeComponent()
        {
            this.deleteButton = new System.Windows.Forms.Button();
            this.cardIdBox = new System.Windows.Forms.TextBox();
            this.markBox = new System.Windows.Forms.TextBox();
            this.modelBox = new System.Windows.Forms.TextBox();
            this.licensePlateBox = new System.Windows.Forms.TextBox();
            this.clientNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Tomato;
            this.deleteButton.Font = new System.Drawing.Font("Roboto", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(109, 123);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 0;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // cardIdBox
            // 
            this.cardIdBox.Font = new System.Drawing.Font("Roboto", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cardIdBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cardIdBox.Location = new System.Drawing.Point(3, 3);
            this.cardIdBox.Name = "cardIdBox";
            this.cardIdBox.ReadOnly = true;
            this.cardIdBox.Size = new System.Drawing.Size(100, 24);
            this.cardIdBox.TabIndex = 0;
            this.cardIdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // markBox
            // 
            this.markBox.Font = new System.Drawing.Font("Roboto", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.markBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.markBox.Location = new System.Drawing.Point(3, 33);
            this.markBox.Name = "markBox";
            this.markBox.ReadOnly = true;
            this.markBox.Size = new System.Drawing.Size(100, 24);
            this.markBox.TabIndex = 0;
            this.markBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // modelBox
            // 
            this.modelBox.Font = new System.Drawing.Font("Roboto", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modelBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.modelBox.Location = new System.Drawing.Point(3, 63);
            this.modelBox.Name = "modelBox";
            this.modelBox.ReadOnly = true;
            this.modelBox.Size = new System.Drawing.Size(100, 24);
            this.modelBox.TabIndex = 0;
            this.modelBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // licensePlateBox
            // 
            this.licensePlateBox.Font = new System.Drawing.Font("Roboto", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.licensePlateBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.licensePlateBox.Location = new System.Drawing.Point(3, 93);
            this.licensePlateBox.Name = "licensePlateBox";
            this.licensePlateBox.ReadOnly = true;
            this.licensePlateBox.Size = new System.Drawing.Size(100, 24);
            this.licensePlateBox.TabIndex = 0;
            this.licensePlateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clientNameBox
            // 
            this.clientNameBox.Font = new System.Drawing.Font("Roboto", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientNameBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clientNameBox.Location = new System.Drawing.Point(3, 123);
            this.clientNameBox.Name = "clientNameBox";
            this.clientNameBox.ReadOnly = true;
            this.clientNameBox.Size = new System.Drawing.Size(100, 24);
            this.clientNameBox.TabIndex = 0;
            this.clientNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // QuickCard
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Green;
            this.Controls.Add(this.cardIdBox);
            this.Controls.Add(this.markBox);
            this.Controls.Add(this.modelBox);
            this.Controls.Add(this.licensePlateBox);
            this.Controls.Add(this.clientNameBox);
            this.Controls.Add(this.deleteButton);
            this.MinimumSize = new System.Drawing.Size(0, 40);
            this.DoubleClick += new System.EventHandler(this.ShortCard_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Sets the field values
        /// </summary>
        public void SetData()
        {
            cardIdBox.Text = "ID: " + Customer.Id.ToString();
            markBox.Text = Customer.Car.Mark;
            modelBox.Text = Customer.Car.Model;
            licensePlateBox.Text = Customer.Car.Number;
            clientNameBox.Text = Customer.Name;
        }

        /// <summary>
        /// Opens a card window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShortCard_DoubleClick(object sender, EventArgs e)
        {
            var cardWindow = new CardWindow(Customer) { MainForm = ParentForm };
            cardWindow.Show();
        }

        /// <summary>
        /// Deletes the card from database and updates short card list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void deleteButton_Click(object sender, EventArgs e)
        {
            var command = new MySqlCommand("DELETE FROM cards WHERE `card_id` = @cardId", ParentForm.DataBase.GetConnection());
            command.Parameters.Add("@cardId", MySqlDbType.Int32).Value = Customer.Id;
            command.ExecuteNonQuery();
            ParentForm.UpdateShortCards();
        }
    }
}
