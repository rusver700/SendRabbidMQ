using WebApi.Dominio.Modelo;

namespace WebApi.Dominio.Excecoes
{
        public class ExcecaoMensagemRabbitMQ : Exception
        {
            public ExcecaoMensagemRabbitMQ(EnviaMensagem enviamensagem) : base($"Erro: {enviamensagem}.") { }
        }
}
