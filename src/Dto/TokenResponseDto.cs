using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Dto
{
    public class TokenResponseDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}