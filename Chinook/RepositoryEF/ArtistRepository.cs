using Chinook.Models;
using Chinook.RepositoryEF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.RepositoryEF
{
    public class ArtistRepository : IArtistRepository
    {
        private ChinookContext dbContext;

        public ArtistRepository(IDbContextFactory<ChinookContext> DbFactory)
        {
            dbContext = DbFactory.CreateDbContext();
        }

        public Task<int> Create(Artist obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Artist obj)
        {
            throw new NotImplementedException();
        }

        public async  Task<Artist> GetById(long id)
        {
            return await dbContext.Artists.SingleOrDefaultAsync(a => a.ArtistId == id);
        }

        public Task<int> Update(Artist obj)
        {
            throw new NotImplementedException();
        }
    }
}
