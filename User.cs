using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace ITParkApp {
    class User 
    {
        private string _userName;
        private string _login;
        private int _password;

        public User(string login, int password)
        {
            Login = login;
            Password = password;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Login { get => _login; set => _login = value; }
        public int Password { get => _password; set => _password = value; }

        public static void AddToDatabaseUser(User user)
        {
            var conectionString = "mongodb://localhost";
            var client = new MongoClient(conectionString);
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(user);
        }

        public static void ListBoxUpdate(ListBox listBox)
        {
            var conectionString = "mongodb://localhost";
            var client = new MongoClient(conectionString);
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            var users = collection.Find(x => true).ToList();

            foreach (var item in users)
            {
                listBox.Items.Add(item.Login);
            }
        }

    }
}
