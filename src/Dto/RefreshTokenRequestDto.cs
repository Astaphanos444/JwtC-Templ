using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Dto
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId { get; set; }
        public required string RefreshToken { get; set; }
    }   
}