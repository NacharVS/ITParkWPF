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
        public string name;
        public string surname;
        public string nickname;

        public User(string name, string surname, string nickname)
        {
            this.name = name;
            this.surname = surname;
            this.nickname = nickname;
        }

        public static void database(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("MatchMaker");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(user);
           
        }
        public static void deleteFromdatabase(string nickname)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("MatchMaker");
            var collection = database.GetCollection<User>("Users");

            collection.DeleteOne(x => x.nickname == nickname);
        }
    }
}
