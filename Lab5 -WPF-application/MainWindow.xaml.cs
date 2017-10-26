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
    
        public bool IsTextBoxUserNameValid { get; set; }
        public bool IsTextBoxEmailValid { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            List<User> user = new List<User>();

            List<User> administrator = new List<User>();

            UserInfo.Content = "Username:\nEmail:";
        }
         

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
                List<string> nameList = new List<string>();
                for (int i = 0; i < UserList.Items.Count; i++)
                {
                    nameList.Add(((User)UserList.Items.GetItemAt(i)).UserName);
                    nameList.Add(((User)UserList.Items.GetItemAt(i)).EmailAddress);
                }
                for (int i = 0; i < AdminList.Items.Count; i++)
                {
                    nameList.Add(((User)AdminList.Items.GetItemAt(i)).UserName);
                    nameList.Add(((User)AdminList.Items.GetItemAt(i)).EmailAddress);
                }

            if (!nameList.Contains(WriteUserName.Text) && !nameList.Contains(WriteEmail.Text))
            {
                UserList.Items.Add(new User(WriteUserName.Text, WriteEmail.Text));
                SameUserNameLabel.Content = string.Empty;
                SameEmailLabel.Content = string.Empty;
            }
            else if (nameList.Contains(WriteEmail.Text) && nameList.Contains(WriteUserName.Text))
            {
                SameUserNameLabel.Content = "Username already exists.";
                SameEmailLabel.Content = "Email already exists.";
            }
            else if (nameList.Contains(WriteUserName.Text))
                SameUserNameLabel.Content = "Username already exists.";
            else if (nameList.Contains(WriteEmail.Text))
                SameEmailLabel.Content = "Email already exists.";
           
            WriteUserName.Text = string.Empty;
            WriteUserName.Focus();
            WriteEmail.Text = string.Empty;

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

            WriteUserName.Text = string.Empty;
            WriteEmail.Text = string.Empty;
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserList.SelectedIndex >= 0)
            {
                SameUserNameLabel.Content = string.Empty;
                SameEmailLabel.Content = string.Empty;

                WriteUserName.Text = ((User)UserList.SelectedItem).UserName;
                WriteEmail.Text = ((User)UserList.SelectedItem).EmailAddress;

                if (UserList.SelectedItem != null)
                {
                    UserInfo.Content = "Username: " +

                        ((User)UserList.SelectedItem).UserName + " \nEmail: " + ((User)UserList.SelectedItem).EmailAddress;
                }

            }
            else
                UserInfo.Content = "Username: \nEmail: ";
            
           

                bool UserListSelected = UserList.SelectedIndex >= 0;

            DeleteUserButton.IsEnabled = UserListSelected;
            ChangeToAdminButton.IsEnabled = UserListSelected;
            UpdateUserButton.IsEnabled = UserListSelected;
        }

        private void AdminList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AdminList.SelectedIndex >= 0)
            {
                SameUserNameLabel.Content = string.Empty;
                SameEmailLabel.Content = string.Empty;

                WriteUserName.Text = ((User)AdminList.SelectedItem).UserName;
                WriteEmail.Text = ((User)AdminList.SelectedItem).EmailAddress;

                if (AdminList.SelectedItem != null)
                {
                    UserInfo.Content = "Username: " +

                        ((User)AdminList.SelectedItem).UserName + "\nEmail: " + ((User)AdminList.SelectedItem).EmailAddress;
                }

            }
            else
                UserInfo.Content = "Username: \nEmail:";

            

            bool AdminListSelected = AdminList.SelectedIndex >= 0;
            ChangeToUser.IsEnabled = AdminListSelected;
            DeleteUserButton.IsEnabled = AdminListSelected;
            UpdateUserButton.IsEnabled = AdminListSelected;
           
        }

      

        private void WriteUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (WriteUserName.Text.Contains("Write username here") || string.IsNullOrEmpty(WriteUserName.Text))
            {
                IsTextBoxUserNameValid = false;
                EnableAddButton();
            }

            else
                IsTextBoxUserNameValid = true;
                EnableAddButton();

            if (ClearTextBoxesButton != null)
            {
                if (!WriteUserName.Text.Equals(""))
                {
                    ClearTextBoxesButton.IsEnabled = true;
                    
                }
                else
                    ClearTextBoxesButton.IsEnabled = false;

            }

            if (SameUserNameLabel != null && SameEmailLabel != null && !WriteUserName.Text.Equals("")) 
            {
                SameUserNameLabel.Content = string.Empty;
                SameEmailLabel.Content = string.Empty;
            }

            
        }

        private void WriteEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (WriteEmail.Text.Contains("Write email here") || !WriteEmail.Text.Contains("@") || !WriteEmail.Text.Contains(".") || WriteEmail.Text.Contains(" "))

            {
                IsTextBoxEmailValid = false;
                EnableAddButton();
            
            }

            else
                IsTextBoxEmailValid = true;
                EnableAddButton();
        }

        private void EnableAddButton()
        {
            if (IsTextBoxUserNameValid && IsTextBoxEmailValid)
                AddUserButton.IsEnabled = true;
            else
                AddUserButton.IsEnabled = false;
        }


            private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
            {

            if (UserList.SelectedIndex >= 0) //om man ändrar på en användare i userlist
            {
                var selectedUser = UserList.Items[UserList.SelectedIndex];

                User user = (User)selectedUser;

                user.UserName = WriteUserName.Text;
                user.EmailAddress = WriteEmail.Text;

                UserList.Items.Refresh();
                UserInfo.Content = "Username: " + user.UserName + "\nEmail: " + user.EmailAddress;
            }
            if (AdminList.SelectedIndex >= 0) //om man ändrar på en användare i adminlist
            {

                var selectedUser = AdminList.Items[AdminList.SelectedIndex];

                User user = (User)selectedUser;

                user.UserName = WriteUserName.Text;
                user.EmailAddress = WriteEmail.Text;

                AdminList.Items.Refresh();
                UserInfo.Content = "Username: " + user.UserName + "\nEmail: " + user.EmailAddress;
            }
            UserList.UnselectAll();
            AdminList.UnselectAll();            

            WriteUserName.Text = string.Empty;
            WriteEmail.Text = string.Empty;

        }

        private void ChangeToAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedIndex >= 0)
            {
               
                var selected = UserList.SelectedItem; // sparar vad man har valt så det inte försvinner när man tar bort det.
                UserList.Items.RemoveAt(UserList.SelectedIndex); 
                AdminList.Items.Add(selected); 

            }
            WriteUserName.Text = string.Empty;
            WriteEmail.Text = string.Empty;
        }

        private void ChangeToUser_Click(object sender, RoutedEventArgs e)
        {
            if (AdminList.SelectedIndex >= 0)
            {
               
                var selected = AdminList.SelectedItem; // sparar vad man har valt så det inte försvinner när man tar bort det.
                AdminList.Items.RemoveAt(AdminList.SelectedIndex);
                UserList.Items.Add(selected);

            }
            WriteUserName.Text = string.Empty;
            WriteEmail.Text = string.Empty;
        }

        private void WriteUserName_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(WriteUserName.Text.Contains("Write username here"))
            WriteUserName.Clear();
        }

        private void WriteEmail_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (WriteEmail.Text.Contains("Write email here"))
                WriteEmail.Clear();
        }

        private void WriteEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && AddUserButton.IsEnabled == true)
                AddUserButton_Click(sender, e);
        }

        private void WriteUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab) { 
                WriteEmail.Clear();
                
                }
            if (e.Key == Key.Enter && AddUserButton.IsEnabled == true)
                AddUserButton_Click(sender, e);

        }

        private void ClearTextBoxesButton_Click(object sender, RoutedEventArgs e)
        {
            WriteUserName.Clear();
            WriteEmail.Clear();
            WriteUserName.Focus();
        }

        private void UserList_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            UserList.UnselectAll();
            AdminList.UnselectAll();
            WriteUserName.Clear();
            WriteEmail.Clear();
        }

        private void AdminList_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AdminList.UnselectAll();
            UserList.UnselectAll();
            WriteUserName.Clear();
            WriteEmail.Clear();
        }
    } 
    }

