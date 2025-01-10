using HaffardBankService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaffardBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        public AccountController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("fields/{account}")]
        public async Task<IActionResult> GetFields(string account)
        {
            var response = await _lookupService.GetFields(account);
            if (response != null) return Ok(response);
            return StatusCode(404);
        }
    }
}
