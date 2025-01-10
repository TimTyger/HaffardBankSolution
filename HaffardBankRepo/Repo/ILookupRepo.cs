using HaffardBankRepo.Models;

namespace HaffardBankRepo.Repo
{
    public interface ILookupRepo
    {
        Task<Account?> GetFields(string accountNum);
    }
}