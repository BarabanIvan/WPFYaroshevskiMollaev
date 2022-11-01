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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=10.128.14.53\SQLEXPRESS;
                                Persist Security Info=True;
                                User ID=user22;
                                Password=wsruser22");
        SqlCommand sqlCommand;
        CBClass cBClass;

        public AddUserWindow()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoleCb.SelectedIndex < 0)
            {
                MBClass.ErrorMB("Выберите роль");

            }
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert Into " +
                    "ddbo.[User] (LoginUser, PasswordUser, IdRole) " +
                    $"Values ({LoginTb.Text},{PasswordTb.Text}, " +
                    $"{RoleCb.SelectedValue.ToString()})", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                MBClass.InformationMB("Успех!");
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.LoadCBRole(RoleCb);
        }
    }
    }

