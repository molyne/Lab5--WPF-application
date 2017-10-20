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

namespace Lab5__WPF_application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

     

            List<User> user = new List<User>
            {
               //new User("Molyn", "molyn@gmail.com"),
               //new User("Camilla", "camilla@hotmail.com"),
               //new User("John", "john@gmail.com"),
               //new User("Silvio", "silvio@hotmail.com"),
               //new User("Sylvester","sylvester@gmail.com")

            };

            List<User> administrator = new List<User>
            {
                //new User("Ragnar","ragnar@hotmail.com"),
                //new User("Ulla-Bella", "ub@gmail.com")
            };


        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {

            UserList.Items.Add(new User(WriteUserName.Text,WriteEmail.Text));
        }

    }
}
