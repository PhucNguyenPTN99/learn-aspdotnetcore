using System;
using System.Linq;
using System.Security.Claims;
using Meeting.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Meeting.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public string UserId
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(claim =>
                    claim.Type == ClaimTypes.NameIdentifier);

                return userIdClaim?.Value ?? Guid.Empty.ToString();
            }
        }
    }
}