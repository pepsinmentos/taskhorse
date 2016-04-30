using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Repositories
{
    public class MemberRepository : MongoRepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(MongoClient mongoClient) : base(mongoClient, "Member")
        {
        }

        public Member Get(string id)
        {
            var filter = Builders<Member>.Filter.Eq("_id", id);

            return Collection.FindSync<Member>(filter).FirstOrDefault();
        }

        public Member GetByEmail(string emailAddress)
        {
            var filter = Builders<Member>.Filter.Eq("Email", emailAddress);

            return Collection.FindSync<Member>(filter).FirstOrDefault();
        }

        public List<Member> All()
        {
            throw new NotImplementedException();
        }

        public Member Delete(string id)
        {
            throw new NotImplementedException();
        }

        
    }
}