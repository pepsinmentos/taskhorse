using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Repositories
{
    public class AuthenticationRepository : MongoRepositoryBase<BsonDocument>, IAuthenticationRepository
    {
        public AuthenticationRepository(MongoClient mongoClient) : base(mongoClient, "Member")
        {
            var indexes = Database.GetCollection<BsonDocument>("Tokens").Indexes;
            if (indexes != null && indexes.List().ToList().All(x => x != "ExpiresOn_-1"))
            {
                indexes.CreateOne(Builders<BsonDocument>.IndexKeys.Descending("ExpiresOn"), new CreateIndexOptions { ExpireAfter = TimeSpan.FromSeconds(0) });

            }
        }

        public void Create(SignUp signUp)
        {
            Collection.InsertOne(new Member() { Email = signUp.Email, Password = signUp.Password, CreatedOn = DateTime.Now }.ToBsonDocument());
        }

        public void  SaveToken(string token, int expiresInSeconds)
        {
            Database.GetCollection<BsonDocument>("Tokens").InsertOne(new BsonDocument(new List<BsonElement>() { new BsonElement("Token",token), new BsonElement("ExpiresOn",DateTime.Now.AddSeconds(expiresInSeconds)) }));
        }

        public bool IsValidUser(AuthenticationRequest auth)
        {
            var filter = Builders<BsonDocument>.Filter.And(Builders<BsonDocument>.Filter.Eq("Email", auth.Email), Builders<BsonDocument>.Filter.Eq("Password", auth.Password));

            var result = Collection.FindSync<Member>(filter).FirstOrDefault();
            return result != null;
        }

        public bool IsValidToken(string token)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Token", token);
            var result = Database.GetCollection<BsonDocument>("Tokens").FindSync<BsonDocument>(filter).FirstOrDefault();
            if (result == null)
                return false;

            if ((DateTime)result["ExpiresOn"] < DateTime.Now)
                return false;

            return true;
        }
    }
}