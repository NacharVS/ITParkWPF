using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ITParkApp
{
    class Team
    {
        private string _user1;
        private string _user2;
        private string _user3;
        private string _user4;
        private string _user5;

        public Team(User user1, User user2, User user3, User user4, User user5)
        {
            User1 = user1.Login;
            User2 = user2.Login;
            User3 = user3.Login;
            User4 = user4.Login;
            User5 = user5.Login;
            

        }

        public string User1 { get => _user1; set => _user1 = value; }
        public string User2 { get => _user2; set => _user2 = value; }
        public string User3 { get => _user3; set => _user3 = value; }
        public string User4 { get => _user4; set => _user4 = value; }
        public string User5 { get => _user5; set => _user5 = value; }

        public static void AddToTeam(string login, ListBox listBox)
        {
            if (!listBox.Items.Contains(login)) listBox.Items.Add(login);
            else System.Windows.MessageBox.Show("Этот игрок уже в команде");
        }

        public void CreateTeam()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Matchmaker");
            var collection = database.GetCollection<User>("Teams");
        }
    }
}
