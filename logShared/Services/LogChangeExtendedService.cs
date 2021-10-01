using logCore.Entities;
using logCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace logShared.Services
{
    public class LogChangeExtendedService : ILogChangeExtendedService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogChangeExtendedService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<responseData> CheckLogChange(LogChange logChange)
        {
            var responseData = new responseData();

            logChange.UserName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            logChange.Date = DateTime.UtcNow;

            return responseData;
        }
    }
}
