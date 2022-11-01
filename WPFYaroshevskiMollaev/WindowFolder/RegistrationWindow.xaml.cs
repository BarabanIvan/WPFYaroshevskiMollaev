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

namespace WPFYaroshevskiMollaev.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=10.128.14.53\SQLEXPRESS;
                                Persist Security Info=True;
                                User ID=user22;
                                Password=wsruser22");
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        public RegistrationWindow()
        {
            InitializeComponent();
        }

    

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string pwd = PasswordTb.Password;
            string zag1 = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string mal = "qwertyuiopasdfghjklzxcvbnm";
            string cif = "1234567890";
            string znak = "!@#$%^&*()_+";

            if(string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Некорректный логин");
                LoginTb.Focus();
            }
            else if(string.IsNullOrWhiteSpace(PasswordTb.Password))
            {
                MBClass.ErrorMB("Некорретный пароль");
                PasswordTb.Focus();
            }
            else if(pwd.Length <6)
                {
                MBClass.ErrorMB("Пароль сликшом короткий " +
                    "не менее 30 символов");
                    PasswordTb.Focus();
            }
            else if(pwd.Length > 30)
            {
                MBClass.ErrorMB("Пароль не должен превышать " +
                    "30 символов");
                PasswordTb.Focus();
            }
            else if(zag1.IndexOfAny(pwd.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать " +
                    "заглавную букву");
                PasswordTb.Focus();
            }
            else if(mal.IndexOfAny(pwd.ToCharArray()) == -1)
                    {
                MBClass.ErrorMB("Пароль должен содержать " +
                    "малую букву");
                PasswordTb.Focus();
            }
            else if (cif.IndexOfAny(pwd.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать " +
                    "цифру");
                PasswordTb.Focus();
            }
            else if (znak.IndexOfAny(pwd.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Долже содержать хотя " +
                    $"бы один из символов из: {znak}");
                PasswordTb.Focus();
            }
            else if(string.IsNullOrWhiteSpace(PasswordTbs.Password))
            {
                MBClass.ErrorMB("Введите повторно пароль");
                PasswordTbs.Focus();
            }
            else if(PasswordTbs.Password != PasswordTb.Password)
            {
                MBClass.ErrorMB("Пароли не совпадают");
                PasswordTbs.Focus();
                PasswordTb.Focus();
            }
            else
            {
                try
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert Into dbo.[User]  " +
                        "(LoginUser,PasswordUser,IdRole) Values " +
                        "(@LoginUser,@PasswordUser,@IdRole)",sqlConnection);
                    sqlCommand.Parameters.AddWithValue("LoginUser", LoginTb.Text);
                    sqlCommand.Parameters.AddWithValue("PasswordUser", PasswordTb.Password);
                    sqlCommand.Parameters.AddWithValue("IdRole", 3);
                    sqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB("Вы успешно зарегистрировались");
                }
                catch(Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }


        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
