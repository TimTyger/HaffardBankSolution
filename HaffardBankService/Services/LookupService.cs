using HaffardBankRepo.Repo;
using HaffardBankService.Models;

namespace HaffardBankService.Services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepo _lookupRepo;
        public LookupService(ILookupRepo lookupRepo)
        {
            _lookupRepo = lookupRepo;
        }

        public async Task<AccountFieldsDto?> GetFields(string accountNo)
        {
            AccountFieldsDto? response = null;
            var accountFields = await _lookupRepo.GetFields(accountNo);

            if (accountFields != null)
            {
                return new AccountFieldsDto
                {
                    Fields = accountFields.Industry?.Fields?.Select(x => new FieldsDto { FieldName = x.FieldName, FieldType = x.FieldType }).ToList() ?? [],
                    AccountNumber = accountNo,
                    Industry = accountFields.Industry?.Name ?? ""
                };
            }
            return response;
        }
    }
}
