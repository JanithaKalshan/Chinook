using Chinook.Models;
using Chinook.RepositoryEF.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace Chinook.RepositoryEF
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Chinook.RepositoryEF.Interfaces.ITrackRepository" />
    public class TrackRepository: ITrackRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        ChinookContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackRepository"/> class.
        /// </summary>
        /// <param name="DbFactory">The database factory.</param>
        public TrackRepository(IDbContextFactory<ChinookContext> DbFactory)
        {
            dbContext = DbFactory.CreateDbContext();
        }

        /// <summary>
        /// insert a new data row to a table
        /// </summary>
        /// <param name="obj">object from current model</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> Create(Track obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a existing row from table
        /// </summary>
        /// <param name="obj">object from</param>
        /// <returns></returns>
        public Task<int> Delete(Track obj)
        {
            dbContext.Update(obj);
            return dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get details by id
        /// </summary>
        /// <param name="id">primary key of the model</param>
        /// <returns></returns>
        public async Task<Track> GetById(long id)
        {
            return await dbContext.Tracks.FirstOrDefaultAsync(t => t.TrackId == id);
        }

        /// <summary>
        /// Gets the tracks by artist identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<List<Track>> GetTracksByArtistId(long id)
        {
            return await dbContext.Tracks.Where(a => a.Album!.ArtistId == id)
           .Include(a => a.Album).ToListAsync();
        }

        /// <summary>
        /// Update a existing row in a table
        /// </summary>
        /// <param name="obj">object from current model with updated</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> Update(Track obj)
        {
            throw new NotImplementedException();
        }
    }
}
