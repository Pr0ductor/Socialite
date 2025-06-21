using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Pages.Query.GetAllPages;

public class GetAllPagesQueryHandler : IRequestHandler<GetAllPagesQuery, IEnumerable<GetAllPagesDto>>
{
    private readonly IPageRepository _pageRepository;
    private readonly IFriendshipRepository _friendshipRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ICurrentUserService _currentUserService;

    public GetAllPagesQueryHandler(
        IPageRepository pageRepository,
        IFriendshipRepository friendshipRepository,
        UserManager<IdentityUser> userManager,
        ICurrentUserService currentUserService)
    {
        _pageRepository = pageRepository;
        _friendshipRepository = friendshipRepository;
        _userManager = userManager;
        _currentUserService = currentUserService;
    }

    public async Task<IEnumerable<GetAllPagesDto>> Handle(GetAllPagesQuery request, CancellationToken ct)
    {
        var users = await _pageRepository.GetAllAsync();
        var currentUser = await _userManager.GetUserAsync(_currentUserService.User);
        
        if (currentUser == null)
            return users.Select(user => MapToDto(user, null, false));

        var dtos = new List<GetAllPagesDto>();
        
        foreach (var user in users)
        {
            if (user.IdentityId == currentUser.Id)
                continue; // Skip current user

            var friendship = await _friendshipRepository.GetFriendshipAsync(currentUser.Id, user.IdentityId);
            var isOutgoingRequest = friendship != null && 
                                  friendship.Status == FriendshipStatus.Pending && 
                                  friendship.UserId == currentUser.Id;

            dtos.Add(MapToDto(user, friendship?.Status, isOutgoingRequest));
        }

        return dtos;
    }

    private GetAllPagesDto MapToDto(User user, FriendshipStatus? friendshipStatus, bool isOutgoingRequest)
    {
        return new GetAllPagesDto
        {
            UserId = user.UserId,
            Name = user.Name,
            Email = user.Email,
            Img = user.Img,
            Bio = user.Bio,
            Gender = user.Gender,
            Relationship = user.Relationship,
            TwoFactorAuthentication = user.TwoFactorAuthentication,
            FriendshipStatus = friendshipStatus,
            IdentityId = user.IdentityId,
            IsOutgoingRequest = isOutgoingRequest
        };
    }
}
