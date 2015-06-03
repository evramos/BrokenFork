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
        private const int ACCOUNT_SETTINGS_TAB_INDEX = 4;

        /// <summary>
        /// The index of the create game tab
        /// </summary>
        private const int CREATE_GAME_TAB_INDEX = 5;

        /// <summary>
        /// The index of the game field tab
        /// </summary>
        private const int GAME_FEILD_TAB = 6;

        /// <summary>
        /// The name of the current user
        /// </summary>
        private string Username = "";

        /// <summary>
        /// Whether or not the client is X in the current game
        /// </summary>
        private bool IAmX = false;

        /// <summary>
        /// Whether or not it is currently X's turn
        /// </summary>
        private bool XsTurn = false;

        /// <summary>
        /// Whether or not the next move request should be ignored
        /// </summary>
        private bool IgnoreMove = false;

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
            tcMainMenu.SelectedIndex = ACCOUNT_SETTINGS_TAB_INDEX;
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
            tcMainMenu.SelectedIndex = CREATE_GAME_TAB_INDEX;
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

        private void btnCreateDotsGame_Click(object sender, EventArgs e)
        {
            //If the games name is invalid warn the user
            if(string.IsNullOrEmpty(txtGameName.Text.Trim()) || txtGameName.Text.Length > 20)
            {
                lblCreateGameError.Text = "* Invalid game name";
                lblCreateGameError.Visible = true;
                return;
            }

            //Create a game for the user
            bool gameCreated = GameServer.CreateGame(txtGameName.Text, false, "");

            //If the game was not created, warn the user
            if(!gameCreated)
            {
                lblCreateGameError.Text = "* Failed to create game";
                lblCreateGameError.Visible = true;
                return;
            }

            //Create a game object to make the lobby loadable
            CurrentGame = new ServerGame()
            {
                ID = -1, /* ID is only needed to join games.. the user is already in this game */
                Name = txtGameName.Text,
                IsFull = false,
                PassProtected = false
            };

            //Clear all of the create game controls for the next time the user sees the form
            txtGameName.Text = "";

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
                timGameRefresh.Enabled = false;
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
                            lbPlayers.Items.Add(newPlayer.Username);
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
                    lbPlayers.Items.Add(newPlayerName);
                }
                else if (responseHeader == "PLAYER LEAVE")
                {
                    string playerLeft = response.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];

                    //Remove the player from the master list and the visible list
                    CurrentGame.Players.Remove(CurrentGame.Players.First((curPlayer) => curPlayer.Username == playerLeft));
                    lbPlayers.Items.Remove(playerLeft);

                    //Update the number of players displayed
                    lblNumberPlayersText.Text = CurrentGame.Players.Count.ToString();

                    //Reset the number of game votes
                    CurrentGame.StartVotes = 0;
                    btnVoteStart.Enabled = true;
                    lblVotesToStartText.Text = CurrentGame.StartVotes.ToString();
                }
                else if (responseHeader == "GAME VOTE")
                {
                    CurrentGame.StartVotes++;
                    lblVotesToStartText.Text = CurrentGame.StartVotes.ToString();
                }
                else if (responseHeader == "GAME START")
                {
                    timRefreshGameList.Enabled = false;
                    LoadGameDisplay();
                    break;
                }

                //Ping the server again
                response = GameServer.GamePing();
            }
        }

        private void timGameRefresh_Tick(object sender, EventArgs e)
        {
            //Keep pinging the server till it has nothing new to tell us
            string response = GameServer.GamePing();
            while (response != "PONG\r\n\r\n")
            {
                string responseHeader = response.Substring(0, response.IndexOf("\r\n"));
                if (responseHeader == "PLAYERX")
                {
                    //Figure out if the client is X or O
                    string xsName = response.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    IAmX = xsName.ToLower() == Username.ToLower();
                    XsTurn = true;

                    //Setup the field appropriately for the X/O status
                    lblYouAreText.Text = (IAmX ? "X" : "O");
                    lblCurrentPlayerText.Text = "X";
                    lblYourTurn.Visible = IAmX;
                    IgnoreMove = false;

                    //Correct the enabled state of the client buttons
                    CorrectTileStates();
                }
                else if (responseHeader.StartsWith("MOVE"))
                {
                    if(IgnoreMove)
                    {
                        IgnoreMove = false;
                        continue;
                    }

                    //Update the game display
                    int opponentPlacment = int.Parse(responseHeader.Split(' ')[1]);
                    switch(opponentPlacment)
                    {
                        case 1: btnSquare1.Text = (IAmX ? "O" : "X"); break;
                        case 2: btnSquare2.Text = (IAmX ? "O" : "X"); break;
                        case 3: btnSquare3.Text = (IAmX ? "O" : "X"); break;
                        case 4: btnSquare4.Text = (IAmX ? "O" : "X"); break;
                        case 5: btnSquare5.Text = (IAmX ? "O" : "X"); break;
                        case 6: btnSquare6.Text = (IAmX ? "O" : "X"); break;
                        case 7: btnSquare7.Text = (IAmX ? "O" : "X"); break;
                        case 8: btnSquare8.Text = (IAmX ? "O" : "X"); break;
                        case 9: btnSquare9.Text = (IAmX ? "O" : "X"); break;
                    }

                    //Update the labels
                    XsTurn = IAmX;
                    lblCurrentPlayerText.Text = (IAmX ? "X" : "O");
                    lblYourTurn.Visible = true;

                    //Correct the enabled state of the client buttons
                    CorrectTileStates();
                }
                else if (responseHeader == "PLAYER LEAVE")
                {
                    string playerLeft = response.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];

                    //Remove the player from the master list and the visible list
                    CurrentGame.Players.Remove(CurrentGame.Players.First((curPlayer) => curPlayer.Username == playerLeft));
                    lbPlayers.Items.Remove(playerLeft);

                    //Update the number of players displayed
                    lblNumberPlayersText.Text = CurrentGame.Players.Count.ToString();

                    //Reset the number of game votes
                    CurrentGame.StartVotes = 0;
                    btnVoteStart.Enabled = true;
                    lblVotesToStartText.Text = CurrentGame.StartVotes.ToString();

                    //Move back to the lovely lobby
                    timGameRefresh.Enabled = false;
                    LoadLobby();
                    break;
                }

                //Ping the server again
                response = GameServer.GamePing();
            }
        }

        private void Click_TickTacTowTile(object sender, EventArgs e)
        {
            //Tell the server to move on the tile we just clicked
            IgnoreMove = true;
            GameServer.GameMove((string)(((Button)sender).Tag));

            //Locally mark the tile we just clicked with our symbol
            Button clickedTile = (Button)sender;
            clickedTile.Text = (IAmX ? "X" : "O");

            //Change to the other players turn
            XsTurn = !IAmX;

            //Update the labels on the screen
            lblCurrentPlayerText.Text = (IAmX ? "O" : "X");
            lblYourTurn.Visible = false;

            //Correct the enable state of the clients buttons
            CorrectTileStates();
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

            //Kick off the lobby refresh
            timRefreshLobby_Tick(this, null);
            timRefreshLobby.Enabled = true;

            //Navigate to the lobby tab
            tcMainMenu.SelectedIndex = LOBBY_TAB_INDEX;
        }

        private void LoadGameDisplay()
        {
            //Clear the board buttons
            btnSquare1.Text = btnSquare2.Text = btnSquare3.Text = btnSquare4.Text = btnSquare5.Text = 
                btnSquare6.Text = btnSquare7.Text = btnSquare8.Text = btnSquare9.Text = "";
            btnSquare1.Enabled = btnSquare2.Enabled = btnSquare3.Enabled = btnSquare4.Enabled = btnSquare5.Enabled =
                btnSquare6.Enabled = btnSquare7.Enabled = btnSquare8.Enabled = btnSquare9.Enabled = true;

            //Kick off the game refresh
            timGameRefresh_Tick(this, null);
            timGameRefresh.Enabled = true;

            //Navigate to the game display
            tcMainMenu.SelectedIndex = GAME_FEILD_TAB;
        }        

        private void CorrectTileStates()
        {
            if((IAmX && XsTurn) || (!IAmX && !XsTurn))
            {
                btnSquare1.Enabled = (btnSquare1.Text == "");
                btnSquare2.Enabled = (btnSquare2.Text == "");
                btnSquare3.Enabled = (btnSquare3.Text == "");
                btnSquare4.Enabled = (btnSquare4.Text == "");
                btnSquare5.Enabled = (btnSquare5.Text == "");
                btnSquare6.Enabled = (btnSquare6.Text == "");
                btnSquare7.Enabled = (btnSquare7.Text == "");
                btnSquare8.Enabled = (btnSquare8.Text == "");
                btnSquare9.Enabled = (btnSquare9.Text == "");
            }
            else
            {
                btnSquare1.Enabled = btnSquare2.Enabled = btnSquare3.Enabled = btnSquare4.Enabled = btnSquare5.Enabled =
                    btnSquare6.Enabled = btnSquare7.Enabled = btnSquare8.Enabled = btnSquare9.Enabled = false;
            }
        }
    }
}
