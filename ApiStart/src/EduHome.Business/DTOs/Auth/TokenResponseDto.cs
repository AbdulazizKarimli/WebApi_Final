using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Business.DTOs.Auth
{
    public class TokenResponseDto
    {
        public string? Token { get; set; }
        public DateTime Expires { get; set; }
        public string? Username { get; set; }
    }
}
