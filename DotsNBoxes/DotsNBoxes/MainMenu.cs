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
        /// <summary>
        /// The index of the login tab
        /// </summary>
        private const int LOGIN_TAB_INDEX = 1;

        /// <summary>
        /// The index of the games list tab
        /// </summary>
        private const int GAME_LIST_TAB_INDEX = 2;

        /// <summary>
        /// The index of the lobby tab
        /// </summary>
        private const int LOBBY_TAB_INDEX = 3;

        /// <summary>
        /// The index of the account settings tab
        /// </summary>
        private const int ACCOUNT_SETTINGS_TAB = 4;

        /// <summary>
        /// The index of the create game tab
        /// </summary>
        private const int CREATE_GAME_TAB = 5;

        /// <summary>
        /// The name of the current user
        /// </summary>
        private string Username = "";

        /// <summary>
        /// The game the user is currently in
        /// </summary>
        private ServerGame CurrentGame;

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

        private void timRefreshGameList_Tick(object sender, EventArgs e)
        {
            //Get a list of all the available games from the server
            List<ListItem> gameList = GameServer.ListGames();

            //If there are items in the game list, display them
            if(gameList != null)
            {
                //If the player currently has a game selected, record it
                ServerGame selectedGame = null;
                if(lbGameList.SelectedValue != null)
                {
                    selectedGame = lbGameList.SelectedValue as ServerGame;
                }

                //Display the newly received list of games
                lbGameList.DataSource = gameList;
                lbGameList.DisplayMember = "Text";
                lbGameList.ValueMember = "Value";

                //If possible, select the game the user previously had selected
                if (selectedGame != null)
                {
                    ListItem newSelection = gameList.FirstOrDefault((curGame) => ((ServerGame)curGame.Value).ID == selectedGame.ID);
                    lbGameList.SelectedItem = newSelection;
                }
            }

            //Otherwise just display a no games message
            else
            {
                lbGameList.DataSource = null;
                lbGameList.Items.Clear();
                lbGameList.Items.Add("No Games Available");
            }
        }

        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            //Navigate the user to the create game tab
            timRefreshGameList.Enabled = false;
            tcMainMenu.SelectedIndex = CREATE_GAME_TAB;
        }

        private void btnJoinGame_Click(object sender, EventArgs e)
        {
            //Do not attempt to join a game if none is selected
            if(lbGameList.SelectedValue == null)
            {
                return;
            }

            //Ask the server to join the selected game
            GameResponse joinStatus = GameServer.JoinGame((ServerGame)lbGameList.SelectedValue, null);

            //Respond appropriately to the join game response
            if(joinStatus == GameResponse.Success)
            {
                CurrentGame = (ServerGame)lbGameList.SelectedValue;
                LoadLobby();
            }
            else if(joinStatus == GameResponse.InvalidPassword)
            {
                MessageBox.Show("Unable to join! Invalid password.", "Can't Join");
            }
            else if(joinStatus == GameResponse.GameFull)
            {
                MessageBox.Show("Unable to join! Game full.", "Can't Join");
            }
            else
            {
                MessageBox.Show("Unable to join!", "Can't Join");
            }
        }

        private void rbPasswordProtect_CheckedChanged(object sender, EventArgs e)
        {
            txtGamePassword.Enabled = rbPasswordProtect.Checked;
        }  

        private void btnCreateDotsGame_Click(object sender, EventArgs e)
        {
            //If the games name is invalid warn the user
            if(string.IsNullOrEmpty(txtGameName.Text.Trim()) || txtGameName.Text.Length > 20)
            {
                lblCreateGameError.Text = "* Invalid game name";
                lblCreateGameError.Visible = true;
                return;
            }

            //If the user did not select the max number of users or grid size, force them to
            if(cbGameUsers.SelectedIndex == -1 || cbGridSize.SelectedIndex == -1)
            {
                lblCreateGameError.Text = "* Max users and grid size required";
                lblCreateGameError.Visible = true;
                return;
            }

            //Create a game for the user
            bool gameCreated = GameServer.CreateGame(txtGameName.Text, cbGameUsers.Text, cbGridSize.Text, 
                rbPasswordProtect.Checked, txtGamePassword.Text);

            //If the game was not created, warn the user
            if(!gameCreated)
            {
                lblCreateGameError.Text = "* Failed to create game";
                lblCreateGameError.Visible = true;
                return;
            }

            //Create a game object to make the lobby loadable
            GridSize selectedGridSize = GridSize.FourByFour;
            if(cbGridSize.SelectedIndex == 1) { selectedGridSize = GridSize.SixBySix; }
            else if(cbGridSize.SelectedIndex == 2) { selectedGridSize = GridSize.EightByEight; }
            CurrentGame = new ServerGame()
            {
                ID = -1, /* ID is only needed to join games.. the user is already in this game */
                Name = txtGameName.Text,
                MapSize = selectedGridSize,
                MaxPlayers = int.Parse(cbGameUsers.Text),
                IsFull = false,
                PassProtected = rbNoPasswordProtect.Checked
            };

            //Clear all of the create game controls for the next time the user sees the form
            txtGameName.Text = "";
            cbGameUsers.SelectedIndex = -1;
            cbGridSize.SelectedIndex = -1;
            rbNoPasswordProtect.Checked = true;
            txtGamePassword.Text = "";

            //Navigate the user to the lobby
            LoadLobby();
        }

        private void btnReturnToList_Click(object sender, EventArgs e)
        {
            //Navigate the user to the game list
            LoadGameList();
        }

        private void btnVoteStart_Click(object sender, EventArgs e)
        {
            GameServer.GameVote();
            btnVoteStart.Enabled = false;
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            //Ask the server to exit the current game
            bool exitStatus = GameServer.ExitGame();

            //If the server let us exit, navigate back to the game list
            if(exitStatus)
            {
                timRefreshLobby.Enabled = false;
                CurrentGame = null;
                LoadGameList();
            }

            //Otherwise display an error to the user
            else
            {
                MessageBox.Show("Unable to exit", "Error!");
            }
        }


        private void timRefreshLobby_Tick(object sender, EventArgs e)
        {
            //Keep pinging the server till it has nothing new to tell us
            string response = GameServer.GamePing();
            while (response != "PONG\r\n\r\n")
            {
                string responseHeader = response.Substring(0, response.IndexOf("\r\n"));
                if (responseHeader == "PLAYER LIST")
                {
                    //Split out the list of players
                    string[] players = response.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                    //Reset the list of players and add all of the listed players to the list
                    CurrentGame.Players.Clear();
                    lbPlayers.Items.Clear();
                    for (int curPlayer = 1; curPlayer < players.Length; curPlayer++)
                    {
                        //Split out the information of the current player
                        string[] playerInfo = players[curPlayer].Split(',');

                        //Add the player to the master list of players
                        GamePlayer newPlayer = new GamePlayer()
                        {
                            InGame = (playerInfo[0] == "true"),
                            Username = playerInfo[1]
                        };
                        CurrentGame.Players.Add(newPlayer);

                        //If the new player's username is not the users username, add the user to the display list
                        if(newPlayer.Username.ToLower() != Username.ToLower())
                        {
                            lbPlayers.Items.Add((newPlayer.InGame ? "(I) " : "(W) ") + newPlayer.Username);
                        }
                    }

                    //Display the number of players on the screen
                    lblNumberPlayersText.Text = CurrentGame.Players.Count.ToString();
                }
                else if (responseHeader == "PLAYER ADDED")
                {
                    string newPlayerName = response.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];

                    //Add the player to the master list of players
                    GamePlayer newPlayerEntry = new GamePlayer()
                    {
                        InGame = false,
                        Username = newPlayerName
                    };
                    CurrentGame.Players.Add(newPlayerEntry);

                    //Add the player to the visible list of players
                    lbPlayers.Items.Add("(W) " + newPlayerName);
                }
                else if (responseHeader == "PLAYER LEAVE")
                {
                    string playerLeft = response.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];

                    //Remove the player from the master list and the visible list
                    CurrentGame.Players.Remove(CurrentGame.Players.First((curPlayer) => curPlayer.Username == playerLeft));
                    lbPlayers.Items.Remove(playerLeft);

                    lblNumberPlayersText.Text = CurrentGame.Players.Count.ToString();
                }
                else if (responseHeader == "GAME PLAYING")
                {
                    CurrentGame.Status = GameStatus.InGame;
                    lblGameStatusText.Text = "Game in progress";
                }
                else if (responseHeader == "GAME WAITING")
                {
                    CurrentGame.Status = GameStatus.Waiting;
                    lblGameStatusText.Text = "Waiting to start";
                }
                else if (responseHeader == "GAME VOTE")
                {
                    CurrentGame.StartVotes++;
                    lblVotesToStartText.Text = CurrentGame.StartVotes.ToString();
                }
                else if (responseHeader == "GAME START")
                {
                    timRefreshGameList.Enabled = false;
                    this.Visible = false;
                    GameDisplay gameVisual = new GameDisplay();
                    gameVisual.ShowDialog();
                    this.Visible = true;
                    timRefreshGameList.Enabled = true;
                    break;
                }


                //Ping the server again
                response = GameServer.GamePing();
            }
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
            timRefreshGameList_Tick(this, null);
            timRefreshGameList.Enabled = true;
            tcMainMenu.SelectedIndex = GAME_LIST_TAB_INDEX;
        }

        /// <summary>
        /// Loads the lobby with the current game
        /// </summary>
        private void LoadLobby()
        {
            //Load all the text info we can to the lobby menu
            btnVoteStart.Enabled = true;
            lblVotesToStartText.Text = "0";
            lblLobbyNameText.Text = CurrentGame.Name;
            if (CurrentGame.MapSize == GridSize.FourByFour) { lblBoardSizeText.Text = "4X4"; }
            else if (CurrentGame.MapSize == GridSize.SixBySix) { lblBoardSizeText.Text = "6X6"; }
            else { lblBoardSizeText.Text = "8X8"; }

            //Kick off the lobby refresh
            timRefreshLobby_Tick(this, null);
            timRefreshLobby.Enabled = true;

            //Navigate to the lobby tab
            tcMainMenu.SelectedIndex = LOBBY_TAB_INDEX;
        }
    }
}
