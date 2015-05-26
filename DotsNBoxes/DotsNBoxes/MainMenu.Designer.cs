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
            this.timRefreshGameList = new System.Windows.Forms.Timer(this.components);
            this.tcMainMenu = new DotsNBoxes.CustomTabControl();
            this.tbSelectServer = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbGameLobby = new System.Windows.Forms.TabPage();
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
            this.tcMainMenu.SuspendLayout();
            this.tbSelectServer.SuspendLayout();
            this.tbLogin.SuspendLayout();
            this.pnCreateAccount.SuspendLayout();
            this.pnLogin.SuspendLayout();
            this.tbGameList.SuspendLayout();
            this.tcUserInfo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tbAccountSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // timRefreshGameList
            // 
            this.timRefreshGameList.Interval = 1000;
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
            // lblServerConnectError
            // 
            this.lblServerConnectError.AutoSize = true;
            this.lblServerConnectError.ForeColor = System.Drawing.Color.Red;
            this.lblServerConnectError.Location = new System.Drawing.Point(159, 171);
            this.lblServerConnectError.Name = "lblServerConnectError";
            this.lblServerConnectError.Size = new System.Drawing.Size(11, 13);
            this.lblServerConnectError.TabIndex = 3;
            this.lblServerConnectError.Text = "*";
            this.lblServerConnectError.Visible = false;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(160, 147);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(176, 20);
            this.txtServerName.TabIndex = 0;
            this.txtServerName.Text = "127.0.0.1";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(157, 131);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(100, 13);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "Enter Server Name:";
            // 
            // btnSelectServer
            // 
            this.btnSelectServer.Location = new System.Drawing.Point(342, 147);
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
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.Location = new System.Drawing.Point(163, 288);
            this.btnJoinGame.Name = "btnJoinGame";
            this.btnJoinGame.Size = new System.Drawing.Size(140, 23);
            this.btnJoinGame.TabIndex = 0;
            this.btnJoinGame.Text = "Join Game";
            this.btnJoinGame.UseVisualStyleBackColor = true;
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
            this.lblGamesListBoardSize.Location = new System.Drawing.Point(200, 24);
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
            this.lbGameList.Items.AddRange(new object[] {
            "(P) EFGHIJKLMNOPABCDEFGH   8X8      1/4"});
            this.lbGameList.Location = new System.Drawing.Point(10, 39);
            this.lbGameList.Name = "lbGameList";
            this.lbGameList.Size = new System.Drawing.Size(293, 228);
            this.lbGameList.TabIndex = 1;
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tabPage2);
            this.tcUserInfo.Controls.Add(this.tabPage3);
            this.tcUserInfo.Location = new System.Drawing.Point(309, 6);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(271, 261);
            this.tcUserInfo.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(263, 235);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Users Online";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "In Game";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Stalk User";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 9F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Items.AddRange(new object[] {
            "AAAAAAAAAAAAAAAAAAAA   Yes"});
            this.listBox1.Location = new System.Drawing.Point(6, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(251, 172);
            this.listBox1.TabIndex = 4;
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
            this.tbGameLobby.Location = new System.Drawing.Point(4, 22);
            this.tbGameLobby.Name = "tbGameLobby";
            this.tbGameLobby.Padding = new System.Windows.Forms.Padding(3);
            this.tbGameLobby.Size = new System.Drawing.Size(586, 299);
            this.tbGameLobby.TabIndex = 3;
            this.tbGameLobby.Text = "Lobby";
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
            this.tbCreateGame.Location = new System.Drawing.Point(4, 22);
            this.tbCreateGame.Name = "tbCreateGame";
            this.tbCreateGame.Padding = new System.Windows.Forms.Padding(3);
            this.tbCreateGame.Size = new System.Drawing.Size(586, 299);
            this.tbCreateGame.TabIndex = 5;
            this.tbCreateGame.Text = "Create Game";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 326);
            this.Controls.Add(this.tcMainMenu);
            this.MaximumSize = new System.Drawing.Size(613, 365);
            this.MinimumSize = new System.Drawing.Size(613, 365);
            this.Name = "MainMenu";
            this.Text = "Dots N Boxes";
            this.tcMainMenu.ResumeLayout(false);
            this.tbSelectServer.ResumeLayout(false);
            this.tbSelectServer.PerformLayout();
            this.tbLogin.ResumeLayout(false);
            this.tbLogin.PerformLayout();
            this.pnCreateAccount.ResumeLayout(false);
            this.pnCreateAccount.PerformLayout();
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.tbGameList.ResumeLayout(false);
            this.tbGameList.PerformLayout();
            this.tcUserInfo.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tbAccountSettings.ResumeLayout(false);
            this.tbAccountSettings.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Timer timRefreshGameList;
        private System.Windows.Forms.TabPage tbGameLobby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
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

    }
}

