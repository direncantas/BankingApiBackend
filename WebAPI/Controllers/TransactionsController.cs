using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _transactionService.GetAll();
            
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            var result = _transactionService.Create(transaction);
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
