using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITParkApp
{
    class Warrior : Character
    {
        [BsonId]
        public ObjectId _id;
        public override int MinStr => 30;

        public Warrior():base()
        {        
        }

        public int AddStrength(int newStr)
        {
            if (newStr < MinStr)
            {
                return MinStr;
            }
            else
                return newStr;
        }
    }
}
