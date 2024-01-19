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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SignUpPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            char[] arr = { '@', '!', '#', '$', '%', '^', '&' };

            string ran = arr.ToString();


            if (pswdBox.Password.Length < 8 && !pswdBox.Password.Contains(ran))
            {
                MessageBox.Show("You need to enter your password!");
            }
            else if (txtFName.Text == "")
            {
                MessageBox.Show("You have to enter your first name!");
            }
            else if (txtLName.Text == "")
            {
                MessageBox.Show("You have to enter your last name!");
            }
            else if (!txtEmail.Text.Contains('@'))
            {
                MessageBox.Show("You have to enter a valid email address!");
            }
            else
            {
                MessageBox.Show($"Success! Your username is: {txtUsername.Text}, and your password is {pswdBox.Password}");
            }

            SqlConnection conn = new SqlConnection(sqlCon);

            try
            {
                conn.Open();
                string query = $"Insert into Credentials_table(Username, FirstName, LastName, Email, Password) values " +
                    $"('{txtUsername.Text}', '{txtFName.Text}', '{txtLName.Text}', '{txtEmail.Text}', '{pswdBox.Password}')";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success! It works fine!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void usernameClear(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
        }

        private void firstNameClear(object sender, RoutedEventArgs e)
        {
            txtFName.Text = "";
        }

        private void lastNameClear(object sender, RoutedEventArgs e)
        {
            txtLName.Text = "";
        }

        private void emailClear(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = "";
        }


        string sqlCon = @"Data Source=LAB108PC18\SQLEXPRESS; Initial Catalog=SignUp; Integrated Security=True;";

        private void Delete(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);

            try
            {
                conn.Open();
                string query = $"DELETE FROM Credentials_table WHERE Username='{txtUsername.Text}'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success! It works fine!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);

            try
            {
                conn.Open();
                string query = $"UPDATE Credentials_table SET FirstName='{txtFName.Text}', LastName='{txtLName.Text}', Email='{txtEmail.Text}', " +
                                $"Password='{pswdBox.Password}' WHERE Username='{txtUsername.Text}'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success! It works fine!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
        }

