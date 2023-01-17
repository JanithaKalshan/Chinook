using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Models
{
    [PrimaryKey(nameof(PlaylistId), nameof(TrackId))]
    public class PlaylistTrack
    {
        public long PlaylistId { get; set; }

        public long TrackId { get; set; }
        public Playlist Playlist { get; set; }
        public Track Track { get; set; }
    }
}
