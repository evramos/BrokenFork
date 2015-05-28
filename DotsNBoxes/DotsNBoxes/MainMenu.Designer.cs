namespace DotsNBoxes
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.timRefreshGameList = new System.Windows.Forms.Timer(this.components);
            this.timRefreshLobby = new System.Windows.Forms.Timer(this.components);
            this.tcMainMenu = new DotsNBoxes.CustomTabControl();
            this.tbSelectServer = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblServerConnectError = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.btnSelectServer = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TabPage();
            this.pnCreateAccount = new System.Windows.Forms.Panel();
            this.lblCreateAccountError = new System.Windows.Forms.Label();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnCheckUsernameAvailability = new System.Windows.Forms.Button();
            this.txtCreateAccountPassword = new System.Windows.Forms.TextBox();
            this.lblCreateAccountPassword = new System.Windows.Forms.Label();
            this.txtCreateAccountUsername = new System.Windows.Forms.TextBox();
            this.lblCreateAccountUsername = new System.Windows.Forms.Label();
            this.lblCreateAccount = new System.Windows.Forms.Label();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.lblLoginAccountError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.lblLoginUsername = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblServerNameFillMe = new System.Windows.Forms.Label();
            this.lblSelectedServer = new System.Windows.Forms.Label();
            this.tbGameList = new System.Windows.Forms.TabPage();
            this.btnAccountSettings = new System.Windows.Forms.Button();
            this.btnCreateGame = new System.Windows.Forms.Button();
            this.btnJoinGame = new System.Windows.Forms.Button();
            this.lblGamesListKey = new System.Windows.Forms.Label();
            this.lblGameListPlayers = new System.Windows.Forms.Label();
            this.lblGamesListBoardSize = new System.Windows.Forms.Label();
            this.lblGamesListName = new System.Windows.Forms.Label();
            this.lblGamesList = new System.Windows.Forms.Label();
            this.lbGameList = new System.Windows.Forms.ListBox();
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbGameLobby = new System.Windows.Forms.TabPage();
            this.lblVotesRequiredText = new System.Windows.Forms.Label();
            this.lblVotesRequired = new System.Windows.Forms.Label();
            this.lblVotesToStartText = new System.Windows.Forms.Label();
            this.lblGameStatusText = new System.Windows.Forms.Label();
            this.lblBoardSizeText = new System.Windows.Forms.Label();
            this.lblNumberPlayersText = new System.Windows.Forms.Label();
            this.lblLobbyNameText = new System.Windows.Forms.Label();
            this.lblVotesToStart = new System.Windows.Forms.Label();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.lblBoardSize = new System.Windows.Forms.Label();
            this.lblNumberPlayers = new System.Windows.Forms.Label();
            this.lblLobbyName = new System.Windows.Forms.Label();
            this.btnVoteStart = new System.Windows.Forms.Button();
            this.lblInGameWaiting = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblGameInfo = new System.Windows.Forms.Label();
            this.lbPlayers = new System.Windows.Forms.ListBox();
            this.btnExitGame = new System.Windows.Forms.Button();
            this.lblGameLobby = new System.Windows.Forms.Label();
            this.tbAccountSettings = new System.Windows.Forms.TabPage();
            this.lblDeletePasswordError = new System.Windows.Forms.Label();
            this.txtDeletePassword = new System.Windows.Forms.TextBox();
            this.lblDeletePassword = new System.Windows.Forms.Label();
            this.txtDeleteUsername = new System.Windows.Forms.TextBox();
            this.lblDeleteUsername = new System.Windows.Forms.Label();
            this.btnReturnToList = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCreateGame = new System.Windows.Forms.TabPage();
            this.txtGamePassword = new System.Windows.Forms.TextBox();
            this.lblGamePassword = new System.Windows.Forms.Label();
            this.rbNoPasswordProtect = new System.Windows.Forms.RadioButton();
            this.rbPasswordProtect = new System.Windows.Forms.RadioButton();
            this.lblPaswordProtect = new System.Windows.Forms.Label();
            this.cbGridSize = new System.Windows.Forms.ComboBox();
            this.lblGridSize = new System.Windows.Forms.Label();
            this.lblCreateGameError = new System.Windows.Forms.Label();
            this.btnReturnToList1 = new System.Windows.Forms.Button();
            this.btnCreateDotsGame = new System.Windows.Forms.Button();
            this.cbGameUsers = new System.Windows.Forms.ComboBox();
            this.lblNumberOfUsers = new System.Windows.Forms.Label();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.lblPublicGameName = new System.Windows.Forms.Label();
            this.lblCreateGame = new System.Windows.Forms.Label();
            this.tcMainMenu.SuspendLayout();
            this.tbSelectServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbLogin.SuspendLayout();
            this.pnCreateAccount.SuspendLayout();
            this.pnLogin.SuspendLayout();
            this.tbGameList.SuspendLayout();
            this.tcUserInfo.SuspendLayout();
            this.tbGameLobby.SuspendLayout();
            this.tbAccountSettings.SuspendLayout();
            this.tbCreateGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // timRefreshGameList
            // 
            this.timRefreshGameList.Interval = 1000;
            this.timRefreshGameList.Tick += new System.EventHandler(this.timRefreshGameList_Tick);
            // 
            // timRefreshLobby
            // 
            this.timRefreshLobby.Interval = 500;
            this.timRefreshLobby.Tick += new System.EventHandler(this.timRefreshLobby_Tick);
            // 
            // tcMainMenu
            // 
            this.tcMainMenu.Controls.Add(this.tbSelectServer);
            this.tcMainMenu.Controls.Add(this.tbLogin);
            this.tcMainMenu.Controls.Add(this.tbGameList);
            this.tcMainMenu.Controls.Add(this.tbGameLobby);
            this.tcMainMenu.Controls.Add(this.tbAccountSettings);
            this.tcMainMenu.Controls.Add(this.tbCreateGame);
            this.tcMainMenu.Location = new System.Drawing.Point(1, 1);
            this.tcMainMenu.Name = "tcMainMenu";
            this.tcMainMenu.SelectedIndex = 0;
            this.tcMainMenu.Size = new System.Drawing.Size(594, 325);
            this.tcMainMenu.TabIndex = 1;
            // 
            // tbSelectServer
            // 
            this.tbSelectServer.BackColor = System.Drawing.SystemColors.Control;
            this.tbSelectServer.Controls.Add(this.pictureBox1);
            this.tbSelectServer.Controls.Add(this.lblServerConnectError);
            this.tbSelectServer.Controls.Add(this.txtServerName);
            this.tbSelectServer.Controls.Add(this.lblServerName);
            this.tbSelectServer.Controls.Add(this.btnSelectServer);
            this.tbSelectServer.Location = new System.Drawing.Point(4, 22);
            this.tbSelectServer.Name = "tbSelectServer";
            this.tbSelectServer.Padding = new System.Windows.Forms.Padding(3);
            this.tbSelectServer.Size = new System.Drawing.Size(586, 299);
            this.tbSelectServer.TabIndex = 0;
            this.tbSelectServer.Text = "Select Server";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DotsNBoxes.Properties.Resources.logo_ver2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(27, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(533, 200);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblServerConnectError
            // 
            this.lblServerConnectError.AutoSize = true;
            this.lblServerConnectError.ForeColor = System.Drawing.Color.Red;
            this.lblServerConnectError.Location = new System.Drawing.Point(159, 285);
            this.lblServerConnectError.Name = "lblServerConnectError";
            this.lblServerConnectError.Size = new System.Drawing.Size(11, 13);
            this.lblServerConnectError.TabIndex = 3;
            this.lblServerConnectError.Text = "*";
            this.lblServerConnectError.Visible = false;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(160, 261);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(176, 20);
            this.txtServerName.TabIndex = 0;
            this.txtServerName.Text = "127.0.0.1";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(157, 245);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(100, 13);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "Enter Server Name:";
            // 
            // btnSelectServer
            // 
            this.btnSelectServer.Location = new System.Drawing.Point(342, 261);
            this.btnSelectServer.Name = "btnSelectServer";
            this.btnSelectServer.Size = new System.Drawing.Size(88, 20);
            this.btnSelectServer.TabIndex = 1;
            this.btnSelectServer.Text = "Connect";
            this.btnSelectServer.UseVisualStyleBackColor = true;
            this.btnSelectServer.Click += new System.EventHandler(this.btnSelectServer_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.BackColor = System.Drawing.SystemColors.Control;
            this.tbLogin.Controls.Add(this.pnCreateAccount);
            this.tbLogin.Controls.Add(this.pnLogin);
            this.tbLogin.Controls.Add(this.lblServerNameFillMe);
            this.tbLogin.Controls.Add(this.lblSelectedServer);
            this.tbLogin.Location = new System.Drawing.Point(4, 22);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tbLogin.Size = new System.Drawing.Size(586, 299);
            this.tbLogin.TabIndex = 1;
            this.tbLogin.Text = "Login";
            // 
            // pnCreateAccount
            // 
            this.pnCreateAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCreateAccount.Controls.Add(this.lblCreateAccountError);
            this.pnCreateAccount.Controls.Add(this.btnCreateAccount);
            this.pnCreateAccount.Controls.Add(this.btnCheckUsernameAvailability);
            this.pnCreateAccount.Controls.Add(this.txtCreateAccountPassword);
            this.pnCreateAccount.Controls.Add(this.lblCreateAccountPassword);
            this.pnCreateAccount.Controls.Add(this.txtCreateAccountUsername);
            this.pnCreateAccount.Controls.Add(this.lblCreateAccountUsername);
            this.pnCreateAccount.Controls.Add(this.lblCreateAccount);
            this.pnCreateAccount.Location = new System.Drawing.Point(305, 16);
            this.pnCreateAccount.Name = "pnCreateAccount";
            this.pnCreateAccount.Size = new System.Drawing.Size(271, 236);
            this.pnCreateAccount.TabIndex = 1;
            // 
            // lblCreateAccountError
            // 
            this.lblCreateAccountError.Location = new System.Drawing.Point(13, 179);
            this.lblCreateAccountError.Name = "lblCreateAccountError";
            this.lblCreateAccountError.Size = new System.Drawing.Size(244, 45);
            this.lblCreateAccountError.TabIndex = 14;
            this.lblCreateAccountError.Text = "*";
            this.lblCreateAccountError.Visible = false;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(159, 149);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(98, 23);
            this.btnCreateAccount.TabIndex = 3;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnCheckUsernameAvailability
            // 
            this.btnCheckUsernameAvailability.Location = new System.Drawing.Point(159, 64);
            this.btnCheckUsernameAvailability.Name = "btnCheckUsernameAvailability";
            this.btnCheckUsernameAvailability.Size = new System.Drawing.Size(98, 23);
            this.btnCheckUsernameAvailability.TabIndex = 1;
            this.btnCheckUsernameAvailability.Text = "Check Avilability";
            this.btnCheckUsernameAvailability.UseVisualStyleBackColor = true;
            this.btnCheckUsernameAvailability.Click += new System.EventHandler(this.btnCheckUsernameAvailability_Click);
            // 
            // txtCreateAccountPassword
            // 
            this.txtCreateAccountPassword.Location = new System.Drawing.Point(14, 123);
            this.txtCreateAccountPassword.Name = "txtCreateAccountPassword";
            this.txtCreateAccountPassword.PasswordChar = '•';
            this.txtCreateAccountPassword.Size = new System.Drawing.Size(243, 20);
            this.txtCreateAccountPassword.TabIndex = 2;
            // 
            // lblCreateAccountPassword
            // 
            this.lblCreateAccountPassword.AutoSize = true;
            this.lblCreateAccountPassword.Location = new System.Drawing.Point(11, 107);
            this.lblCreateAccountPassword.Name = "lblCreateAccountPassword";
            this.lblCreateAccountPassword.Size = new System.Drawing.Size(56, 13);
            this.lblCreateAccountPassword.TabIndex = 8;
            this.lblCreateAccountPassword.Text = "Password:";
            // 
            // txtCreateAccountUsername
            // 
            this.txtCreateAccountUsername.Location = new System.Drawing.Point(14, 66);
            this.txtCreateAccountUsername.Name = "txtCreateAccountUsername";
            this.txtCreateAccountUsername.Size = new System.Drawing.Size(139, 20);
            this.txtCreateAccountUsername.TabIndex = 0;
            // 
            // lblCreateAccountUsername
            // 
            this.lblCreateAccountUsername.AutoSize = true;
            this.lblCreateAccountUsername.Location = new System.Drawing.Point(11, 50);
            this.lblCreateAccountUsername.Name = "lblCreateAccountUsername";
            this.lblCreateAccountUsername.Size = new System.Drawing.Size(58, 13);
            this.lblCreateAccountUsername.TabIndex = 6;
            this.lblCreateAccountUsername.Text = "Username:";
            // 
            // lblCreateAccount
            // 
            this.lblCreateAccount.AutoSize = true;
            this.lblCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateAccount.Location = new System.Drawing.Point(11, 11);
            this.lblCreateAccount.Name = "lblCreateAccount";
            this.lblCreateAccount.Size = new System.Drawing.Size(162, 25);
            this.lblCreateAccount.TabIndex = 1;
            this.lblCreateAccount.Text = "Create Account";
            // 
            // pnLogin
            // 
            this.pnLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLogin.Controls.Add(this.lblLoginAccountError);
            this.pnLogin.Controls.Add(this.btnLogin);
            this.pnLogin.Controls.Add(this.txtLoginPassword);
            this.pnLogin.Controls.Add(this.lblLoginPassword);
            this.pnLogin.Controls.Add(this.txtLoginUsername);
            this.pnLogin.Controls.Add(this.lblLoginUsername);
            this.pnLogin.Controls.Add(this.lblLogin);
            this.pnLogin.Location = new System.Drawing.Point(14, 16);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(271, 236);
            this.pnLogin.TabIndex = 0;
            // 
            // lblLoginAccountError
            // 
            this.lblLoginAccountError.ForeColor = System.Drawing.Color.Red;
            this.lblLoginAccountError.Location = new System.Drawing.Point(13, 179);
            this.lblLoginAccountError.Name = "lblLoginAccountError";
            this.lblLoginAccountError.Size = new System.Drawing.Size(244, 45);
            this.lblLoginAccountError.TabIndex = 15;
            this.lblLoginAccountError.Text = "*";
            this.lblLoginAccountError.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(149, 149);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(98, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(14, 123);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '•';
            this.txtLoginPassword.Size = new System.Drawing.Size(233, 20);
            this.txtLoginPassword.TabIndex = 1;
            // 
            // lblLoginPassword
            // 
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Location = new System.Drawing.Point(11, 107);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Size = new System.Drawing.Size(56, 13);
            this.lblLoginPassword.TabIndex = 3;
            this.lblLoginPassword.Text = "Password:";
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.Location = new System.Drawing.Point(14, 66);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(233, 20);
            this.txtLoginUsername.TabIndex = 0;
            // 
            // lblLoginUsername
            // 
            this.lblLoginUsername.AutoSize = true;
            this.lblLoginUsername.Location = new System.Drawing.Point(11, 50);
            this.lblLoginUsername.Name = "lblLoginUsername";
            this.lblLoginUsername.Size = new System.Drawing.Size(58, 13);
            this.lblLoginUsername.TabIndex = 1;
            this.lblLoginUsername.Text = "Username:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(10, 11);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(65, 25);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            // 
            // lblServerNameFillMe
            // 
            this.lblServerNameFillMe.AutoSize = true;
            this.lblServerNameFillMe.Location = new System.Drawing.Point(106, 273);
            this.lblServerNameFillMe.Name = "lblServerNameFillMe";
            this.lblServerNameFillMe.Size = new System.Drawing.Size(72, 13);
            this.lblServerNameFillMe.TabIndex = 2;
            this.lblServerNameFillMe.Text = "[ServerName]";
            // 
            // lblSelectedServer
            // 
            this.lblSelectedServer.AutoSize = true;
            this.lblSelectedServer.Location = new System.Drawing.Point(14, 273);
            this.lblSelectedServer.Name = "lblSelectedServer";
            this.lblSelectedServer.Size = new System.Drawing.Size(86, 13);
            this.lblSelectedServer.TabIndex = 1;
            this.lblSelectedServer.Text = "Server Selected:";
            // 
            // tbGameList
            // 
            this.tbGameList.BackColor = System.Drawing.SystemColors.Control;
            this.tbGameList.Controls.Add(this.btnAccountSettings);
            this.tbGameList.Controls.Add(this.btnCreateGame);
            this.tbGameList.Controls.Add(this.btnJoinGame);
            this.tbGameList.Controls.Add(this.lblGamesListKey);
            this.tbGameList.Controls.Add(this.lblGameListPlayers);
            this.tbGameList.Controls.Add(this.lblGamesListBoardSize);
            this.tbGameList.Controls.Add(this.lblGamesListName);
            this.tbGameList.Controls.Add(this.lblGamesList);
            this.tbGameList.Controls.Add(this.lbGameList);
            this.tbGameList.Controls.Add(this.tcUserInfo);
            this.tbGameList.Location = new System.Drawing.Point(4, 22);
            this.tbGameList.Name = "tbGameList";
            this.tbGameList.Padding = new System.Windows.Forms.Padding(3);
            this.tbGameList.Size = new System.Drawing.Size(586, 299);
            this.tbGameList.TabIndex = 2;
            this.tbGameList.Text = "GameList";
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.Location = new System.Drawing.Point(440, 288);
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.Size = new System.Drawing.Size(140, 23);
            this.btnAccountSettings.TabIndex = 8;
            this.btnAccountSettings.Text = "Account Settings";
            this.btnAccountSettings.UseVisualStyleBackColor = true;
            this.btnAccountSettings.Click += new System.EventHandler(this.btnAccountSettings_Click);
            // 
            // btnCreateGame
            // 
            this.btnCreateGame.Location = new System.Drawing.Point(10, 288);
            this.btnCreateGame.Name = "btnCreateGame";
            this.btnCreateGame.Size = new System.Drawing.Size(140, 23);
            this.btnCreateGame.TabIndex = 7;
            this.btnCreateGame.Text = "Create Game";
            this.btnCreateGame.UseVisualStyleBackColor = true;
            this.btnCreateGame.Click += new System.EventHandler(this.btnCreateGame_Click);
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.Location = new System.Drawing.Point(163, 288);
            this.btnJoinGame.Name = "btnJoinGame";
            this.btnJoinGame.Size = new System.Drawing.Size(140, 23);
            this.btnJoinGame.TabIndex = 0;
            this.btnJoinGame.Text = "Join Game";
            this.btnJoinGame.UseVisualStyleBackColor = true;
            this.btnJoinGame.Click += new System.EventHandler(this.btnJoinGame_Click);
            // 
            // lblGamesListKey
            // 
            this.lblGamesListKey.AutoSize = true;
            this.lblGamesListKey.Location = new System.Drawing.Point(7, 269);
            this.lblGamesListKey.Name = "lblGamesListKey";
            this.lblGamesListKey.Size = new System.Drawing.Size(177, 13);
            this.lblGamesListKey.TabIndex = 6;
            this.lblGamesListKey.Text = "(P) = Password required, (O) = Open";
            // 
            // lblGameListPlayers
            // 
            this.lblGameListPlayers.AutoSize = true;
            this.lblGameListPlayers.Location = new System.Drawing.Point(262, 24);
            this.lblGameListPlayers.Name = "lblGameListPlayers";
            this.lblGameListPlayers.Size = new System.Drawing.Size(41, 13);
            this.lblGameListPlayers.TabIndex = 5;
            this.lblGameListPlayers.Text = "Players";
            // 
            // lblGamesListBoardSize
            // 
            this.lblGamesListBoardSize.AutoSize = true;
            this.lblGamesListBoardSize.Location = new System.Drawing.Point(197, 24);
            this.lblGamesListBoardSize.Name = "lblGamesListBoardSize";
            this.lblGamesListBoardSize.Size = new System.Drawing.Size(58, 13);
            this.lblGamesListBoardSize.TabIndex = 4;
            this.lblGamesListBoardSize.Text = "Board Size";
            // 
            // lblGamesListName
            // 
            this.lblGamesListName.AutoSize = true;
            this.lblGamesListName.Location = new System.Drawing.Point(7, 24);
            this.lblGamesListName.Name = "lblGamesListName";
            this.lblGamesListName.Size = new System.Drawing.Size(35, 13);
            this.lblGamesListName.TabIndex = 3;
            this.lblGamesListName.Text = "Name";
            // 
            // lblGamesList
            // 
            this.lblGamesList.AutoSize = true;
            this.lblGamesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblGamesList.Location = new System.Drawing.Point(7, 6);
            this.lblGamesList.Name = "lblGamesList";
            this.lblGamesList.Size = new System.Drawing.Size(58, 17);
            this.lblGamesList.TabIndex = 2;
            this.lblGamesList.Text = "Games";
            // 
            // lbGameList
            // 
            this.lbGameList.Font = new System.Drawing.Font("Consolas", 9F);
            this.lbGameList.FormattingEnabled = true;
            this.lbGameList.ItemHeight = 14;
            this.lbGameList.Location = new System.Drawing.Point(10, 39);
            this.lbGameList.Name = "lbGameList";
            this.lbGameList.Size = new System.Drawing.Size(293, 228);
            this.lbGameList.TabIndex = 1;
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tabPage3);
            this.tcUserInfo.Location = new System.Drawing.Point(309, 6);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(271, 261);
            this.tcUserInfo.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(263, 235);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Leaderboards";
            // 
            // tbGameLobby
            // 
            this.tbGameLobby.BackColor = System.Drawing.SystemColors.Control;
            this.tbGameLobby.Controls.Add(this.lblVotesRequiredText);
            this.tbGameLobby.Controls.Add(this.lblVotesRequired);
            this.tbGameLobby.Controls.Add(this.lblVotesToStartText);
            this.tbGameLobby.Controls.Add(this.lblGameStatusText);
            this.tbGameLobby.Controls.Add(this.lblBoardSizeText);
            this.tbGameLobby.Controls.Add(this.lblNumberPlayersText);
            this.tbGameLobby.Controls.Add(this.lblLobbyNameText);
            this.tbGameLobby.Controls.Add(this.lblVotesToStart);
            this.tbGameLobby.Controls.Add(this.lblGameStatus);
            this.tbGameLobby.Controls.Add(this.lblBoardSize);
            this.tbGameLobby.Controls.Add(this.lblNumberPlayers);
            this.tbGameLobby.Controls.Add(this.lblLobbyName);
            this.tbGameLobby.Controls.Add(this.btnVoteStart);
            this.tbGameLobby.Controls.Add(this.lblInGameWaiting);
            this.tbGameLobby.Controls.Add(this.lblPlayers);
            this.tbGameLobby.Controls.Add(this.lblGameInfo);
            this.tbGameLobby.Controls.Add(this.lbPlayers);
            this.tbGameLobby.Controls.Add(this.btnExitGame);
            this.tbGameLobby.Controls.Add(this.lblGameLobby);
            this.tbGameLobby.Location = new System.Drawing.Point(4, 22);
            this.tbGameLobby.Name = "tbGameLobby";
            this.tbGameLobby.Padding = new System.Windows.Forms.Padding(3);
            this.tbGameLobby.Size = new System.Drawing.Size(586, 299);
            this.tbGameLobby.TabIndex = 3;
            this.tbGameLobby.Text = "Lobby";
            // 
            // lblVotesRequiredText
            // 
            this.lblVotesRequiredText.AutoSize = true;
            this.lblVotesRequiredText.Location = new System.Drawing.Point(114, 138);
            this.lblVotesRequiredText.Name = "lblVotesRequiredText";
            this.lblVotesRequiredText.Size = new System.Drawing.Size(13, 13);
            this.lblVotesRequiredText.TabIndex = 28;
            this.lblVotesRequiredText.Text = "2";
            // 
            // lblVotesRequired
            // 
            this.lblVotesRequired.AutoSize = true;
            this.lblVotesRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVotesRequired.Location = new System.Drawing.Point(12, 138);
            this.lblVotesRequired.Name = "lblVotesRequired";
            this.lblVotesRequired.Size = new System.Drawing.Size(98, 13);
            this.lblVotesRequired.TabIndex = 27;
            this.lblVotesRequired.Text = "Votes Required:";
            // 
            // lblVotesToStartText
            // 
            this.lblVotesToStartText.AutoSize = true;
            this.lblVotesToStartText.Location = new System.Drawing.Point(114, 120);
            this.lblVotesToStartText.Name = "lblVotesToStartText";
            this.lblVotesToStartText.Size = new System.Drawing.Size(75, 13);
            this.lblVotesToStartText.TabIndex = 26;
            this.lblVotesToStartText.Text = "[VotesToStart]";
            // 
            // lblGameStatusText
            // 
            this.lblGameStatusText.AutoSize = true;
            this.lblGameStatusText.Location = new System.Drawing.Point(114, 102);
            this.lblGameStatusText.Name = "lblGameStatusText";
            this.lblGameStatusText.Size = new System.Drawing.Size(71, 13);
            this.lblGameStatusText.TabIndex = 25;
            this.lblGameStatusText.Text = "[GameStatus]";
            // 
            // lblBoardSizeText
            // 
            this.lblBoardSizeText.AutoSize = true;
            this.lblBoardSizeText.Location = new System.Drawing.Point(114, 84);
            this.lblBoardSizeText.Name = "lblBoardSizeText";
            this.lblBoardSizeText.Size = new System.Drawing.Size(61, 13);
            this.lblBoardSizeText.TabIndex = 24;
            this.lblBoardSizeText.Text = "[BoardSize]";
            // 
            // lblNumberPlayersText
            // 
            this.lblNumberPlayersText.AutoSize = true;
            this.lblNumberPlayersText.Location = new System.Drawing.Point(114, 66);
            this.lblNumberPlayersText.Name = "lblNumberPlayersText";
            this.lblNumberPlayersText.Size = new System.Drawing.Size(84, 13);
            this.lblNumberPlayersText.TabIndex = 23;
            this.lblNumberPlayersText.Text = "[NumberPlayers]";
            // 
            // lblLobbyNameText
            // 
            this.lblLobbyNameText.AutoSize = true;
            this.lblLobbyNameText.Location = new System.Drawing.Point(114, 48);
            this.lblLobbyNameText.Name = "lblLobbyNameText";
            this.lblLobbyNameText.Size = new System.Drawing.Size(70, 13);
            this.lblLobbyNameText.TabIndex = 22;
            this.lblLobbyNameText.Text = "[LobbyName]";
            // 
            // lblVotesToStart
            // 
            this.lblVotesToStart.AutoSize = true;
            this.lblVotesToStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVotesToStart.Location = new System.Drawing.Point(12, 120);
            this.lblVotesToStart.Name = "lblVotesToStart";
            this.lblVotesToStart.Size = new System.Drawing.Size(93, 13);
            this.lblVotesToStart.TabIndex = 21;
            this.lblVotesToStart.Text = "Votes To Start:";
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameStatus.Location = new System.Drawing.Point(12, 102);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(83, 13);
            this.lblGameStatus.TabIndex = 20;
            this.lblGameStatus.Text = "Game Status:";
            // 
            // lblBoardSize
            // 
            this.lblBoardSize.AutoSize = true;
            this.lblBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardSize.Location = new System.Drawing.Point(12, 84);
            this.lblBoardSize.Name = "lblBoardSize";
            this.lblBoardSize.Size = new System.Drawing.Size(72, 13);
            this.lblBoardSize.TabIndex = 19;
            this.lblBoardSize.Text = "Board Size:";
            // 
            // lblNumberPlayers
            // 
            this.lblNumberPlayers.AutoSize = true;
            this.lblNumberPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberPlayers.Location = new System.Drawing.Point(12, 66);
            this.lblNumberPlayers.Name = "lblNumberPlayers";
            this.lblNumberPlayers.Size = new System.Drawing.Size(83, 13);
            this.lblNumberPlayers.TabIndex = 18;
            this.lblNumberPlayers.Text = "# of Players: ";
            // 
            // lblLobbyName
            // 
            this.lblLobbyName.AutoSize = true;
            this.lblLobbyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLobbyName.Location = new System.Drawing.Point(12, 48);
            this.lblLobbyName.Name = "lblLobbyName";
            this.lblLobbyName.Size = new System.Drawing.Size(85, 13);
            this.lblLobbyName.TabIndex = 17;
            this.lblLobbyName.Text = "Lobby Name: ";
            // 
            // btnVoteStart
            // 
            this.btnVoteStart.Location = new System.Drawing.Point(317, 241);
            this.btnVoteStart.Name = "btnVoteStart";
            this.btnVoteStart.Size = new System.Drawing.Size(119, 23);
            this.btnVoteStart.TabIndex = 16;
            this.btnVoteStart.Text = "Vote Start";
            this.btnVoteStart.UseVisualStyleBackColor = true;
            this.btnVoteStart.Click += new System.EventHandler(this.btnVoteStart_Click);
            // 
            // lblInGameWaiting
            // 
            this.lblInGameWaiting.AutoSize = true;
            this.lblInGameWaiting.Location = new System.Drawing.Point(314, 221);
            this.lblInGameWaiting.Name = "lblInGameWaiting";
            this.lblInGameWaiting.Size = new System.Drawing.Size(137, 13);
            this.lblInGameWaiting.TabIndex = 14;
            this.lblInGameWaiting.Text = "(I) = In game, (W) = Waiting";
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPlayers.Location = new System.Drawing.Point(314, 27);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(62, 17);
            this.lblPlayers.TabIndex = 13;
            this.lblPlayers.Text = "Players";
            // 
            // lblGameInfo
            // 
            this.lblGameInfo.AutoSize = true;
            this.lblGameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGameInfo.Location = new System.Drawing.Point(11, 27);
            this.lblGameInfo.Name = "lblGameInfo";
            this.lblGameInfo.Size = new System.Drawing.Size(82, 17);
            this.lblGameInfo.TabIndex = 12;
            this.lblGameInfo.Text = "Game Info";
            // 
            // lbPlayers
            // 
            this.lbPlayers.Font = new System.Drawing.Font("Consolas", 9F);
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.ItemHeight = 14;
            this.lbPlayers.Location = new System.Drawing.Point(317, 46);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbPlayers.Size = new System.Drawing.Size(251, 172);
            this.lbPlayers.TabIndex = 9;
            // 
            // btnExitGame
            // 
            this.btnExitGame.Location = new System.Drawing.Point(449, 241);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new System.Drawing.Size(119, 23);
            this.btnExitGame.TabIndex = 4;
            this.btnExitGame.Text = "Exit Lobby";
            this.btnExitGame.UseVisualStyleBackColor = true;
            this.btnExitGame.Click += new System.EventHandler(this.btnExitGame_Click);
            // 
            // lblGameLobby
            // 
            this.lblGameLobby.AutoSize = true;
            this.lblGameLobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameLobby.Location = new System.Drawing.Point(7, 3);
            this.lblGameLobby.Name = "lblGameLobby";
            this.lblGameLobby.Size = new System.Drawing.Size(122, 25);
            this.lblGameLobby.TabIndex = 3;
            this.lblGameLobby.Text = "Game Loby";
            // 
            // tbAccountSettings
            // 
            this.tbAccountSettings.BackColor = System.Drawing.SystemColors.Control;
            this.tbAccountSettings.Controls.Add(this.lblDeletePasswordError);
            this.tbAccountSettings.Controls.Add(this.txtDeletePassword);
            this.tbAccountSettings.Controls.Add(this.lblDeletePassword);
            this.tbAccountSettings.Controls.Add(this.txtDeleteUsername);
            this.tbAccountSettings.Controls.Add(this.lblDeleteUsername);
            this.tbAccountSettings.Controls.Add(this.btnReturnToList);
            this.tbAccountSettings.Controls.Add(this.btnDeleteAccount);
            this.tbAccountSettings.Controls.Add(this.label3);
            this.tbAccountSettings.Location = new System.Drawing.Point(4, 22);
            this.tbAccountSettings.Name = "tbAccountSettings";
            this.tbAccountSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbAccountSettings.Size = new System.Drawing.Size(586, 299);
            this.tbAccountSettings.TabIndex = 4;
            this.tbAccountSettings.Text = "AccountSettings";
            // 
            // lblDeletePasswordError
            // 
            this.lblDeletePasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblDeletePasswordError.Location = new System.Drawing.Point(9, 173);
            this.lblDeletePasswordError.Name = "lblDeletePasswordError";
            this.lblDeletePasswordError.Size = new System.Drawing.Size(244, 45);
            this.lblDeletePasswordError.TabIndex = 16;
            this.lblDeletePasswordError.Text = "*";
            this.lblDeletePasswordError.Visible = false;
            // 
            // txtDeletePassword
            // 
            this.txtDeletePassword.Location = new System.Drawing.Point(12, 106);
            this.txtDeletePassword.Name = "txtDeletePassword";
            this.txtDeletePassword.PasswordChar = '•';
            this.txtDeletePassword.Size = new System.Drawing.Size(233, 20);
            this.txtDeletePassword.TabIndex = 0;
            // 
            // lblDeletePassword
            // 
            this.lblDeletePassword.AutoSize = true;
            this.lblDeletePassword.Location = new System.Drawing.Point(9, 90);
            this.lblDeletePassword.Name = "lblDeletePassword";
            this.lblDeletePassword.Size = new System.Drawing.Size(56, 13);
            this.lblDeletePassword.TabIndex = 13;
            this.lblDeletePassword.Text = "Password:";
            // 
            // txtDeleteUsername
            // 
            this.txtDeleteUsername.Location = new System.Drawing.Point(12, 49);
            this.txtDeleteUsername.Name = "txtDeleteUsername";
            this.txtDeleteUsername.Size = new System.Drawing.Size(233, 20);
            this.txtDeleteUsername.TabIndex = 10;
            this.txtDeleteUsername.TabStop = false;
            // 
            // lblDeleteUsername
            // 
            this.lblDeleteUsername.AutoSize = true;
            this.lblDeleteUsername.Location = new System.Drawing.Point(9, 33);
            this.lblDeleteUsername.Name = "lblDeleteUsername";
            this.lblDeleteUsername.Size = new System.Drawing.Size(58, 13);
            this.lblDeleteUsername.TabIndex = 12;
            this.lblDeleteUsername.Text = "Username:";
            // 
            // btnReturnToList
            // 
            this.btnReturnToList.Location = new System.Drawing.Point(12, 142);
            this.btnReturnToList.Name = "btnReturnToList";
            this.btnReturnToList.Size = new System.Drawing.Size(114, 23);
            this.btnReturnToList.TabIndex = 1;
            this.btnReturnToList.Text = "Return to List";
            this.btnReturnToList.UseVisualStyleBackColor = true;
            this.btnReturnToList.Click += new System.EventHandler(this.btnReturnToList_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(131, 142);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(114, 23);
            this.btnDeleteAccount.TabIndex = 2;
            this.btnDeleteAccount.Text = "Delete Account";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Account Settings";
            // 
            // tbCreateGame
            // 
            this.tbCreateGame.BackColor = System.Drawing.SystemColors.Control;
            this.tbCreateGame.Controls.Add(this.txtGamePassword);
            this.tbCreateGame.Controls.Add(this.lblGamePassword);
            this.tbCreateGame.Controls.Add(this.rbNoPasswordProtect);
            this.tbCreateGame.Controls.Add(this.rbPasswordProtect);
            this.tbCreateGame.Controls.Add(this.lblPaswordProtect);
            this.tbCreateGame.Controls.Add(this.cbGridSize);
            this.tbCreateGame.Controls.Add(this.lblGridSize);
            this.tbCreateGame.Controls.Add(this.lblCreateGameError);
            this.tbCreateGame.Controls.Add(this.btnReturnToList1);
            this.tbCreateGame.Controls.Add(this.btnCreateDotsGame);
            this.tbCreateGame.Controls.Add(this.cbGameUsers);
            this.tbCreateGame.Controls.Add(this.lblNumberOfUsers);
            this.tbCreateGame.Controls.Add(this.txtGameName);
            this.tbCreateGame.Controls.Add(this.lblPublicGameName);
            this.tbCreateGame.Controls.Add(this.lblCreateGame);
            this.tbCreateGame.Location = new System.Drawing.Point(4, 22);
            this.tbCreateGame.Name = "tbCreateGame";
            this.tbCreateGame.Padding = new System.Windows.Forms.Padding(3);
            this.tbCreateGame.Size = new System.Drawing.Size(586, 299);
            this.tbCreateGame.TabIndex = 5;
            this.tbCreateGame.Text = "Create Game";
            // 
            // txtGamePassword
            // 
            this.txtGamePassword.Enabled = false;
            this.txtGamePassword.Location = new System.Drawing.Point(12, 229);
            this.txtGamePassword.Name = "txtGamePassword";
            this.txtGamePassword.PasswordChar = '•';
            this.txtGamePassword.Size = new System.Drawing.Size(233, 20);
            this.txtGamePassword.TabIndex = 5;
            // 
            // lblGamePassword
            // 
            this.lblGamePassword.AutoSize = true;
            this.lblGamePassword.Location = new System.Drawing.Point(9, 213);
            this.lblGamePassword.Name = "lblGamePassword";
            this.lblGamePassword.Size = new System.Drawing.Size(87, 13);
            this.lblGamePassword.TabIndex = 29;
            this.lblGamePassword.Text = "Game Password:";
            // 
            // rbNoPasswordProtect
            // 
            this.rbNoPasswordProtect.AutoSize = true;
            this.rbNoPasswordProtect.Checked = true;
            this.rbNoPasswordProtect.Location = new System.Drawing.Point(73, 186);
            this.rbNoPasswordProtect.Name = "rbNoPasswordProtect";
            this.rbNoPasswordProtect.Size = new System.Drawing.Size(39, 17);
            this.rbNoPasswordProtect.TabIndex = 4;
            this.rbNoPasswordProtect.TabStop = true;
            this.rbNoPasswordProtect.Text = "No";
            this.rbNoPasswordProtect.UseVisualStyleBackColor = true;
            // 
            // rbPasswordProtect
            // 
            this.rbPasswordProtect.AutoSize = true;
            this.rbPasswordProtect.Location = new System.Drawing.Point(12, 186);
            this.rbPasswordProtect.Name = "rbPasswordProtect";
            this.rbPasswordProtect.Size = new System.Drawing.Size(43, 17);
            this.rbPasswordProtect.TabIndex = 3;
            this.rbPasswordProtect.Text = "Yes";
            this.rbPasswordProtect.UseVisualStyleBackColor = true;
            this.rbPasswordProtect.CheckedChanged += new System.EventHandler(this.rbPasswordProtect_CheckedChanged);
            // 
            // lblPaswordProtect
            // 
            this.lblPaswordProtect.AutoSize = true;
            this.lblPaswordProtect.Location = new System.Drawing.Point(9, 168);
            this.lblPaswordProtect.Name = "lblPaswordProtect";
            this.lblPaswordProtect.Size = new System.Drawing.Size(124, 13);
            this.lblPaswordProtect.TabIndex = 25;
            this.lblPaswordProtect.Text = "Password Protect Game:";
            // 
            // cbGridSize
            // 
            this.cbGridSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGridSize.FormattingEnabled = true;
            this.cbGridSize.Items.AddRange(new object[] {
            "4X4",
            "6X6",
            "8X8"});
            this.cbGridSize.Location = new System.Drawing.Point(12, 139);
            this.cbGridSize.Name = "cbGridSize";
            this.cbGridSize.Size = new System.Drawing.Size(233, 21);
            this.cbGridSize.TabIndex = 2;
            // 
            // lblGridSize
            // 
            this.lblGridSize.AutoSize = true;
            this.lblGridSize.Location = new System.Drawing.Point(9, 123);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(52, 13);
            this.lblGridSize.TabIndex = 23;
            this.lblGridSize.Text = "Grid Size:";
            // 
            // lblCreateGameError
            // 
            this.lblCreateGameError.ForeColor = System.Drawing.Color.Red;
            this.lblCreateGameError.Location = new System.Drawing.Point(9, 288);
            this.lblCreateGameError.Name = "lblCreateGameError";
            this.lblCreateGameError.Size = new System.Drawing.Size(244, 45);
            this.lblCreateGameError.TabIndex = 22;
            this.lblCreateGameError.Text = "*";
            this.lblCreateGameError.Visible = false;
            // 
            // btnReturnToList1
            // 
            this.btnReturnToList1.Location = new System.Drawing.Point(12, 258);
            this.btnReturnToList1.Name = "btnReturnToList1";
            this.btnReturnToList1.Size = new System.Drawing.Size(114, 23);
            this.btnReturnToList1.TabIndex = 7;
            this.btnReturnToList1.Text = "Return to List";
            this.btnReturnToList1.UseVisualStyleBackColor = true;
            this.btnReturnToList1.Click += new System.EventHandler(this.btnReturnToList_Click);
            // 
            // btnCreateDotsGame
            // 
            this.btnCreateDotsGame.Location = new System.Drawing.Point(131, 258);
            this.btnCreateDotsGame.Name = "btnCreateDotsGame";
            this.btnCreateDotsGame.Size = new System.Drawing.Size(114, 23);
            this.btnCreateDotsGame.TabIndex = 6;
            this.btnCreateDotsGame.Text = "Create Game";
            this.btnCreateDotsGame.UseVisualStyleBackColor = true;
            this.btnCreateDotsGame.Click += new System.EventHandler(this.btnCreateDotsGame_Click);
            // 
            // cbGameUsers
            // 
            this.cbGameUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGameUsers.FormattingEnabled = true;
            this.cbGameUsers.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.cbGameUsers.Location = new System.Drawing.Point(12, 94);
            this.cbGameUsers.Name = "cbGameUsers";
            this.cbGameUsers.Size = new System.Drawing.Size(233, 21);
            this.cbGameUsers.TabIndex = 1;
            // 
            // lblNumberOfUsers
            // 
            this.lblNumberOfUsers.AutoSize = true;
            this.lblNumberOfUsers.Location = new System.Drawing.Point(9, 78);
            this.lblNumberOfUsers.Name = "lblNumberOfUsers";
            this.lblNumberOfUsers.Size = new System.Drawing.Size(89, 13);
            this.lblNumberOfUsers.TabIndex = 17;
            this.lblNumberOfUsers.Text = "Number of Users:";
            // 
            // txtGameName
            // 
            this.txtGameName.Location = new System.Drawing.Point(12, 49);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(233, 20);
            this.txtGameName.TabIndex = 0;
            this.txtGameName.TabStop = false;
            // 
            // lblPublicGameName
            // 
            this.lblPublicGameName.AutoSize = true;
            this.lblPublicGameName.Location = new System.Drawing.Point(9, 33);
            this.lblPublicGameName.Name = "lblPublicGameName";
            this.lblPublicGameName.Size = new System.Drawing.Size(68, 13);
            this.lblPublicGameName.TabIndex = 13;
            this.lblPublicGameName.Text = "Lobby name:";
            // 
            // lblCreateGame
            // 
            this.lblCreateGame.AutoSize = true;
            this.lblCreateGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateGame.Location = new System.Drawing.Point(7, 3);
            this.lblCreateGame.Name = "lblCreateGame";
            this.lblCreateGame.Size = new System.Drawing.Size(140, 25);
            this.lblCreateGame.TabIndex = 2;
            this.lblCreateGame.Text = "Create Game";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 326);
            this.Controls.Add(this.tcMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(613, 365);
            this.MinimumSize = new System.Drawing.Size(613, 365);
            this.Name = "MainMenu";
            this.Text = "Dots & Boxes";
            this.tcMainMenu.ResumeLayout(false);
            this.tbSelectServer.ResumeLayout(false);
            this.tbSelectServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbLogin.ResumeLayout(false);
            this.tbLogin.PerformLayout();
            this.pnCreateAccount.ResumeLayout(false);
            this.pnCreateAccount.PerformLayout();
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.tbGameList.ResumeLayout(false);
            this.tbGameList.PerformLayout();
            this.tcUserInfo.ResumeLayout(false);
            this.tbGameLobby.ResumeLayout(false);
            this.tbGameLobby.PerformLayout();
            this.tbAccountSettings.ResumeLayout(false);
            this.tbAccountSettings.PerformLayout();
            this.tbCreateGame.ResumeLayout(false);
            this.tbCreateGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabControl tcMainMenu;
        private System.Windows.Forms.TabPage tbSelectServer;
        private System.Windows.Forms.TabPage tbLogin;
        private System.Windows.Forms.Button btnSelectServer;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblSelectedServer;
        private System.Windows.Forms.Label lblServerNameFillMe;
        private System.Windows.Forms.Panel pnCreateAccount;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Button btnCheckUsernameAvailability;
        private System.Windows.Forms.TextBox txtCreateAccountPassword;
        private System.Windows.Forms.Label lblCreateAccountPassword;
        private System.Windows.Forms.TextBox txtCreateAccountUsername;
        private System.Windows.Forms.Label lblCreateAccountUsername;
        private System.Windows.Forms.Label lblCreateAccount;
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.Label lblLoginUsername;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblServerConnectError;
        private System.Windows.Forms.Label lblCreateAccountError;
        private System.Windows.Forms.TabPage tbGameList;
        private System.Windows.Forms.Button btnCreateGame;
        private System.Windows.Forms.Button btnJoinGame;
        private System.Windows.Forms.Label lblGamesListKey;
        private System.Windows.Forms.Label lblGameListPlayers;
        private System.Windows.Forms.Label lblGamesListBoardSize;
        private System.Windows.Forms.Label lblGamesListName;
        private System.Windows.Forms.Label lblGamesList;
        private System.Windows.Forms.ListBox lbGameList;
        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Timer timRefreshGameList;
        private System.Windows.Forms.TabPage tbGameLobby;
        private System.Windows.Forms.Label lblLoginAccountError;
        private System.Windows.Forms.Button btnAccountSettings;
        private System.Windows.Forms.TabPage tbAccountSettings;
        private System.Windows.Forms.Button btnReturnToList;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeletePassword;
        private System.Windows.Forms.Label lblDeletePassword;
        private System.Windows.Forms.TextBox txtDeleteUsername;
        private System.Windows.Forms.Label lblDeleteUsername;
        private System.Windows.Forms.Label lblDeletePasswordError;
        private System.Windows.Forms.TabPage tbCreateGame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPublicGameName;
        private System.Windows.Forms.Label lblCreateGame;
        private System.Windows.Forms.TextBox txtGamePassword;
        private System.Windows.Forms.Label lblGamePassword;
        private System.Windows.Forms.RadioButton rbNoPasswordProtect;
        private System.Windows.Forms.RadioButton rbPasswordProtect;
        private System.Windows.Forms.Label lblPaswordProtect;
        private System.Windows.Forms.ComboBox cbGridSize;
        private System.Windows.Forms.Label lblGridSize;
        private System.Windows.Forms.Label lblCreateGameError;
        private System.Windows.Forms.Button btnReturnToList1;
        private System.Windows.Forms.Button btnCreateDotsGame;
        private System.Windows.Forms.ComboBox cbGameUsers;
        private System.Windows.Forms.Label lblNumberOfUsers;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Label lblGameLobby;
        private System.Windows.Forms.Timer timRefreshLobby;
        private System.Windows.Forms.Button btnExitGame;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblGameInfo;
        private System.Windows.Forms.ListBox lbPlayers;
        private System.Windows.Forms.Label lblVotesToStartText;
        private System.Windows.Forms.Label lblGameStatusText;
        private System.Windows.Forms.Label lblBoardSizeText;
        private System.Windows.Forms.Label lblNumberPlayersText;
        private System.Windows.Forms.Label lblLobbyNameText;
        private System.Windows.Forms.Label lblVotesToStart;
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.Label lblBoardSize;
        private System.Windows.Forms.Label lblNumberPlayers;
        private System.Windows.Forms.Label lblLobbyName;
        private System.Windows.Forms.Button btnVoteStart;
        private System.Windows.Forms.Label lblInGameWaiting;
        private System.Windows.Forms.Label lblVotesRequiredText;
        private System.Windows.Forms.Label lblVotesRequired;

    }
}

