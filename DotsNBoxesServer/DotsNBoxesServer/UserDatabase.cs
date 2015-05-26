using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DotsNBoxesServer
{
    /// <summary>
    /// Contains methods for controlling the user database
    /// </summary>
    static class UserDatabase
    {
        /// <summary>
        /// The path to the user database XML file
        /// </summary>
        private const string DATABASE_FILE_PATH = "Users.xml";

        /// <summary>
        /// Used for preventing two clients from stepping on each other by accessing the user DB at the same time
        /// </summary>
        private static object DatabaseLock = new object();

        /// <summary>
        /// A XML Document to read the user database XML
        /// </summary>
        private static XDocument UserDatabaseXML;

        /// <summary>
        /// Checks to see if a given username is valid and available
        /// </summary>
        /// <param name="username">The username to check</param>
        /// <returns>The response to send to the client</returns>
        public static string CheckAvailable(string username)
        {
            //If the username is not valid, return a username invalid response
            if(!UsernameValid(username))
            {
                return "USERNAME INVALID";
            }

            //Lock on the user database
            bool usernameTaken;
            lock (DatabaseLock)
            {
                //Load the user database
                UserDatabaseXML = XDocument.Load(DATABASE_FILE_PATH);

                //Determine if the requested username is already taken
                usernameTaken = CheckUsernameExists(username);

                //Unload the user database
                UserDatabaseXML = null;
            }

            //If the current username is taken, return a message stating that the username is taken
            if (usernameTaken)
            {
                return "USERNAME TAKEN";
            }

            //Otherwise, return a message stating that the username is available
            else
            {
                return "USERNAME AVAILABLE";
            }
        }

        /// <summary>
        /// Creates a user account in the database
        /// </summary>
        /// <param name="username">The username to create the account with</param>
        /// <param name="password">The password to create the account with</param>
        /// <param name="clientInfo">The clients data object</param>
        /// <returns>The response to send to the client</returns>
        public static string CreateAccount(string username, string password, ClientData clientInfo)
        {
            //If the username is not valid, return a username invalid response
            if (!UsernameValid(username))
            {
                return "USERNAME INVALID";
            }

            //Lock on the user database
            lock (DatabaseLock)
            {
                //Load the user database
                UserDatabaseXML = XDocument.Load(DATABASE_FILE_PATH);

                //If the requested username already exists, return a username taken response
                if(CheckUsernameExists(username))
                {
                    return "USERNAME TAKEN";
                }

                //Create a new XElement for the new user
                XElement newUser = new XElement("user");

                //Add the users username to the new user XElement
                newUser.Add(new XAttribute("username", username));

                //Add the user's password to the new XElement
                XElement newPassword = new XElement("password");
                string passwordSalt = PasswordHasher.GenerateSalt();
                newPassword.Add(new XAttribute("salt", passwordSalt));
                newPassword.Value = PasswordHasher.HashPassword(password, passwordSalt);
                newUser.Add(newPassword);

                //Add scoreboard elements to the new user
                XElement scorboard = new XElement("scores");
                XElement score4x4 = new XElement("score");
                score4x4.Add(new XAttribute("type", "4X4"));
                score4x4.Value = "0";
                scorboard.Add(score4x4);
                XElement score6x6 = new XElement("score");
                score6x6.Add(new XAttribute("type", "6X6"));
                score6x6.Value = "0";
                scorboard.Add(score6x6);
                XElement score8x8 = new XElement("score");
                score8x8.Add(new XAttribute("type", "8X8"));
                score8x8.Value = "0";
                scorboard.Add(score8x8);
                newUser.Add(scorboard);

                //Add the new user to the user database
                XElement userRoot = UserDatabaseXML.Descendants("users").FirstOrDefault();
                userRoot.Add(newUser);
                UserDatabaseXML.Save(DATABASE_FILE_PATH);

                //Unload the user database
                UserDatabaseXML = null;
            }

            //Log the client into the account they just created
            clientInfo.Username = username;
            clientInfo.IsAuthenticated = true;

            //Announce that the client has been signed in
            Console.WriteLine(username + " has signed in!");

            //The new account has been created, return success
            return "SUCCESS";
        }

        /// <summary>
        /// Validates a username and password to sign a user into an account
        /// </summary>
        /// <param name="username">The username to attempt login to</param>
        /// <param name="password">The password to attempt to authenticate with</param>
        /// <param name="clientInfo">The clients information object</param>
        /// <returns>The response to send to the client</returns>
        public static string AuthenticateAccount(string username, string password, ClientData clientInfo)
        {
            //Lock on the user database
            lock (DatabaseLock)
            {
                //Load the user database
                UserDatabaseXML = XDocument.Load(DATABASE_FILE_PATH);

                //Get a list of all the users in the database
                XElement userRoot = UserDatabaseXML.Descendants("users").FirstOrDefault();
                List<XElement> userList = userRoot.Descendants("user").ToList<XElement>();

                //Find the user with the requested username
                XElement requestedUser = userList.FirstOrDefault(curUser => curUser.Attribute("username").Value.ToLower() == username.ToLower());

                //If the requested user does not exist or the provided password is incorrect, return failed authentication
                if(requestedUser == null || !CheckPasswordValidity(requestedUser, password))
                {
                    return "AUTHENTICATION FAILED";
                }                

                //Unload the user database
                UserDatabaseXML = null;
            }

            //Log the client into the account that was just authenticated
            clientInfo.Username = username;
            clientInfo.IsAuthenticated = true;

            //Announce that the client has been signed in
            Console.WriteLine(username + " has signed in!");

            //The user has been logged in return success
            return "SUCCESS";
        }

        /// <summary>
        /// Deletes an authenticated user account from the database
        /// </summary>
        /// <param name="username">The username of the account to delete</param>
        /// <param name="password">The password of the account to delete (used to authenticate for deletion)</param>
        /// <param name="clientInfo">The clients information object</param>
        /// <returns>The response to send to the client</returns>
        public static string DeleteAccount(string username, string password, ClientData clientInfo)
        {
            //Lock on the user database
            lock (DatabaseLock)
            {
                //Load the user database
                UserDatabaseXML = XDocument.Load(DATABASE_FILE_PATH);

                //Get a list of all the users in the database
                XElement userRoot = UserDatabaseXML.Descendants("users").FirstOrDefault();
                List<XElement> userList = userRoot.Descendants("user").ToList<XElement>();

                //Find the user with the requested username
                XElement requestedUser = userList.FirstOrDefault(curUser => curUser.Attribute("username").Value.ToLower() == username.ToLower());

                //If the requested user does not exist or the provided password is incorrect, return failed authentication
                if (requestedUser == null || !CheckPasswordValidity(requestedUser, password))
                {
                    return "AUTHENTICATION FAILED";
                }

                //Delete the user from the database
                requestedUser.Remove();
                UserDatabaseXML.Save(DATABASE_FILE_PATH);

                //Unload the user database
                UserDatabaseXML = null;
            }

            //Log the client out of their account
            clientInfo.Username = "";
            clientInfo.IsAuthenticated = false;

            //Announce that the client has been signed in
            Console.WriteLine(username + " has left forever :(");

            //The user account has been deleted, return success
            return "SUCCESS";
        }

        /// <summary>
        /// Checks to see if a given username is valid
        /// </summary>
        /// <param name="username">The username to check the validity of</param>
        /// <returns>True if username is valid; false otherwise</returns>
        private static bool UsernameValid(string username)
        {
            //If the username is more than 20 chars or less than three, return false
            if(username.Length < 3 || username.Length > 20)
            {
                return false;
            }

            //If the username contains chars that are not numbers or letters
            char[] usernameChars = username.ToCharArray();
            foreach(char currentChar in usernameChars)
            {
                if(!char.IsLetterOrDigit(currentChar))
                {
                    return false;
                }
            }

            //The username seems solid, return true
            return true;
        }

        /// <summary>
        /// Checks to see if a username exists in the user database.
        /// NOTE: UserDatabase must be loaded and locked to call this
        /// </summary>
        /// <param name="username">The username to check</param>
        /// <returns>True if username exists; false otherwise</returns>
        private static bool CheckUsernameExists(string username)
        {
            //Get a list of all the users in the database
            XElement userRoot = UserDatabaseXML.Descendants("users").FirstOrDefault();
            List<XElement> userList = userRoot.Descendants("user").ToList<XElement>();

            //Check each of the users to see if their username matches the requested username
            foreach (XElement currentUser in userList)
            {
                //If we have a match, return true
                if (currentUser.Attribute("username").Value.ToLower() == username.ToLower())
                {
                    return true;
                }
            }

            //The username does not appear to be used, return false
            return false;
        }

        /// <summary>
        /// Checks to see if a given password matches the password of a user
        /// </summary>
        /// <param name="user">The XElement of the user to check</param>
        /// <param name="password">The password to check against the hashed password on file</param>
        /// <returns>True if the password is correct; false otherwise</returns>
        private static bool CheckPasswordValidity(XElement user, string password)
        {
            //Extract the users stored password hash and salt
            XElement userPasswordInfo = user.Descendants("password").FirstOrDefault();
            string passwordSalt = userPasswordInfo.Attribute("salt").Value;
            string storedPasswordHash = userPasswordInfo.Value;

            //Hash the provided password with the users salt
            string passwordHash = PasswordHasher.HashPassword(password, passwordSalt);

            //Return whether or not the the provided password matches the password on file
            return (passwordHash == storedPasswordHash);
        }
    }
}
