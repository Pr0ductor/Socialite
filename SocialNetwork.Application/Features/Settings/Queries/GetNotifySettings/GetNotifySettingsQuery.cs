using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Queries.GetNotifySettings
{
    public class GetNotifySettingsQuery : IRequest<NotifySettingsDto>
    {
    }
} 