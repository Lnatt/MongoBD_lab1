using System;
using System.Collections.Generic;
using System.Text;
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
        public IEnumerable<User> GetUsersByNameTyped(string name)
        {
            var collection = _database.GetCollection<User>("users");
            var users = collection.Find(x => x.Name.Equals(name));
            return users.ToEnumerable();
        }

    }
}
