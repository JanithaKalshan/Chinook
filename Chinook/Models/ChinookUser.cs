using Microsoft.AspNetCore.Identity;

namespace Chinook.Models;

// Add profile data for application users by adding properties to the ChinookUser class
/// <summary>
/// 
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
public class ChinookUser : IdentityUser
{
    /// <summary>
    /// Gets or sets the user playlists.
    /// </summary>
    /// <value>
    /// The user playlists.
    /// </value>
    public virtual ICollection<UserPlaylist> UserPlaylists { get; set; }
}

