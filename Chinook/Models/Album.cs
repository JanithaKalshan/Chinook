using System;
using System.Collections.Generic;

namespace Chinook.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Album
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Album"/> class.
        /// </summary>
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        /// <summary>
        /// Gets or sets the album identifier.
        /// </summary>
        /// <value>
        /// The album identifier.
        /// </value>
        public long AlbumId { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; } = null!;
        /// <summary>
        /// Gets or sets the artist identifier.
        /// </summary>
        /// <value>
        /// The artist identifier.
        /// </value>
        public long ArtistId { get; set; }

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        /// <value>
        /// The artist.
        /// </value>
        public virtual Artist Artist { get; set; } = null!;
        /// <summary>
        /// Gets or sets the tracks.
        /// </summary>
        /// <value>
        /// The tracks.
        /// </value>
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
