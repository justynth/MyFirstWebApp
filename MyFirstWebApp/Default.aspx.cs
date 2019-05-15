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
            string queryString = @"INSERT INTO " + tableName + " (" + firstNameColumnHeader + ", " + lastNameColumnHeader + ") " +
                                    "VALUES('"+firstName+"','"+lastName+"');";

            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand(queryString, myConnection);

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