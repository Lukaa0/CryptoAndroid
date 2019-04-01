using SQLite.Net.Attributes;

namespace HandyCrypto.Model
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string []coinID;

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public string[] CoinID { get => coinID; set => coinID = value; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public User() { }
    }
}