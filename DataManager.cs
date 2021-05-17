using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoBD_lab1
{
    public class DataManager
    {
        private IMongoDatabase _database;
        public DataManager(string connectionString, string databaseName) // конструктор 
        {
            var mongoClient = new MongoClient(connectionString);
            _database =  mongoClient.GetDatabase(databaseName);
        }
        public IEnumerable<BsonDocument> GetUsers() 
        {
            var collection = _database.GetCollection<BsonDocument>("users");
            var docs = collection.Find(x => true);
            return docs.ToEnumerable();
        }
        public IEnumerable<BsonDocument>GetUsersByName(string name) // ищем по имени
        {
            var collection = _database.GetCollection<BsonDocument>("users");
            var users = collection.Find(x => x["name"].Equals(name));
            return users.ToEnumerable();
        }
        public IEnumerable<Car> GetCarsByNameTyped(string name)
        {
            var collection = _database.GetCollection<Car>("users");
            var manufacture = collection.Find(x => x.Manufacture.Equals(name));
            return manufacture.ToEnumerable();
        }
        public IEnumerable<Car> GetCarsByYearTyped(int year)
        {
            var collection = _database.GetCollection<Car>("users");
            var manufacture = collection.Find(x => x.Year < year);
            return manufacture.ToEnumerable();
        }
        public IEnumerable<Car> GetCarsByOptionsTyped(string id) //сюда должен передаваться или обжектид или внутри приводиться стринг к обжекту
        {
            //Convert.ToString(id);
            //MongoDB.Bson.ObjectId.Parse(id);
            var collection = _database.GetCollection<Car>("users");
            var manufacture = collection.Find(x => x.Id.Equals(MongoDB.Bson.ObjectId.Parse(id)));
            return manufacture.ToEnumerable();
        }
    }
}
