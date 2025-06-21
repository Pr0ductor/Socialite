using MediatR;
using SocialNetwork.Application.Features.Settings.Dtos;

namespace SocialNetwork.Application.Features.Settings.Queries.GetPrivacySettings
{
    public class GetPrivacySettingsQuery : IRequest<PrivacySettingsDto>
    {
    }
} 