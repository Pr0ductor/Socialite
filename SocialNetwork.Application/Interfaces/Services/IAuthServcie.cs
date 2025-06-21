using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Interfaces.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(string firstname, string lastname, string email, string password);
    
    Task<bool> LoginAsync(string email, string password);
    
}
