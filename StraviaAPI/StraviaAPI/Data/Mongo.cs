using MongoDB.Driver;
using StraviaAPI.Models;

namespace StraviaAPI.Data
{
    public class Mongo
    {
        private const String CONNECTION_STRING = "mongodb://admin-stravia:F0I2gnkrVIXxAH47OY5gdhSiu9YVcWB7jES7ilnvrhSDKNYgM4muVCJI3Bjl4L882YC9oLeBblVtHeCQMS2HSQ==@admin-stravia.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@ADMIN-stravia@";
        private readonly MongoClient _Connection;
        private readonly IMongoDatabase _Database;
        private const String DATABASE = "test";

        public Mongo()
        {
            _Connection = new MongoClient(CONNECTION_STRING);
            _Database = _Connection.GetDatabase(DATABASE);
        }

        // List
        public async Task<List<Comment>> GetComments()
        {
            var result = await _Database.GetCollection<Comment>("Comments").FindAsync(_ => true);
            return result.ToList();
        }

        // Individuals
        public async Task<Comment> FindComments(String id)
        {
            var result = await _Database.GetCollection<Comment>("Comments").FindAsync(comment => comment.Id == id);
            return result.FirstOrDefault();            
        }

        // Add
        public async Task AddComment(Comment comment)
        {
            await _Database.GetCollection<Comment>("Comments").InsertOneAsync(comment);
        }

    }
}
