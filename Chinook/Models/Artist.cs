using System;
using System.Collections.Generic;

namespace Chinook.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Artist
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Artist"/> class.
        /// </summary>
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        /// <summary>
        /// Gets or sets the artist identifier.
        /// </summary>
        /// <value>
        /// The artist identifier.
        /// </value>
        public long ArtistId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the albums.
        /// </summary>
        /// <value>
        /// The albums.
        /// </value>
        public virtual ICollection<Album> Albums { get; set; }
    }
}
