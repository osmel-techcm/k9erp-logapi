using logCore.Entities;
using System.Threading.Tasks;

namespace logCore.Interfaces
{
    public interface ILogChangeExtendedService
    {
        Task<responseData> CheckLogChange(LogChange logChange);
    }
}
