using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotsNBoxes
{
    public partial class MainMenu : Form
    {
        private const int LOGIN_TAB_INDEX = 1;

        /// <summary>
        /// The index of the games list tab
        /// </summary>
        private const int GAME_LIST_TAB_INDEX = 2;

        /// <summary>
        /// The index of the account settings tab
        /// </summary>
        private const int ACCOUNT_SETTINGS_TAB = 4;

        /// <summary>
        /// The name of the current user
        /// </summary>
        private string Username = "";

        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnSelectServer_Click(object sender, EventArgs e)
        {
            //Attempt to connect to the user selected server
            ConnectionResponse serverConnection = GameServer.Connect(txtServerName.Text);

            //If the connection to the server is valid, move onto the login page
            if (serverConnection == ConnectionResponse.Connected)
            {
                lblServerNameFillMe.Text = txtServerName.Text;
                LoadLoginPage();
            }

            //Otherwise print an error to the screen
            else
            {
                if(serverConnection == ConnectionResponse.WrongVersion)
                {
                    lblServerConnectError.Text = "* The requested server is running the wrong version";
                }

                else
                {
                    lblServerConnectError.Text = "* Unable to connect to server";
                }

                //Make the connection error textbox visible
                lblServerConnectError.Visible = true;
            }
        }

        private void btnCheckUsernameAvailability_Click(object sender, EventArgs e)
        {
            //Ask the server if the provided username is available
            UserResponse usernameAvailable = GameServer.CheckUsernameAvailability(txtCreateAccountUsername.Text);

            //If the requested account name is available, tell the user in green text
            if(usernameAvailable == UserResponse.UsernameAvailable)
            {
                lblCreateAccountError.ForeColor = Color.Green;
                lblCreateAccountError.Text = "* Requested account name is available!";
                lblCreateAccountError.Visible = true;
            }

            //Otherwise break the bad news to the user in red text
            else
            {
                //Set the text color of the error box to red
                lblCreateAccountError.ForeColor = Color.Red;

                //Show the appropriate error message
                if(usernameAvailable == UserResponse.UsernameInvalid)
                {
                    lblCreateAccountError.Text = "* The username you requested is invalid. Must be alpha-numeric, and contain between 3 and 20 characters.";
                }
                else if (usernameAvailable == UserResponse.UsernameTaken)
                {
                    lblCreateAccountError.Text = "* The username you requested is already in use.";
                }
                else
                {
                    lblCreateAccountError.Text = "* Unknown error!";
                }
                //Make the error text visible
                lblCreateAccountError.Visible = true;
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            //Ask the server to create an account
            UserResponse createAccount = GameServer.CreateAccount(txtCreateAccountUsername.Text, txtCreateAccountPassword.Text);

            //If the requested account was created successfully, move to the game list
            if (createAccount == UserResponse.Success)
            {
                Username = txtCreateAccountUsername.Text;
                LoadGameList();
            }

            //Otherwise break the bad news to the user in red text
            else
            {
                //Set the text color of the error box to red
                lblCreateAccountError.ForeColor = Color.Red;

                //Show the appropriate error message
                if (createAccount == UserResponse.UsernameInvalid)
                {
                    lblCreateAccountError.Text = "* The username you requested is invalid. Must be alpha-numeric, and contain between 3 and 20 characters.";
                }
                else if (createAccount == UserResponse.UsernameTaken)
                {
                    lblCreateAccountError.Text = "* The username you requested is already in use.";
                }
                else
                {
                    lblCreateAccountError.Text = "* Unknown error!";
                }

                //Make the error text visible
                lblCreateAccountError.Visible = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Ask the server to authenticate credentials
            UserResponse authenticateAccount = GameServer.Login(txtLoginUsername.Text, txtLoginPassword.Text);

            //If the requested account authentication was successful, move to the game list
            if (authenticateAccount == UserResponse.Success)
            {
                Username = txtLoginUsername.Text;
                LoadGameList();
            }

            //Otherwise break the bad news to the user
            else
            {
                //Show the appropriate error message
                if (authenticateAccount == UserResponse.AuthenticationFailed)
                {
                    lblLoginAccountError.Text = "* Unable to authenticate account";
                }
                else
                {
                    lblLoginAccountError.Text = "* Unknown error!";
                }
                
                //Make the error text visible
                lblLoginAccountError.Visible = true;
            }
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            //Navigate the user to the account settings page
            timRefreshGameList.Enabled = false;
            txtDeleteUsername.Text = Username;
            tcMainMenu.SelectedIndex = ACCOUNT_SETTINGS_TAB;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            //If no password was provided, print an error
            if(txtDeletePassword.Text == "")
            {
                lblDeletePasswordError.Text = "* Unable to delete account without password";
                lblDeletePasswordError.Visible = true;
                return;
            }

            //Ask the server to delete this account
            UserResponse deleteAccount = GameServer.DeleteAccount(txtDeleteUsername.Text, txtDeletePassword.Text);

            //If the requested account deletion was successful, move to the login page
            if (deleteAccount == UserResponse.Success)
            {
                MessageBox.Show("Account \"" + Username + "\" deleted.", "Account Deleted");
                LoadLoginPage();
            }

            //Otherwise break the bad news to the user
            else
            {
                //Show the appropriate error message
                if (deleteAccount == UserResponse.AuthenticationFailed)
                {
                    lblDeletePasswordError.Text = "* Unable to authenticate account";
                }
                else
                {
                    lblDeletePasswordError.Text = "* Unknown error!";
                }

                //Make the error text visible
                lblDeletePasswordError.Visible = true;
            }
        }

        private void btnReturnToList_Click(object sender, EventArgs e)
        {
            //Navigate the user to the game list
            LoadGameList();
        }

        /// <summary>
        /// Loads the login page
        /// </summary>
        private void LoadLoginPage()
        {
            txtLoginUsername.Text = txtCreateAccountUsername.Text = txtDeleteUsername.Text = "";
            txtLoginPassword.Text = txtCreateAccountPassword.Text = txtDeletePassword.Text = "";
            lblLoginAccountError.Visible = lblCreateAccountError.Visible = lblDeletePasswordError.Visible = false;
            tcMainMenu.SelectedIndex = LOGIN_TAB_INDEX;
        }

        /// <summary>
        /// Loads the game list
        /// </summary>
        private void LoadGameList()
        {
            timRefreshGameList.Enabled = true;
            tcMainMenu.SelectedIndex = GAME_LIST_TAB_INDEX;
        }

        
        

        

        
    }
}
