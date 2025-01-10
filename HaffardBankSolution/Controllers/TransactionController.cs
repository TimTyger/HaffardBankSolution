using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaffardBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public TransactionController()
        {
            
        }

        //[HttpPost("submit")]
        //public IActionResult SubmitFeedback([FromBody] TransactionRequestDto form)
        //{
        //    if (form == null || string.IsNullOrEmpty(form.AccountId))
        //    {
        //        return BadRequest("Invalid form submission.");
        //    }

        //    return Ok(new { Message = "Feedback submitted successfully." });
        //}
    }
}
