using MongoDB.Bson;
using MongoDB.Driver;

namespace Masami.Database
{
    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string name)
        {
            var mongourl = Settings.BotConfig.URL;

            var client = new MongoClient(mongourl);     
            db = client.GetDatabase(name);
        }

            public void InsertRecord<T>(string table, T record)
            {
                var collection = db.GetCollection<T>(table);

                collection.InsertOne(record);
            }

            public List<T> LoadRecords<T>(string table)
            {
                var collection = db.GetCollection<T>(table);

                return collection.Find(new BsonDocument()).ToList();
            }

            public T LoadRecordById<T>(string table, string id)
            {
                var collection = db.GetCollection<T>(table);
                var filter = Builders<T>.Filter.Eq("Id", id);

                return collection.Find(filter).First();
            }

            public void UpsertRecord<T>(string table, string id, T record)
            {
                var collection = db.GetCollection<T>(table);

#pragma warning disable CS0618 // Type or member is obsolete
                var result = collection.ReplaceOne(
                    new BsonDocument("_id", id),
                    record,
                    new UpdateOptions { IsUpsert = true});
#pragma warning restore CS0618 // Type or member is obsolete


            }

            public void DeleteRecord<T>(string table, string id)
            {
                var collection = db.GetCollection<T>(table);
                var filter = Builders<T>.Filter.Eq("Id", id);
                collection.DeleteOne(filter);
            }
        }
}