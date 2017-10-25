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

            UserInfo.Content = "Username:\nEmail:";
        }

      // TO-DO
      // När man trycker på edit så läggs en till användare till istället för att ändra på den markerade
      // när man markerar en användare skall adduserbutton vara disable
      // när man lagt till en användare skall textboxarna bli tomma eller återgå till texten från början
      // jag gjorde privata bools och la dom utanför, vara konsekventa
   

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
                ErrorLabel.Content = string.Empty;
            }
            else if (nameList.Contains(WriteEmail.Text) && nameList.Contains(WriteUserName.Text))
            {
                ErrorLabel.Content = "Username already exists.";
                ErrorLabel2.Content = "Email already exists.";
            }
            else if (nameList.Contains(WriteUserName.Text))
                ErrorLabel.Content = "Username already exists.";
            else if (nameList.Contains(WriteEmail.Text))
                ErrorLabel2.Content = "Email already exists.";
           

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
                ErrorLabel.Content = string.Empty;
                ErrorLabel2.Content = string.Empty;

                WriteUserName.Text = ((User)UserList.SelectedItem).UserName;
                WriteEmail.Text = ((User)UserList.SelectedItem).EmailAddress;

                if (UserList.SelectedItem != null)
                {
                    UserInfo.Content = "Username: " +

                        ((User)UserList.SelectedItem).UserName + " \nEmail: " + ((User)UserList.SelectedItem).EmailAddress;
                    AddUserButton.IsEnabled = false;
                }

            }
            else
                UserInfo.Content = "Username: \nEmail: ";
            

                bool canClick = UserList.SelectedIndex >= 0;
            DeleteUserButton.IsEnabled = canClick;

            ChangeToAdminButton.IsEnabled = canClick;

            EditUserButton.IsEnabled = canClick;

            


        }

        private void AdminList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (AdminList.SelectedIndex >= 0)
            {
                ErrorLabel.Content = string.Empty;
                ErrorLabel2.Content = string.Empty;

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


            bool canClick = AdminList.SelectedIndex >= 0;
            ChangeToUser.IsEnabled = canClick;
            DeleteUserButton.IsEnabled = canClick;
            EditUserButton.IsEnabled = canClick;
           
        }

        private bool checkTextBoxUserName;
        private bool checkTextBoxWriteEmail;

        private void WriteUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (WriteUserName.Text.Contains("Write username") || string.IsNullOrEmpty(WriteUserName.Text))
                checkTextBoxUserName = false;

            else
                checkTextBoxUserName = true;

            if (ClearTextBoxesButton != null)
            {
                if (!WriteUserName.Text.Equals(""))

                    ClearTextBoxesButton.IsEnabled = true;
                else
                    ClearTextBoxesButton.IsEnabled = false;

            }
        }


        private void WriteEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (WriteEmail.Text.Contains("Write email here") || !WriteEmail.Text.Contains("@") || !WriteEmail.Text.Contains(".") || string.IsNullOrEmpty(WriteEmail.Text))
            {
                checkTextBoxWriteEmail = false;
                EnableClickButton();
               
            }

            else
                
                checkTextBoxWriteEmail = true;
                EnableClickButton();
           

        }

        private void EnableClickButton()
        {
            if (checkTextBoxUserName && checkTextBoxWriteEmail)
                AddUserButton.IsEnabled = true;
            else
                AddUserButton.IsEnabled = false;
        }


            private void EditUserButton_Click(object sender, RoutedEventArgs e)
            {
            //När man klickar på den ska den användare i ListBox som är vald uppdateras med nya värden

            //TO DO - när man ändrar på en användare kan man göra så att användaren inte har något användrnamn. Ändra så att antingen amn inte kan klicka på knappen eller att en text kommer ut att det inte går

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
            if(WriteUserName.Text.Contains("Write username"))
            WriteUserName.Clear();
        }

        private void WriteEmail_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (WriteEmail.Text.Contains("Write email here"))
                WriteEmail.Clear();
        }

        private void WriteEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                AddUserButton_Click(sender, e);
        }

        private void WriteUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab) { 
                WriteEmail.Clear();
                
           
                }
             
        }

        private void ClearTextBoxesButton_Click(object sender, RoutedEventArgs e)
        {
            WriteUserName.Clear();
            WriteEmail.Clear();
            WriteUserName.Focus();
        }
    } 
    }

