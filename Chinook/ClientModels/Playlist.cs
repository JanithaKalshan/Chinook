namespace Chinook.ClientModels;

/// <summary>
/// 
/// </summary>
public class Playlist
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the tracks.
    /// </summary>
    /// <value>
    /// The tracks.
    /// </value>
    public List<PlaylistTrack> Tracks { get; set; }
}