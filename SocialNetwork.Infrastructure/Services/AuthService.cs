using Microsoft.AspNetCore.Identity;
using SocialNetwork.Application.Interfaces.Services;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using SocialNetwork.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IEmailService _emailService;
    private readonly ApplicationDbContext _context;

    public AuthService
        (UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager, 
        IEmailService emailService,
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _context = context;
    }

    public async Task<bool> RegisterAsync(string firstname, string lastname, string email, string password)
    {
        var identityUser = new IdentityUser
        {
            UserName = email,
            Email = email,
        };

        var result = await _userManager.CreateAsync(identityUser, password);

        if (!result.Succeeded)
            return false;

        await _signInManager.SignInAsync(identityUser, isPersistent: false);

        // Создаем доменную сущность User
        var user = new User
        {
            IdentityId = identityUser.Id,
            Name = $"{firstname} {lastname}",
            Email = email,
            Img = "default_profile.jpg",
            Bio = string.Empty,
            Gender = Gender.Male,
            Relationship = Relationship.Single,
            TwoFactorAuthentication = Enable.Disable,
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        // Отправка письма
        var subject = "Регистрация прошла успешно";
        var body = $"<h1>Здравствуйте, {firstname} {lastname}!</h1>" +
                   "<p>Вы успешно зарегистрировались на нашем сайте Socialize.</p>" +
                   "<p>Ваши данные: </p>" +
                   $"<p>Login: {email}</p>" +
                   $"<p>Password: {password}</p>";

        await _emailService.SendEmailAsync(email, subject, body);

        return true;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return false;

        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

        return result.Succeeded ? true :
        false;
    }
}
