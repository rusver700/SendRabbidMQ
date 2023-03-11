using WebApi.Dominio.Enums;

namespace WebApi.Dominio.Modelo
{
    public class EnviaMensagem
    {
        public Guid IdMsg { get; set; } 
        public string? Assunto { get; set; }
        public DateTime Data { get; set; }
        public int NumeroEnvelope { get; set; }
        public  StatusMensagem StatusMensagem { get; set; }
        public string? TextoMsg { get; set; }
    }
}
