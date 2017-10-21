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
            if(WriteUserName.Text !="" && WriteEmail.Text!="")
            UserList.Items.Add(new User(WriteUserName.Text,WriteEmail.Text));
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedIndex >= 0)
            {

                int postition = UserList.SelectedIndex;
                UserList.Items.RemoveAt(postition);

                if (UserList.Items.Count <= postition)
                    UserList.SelectedIndex = postition - 1;
                else
                    UserList.SelectedIndex = postition;
            }
            if (AdminList.SelectedIndex >= 0)
            {

                int postition = AdminList.SelectedIndex;
                AdminList.Items.RemoveAt(postition);

                if (AdminList.Items.Count <= postition)
                    AdminList.SelectedIndex = postition - 1;
                else
                    AdminList.SelectedIndex = postition;
            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool canClick = UserList.SelectedIndex >= 0;
            DeleteUserButton.IsEnabled = canClick;

            ChangeToAdminButton.IsEnabled = canClick;


        }

        private void AdminList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool canClick = AdminList.SelectedIndex >= 0;
            ChangeToUser.IsEnabled = canClick;
            DeleteUserButton.IsEnabled = canClick;
        }

        private void WriteUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (WriteUserName.Text.Contains("Write username") || WriteUserName.Text=="")
                AddUserButton.IsEnabled = false;
            else
                AddUserButton.IsEnabled = true;
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            //När man klickar på den ska den användare i ListBox som är vald uppdateras med nya värden

            


        }

        private void ChangeToAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedIndex >= 0)
            {
               

                var selected = UserList.SelectedItem; // sparar vad man har valt så det inte försvinner när man tar bort det.
                UserList.Items.RemoveAt(UserList.SelectedIndex); 
                AdminList.Items.Add(selected); 

            }
        }

        private void ChangeToUser_Click(object sender, RoutedEventArgs e)
        {
            if (AdminList.SelectedIndex >= 0)
            {
               
                var selected = AdminList.SelectedItem; // sparar vad man har valt så det inte försvinner när man tar bort det.
                AdminList.Items.RemoveAt(AdminList.SelectedIndex);
                UserList.Items.Add(selected);

            }
        }

      
    }
}
