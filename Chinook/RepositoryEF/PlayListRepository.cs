using Chinook.ClientModels;
using Chinook.Models;
using Chinook.RepositoryEF.Interfaces;
using Chinook.Shared.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.DependencyResolver;
using Playlist = Chinook.Models.Playlist;

namespace Chinook.RepositoryEF
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Chinook.RepositoryEF.Interfaces.IPlayListRepository" />
    public class PlayListRepository : IPlayListRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        ChinookContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayListRepository"/> class.
        /// </summary>
        /// <param name="DbFactory">The database factory.</param>
        public PlayListRepository(IDbContextFactory<ChinookContext> DbFactory)
        {
            dbContext = DbFactory.CreateDbContext();
        }


        /// <summary>
        /// Get play lsit including Tracks, Album and Artist details
        /// </summary>
        /// <param name="id">play list id</param>
        /// <returns>
        /// List Playlist
        /// </returns>
        public async Task<List<Playlist>?> GetDetailPlayList(long id)
        {
            var result = dbContext.Playlists
                    .Include(a => a.Tracks).ThenInclude(a => a.Album).ThenInclude(a => a.Artist)
                    .Where(p => p.PlaylistId == id);
            return await result.ToListAsync();
        }


        /// <summary>
        /// Get details by id
        /// </summary>
        /// <param name="id">primary key of the model</param>
        /// <returns></returns>
        public async Task<Playlist> GetById(long id)
        {
            var result = await dbContext.Playlists.FirstOrDefaultAsync(x => x.PlaylistId == id);
            return result;
        }

        /// <summary>
        /// Get play list by user
        /// </summary>
        /// <param name="userId">Users Id</param>
        /// <returns>
        /// List playlist
        /// </returns>
        public async Task<List<Playlist>> GetAllForUser(string userId)
        {
            var result = await dbContext.Playlists.Include(a => a.UserPlaylists).Where(x => x.UserPlaylists.Any(c => c.UserId == userId)).ToListAsync();
            return result;

        }

        /// <summary>
        /// insert a new data row to a table
        /// </summary>
        /// <param name="obj">object from current model</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> Create(Playlist obj)
        {
            dbContext.Add(obj);
            return dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update a existing row in a table
        /// </summary>
        /// <param name="obj">object from current model with updated</param>
        /// <returns></returns>
        public Task<int> Update(Playlist obj)
        {

            dbContext.Update(obj);
            return dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// Delete a existing row from table
        /// </summary>
        /// <param name="obj">object from</param>
        /// <returns></returns>
        public Task<int> Delete(Playlist obj)
        {
            dbContext.Remove(obj);
            return dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get Play list details with Track details
        /// </summary>
        /// <param name="playListId">play list id</param>
        /// <returns>
        /// Playlist
        /// </returns>
        public async Task<Playlist?> GetPlayListWithTracks(long playListId)
        {
                var result = await dbContext.Playlists
                    .Include(a => a.Tracks).Where(p => p.PlaylistId == playListId).FirstOrDefaultAsync();
                return result;
        }

        /// <summary>
        /// Get a track in a play list
        /// </summary>
        /// <param name="playListId">play list id</param>
        /// <param name="trackId">track id</param>
        /// <returns>
        /// Playlist
        /// </returns>
        public async Task<Playlist?> GetTrackInPlayList(long playListId, long trackId)
        {
            var result = await dbContext.Playlists
                    .Include(a => a.Tracks.Where(o => o.TrackId == trackId)).Where(p => p.PlaylistId == playListId).FirstOrDefaultAsync();
            return result;
        }
    }
}
