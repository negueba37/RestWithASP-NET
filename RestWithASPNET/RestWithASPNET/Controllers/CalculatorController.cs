using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("Sum/{firstNuber}/{secondNuber}")]
        public IActionResult Sum(string firstNuber, string secondNuber)
        {
             if (IsNumeric(firstNuber) && IsNumeric(secondNuber))
            {
            var sum = ConvertToDecimal(firstNuber) + ConvertToDecimal(secondNuber);
            //var sum = firstNumber + secondNuber;
            return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("Subtraction/{firstNuber}/{secondNuber}")]
        public IActionResult Subtraction(string firstNuber, string secondNuber)
        {
            if (IsNumeric(firstNuber) && IsNumeric(secondNuber))
            {
                var sum = ConvertToDecimal(firstNuber) - ConvertToDecimal(secondNuber);
                //var sum = firstNumber + secondNuber;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("Multiplication/{firstNuber}/{secondNuber}")]
        public IActionResult Multiplication(string firstNuber, string secondNuber)
        {
            if (IsNumeric(firstNuber) && IsNumeric(secondNuber))
            {
                var sum = ConvertToDecimal(firstNuber) * ConvertToDecimal(secondNuber);
                //var sum = firstNumber + secondNuber;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("Division/{firstNuber}/{secondNuber}")]
        public IActionResult Division(string firstNuber, string secondNuber)
        {
            if (IsNumeric(firstNuber) && IsNumeric(secondNuber))
            {
                var sum = ConvertToDecimal(firstNuber) / ConvertToDecimal(secondNuber);
                //var sum = firstNumber + secondNuber;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }


        private Decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}