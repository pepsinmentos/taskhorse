using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using QuestBoard.Api.Models;
using MongoDB.Bson;

namespace QuestBoard.Api.Repositories
{
    public class QuestRepository : MongoRepositoryBase<BsonDocument>, IQuestRepository
    {
        public QuestRepository(MongoClient mongoClient) : base(mongoClient, "Quest")
        {
        }

        public Quest Create(Quest model)
        {
            Collection.InsertOne(model.ToBsonDocument());
            return model;
        }

        public Quest Get(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            return Collection.FindSync<Quest>(filter).FirstOrDefault();
        }

        public List<Quest> All()
        {
            throw new NotImplementedException();
        }

        public Quest Delete(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var result = Collection.FindOneAndDelete<Quest>(filter);
            return result;
        }

        public List<Quest> AllForBoard(string boardId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("BoardId", boardId);
            return Collection.FindSync<Quest>(filter).ToList();
        }
    }
}