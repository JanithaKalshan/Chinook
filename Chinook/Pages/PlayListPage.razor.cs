
using Chinook.RepositoryEF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Chinook.RepositoryEF;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Chinook.Shared.Components;
using Chinook.Models;
using Chinook.ClientModels;

namespace Chinook.Pages;

public partial class PlayListPage : ComponentBase
{
    #region >> Prameters
    [Parameter] public long PlaylistId { get; set; }
    [CascadingParameter] private Task<AuthenticationState> authenticationState { get; set; }
    #endregion

    #region >> Injections

    [Inject] IDbContextFactory<ChinookContext> DbFactory { get; set; }
    [Inject] private IPlayListRepository playListRepo { get; set; }
    [Inject] private ITrackRepository tracksRepo { get; set; }
    [Inject] public NavigationManager navigationManager { get; set; }

    #endregion

    #region >> Local Varibles 
    protected Chinook.ClientModels.Playlist? Playlist;
    protected string CurrentUserId;
    protected string InfoMessage;
    protected long TrackId;
    protected Modal PlaylistModal { get; set; }
    protected Modal PlaylistModalDelete { get; set; }
    protected Modal TrackModalDelete { get; set; }
    protected string txtName;
    protected string artistName;
    #endregion

    #region >> Setup
    //Triggerd on Initailization of the page 
    protected override async Task OnInitializedAsync()
    {
        CurrentUserId = await GetUserId();

        await InvokeAsync(StateHasChanged);
        var DbContext = await DbFactory.CreateDbContextAsync();

        var result = await playListRepo.GetDetailPlayList(PlaylistId);

        Playlist = result
                   .Select(p => new ClientModels.Playlist()
                   {
                       Name = p.Name,
                       Tracks = p.Tracks.Select(t => new ClientModels.PlaylistTrack()
                       {
                           AlbumTitle = t.Album!.Title,
                           ArtistName = t.Album.Artist.Name!,
                           TrackId = t.TrackId,
                           TrackName = t.Name,
                           IsFavorite = t.Playlists.Where(p => p.UserPlaylists != null && p.UserPlaylists.Any(up => up.UserId == CurrentUserId && up.Playlist.Name == "Favorites")).Any()
                       }).ToList()
                   })
                   .FirstOrDefault();
    }
    #endregion

    #region >> Page Related Methods
    protected async Task<string> GetUserId()
    {
        var user = (await authenticationState).User;
        var userId = user.FindFirst(u => u.Type.Contains(ClaimTypes.NameIdentifier))?.Value;
        return userId;
    }
    
    //Delete list of track.flag to caputure yse No from the dialog box yes means true No mean false
    protected async void DeleteList(bool flag)
    {
        if (flag)
        {
            var obj = await playListRepo.GetPlayListWithTracks(PlaylistId);

            if (obj != null)
            {
                obj.Tracks = new List<Track>();
                await playListRepo.Update(obj);
                InfoMessage = $"Play list {obj.Name} deleted sucessfully";
                playListRepo.Delete(obj);
                this.StateHasChanged();
            }
            else
            {
                InfoMessage = $"Play list not found with id {PlaylistId}";
            }
        }

        PlaylistModalDelete.Close();

    }


    //Delete play list selected track.flag to caputure yse No from the dialog box yes means true No mean false
    protected async void DeletePlayListTrack(bool flag)
    {
        if (flag)
        {
            var obj = await playListRepo.GetPlayListWithTracks(PlaylistId);

            if (obj != null)
            {

                obj.Tracks.Where(l => l.TrackId == TrackId).ToList().ForEach(x =>
                {
                    obj.Tracks.Remove(x);

                });

                await playListRepo.Update(obj);
                InfoMessage = $"Track {TrackId} deleted sucessfully";
               
            }
            else
            {
                InfoMessage = $"Play list Or Track not found";
            }
            
        }

        TrackModalDelete.Close();
        navigationManager.NavigateTo($"playlist/{PlaylistId}");
        StateHasChanged();

    }



    #endregion

    #region >> Event Handlers

    // Open edit play list name modal
    protected void OpenEditPlaylistNameModal()
    {
        CloseInfoMessage();
        txtName = Playlist.Name;
        PlaylistModal.Open();
    }

    //Track delete modal
    protected void RemoveTrack(long trackId)
    {
        CloseInfoMessage();
        TrackModalDelete.Open();
        TrackId = trackId;
    }

    //Open Play list delete modal
    protected void OpenPlaylistDeleteModal()
    {
        CloseInfoMessage();
        PlaylistModalDelete.Open();
    }

    // Close info message 
    protected void CloseInfoMessage()
    {
        InfoMessage = "";
    }

    //Search fucntion 
    protected  async void  Search()
    {
        var result = await playListRepo.GetDetailPlayList(PlaylistId);

        Playlist = result
                   .Select(p => new ClientModels.Playlist()
                   {
                       Name = p.Name,
                       Tracks = p.Tracks.Select(t => new ClientModels.PlaylistTrack()
                       {
                           AlbumTitle = t.Album!.Title,
                           ArtistName = t.Album.Artist.Name!,
                           TrackId = t.TrackId,
                           TrackName = t.Name,
                           IsFavorite = t.Playlists.Where(p => p.UserPlaylists != null && p.UserPlaylists.Any(up => up.UserId == CurrentUserId && up.Playlist.Name == "Favorites")).Any()
                       }).ToList()
                   })
                   .FirstOrDefault();

        Playlist.Tracks.RemoveAll(c => !c.ArtistName.StartsWith(artistName));
     
    }

    // Edit Play list name to new name 
    protected async void ChagePlayListName()
    {
        var obj = await playListRepo.GetById(PlaylistId);
        if (obj != null)
        {
            obj.Name = txtName;
            playListRepo.Update(obj);
            InfoMessage = $"Play list name changed to {txtName}";
            Playlist.Name = txtName;
        }
        else
        {
            InfoMessage = $"Play list not found with id {PlaylistId}";
        }

        PlaylistModal.Close();

    }

    //Add a track to a favorite track
    protected async void FavoriteTrack(long trackId)
    {

        //var obj = await playListRepo.GetPlayListWithTracks(1);


        //if (obj != null)
        //{

        //    var trk = await tracksRepo.GetById(trackId);
        //    if (!obj.Tracks.Any(c => c.TrackId == trackId))
        //    {
        //        obj.Tracks.Add(trk);
        //        await playListRepo.Create(obj);
        //        InfoMessage = $"Track {trackId} added to playlist Favorites.";
        //    }

        //}
        //else
        //{
        //    InfoMessage = $"Play list Or Track not found";
        //}


    }

    //Remove track from a favorite list
    protected async void UnfavoriteTrack(long trackId)
    {
        //var obj = await playListRepo.GetPlayListWithTracks(1);


        //if (obj != null)
        //{

        //    var trk = await tracksRepo.GetById(trackId);

        //    obj.Tracks.Remove(trk);
        //    await playListRepo.Update(obj);
        //    InfoMessage = $"Track {trackId} removed from  playlist Favorites.";

        //}
        //else
        //{
        //    InfoMessage = $"Play list Or Track not found";
        //}
    }

    #endregion

}

