
using DOMAIN.Enums;


namespace DOMAIN.Entities
{
    public class Interacao
    {
        public Guid Id { get; private set; }
        public Guid ChamadoId { get; private set; }
        public Guid TecnicoId { get; private set; }
        public string Mensagem { get; private set; }
        public DateTime DataInteracao { get; private set; }

        protected Interacao() { }

        public Interacao(Guid chamadoId, Guid tecnicoId, string mensagem)
        {
            Id = Guid.NewGuid();
            ChamadoId = chamadoId;
            TecnicoId = tecnicoId;
            Mensagem = mensagem;
            DataInteracao = DateTime.UtcNow;
        }
    }
}