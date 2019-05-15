using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        // Fill in the variables in the connection string and populate the tableName, firstNameColumnHeader, and lastNameColumnHeader variables
        // in order to insert your name into an SQL Server!
        private static string connectionString = "Data Source = ; Inital Catalog = ; User ID = ; Password = ";
        private static string tableName = String.Empty;
        private static string firstNameColumnHeader = String.Empty;
        private static string lastNameColumnHeader = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;

            string result = "Hello " + firstName + " " + lastName;

            //SendToSQLServer(firstName, lastName);

            resultLabel.Text = result;

            firstNameTextBox.Text = String.Empty;
            lastNameTextBox.Text = String.Empty;
        }


        private void SendToSQLServer(string firstName, string lastName)
        {
            /* 
             * This method will allow you to connect to an SQL Server and insert the user input into an SQL database.
             * In order to make this happen you will need to a) find an SQL database b) populate the variables that are
             * declared in the Default class at the top of this page c) uncomment the method call in okButton_Click
            */
            string sqlString = @"INSERT INTO " + tableName + " (" + firstNameColumnHeader + ", " + lastNameColumnHeader + ") " +
                                    "VALUES('"+firstName+"','"+lastName+"');";

            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand(sqlString, myConnection);

            try
            {
                myConnection.Open();
                myCommand.CommandTimeout = 15;

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
            finally
            {
                myConnection.Close();
            }
                
        }
    }
}