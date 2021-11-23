using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITParkApp {
    class Team 
    {
        //private string _teamName;
        private string _user1;
        private string _user2;
        private string _user3;
        private string _user4;
        private string _user5;

        public Team(string user1, string user2, string user3, string user4, string user5)
        {
           // _teamName = teamName;
            _user1 = user1;
            _user2 = user2;
            _user3 = user3;
            _user4 = user4;
            _user5 = user5;
        }

        //public string TeamName { get => _teamName; set => _teamName = value; }
        public string User1 { get => _user1; set => _user1 = value; }
        public string User2 { get => _user2; set => _user2 = value; }
        public string User3 { get => _user3; set => _user3 = value; }
        public string User4 { get => _user4; set => _user4 = value; }
        public string User5 { get => _user5; set => _user5 = value; }

        public static void AddToDatabaseTeam(Team teamName)
        {
            var conectionString = "mongodb://localhost";
            var client = new MongoClient(conectionString);
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<Team>("Teams");
            collection.InsertOne(teamName);
        }

        public static void CreateNewTeam()
        {

        }
    }
}
