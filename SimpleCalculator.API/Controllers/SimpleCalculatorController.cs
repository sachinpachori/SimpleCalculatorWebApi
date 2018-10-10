using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Services;

namespace SimpleCalculator.API.Controllers
{
    [Route("api/[controller]")]   
    public class SimpleCalculatorController : Controller
    {
        public readonly ISimpleCalculatorService _calculatorService;
        public SimpleCalculatorController(ISimpleCalculatorService CalculatorService)
        {
            _calculatorService = CalculatorService;
        }       

        [HttpGet("{start}/{amount}/{op}")]
        public IActionResult Index(int start, int amount, string op)
        {
            int result=0;
            switch (op)
            {
                case "add":
                     result=Add(start, amount);
                    break;
                case "subtract":
                    result=Subtract(start, amount);
                    break;
                case "multiply":
                    result=Multiply(start, amount);
                    break;
                case "divide":
                    result=Divide(start, amount);
                    break;
                default:                   
                    break;
            }
          
            return Ok(result.ToString());            
        }
     
        public int Add(int start, int amount)
        {
            var result = _calculatorService.Add(start, amount);           
            return result;
        }        

        public int Subtract(int start, int amount)
        {
            var result = _calculatorService.Subtract(start, amount);
            return result;
        }

        public int Multiply(int start, int amount)
        {
            var result = _calculatorService.Multiply(start, amount);
            return result;
        }
     
        public int Divide(int start, int amount)
        {
            var result = _calculatorService.Divide(start, amount);
            return result;
        }
    }
}
