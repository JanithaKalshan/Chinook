using Chinook.Models;
using Chinook.RepositoryEF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.RepositoryEF
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Chinook.RepositoryEF.Interfaces.IUserPlayList" />
    public class UserPlayList : IUserPlayList
    {

        /// <summary>
        /// The database context
        /// </summary>
        ChinookContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPlayList"/> class.
        /// </summary>
        /// <param name="DbFactory">The database factory.</param>
        public UserPlayList(IDbContextFactory<ChinookContext> DbFactory)
        {
           dbContext = DbFactory.CreateDbContext();
        }

        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public Task<int> Create(UserPlaylist obj)
        {
            dbContext.AddAsync(obj);
            return dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> Delete(UserPlaylist obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<UserPlaylist> GetById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> Update(UserPlaylist obj)
        {
            throw new NotImplementedException();
        }
    }
}
