
using Chinook.Models;
using Chinook.RepositoryEF.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Chinook.Shared;

public partial class NavMenu : ComponentBase
{

    [Inject] private IPlayListRepository playListRepo { get; set; }
    [Inject] private IUserPlayList userPlayListRepo { get; set; }

    [CascadingParameter] protected Task<AuthenticationState> authenticationState { get; set; }

    protected List<Playlist> playList;
    private bool collapseNavMenu = true;

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }


    protected override async Task OnInitializedAsync()
    {
        var userId = await GetUserId();
        playList = await playListRepo.GetAllForUser(userId);
    }

    private async Task<string> GetUserId()
    {
        var user = (await authenticationState).User;
        var userId = user.FindFirst(u => u.Type.Contains(ClaimTypes.NameIdentifier))?.Value;
        return userId;
    }
}

