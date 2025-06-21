using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Pages.Query.GetAllPages
{
    public record GetAllPagesQuery : IRequest<IEnumerable<GetAllPagesDto>>;
}
