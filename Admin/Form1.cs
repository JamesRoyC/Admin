using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Admin
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"
                Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\Documents\AdminDatabase.accdb;
                Persist Security Info=False; ";                        

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                checkConnection.Text = "Connection Successful";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection; 

            command.CommandText = " select * from UserData where username='" + txt_User.Text + "' and password='"+txt_Pass.Text+"'";

            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if(count == 1)
            {
                MessageBox.Show("Username and password is correct ");
            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate username and pass");
            }
            else
            {
                MessageBox.Show("user pass not correct");
            }
            connection.Close();
        }
    }
}
