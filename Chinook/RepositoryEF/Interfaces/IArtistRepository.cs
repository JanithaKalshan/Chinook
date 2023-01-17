using Chinook.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chinook.RepositoryEF.Interfaces;

public interface IArtistRepository : IRepository<Artist>
{
    
}

