using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;

namespace autoserviceAppication
{
    /// <summary>
    /// Form for adding a new card
    /// </summary>
    public class AddCardWindow : Form
    {
        private TextBox markBox;
        private Label markLabel;
        private TextBox modelBox;
        private Label modelLabel;
        private TextBox licensePlateBox;
        private Label licensePlateLabel;
        private TextBox clientNameBox;
        private Label clientNameLabel;
        private TextBox clientPhoneBox;
        private Label clientPhoneLabel;
        private Label problemDescriptionLabel;
        private Button addCardButton;
        private RichTextBox problemDescriptionBox;

        /// <summary>
        /// Parent form
        /// </summary>
        public MainWindow MainForm { get; set; }
        
        /// <summary>
        /// Configures the form
        /// </summary>
        public AddCardWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configures the form
        /// </summary>
        public void InitializeComponent()
        {
            this.markBox = new System.Windows.Forms.TextBox();
            this.markLabel = new System.Windows.Forms.Label();
            this.modelBox = new System.Windows.Forms.TextBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.licensePlateBox = new System.Windows.Forms.TextBox();
            this.licensePlateLabel = new System.Windows.Forms.Label();
            this.clientNameBox = new System.Windows.Forms.TextBox();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.clientPhoneBox = new System.Windows.Forms.TextBox();
            this.clientPhoneLabel = new System.Windows.Forms.Label();
            this.problemDescriptionLabel = new System.Windows.Forms.Label();
            this.addCardButton = new System.Windows.Forms.Button();
            this.problemDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // markBox
            // 
            this.markBox.Location = new System.Drawing.Point(12, 32);
            this.markBox.Name = "markBox";
            this.markBox.Size = new System.Drawing.Size(100, 20);
            this.markBox.TabIndex = 0;
            // 
            // markLabel
            // 
            this.markLabel.AutoSize = true;
            this.markLabel.Location = new System.Drawing.Point(12, 16);
            this.markLabel.Name = "markLabel";
            this.markLabel.Size = new System.Drawing.Size(62, 13);
            this.markLabel.TabIndex = 1;
            this.markLabel.Text = "Марка т/с:";
            // 
            // modelBox
            // 
            this.modelBox.Location = new System.Drawing.Point(177, 31);
            this.modelBox.Name = "modelBox";
            this.modelBox.Size = new System.Drawing.Size(100, 20);
            this.modelBox.TabIndex = 2;
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(177, 16);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(68, 13);
            this.modelLabel.TabIndex = 3;
            this.modelLabel.Text = "Модель т/с:";
            // 
            // licensePlateBox
            // 
            this.licensePlateBox.Location = new System.Drawing.Point(365, 31);
            this.licensePlateBox.Name = "licensePlateBox";
            this.licensePlateBox.Size = new System.Drawing.Size(100, 20);
            this.licensePlateBox.TabIndex = 4;
            // 
            // licensePlateLabel
            // 
            this.licensePlateLabel.AutoSize = true;
            this.licensePlateLabel.Location = new System.Drawing.Point(362, 16);
            this.licensePlateLabel.Name = "licensePlateLabel";
            this.licensePlateLabel.Size = new System.Drawing.Size(63, 13);
            this.licensePlateLabel.TabIndex = 5;
            this.licensePlateLabel.Text = "Гос.номер:";
            // 
            // clientNameBox
            // 
            this.clientNameBox.Location = new System.Drawing.Point(12, 103);
            this.clientNameBox.Name = "clientNameBox";
            this.clientNameBox.Size = new System.Drawing.Size(100, 20);
            this.clientNameBox.TabIndex = 6;
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.AutoSize = true;
            this.clientNameLabel.Location = new System.Drawing.Point(12, 87);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Size = new System.Drawing.Size(81, 13);
            this.clientNameLabel.TabIndex = 7;
            this.clientNameLabel.Text = "ФИО клиента:";
            // 
            // clientPhoneBox
            // 
            this.clientPhoneBox.Location = new System.Drawing.Point(177, 103);
            this.clientPhoneBox.Name = "clientPhoneBox";
            this.clientPhoneBox.Size = new System.Drawing.Size(100, 20);
            this.clientPhoneBox.TabIndex = 8;
            // 
            // clientPhoneLabel
            // 
            this.clientPhoneLabel.AutoSize = true;
            this.clientPhoneLabel.Location = new System.Drawing.Point(177, 87);
            this.clientPhoneLabel.Name = "clientPhoneLabel";
            this.clientPhoneLabel.Size = new System.Drawing.Size(140, 13);
            this.clientPhoneLabel.TabIndex = 9;
            this.clientPhoneLabel.Text = "Номер телефона клиента:";
            // 
            // problemDescriptionLabel
            // 
            this.problemDescriptionLabel.AutoSize = true;
            this.problemDescriptionLabel.Location = new System.Drawing.Point(12, 158);
            this.problemDescriptionLabel.Name = "problemDescriptionLabel";
            this.problemDescriptionLabel.Size = new System.Drawing.Size(115, 13);
            this.problemDescriptionLabel.TabIndex = 11;
            this.problemDescriptionLabel.Text = "Описание проблемы:";
            // 
            // addCardButton
            // 
            this.addCardButton.Location = new System.Drawing.Point(420, 246);
            this.addCardButton.Name = "addCardButton";
            this.addCardButton.Size = new System.Drawing.Size(150, 23);
            this.addCardButton.TabIndex = 12;
            this.addCardButton.Text = "Добавить запись";
            this.addCardButton.UseVisualStyleBackColor = true;
            this.addCardButton.Click += new System.EventHandler(this.addCardButton_Click);
            // 
            // problemDescriptionBox
            // 
            this.problemDescriptionBox.Location = new System.Drawing.Point(15, 175);
            this.problemDescriptionBox.Name = "problemDescriptionBox";
            this.problemDescriptionBox.Size = new System.Drawing.Size(262, 74);
            this.problemDescriptionBox.TabIndex = 13;
            this.problemDescriptionBox.Text = "";
            // 
            // AddCardWindow
            // 
            this.ClientSize = new System.Drawing.Size(584, 281);
            this.Controls.Add(this.problemDescriptionBox);
            this.Controls.Add(this.addCardButton);
            this.Controls.Add(this.problemDescriptionLabel);
            this.Controls.Add(this.clientPhoneLabel);
            this.Controls.Add(this.clientPhoneBox);
            this.Controls.Add(this.clientNameLabel);
            this.Controls.Add(this.clientNameBox);
            this.Controls.Add(this.licensePlateLabel);
            this.Controls.Add(this.licensePlateBox);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.modelBox);
            this.Controls.Add(this.markLabel);
            this.Controls.Add(this.markBox);
            this.MaximumSize = new System.Drawing.Size(600, 320);
            this.MinimumSize = new System.Drawing.Size(600, 320);
            this.Name = "AddCardWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Adds new card to database and updates the card list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void addCardButton_Click(object sender, EventArgs e)
        {
            var db = new DataBase();
            db.OpenConnection();
            var command = new MySqlCommand("INSERT INTO cards(`mark`,`model`,`license_plate`,`client_name`,`client_phonenumber`,`problem_description`) VALUES(@mark,@model,@licensePlate,@clientName,@clientPhonenumber,@problemDescription);", db.GetConnection());
            command.Parameters.Add("@mark", MySqlDbType.Text).Value = markBox.Text;
            command.Parameters.Add("@model", MySqlDbType.Text).Value = modelBox.Text;
            command.Parameters.Add("@licensePlate", MySqlDbType.Text).Value = licensePlateBox.Text;
            command.Parameters.Add("@clientName", MySqlDbType.Text).Value = clientNameBox.Text;
            command.Parameters.Add("@clientPhonenumber", MySqlDbType.Text).Value = clientPhoneBox.Text;
            command.Parameters.Add("@problemDescription", MySqlDbType.Text).Value = problemDescriptionBox.Text;
            command.ExecuteNonQuery();
            MainForm.UpdateShortCards();
        }
    }
}
