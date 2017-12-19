using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.MongoDB.Stores
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        private readonly IOperationDbContext _dbContext;

        public PersistedGrantStore(IOperationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            var filter = Builders<Models.PersistedGrant>.Filter.Eq(u => u.subjectId, subjectId);

            var records = await _dbContext.PersistedGrant.Find(filter).ToListAsync();

            return records.Select(Map).ToList();
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            var filter = Builders<Models.PersistedGrant>.Filter.Eq(u => u.key, key);

            var record = await _dbContext.PersistedGrant.Find(filter).FirstOrDefaultAsync();

            if(record == null)
            {
                return null;
            }

            return Map(record);
        }

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            var filter = Builders<Models.PersistedGrant>.Filter.And(
                    Builders<Models.PersistedGrant>.Filter.Eq(u => u.subjectId, subjectId),
                    Builders<Models.PersistedGrant>.Filter.Eq(u => u.clientId, clientId)
            );

            return _dbContext.PersistedGrant.DeleteManyAsync(filter);
        }

        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            var filter = Builders<Models.PersistedGrant>.Filter.And(
                    Builders<Models.PersistedGrant>.Filter.Eq(u => u.subjectId, subjectId),
                    Builders<Models.PersistedGrant>.Filter.Eq(u => u.clientId, clientId),
                    Builders<Models.PersistedGrant>.Filter.Eq(u => u.type, type)
            );

            return _dbContext.PersistedGrant.DeleteManyAsync(filter);
        }

        public Task RemoveAsync(string key)
        {
            var filter = Builders<Models.PersistedGrant>.Filter.Eq(u => u.key, key);

            return _dbContext.PersistedGrant.DeleteManyAsync(filter);
        }

        public async Task StoreAsync(PersistedGrant grant)
        {
            var filter = Builders<Models.PersistedGrant>.Filter.Eq(u => u.key, grant.Key);

            var existing = await _dbContext.PersistedGrant.Find(filter).SingleOrDefaultAsync();
            if (existing == null)
            {
                await _dbContext.PersistedGrant.InsertOneAsync(Map(null, grant));
            }
            else
            {
                await _dbContext.PersistedGrant.ReplaceOneAsync(filter, Map(existing, grant));
            }
        }

        private PersistedGrant Map(Models.PersistedGrant grant)
        {
            return new PersistedGrant
            {
                ClientId = grant.clientId,
                CreationTime = grant.creationTime,
                Data = grant.data,
                Expiration = grant.expiration,
                Key = grant.key,
                SubjectId = grant.subjectId,
                Type = grant.type
            };
        }

        private Models.PersistedGrant Map(Models.PersistedGrant existing, PersistedGrant grant)
        {
            if (existing == null)
                existing = new Models.PersistedGrant();

            existing.clientId = grant.ClientId;
            existing.creationTime = grant.CreationTime;
            existing.data = grant.Data;
            existing.expiration = grant.Expiration;
            existing.key = grant.Key;
            existing.subjectId = grant.SubjectId;
            existing.type = grant.Type;

            return existing;
        }
    }
}