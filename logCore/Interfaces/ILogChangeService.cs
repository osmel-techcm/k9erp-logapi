using logCore.Entities;
using System.Threading.Tasks;

namespace logCore.Interfaces
{
    public interface ILogChangeService
    {
        Task<responseData> PostLogChange(LogChange logChange);
    }
}
