using System;
using System.Collections.Generic;
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

            char[] arr = {'@', '!', '#', '$', '%', '^', '&'};

            string ran = arr.ToString();


            if (pswdBox.Password.Length < 8 && !pswdBox.Password.Contains(ran))
            {
                MessageBox.Show("You need to enter your password!");
            }
            else if (txtFName.Text=="")
            {
                MessageBox.Show("You have to enter your first name!");
            }
            else if (txtLName.Text=="")
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
    }
}
