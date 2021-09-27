using logCore.Entities;
using logCore.Interfaces;
using System.Threading.Tasks;

namespace logCore.Services
{
    public class LogChangeService : ILogChangeService
    {
        private readonly ILogChangeRepo _iLogChangeRepo;

        public LogChangeService(ILogChangeRepo iLogChangeRepo)
        {
            _iLogChangeRepo = iLogChangeRepo;
        }

        public async Task<responseData> PostLogChange(LogChange logChange)
        {
            return await _iLogChangeRepo.PostLogChange(logChange);
        }
    }
}
