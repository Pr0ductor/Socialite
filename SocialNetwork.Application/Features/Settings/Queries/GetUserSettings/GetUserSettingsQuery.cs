using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Queries.GetUserSettings
{
    public class GetUserSettingsQuery : IRequest<UserSettingsDto>
    {
    }
} 