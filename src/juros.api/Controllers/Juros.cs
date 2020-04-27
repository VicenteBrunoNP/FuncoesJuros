using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using juros.api.Services;

namespace juros.api.Controllers
{
    [ApiController]
    //[Route("v1")]
    public class JurosController : ControllerBase
    {
        [HttpGet]
        [Route("calculajuros")]
        public IActionResult Calculajuros([FromQuery] double valorinicial, [FromQuery]int meses)
        {
            double valorFinal = 0;
            double taxaJuros = ServiceTaxaJuros.GetTaxaJuros();

            try
            {
                if(valorinicial<=0)
                    return NotFound("Valor inicial n�o pode ser menor ou inferior 0");

                if (meses <= 0)
                    return NotFound("Meses n�o pode ser menor ou inferior");

                valorFinal = valorinicial * (Math.Pow(1 + taxaJuros,meses));
                valorFinal = Math.Round(valorFinal,2);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(valorFinal);
        }

        [HttpGet]
        [Route("showmethecode")]
        public string Showmethecode()
        {
            return "https://github.com/VicenteBrunoNP/FuncoesJuros";
        }
    }
}