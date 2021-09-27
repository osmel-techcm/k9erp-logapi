using logCore.Entities;
using System.Threading.Tasks;

namespace logCore.Interfaces
{
    public interface ILogChangeRepo
    {
        Task<responseData> PostLogChange(LogChange logChange);
    }
}
