using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Repositories
{
    public class AuthenticationRepository : MongoRepositoryBase<Member>, IAuthenticationRepository
    {
        public AuthenticationRepository(MongoClient mongoClient) : base(mongoClient, "Member")
        {

        }

        public void Create(SignUp signUp)
        {
            Collection.InsertOne(new Member() { Id = Guid.NewGuid().ToString(), Email = signUp.Email, Password = signUp.Password, CreatedOn = DateTime.Now });
        }

        public void  SaveToken(string token)
        {
         
        }
    }
}