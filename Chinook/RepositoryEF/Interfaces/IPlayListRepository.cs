
using Chinook.Models;
using System.Runtime.CompilerServices;

namespace Chinook.RepositoryEF.Interfaces
{
    public interface IPlayListRepository:IRepository<Playlist>
    {
        /// <summary>
        /// Get play lsit including Tracks, Album and Artist details
        /// </summary>
        /// <param name="id"> play list id</param>
        /// <returns> List Playlist </returns>
        Task<List<Playlist>?> GetDetailPlayList(long id);
        /// <summary>
        /// Get play list by user
        /// </summary>
        /// <param name="userId"> Users Id </param>
        /// <returns>List playlist</returns>
        Task<List<Playlist>> GetAllForUser(string userId);
        /// <summary>
        /// Get Play list details with Track details
        /// </summary>
        /// <param name="playListId"> play list id</param>
        /// <returns> Playlist </returns>
        Task<Playlist?> GetPlayListWithTracks(long playListId);
        /// <summary>
        /// Get a track in a play list 
        /// </summary>
        /// <param name="playListId">play list id</param>
        /// <param name="trackId"> track id </param>
        /// <returns>Playlist</returns>
        Task<Playlist?> GetTrackInPlayList(long playListId, long trackId);
    }
}
