using Chinook.ClientModels;
using Chinook.Models;
using Chinook.RepositoryEF;
using Chinook.RepositoryEF.Interfaces;
using Chinook.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Chinook.Pages;

public partial class ArtistPage : ComponentBase
{
    [Parameter] public long ArtistId { get; set; }
    [CascadingParameter] protected Task<AuthenticationState> authenticationState { get; set; }
    [Inject] IDbContextFactory<ChinookContext> DbFactory { get; set; }
    [Inject] private IArtistRepository artistRepo { get; set; }
    [Inject] private ITrackRepository tracksRepo { get; set; }
    protected Modal PlaylistDialog { get; set; }

    protected Artist Artist;
    protected List<ClientModels.PlaylistTrack> Tracks;
    protected DbContext DbContext;
    protected ClientModels.PlaylistTrack SelectedTrack;
    protected string InfoMessage;
    protected string CurrentUserId;

    protected override async Task OnInitializedAsync()
    {
        await InvokeAsync(StateHasChanged);
        CurrentUserId = await GetUserId();
        var DbContext = await DbFactory.CreateDbContextAsync();

        Artist = await artistRepo.GetById(ArtistId);

        var tracksLst = await tracksRepo.GetTracksByArtistId(ArtistId);

        Tracks = tracksLst
            .Select(t => new ClientModels.PlaylistTrack()
            {
                AlbumTitle = (t.Album == null ? "-" : t.Album.Title),
                TrackId = t.TrackId,
                TrackName = t.Name,
                IsFavorite = t.Playlists.Where(p => p.UserPlaylists.Any(up => up.UserId == CurrentUserId && up.Playlist.Name == "Favorites")).Any()
            })
            .ToList();
    }

    private async Task<string> GetUserId()
    {
        var user = (await authenticationState).User;
        var userId = user.FindFirst(u => u.Type.Contains(ClaimTypes.NameIdentifier))?.Value;
        return userId;
    }

    private void FavoriteTrack(long trackId)
    {
        var track = Tracks.FirstOrDefault(t => t.TrackId == trackId);
        InfoMessage = $"Track {track.ArtistName} - {track.AlbumTitle} - {track.TrackName} added to playlist Favorites.";
    }

    private void UnfavoriteTrack(long trackId)
    {
        var track = Tracks.FirstOrDefault(t => t.TrackId == trackId);
        InfoMessage = $"Track {track.ArtistName} - {track.AlbumTitle} - {track.TrackName} removed from playlist Favorites.";
    }

    private void OpenPlaylistDialog(long trackId)
    {
        CloseInfoMessage();
        SelectedTrack = Tracks.FirstOrDefault(t => t.TrackId == trackId);
        PlaylistDialog.Open();
    }

    private void AddTrackToPlaylist()
    {
        CloseInfoMessage();
        InfoMessage = $"Track {Artist.Name} - {SelectedTrack.AlbumTitle} - {SelectedTrack.TrackName} added to playlist {{playlist name}}.";
        PlaylistDialog.Close();
    }

    private void CloseInfoMessage()
    {
        InfoMessage = "";
    }

}

