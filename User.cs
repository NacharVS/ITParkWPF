using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITParkApp
{
    class User
    {

        private string _login;
        private string _userName;
        private int _winsCount = 0;
        private int _lossCount = 0;
        private string _password;

        public User(string username, string login, string password)
        {
            UserName = username;
            Login = login;
            Password = _password;
        }
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId  _id { get ; set ; }
        public int LossCount { get => _lossCount; set => _lossCount = value; }
        public int WinsCount { get => _winsCount; set => _winsCount = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }

        public static void AddToDatabase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Matchmaker");
            var collection = database.GetCollection<User>("Users");

            collection.InsertOne(user);
        }
    }
}
