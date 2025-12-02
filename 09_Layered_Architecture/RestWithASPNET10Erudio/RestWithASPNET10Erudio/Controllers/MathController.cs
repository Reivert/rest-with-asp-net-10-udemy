using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Services;
using RestWithASPNET10Erudio.Utils;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly MathService _mathService;

        public MathController(MathService mathService)
        {
            _mathService = mathService;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber)) {

                var sum = _mathService.Sum(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(sum);
            }
            return BadRequest("Invalid input!");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {

                var subtraction = _mathService.Subtraction(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(subtraction);
            }
            return BadRequest("Invalid input!");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {

                var multiplication = NumberHelper.ConvertToDecimal(firstNumber) * NumberHelper.ConvertToDecimal(secondNumber);
                return Ok(multiplication);
            }
            return BadRequest("Invalid input!");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {

                var division = _mathService.Division(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(division);
            }
            return BadRequest("Invalid input!");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {

                var mean = _mathService.Mean(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(mean);
            }
            return BadRequest("Invalid input!");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (NumberHelper.IsNumeric(number))
            {
                var sqareRoot = _mathService.SquareRoot((double)NumberHelper.ConvertToDecimal(number));
                return Ok(sqareRoot);
            }
            return BadRequest("Invalid input!");
        }
    }
}
