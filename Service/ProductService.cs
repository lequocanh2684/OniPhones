﻿using DoAn1.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace DoAn1.Service
{
    public class ProductService
    {
        ClassDB db = new ClassDB();
        private IMongoCollection<Smartphone> _collection;

        public ProductService()
        {
            _collection = db.GetConnection().GetCollection<Smartphone>("smartphone");
        }

        public List<Smartphone> GetSmartphones()
        {

            return _collection.Find(_ => true).Limit(5).ToList();
        }

        public List<Smartphone> GetSmartphonesFilter(string _key)
        {
            var filter = Builders<Smartphone>.Filter.Regex("key", new BsonRegularExpression(_key, "i"));
            return _collection.Find(filter).ToList();
        }

    }
}
