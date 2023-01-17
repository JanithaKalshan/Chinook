namespace Chinook.Models;

/// <summary>
/// 
/// </summary>
public class UserPlaylist
{
    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    /// <value>
    /// The user identifier.
    /// </value>
    public string UserId { get; set; }
    /// <summary>
    /// Gets or sets the playlist identifier.
    /// </summary>
    /// <value>
    /// The playlist identifier.
    /// </value>
    public long PlaylistId { get; set; }
    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>
    /// The user.
    /// </value>
    public ChinookUser User { get; set; }
    /// <summary>
    /// Gets or sets the playlist.
    /// </summary>
    /// <value>
    /// The playlist.
    /// </value>
    public Playlist Playlist { get; set; }
}
