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
    class ImageClass
    {

        [BsonId]
        public ObjectId _id;
        [BsonElement("ImageArray")]
        byte[] imageField;
        public ImageClass(byte[] image)
        {
            this.imageField = image;
        }
            public static void database(ImageClass image)
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("Image");
                var collection = database.GetCollection<ImageClass>("image");
                collection.InsertOne(image);
            }
       
    }
}
