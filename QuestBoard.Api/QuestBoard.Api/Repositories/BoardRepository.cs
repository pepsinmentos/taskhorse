using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestBoard.Api.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace QuestBoard.Api.Repositories
{
    public class BoardRepository : MongoRepositoryBase<Board>, IBoardRepository
    {
        public BoardRepository(MongoClient mongoClient) : base(mongoClient, "Board") 
        {

        }

        public List<Board> All()
        {
            return Collection.FindSync(new BsonDocument()).ToList();
        }

        public Board Create(Board model)
        {
            Collection.InsertOne(model);
            return model;
        }

        public Board Delete(string id)
        {
            return Collection.FindOneAndDelete<Board>(x => x.Id == id);
        }

        public Board Get(string id)
        {
            return Collection.FindSync<Board>(x => x.Id == id).FirstOrDefault();
        }
    }
}