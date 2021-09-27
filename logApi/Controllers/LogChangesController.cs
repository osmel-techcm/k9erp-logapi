using logCore.Entities;
using logCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace logApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogChangesController : ControllerBase
    {
        private readonly ILogChangeService _logChangeService;

        public LogChangesController(ILogChangeService logChangeService)
        {
            _logChangeService = logChangeService;
        }

        [HttpPost]
        public async Task<responseData> PostLogChange(LogChange logChange)
        {
            return await _logChangeService.PostLogChange(logChange);
        }
    }
}
