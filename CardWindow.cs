using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.IO.Font;

namespace autoserviceAppication
{
    /// <summary>
    /// Shows a window with a full information about a client
    /// </summary>
    public class CardWindow : Form
    {
        private TextBox markBox;
        private Label markLabel;
        private TextBox modelBox;
        private TextBox licensePlateBox;
        private Label licensePlateLabel;
        private TextBox clientNameBox;
        private Label clientNameLabel;
        private TextBox clientPhoneBox;
        private Label clientPhoneLabel;
        private RichTextBox problemDescriptionBox;
        private Label problemDescriptionLabel;
        private RichTextBox servicesBox;
        private Label servicesLabel;
        private RichTextBox detailsBox;
        private Label detailsLabel;
        private TextBox employeeNameBox;
        private Label employeeNameLabel;
        private Button finishButton;
        private Button updateButton;
        private Button createReceiptButton;
        private Label modelLabel;

        /// <summary>
        /// Parent form 
        /// </summary>
        public MainWindow MainForm { get; set; }

        /// <summary>
        /// Entity of client
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Configures the form
        /// </summary>
        /// <param name="customer"></param>
        public CardWindow(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
        }

        /// <summary>
        /// Initialize a window
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
            this.problemDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.problemDescriptionLabel = new System.Windows.Forms.Label();
            this.servicesBox = new System.Windows.Forms.RichTextBox();
            this.servicesLabel = new System.Windows.Forms.Label();
            this.detailsBox = new System.Windows.Forms.RichTextBox();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.employeeNameBox = new System.Windows.Forms.TextBox();
            this.employeeNameLabel = new System.Windows.Forms.Label();
            this.finishButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.createReceiptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // markBox
            // 
            this.markBox.Location = new System.Drawing.Point(12, 37);
            this.markBox.Name = "markBox";
            this.markBox.Size = new System.Drawing.Size(100, 20);
            this.markBox.TabIndex = 0;
            // 
            // markLabel
            // 
            this.markLabel.AutoSize = true;
            this.markLabel.Location = new System.Drawing.Point(9, 21);
            this.markLabel.Name = "markLabel";
            this.markLabel.Size = new System.Drawing.Size(43, 13);
            this.markLabel.TabIndex = 1;
            this.markLabel.Text = "Марка:";
            // 
            // modelBox
            // 
            this.modelBox.Location = new System.Drawing.Point(193, 37);
            this.modelBox.Name = "modelBox";
            this.modelBox.Size = new System.Drawing.Size(100, 20);
            this.modelBox.TabIndex = 2;
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(190, 21);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(49, 13);
            this.modelLabel.TabIndex = 3;
            this.modelLabel.Text = "Модель:";
            // 
            // licensePlateBox
            // 
            this.licensePlateBox.Location = new System.Drawing.Point(380, 37);
            this.licensePlateBox.Name = "licensePlateBox";
            this.licensePlateBox.Size = new System.Drawing.Size(100, 20);
            this.licensePlateBox.TabIndex = 4;
            // 
            // licensePlateLabel
            // 
            this.licensePlateLabel.AutoSize = true;
            this.licensePlateLabel.Location = new System.Drawing.Point(380, 21);
            this.licensePlateLabel.Name = "licensePlateLabel";
            this.licensePlateLabel.Size = new System.Drawing.Size(63, 13);
            this.licensePlateLabel.TabIndex = 5;
            this.licensePlateLabel.Text = "Гос.номер:";
            // 
            // clientNameBox
            // 
            this.clientNameBox.Location = new System.Drawing.Point(12, 91);
            this.clientNameBox.Name = "clientNameBox";
            this.clientNameBox.Size = new System.Drawing.Size(100, 20);
            this.clientNameBox.TabIndex = 6;
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.AutoSize = true;
            this.clientNameLabel.Location = new System.Drawing.Point(9, 75);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Size = new System.Drawing.Size(58, 13);
            this.clientNameLabel.TabIndex = 7;
            this.clientNameLabel.Text = "Заказчик:";
            // 
            // clientPhoneBox
            // 
            this.clientPhoneBox.Location = new System.Drawing.Point(193, 90);
            this.clientPhoneBox.Name = "clientPhoneBox";
            this.clientPhoneBox.Size = new System.Drawing.Size(100, 20);
            this.clientPhoneBox.TabIndex = 8;
            // 
            // clientPhoneLabel
            // 
            this.clientPhoneLabel.AutoSize = true;
            this.clientPhoneLabel.Location = new System.Drawing.Point(193, 75);
            this.clientPhoneLabel.Name = "clientPhoneLabel";
            this.clientPhoneLabel.Size = new System.Drawing.Size(111, 13);
            this.clientPhoneLabel.TabIndex = 9;
            this.clientPhoneLabel.Text = "Телефон заказчика:";
            // 
            // problemDescriptionBox
            // 
            this.problemDescriptionBox.Location = new System.Drawing.Point(12, 218);
            this.problemDescriptionBox.Name = "problemDescriptionBox";
            this.problemDescriptionBox.Size = new System.Drawing.Size(617, 82);
            this.problemDescriptionBox.TabIndex = 10;
            this.problemDescriptionBox.Text = "";
            // 
            // problemDescriptionLabel
            // 
            this.problemDescriptionLabel.AutoSize = true;
            this.problemDescriptionLabel.Location = new System.Drawing.Point(12, 202);
            this.problemDescriptionLabel.Name = "problemDescriptionLabel";
            this.problemDescriptionLabel.Size = new System.Drawing.Size(115, 13);
            this.problemDescriptionLabel.TabIndex = 11;
            this.problemDescriptionLabel.Text = "Описание проблемы:";
            // 
            // servicesBox
            // 
            this.servicesBox.Location = new System.Drawing.Point(12, 336);
            this.servicesBox.Name = "servicesBox";
            this.servicesBox.Size = new System.Drawing.Size(617, 86);
            this.servicesBox.TabIndex = 12;
            this.servicesBox.Text = "";
            // 
            // servicesLabel
            // 
            this.servicesLabel.AutoSize = true;
            this.servicesLabel.Location = new System.Drawing.Point(12, 320);
            this.servicesLabel.Name = "servicesLabel";
            this.servicesLabel.Size = new System.Drawing.Size(46, 13);
            this.servicesLabel.TabIndex = 13;
            this.servicesLabel.Text = "Услуги:";
            // 
            // detailsBox
            // 
            this.detailsBox.Location = new System.Drawing.Point(12, 460);
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.Size = new System.Drawing.Size(617, 89);
            this.detailsBox.TabIndex = 14;
            this.detailsBox.Text = "";
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Location = new System.Drawing.Point(12, 444);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(136, 13);
            this.detailsLabel.TabIndex = 15;
            this.detailsLabel.Text = "Использованные детали:";
            // 
            // employeeNameBox
            // 
            this.employeeNameBox.Location = new System.Drawing.Point(12, 155);
            this.employeeNameBox.Name = "employeeNameBox";
            this.employeeNameBox.Size = new System.Drawing.Size(100, 20);
            this.employeeNameBox.TabIndex = 16;
            // 
            // employeeNameLabel
            // 
            this.employeeNameLabel.AutoSize = true;
            this.employeeNameLabel.Location = new System.Drawing.Point(9, 139);
            this.employeeNameLabel.Name = "employeeNameLabel";
            this.employeeNameLabel.Size = new System.Drawing.Size(54, 13);
            this.employeeNameLabel.TabIndex = 17;
            this.employeeNameLabel.Text = "Механик:";
            // 
            // finishButton
            // 
            this.finishButton.BackColor = System.Drawing.Color.Tomato;
            this.finishButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.finishButton.Location = new System.Drawing.Point(554, 588);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 18;
            this.finishButton.Text = "Завершить";
            this.finishButton.UseVisualStyleBackColor = false;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(460, 588);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 19;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // createReceiptButton
            // 
            this.createReceiptButton.AutoSize = true;
            this.createReceiptButton.Location = new System.Drawing.Point(368, 588);
            this.createReceiptButton.Name = "createReceiptButton";
            this.createReceiptButton.Size = new System.Drawing.Size(79, 23);
            this.createReceiptButton.TabIndex = 20;
            this.createReceiptButton.Text = "Создать чек";
            this.createReceiptButton.UseVisualStyleBackColor = true;
            this.createReceiptButton.Click += new System.EventHandler(this.createReceiptButton_Click);
            // 
            // CardWindow
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(644, 624);
            this.Controls.Add(this.createReceiptButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.employeeNameLabel);
            this.Controls.Add(this.employeeNameBox);
            this.Controls.Add(this.detailsLabel);
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.servicesLabel);
            this.Controls.Add(this.servicesBox);
            this.Controls.Add(this.problemDescriptionLabel);
            this.Controls.Add(this.problemDescriptionBox);
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
            this.MinimumSize = new System.Drawing.Size(660, 600);
            this.Name = "CardWindow";
            this.Load += new System.EventHandler(this.CardWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Assigns the "serviced" status to a card and hides it from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void finishButton_Click(object sender, EventArgs e)
        {
            var command = new MySqlCommand("UPDATE `cards` SET `isFinished` = '1' WHERE `cards`.`card_id` = @cardId", MainForm.DataBase.GetConnection());
            command.Parameters.Add("@cardId", MySqlDbType.Byte).Value = Customer.Id;
            command.ExecuteNonQuery();
            MainForm.UpdateShortCards();
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// The values of the fields are updated when loading this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CardWindow_Load(object sender, EventArgs e)
        {
            this.Text = "Card ID: " + Customer.Id.ToString();
            markBox.Text = Customer.Car.Mark;
            modelBox.Text = Customer.Car.Model;
            licensePlateBox.Text = Customer.Car.Number;
            clientNameBox.Text = Customer.Name;
            clientPhoneBox.Text = Customer.Phone;
            problemDescriptionBox.Text = Customer.Problem;
            employeeNameBox.Text = Customer.EmployeeName;
            servicesBox.Text = Customer.Services;
            detailsBox.Text = Customer.Details;
        }

        /// <summary>
        /// When the fields are changed, changed information is sent to the database and updated in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void updateButton_Click(object sender, EventArgs e)
        {
            var command = new MySqlCommand("UPDATE `cards` SET `mark` = @mark, `model` = @model, `license_plate` = @licensePlate, `client_name` = @clientName, `client_phonenumber` = @clientPhone, `problem_description` = @problemDescription, `employee_name` = @employeeName, `services` = @services, `used_details` = @usedDetails WHERE `cards`.`card_id` = @cardId;", MainForm.DataBase.GetConnection());
            command.Parameters.Add("@mark", MySqlDbType.Text).Value = markBox.Text;
            command.Parameters.Add("@model", MySqlDbType.Text).Value = modelBox.Text;
            command.Parameters.Add("@licensePlate", MySqlDbType.Text).Value = licensePlateBox.Text;
            command.Parameters.Add("@clientName", MySqlDbType.Text).Value = clientNameBox.Text;
            command.Parameters.Add("@clientPhone", MySqlDbType.Text).Value = clientPhoneBox.Text;
            command.Parameters.Add("@problemDescription", MySqlDbType.Text).Value = problemDescriptionBox.Text;
            command.Parameters.Add("@employeeName", MySqlDbType.Text).Value = employeeNameBox.Text;
            command.Parameters.Add("@services", MySqlDbType.Text).Value = servicesBox.Text;
            command.Parameters.Add("@usedDetails", MySqlDbType.Text).Value = detailsBox.Text;
            command.Parameters.Add("@cardId", MySqlDbType.Text).Value = Customer.Id;
            command.ExecuteNonQuery();
            MainForm.UpdateShortCards();
        }

        /// <summary>
        /// The receipted is created in a pdf-file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void createReceiptButton_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            var path = "";
            saveDialog.Title = "Сохранить чек";
            saveDialog.Filter = "Text Files(*.pdf)|*.pdf";
            if(saveDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveDialog.FileName;
            }
            var writer = new PdfWriter(path);
            var pdfDocument = new PdfDocument(writer);
            var document = new iText.Layout.Document(pdfDocument);
            var outputStr = string.Format("Клиент: {0}\tТелефон: {1}\n" + 
                "Марка машины: {2}\tМодель машины: {3}\tГос.номер: {4}\n" + 
                "Механик: {5}\n\n\n" + 
                "Описание проблемы:\n" + 
                "{6}\n" + 
                "Предоставленные услуги:\n" + 
                "{7}\n" +
                "Использованные детали:\n" +
                "{8}\n\n\n" +
                "Итоговая цена:",Customer.Name,Customer.Phone,Customer.Car.Mark,Customer.Car.Model,Customer.Car.Number,Customer.EmployeeName,Customer.Problem,Customer.Services,Customer.Details);
            var font = PdfFontFactory.CreateFont("C:\\Windows\\Fonts\\Arial.ttf", PdfEncodings.IDENTITY_H);
            document.Add(new iText.Layout.Element.Paragraph(outputStr).SetFont(font));
            document.Close();
            writer.Close();
        }
    }
}