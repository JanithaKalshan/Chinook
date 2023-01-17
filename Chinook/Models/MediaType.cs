using System;
using System.Collections.Generic;

namespace Chinook.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MediaType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaType"/> class.
        /// </summary>
        public MediaType()
        {
            Tracks = new HashSet<Track>();
        }

        /// <summary>
        /// Gets or sets the media type identifier.
        /// </summary>
        /// <value>
        /// The media type identifier.
        /// </value>
        public long MediaTypeId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the tracks.
        /// </summary>
        /// <value>
        /// The tracks.
        /// </value>
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
