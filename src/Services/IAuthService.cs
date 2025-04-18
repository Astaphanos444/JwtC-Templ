using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Dto;
using app.src.Model;

namespace app.src.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);

    }
}