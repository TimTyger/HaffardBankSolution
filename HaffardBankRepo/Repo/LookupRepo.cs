using HaffardBankRepo.Data;
using HaffardBankRepo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaffardBankRepo.Repo
{
    public class LookupRepo : ILookupRepo
    {
        private readonly ApplicationContext _context;
        public LookupRepo(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Account?> GetFields(string accountNum)
        {
            return await _context.Accounts
                .Include(a => a.Industry)
                .ThenInclude(i => i!.Fields)
                .Where(a => a.CustomerAccount == accountNum)
                .FirstOrDefaultAsync();
        }
    }
}
