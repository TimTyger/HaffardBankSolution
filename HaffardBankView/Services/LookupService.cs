using HaffardBankWebApp.ApiClient;
using Microsoft.Extensions.Options;

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
            var getfieldsUrl = _config.GetSection("GetFieldsUrl").Value;
            var response = await _apiImplementor.GetApiServiceWithHeaders<AccountFieldsDto>(accountNo);
            return response;
        }
    }
}
