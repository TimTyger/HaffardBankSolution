using HaffardBankService.Models;
using HaffardBankService.Services;
using HaffardBankWebApp.ApiClient;

namespace HaffardBankWebApp.Services
{
    public class LookupService : ILookupService
    {
        private readonly ApiImplementor _apiImplementor;
        private readonly IConfiguration _config;
        public LookupService(ApiImplementor apiImplementor, IConfiguration config)
        {
            _apiImplementor = apiImplementor;
            _config = config;
        }
        public async Task<AccountFieldsDto?> GetFields(string accountNo)
        {
            var getfieldsUrl = _config.GetValue<string>("GetFieldsUrl")??"";
            var url = string.Format(getfieldsUrl!, accountNo);
            var response = await _apiImplementor.GetApiServiceWithHeaders<AccountFieldsDto>(url);
            if (response.Item2)
            {
                return response.Item1;
            }
            return null;
        }
    }
}
