using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ITParkApp {

    [Serializable]
    class Passport 
    {
        private byte[] _picture;

        
        public Passport(byte[] picture)
        {
            _picture = picture;
        }
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        public byte[] Picture { get => _picture; set => _picture = value; }

        public static void AddToDatabasePicture(Passport passport)
        {
            var conectionString = "mongodb://localhost";
            var client = new MongoClient(conectionString);
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<Passport>("Pictures");
            collection.InsertOne(passport);
        }

        public static void GetFromDatabasePicture()
        {
            var conectionString = "mongodb://localhost";
            var client = new MongoClient(conectionString);
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<Passport>("Pictures");
            Passport passports = collection.Find(filter => true).FirstOrDefault();
            if(passports != null)
            {
                using (FileStream fs = new FileStream($"C:/Users/01/Desktop/ITParkWPF/{passports._id}.png", FileMode.OpenOrCreate))
                {
                    fs.Write(passports.Picture, 0, passports.Picture.Length);
                }
            }
            
        }
    }
}
