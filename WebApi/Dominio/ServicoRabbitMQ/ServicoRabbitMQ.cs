using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using WebApi.Dominio.Modelo;
using WebApi.Dominio.Excecoes;
using WebApi.Dominio.Enums;

namespace WebApi.Dominio.ServicoRabbitMQ
{
    public class ServicoRabbitMQ : IServicoRabbitMQ
    {
        private ILogger<ServicoRabbitMQ> _logger;
        public ServicoRabbitMQ(ILogger<ServicoRabbitMQ> logger)
        {
            _logger = logger;
        }
        public EnviaMensagem EnviaMensagem(EnviaMensagem enviamensagem)
        {
            _logger.LogInformation("Iniciando ServicoRabbitMQ...");

            if(enviamensagem.StatusMensagem == StatusMensagem.enviar) 
            try
            {
                #region INSERIR NA FILA RabbitMQ
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest"
                };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "MensagemQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string messageJson = JsonSerializer.Serialize(enviamensagem);

                var body = Encoding.UTF8.GetBytes(messageJson);

                channel.BasicPublish(exchange: "",
                                     routingKey: "MensagemQueue",
                                     basicProperties: null,
                                     body: body);
                #endregion
                _logger.LogInformation($"Mensagem Inserida na fila RabbitMQ: {messageJson}");
            }
            catch (ExcecaoMensagemRabbitMQ ex)
            {
                _logger.LogError(ex.Message);

            }
            else
                _logger.LogInformation($"Mensagem não Inserida na fila RabbitMQ Status Invalido");

            return enviamensagem;
        }
    }
}
