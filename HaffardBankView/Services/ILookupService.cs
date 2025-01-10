namespace HaffardBankWebApp.Services
{
    public interface ILookupService
    {
        Task<AccountFieldsDto?> GetFields(string accountNo);
    }
}