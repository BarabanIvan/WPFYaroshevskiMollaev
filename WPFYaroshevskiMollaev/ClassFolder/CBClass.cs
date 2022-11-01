using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFYaroshevskiMollaev.ClassFolder
{
    class CBClass
    {

        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=10.128.14.48\SQLEXPRESS;
                                Persist Security Info=True;
                                User ID=user22;
                                Password=wsruser22");
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        public void LoadCBRole(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select IdRole, NameRole " +
                    "From dbo.[Role] Order by IdRole ASC", 
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet
                    .Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                    .Tables["[Role]"].Columns["NameRole"].ToString();
                comboBox.SelectedValuePath = dataSet
                    .Tables["[Role]"].Columns["IdRole"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadCBStaff(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select IdStaff, " +
                    "LastNameStaff, FirstNameStaff, MiddleNameStaff, " +
                    "NumberPhoneStaff, OfficeStaff, EmailStaff, " +
                    "IdPost, IdUser " +
                    "From dbo.[Staff] Order by IdStaff ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[Staff]");
                comboBox.ItemsSource = dataSet
                    .Tables["[Staff]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                        .Tables["[Staff]"]
                        .Columns["LastNameStaff"].ToString();
                comboBox.DisplayMemberPath = dataSet
                        .Tables["[Staff]"]
                        .Columns["FirstNameStaff"].ToString();
                comboBox.DisplayMemberPath = dataSet
                        .Tables["[Staff]"]
                        .Columns["MiddleNameStaff"].ToString();
                comboBox.DisplayMemberPath = dataSet
                        .Tables["[Staff]"]
                        .Columns["NumberPhoneStaff"].ToString();
                comboBox.DisplayMemberPath = dataSet
                        .Tables["[Staff]"]
                        .Columns["OfficeStaff"].ToString();
                comboBox.DisplayMemberPath = dataSet
                        .Tables["[Staff]"]
                        .Columns["EmailStaff"].ToString();
                comboBox.SelectedValuePath = dataSet
                        .Tables["[Staff]"]
                        .Columns["IdStaff"].ToString();
                comboBox.SelectedValuePath = dataSet
                        .Tables["[Staff]"]
                        .Columns["IdPost"].ToString();
                comboBox.SelectedValuePath = dataSet
                        .Tables["[Staff]"]
                        .Columns["IdUser"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadCBPost(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter =
                    new SqlDataAdapter("Select IdPost, NamePost " +
                    "From dbo.[Post] Order by IdPost ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[Post]");
                comboBox.ItemsSource = dataSet
                    .Tables["[Post]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                    .Tables["[Post]"].Columns["NamePost"].ToString();
                comboBox.SelectedValuePath = dataSet
                    .Tables["[Post]"].Columns["IdPost"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
