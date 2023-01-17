namespace Chinook.ClientModels;

/// <summary>
/// 
/// </summary>
public class PlaylistTrack
{
    /// <summary>
    /// Gets or sets the track identifier.
    /// </summary>
    /// <value>
    /// The track identifier.
    /// </value>
    public long TrackId { get; set; }
    /// <summary>
    /// Gets or sets the name of the track.
    /// </summary>
    /// <value>
    /// The name of the track.
    /// </value>
    public string TrackName { get; set; }
    /// <summary>
    /// Gets or sets the album title.
    /// </summary>
    /// <value>
    /// The album title.
    /// </value>
    public string AlbumTitle { get; set; }
    /// <summary>
    /// Gets or sets the name of the artist.
    /// </summary>
    /// <value>
    /// The name of the artist.
    /// </value>
    public string ArtistName { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this instance is favorite.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is favorite; otherwise, <c>false</c>.
    /// </value>
    public bool IsFavorite { get; set; }

}