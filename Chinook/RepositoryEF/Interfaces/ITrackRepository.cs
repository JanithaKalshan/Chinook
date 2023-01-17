using Chinook.Models;

namespace Chinook.RepositoryEF.Interfaces
{
   
    public interface ITrackRepository:IRepository<Track>
    {
        /// <summary>
        /// Gets the tracks by artist identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<List<Track>> GetTracksByArtistId(long id);
    }
}
