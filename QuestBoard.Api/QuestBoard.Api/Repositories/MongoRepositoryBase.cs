using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Repositories
{
    public class MongoRepositoryBase<TDefaultDocumentType>
    {
        protected readonly MongoClient MongoClient;
        protected string DefaultCollectionName;
        protected string DefaultDatabaseName;
        protected IMongoDatabase Database;
        protected IMongoCollection<TDefaultDocumentType> Collection;

        public MongoRepositoryBase(MongoClient mongoClient, string defaultCollectionName, string defaultDatabaseName = "questboard")
        {
            MongoClient = mongoClient;
            DefaultCollectionName = defaultCollectionName;
            DefaultDatabaseName = defaultDatabaseName;
            Database = mongoClient.GetDatabase(DefaultDatabaseName);
            Collection = Database.GetCollection<TDefaultDocumentType>(DefaultCollectionName);
        }
    }
}