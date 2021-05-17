using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoBD_lab1
{
    [BsonIgnoreExtraElements] //игнорировать те поля которых в классе у нас нет
    public class Car
    {
        [BsonElement("manufacture")]
        public string Manufacture { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }
        
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("car_option")]
        public Array Car_options { get; set; }
    }
}
