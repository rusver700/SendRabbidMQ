using Microsoft.AspNetCore.Mvc;
using WebApi.Dominio.Modelo;
using WebApi.Dominio.ServicoRabbitMQ;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        private IServicoRabbitMQ _servicoRabbitMQ; 
        public MensagemController(IServicoRabbitMQ servicoRabbitMQ)
        {
            _servicoRabbitMQ = servicoRabbitMQ;
        }

        [HttpPost]
        public IActionResult InserirMsg(EnviaMensagem enviamensagem)
        {
                return Ok(_servicoRabbitMQ.EnviaMensagem(enviamensagem));
        }
    }
}
