using WebApi.Dominio.Modelo;

namespace WebApi.Dominio.ServicoRabbitMQ
{
    public interface IServicoRabbitMQ
    {
        public EnviaMensagem EnviaMensagem(EnviaMensagem enviamensagem);
    }
}
