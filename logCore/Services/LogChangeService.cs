using logCore.Entities;
using logCore.Interfaces;
using System.Threading.Tasks;

namespace logCore.Services
{
    public class LogChangeService : ILogChangeService
    {
        private readonly ILogChangeRepo _iLogChangeRepo;
        private readonly ILogChangeExtendedService _iLogChangeExtendedService;

        public LogChangeService(ILogChangeRepo iLogChangeRepo, ILogChangeExtendedService iLogChangeExtendedService)
        {
            _iLogChangeRepo = iLogChangeRepo;
            _iLogChangeExtendedService = iLogChangeExtendedService;
        }

        public async Task<responseData> PostLogChange(LogChange logChange)
        {
            var reposnseData = await _iLogChangeExtendedService.CheckLogChange(logChange);
            if (reposnseData.error)
            {
                return reposnseData;
            }

            if (string.IsNullOrEmpty(logChange.InfoForm))
            {
                reposnseData.error = true;
                reposnseData.errorValue = 2;
                reposnseData.description = "The Info Form is required!";
                return reposnseData;
            }

            return await _iLogChangeRepo.PostLogChange(logChange);
        }
    }
}
