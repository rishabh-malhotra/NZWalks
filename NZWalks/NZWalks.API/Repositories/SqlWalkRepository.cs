using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SqlWalkRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _dbContext.Walks.Include(nameof(Difficulty)).Include(nameof(Region)).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync( Guid id)
        {
            return await _dbContext.Walks.Include(x=>x.Difficulty).Include(y=>y.Region).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = _dbContext.Walks.Include(x=>x.Difficulty).Include(y=>y.Region).FirstOrDefault(x => x.Id == id);
            if(existingWalk == null) 
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _dbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk == null) 
            {
                return null;
            }
            _dbContext.Walks.Remove(existingWalk);
            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
