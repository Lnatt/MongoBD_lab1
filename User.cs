using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoBD_lab1
{
    [BsonIgnoreExtraElements] //игнорировать те поля которых в классе у нас нет
    public class User
    {
        [BsonElement("name")]
        public string Name { get; set; } 
        public ObjectId _id { get; set; }
    }
}
