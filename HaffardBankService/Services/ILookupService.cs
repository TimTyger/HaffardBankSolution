using HaffardBankService.Models;

namespace HaffardBankService.Services
{
    public interface ILookupService
    {
        Task<AccountFieldsDto?> GetFields(string accountNo);

    }
}