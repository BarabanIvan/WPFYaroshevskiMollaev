using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFYaroshevskiMollaev.ClassFolder;

namespace WPFYaroshevskiMollaev.WindowFolder.AdminFolder.AddFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=10.128.14.53\SQLEXPRESS;
                                Persist Security Info=True;
                                User ID=user22;
                                Password=wsruser22");
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        CBClass cBClass;
        public AddStaffWindow()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.LoadCBPost(PostCb);
            cBClass.LoadCBRole(RoleCB);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            int idUser = 1;
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand("Insert Into dbo.[User] " +
                    "(LoginUser, PasswordUser, IdRole) " +
                    $" Values ('{LoginTb.Text}','{PasswordTb.Text}', " +
                    $"'{RoleCB.SelectedValue.ToString()}')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("" +
                    "Select IdUser From " +
                    $"dbo.[User] Where " +
                    $"LoginUser='{LoginTb.Text}'",
                    sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                idUser = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert Into dbo.Staff (LastNameStaff " +
                    "FirstNameStaff, MaiddleNameStaff, NumberPhoneStaff, " +
                    "EmailStaff, IdUser) " +
                    $"Values ('{LastName.Text}', '{FirstName.Text}') " +
                    $"'{MiddleNameTb.Text}','{PhN.Text}', " +
                    $"'{Email.Text}','{idUser}')", sqlConnection);

                sqlCommand.ExecuteNonQuery();

                MBClass.InformationMB($"Сотрудник {LastName.Text} {FirstName.Text} " +
                    $"{MiddleNameTb.Text} успешно добавлен");
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
