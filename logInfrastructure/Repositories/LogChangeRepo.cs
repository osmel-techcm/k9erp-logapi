using logCore.Entities;
using logCore.Interfaces;
using logInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logInfrastructure.Repositories
{
    public class LogChangeRepo : ILogChangeRepo
    {
        private readonly MultitenantDbContext _context;

        public LogChangeRepo(MultitenantDbContext context)
        {
            _context = context;
        }

        public async Task<responseData> PostLogChange(LogChange logChange)
        {
            var responseData = new responseData();

            try
            {
                _context.LogChanges.Add(logChange);
                await _context.SaveChangesAsync();
                responseData.data = logChange;
            }
            catch (Exception e)
            {
                responseData.error = true;
                responseData.errorValue = 2;
                responseData.description = e.Message;
                responseData.data = e;
            }

            return responseData;
        }
    }
}
